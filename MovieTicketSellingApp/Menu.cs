    using System;
    using System.Data;
    using System.Data.SQLite;
    using System.Linq;
    using System.Windows.Forms;

    namespace MovieTicketSellingApp
    {
        public partial class Menu : Form
        {
        private static string dbFilePath = "moviedata.db";
        private double price;
        private static string connectionString => $"Data Source={dbFilePath};Version=3;";
        public Menu()
        {
            InitializeComponent();
            movieListView.View = View.Details;
            LoadTableSchema();
            LoadTableData();
            AdjustColumnWidths();
            movieListView.FullRowSelect = true;
            movieListView.HideSelection = false;
            movieListView.Resize += listView1_Resize;
        }

        private void AdjustColumnWidths()
        {
            int totalWidth = movieListView.ClientSize.Width;
            int columnCount = movieListView.Columns.Count;
            int columnWidth = totalWidth / columnCount;

            for (int i = 0; i < columnCount; i++)
            {
                if (i == columnCount - 1)
                {
                    movieListView.Columns[i].Width = totalWidth - (columnWidth * (columnCount - 1));
                }
                else
                {
                    movieListView.Columns[i].Width = columnWidth;
                }
            }
        }

        private void LoadTableSchema()
        {
            movieListView.Columns.Clear();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "PRAGMA table_info(Movies);";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string columnName = reader["name"].ToString();
                        if (!columnName.Equals("Price", StringComparison.OrdinalIgnoreCase))
                        {
                            movieListView.Columns.Add(columnName);
                        }
                    }
                }
            }
        }

        public void LoadTableData()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Movies;";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateTime startTime = DateTime.Parse(reader["StartTime"].ToString());
                        DateTime endTime = DateTime.Parse(reader["EndTime"].ToString());

                        if (startTime < DateTime.Now || endTime < DateTime.Now)
                        {
                            continue;
                        }

                        this.price = Convert.ToDouble(reader["Price"]);

                        var items = new string[movieListView.Columns.Count];

                        for (int i = 0, columnIndex = 0; i < reader.FieldCount; i++)
                        {
                            string columnName = reader.GetName(i);
                            if (movieListView.Columns.Cast<ColumnHeader>().Any(col => col.Text == columnName))
                            {
                                items[columnIndex++] = reader[i].ToString();
                            }
                        }

                        var listViewItem = new ListViewItem(items);
                        movieListView.Items.Add(listViewItem);
                    }
                }
            }
        }

        private void listView1_Resize(object sender, EventArgs e)
        {
            AdjustColumnWidths();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (movieListView.SelectedItems.Count == 1)
            {
                var selectedItem = movieListView.SelectedItems[0];
                string title = selectedItem.SubItems[1].Text;
                string startTime = selectedItem.SubItems[2].Text;
                string endTime = selectedItem.SubItems[3].Text;
                int room = int.Parse(selectedItem.SubItems[4].Text);
                ViewDetails viewDetails = new ViewDetails(title, startTime, endTime, room, price);
                viewDetails.Show();
            }
            else
            {
                MessageBox.Show("Please select a single row to view details.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void LoadTableData(string searchTerm = "")
        {
            movieListView.Items.Clear();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Movies";
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query += " WHERE Title LIKE @Search OR ID LIKE @Search OR Tags LIKE @Search";
                }

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Search", "%" + searchTerm + "%");

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime startTime = DateTime.Parse(reader["StartTime"].ToString());
                            DateTime endTime = DateTime.Parse(reader["EndTime"].ToString());

                            if (startTime < DateTime.Now || endTime < DateTime.Now)
                            {
                                continue;
                            }

                            this.price = Convert.ToDouble(reader["Price"]);

                            var items = new string[movieListView.Columns.Count];

                            for (int i = 0, columnIndex = 0; i < reader.FieldCount; i++)
                            {
                                string columnName = reader.GetName(i);
                                if (movieListView.Columns.Cast<ColumnHeader>().Any(col => col.Text == columnName))
                                {
                                    items[columnIndex++] = reader[i].ToString();
                                }
                            }

                            var listViewItem = new ListViewItem(items);
                            movieListView.Items.Add(listViewItem);
                        }
                    }
                }
            }
        }


        private void searcherTxt_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = searcherTxt.Text.Trim();
            LoadTableData(searchTerm);
        }

        private void movieListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
