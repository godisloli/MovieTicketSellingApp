using System;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;

namespace MovieTicketSellingApp
{
    public partial class UpdateStatus : Form
    {
        private static string dbFilePath = "moviedata.db";
        private double price;
        private static string connectionString => $"Data Source={dbFilePath};Version=3;";
        public UpdateStatus()
        {
            InitializeComponent();
            LoadTableSchema();
            LoadTableData();
            AdjustColumnWidths();
            movieListView.View = View.Details;
            movieListView.FullRowSelect = true;
            movieListView.HideSelection = false;
            movieListView.Resize += listView1_Resize;
        }

        private void listView1_Resize(object sender, EventArgs e)
        {
            AdjustColumnWidths();
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

        private void LoadTableData()
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

        private void returnBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (movieListView.SelectedItems.Count == 1)
            {
                var selectedItem = movieListView.SelectedItems[0];

                string id = selectedItem.SubItems[0].Text;

                var confirmResult = MessageBox.Show(
                    $"Are you sure you want to delete the selected item (ID: {id})?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    DeleteFromDatabase(id);
                    movieListView.Items.Remove(selectedItem);
                    MessageBox.Show("Item deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a single item to delete.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DeleteFromDatabase(string id)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Movies WHERE ID = @ID;";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        MessageBox.Show("No rows were deleted. Ensure the ID is valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void LoadTableData(string searchTerm = "")
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


        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (movieListView.SelectedItems.Count == 1)
            {
                var selectedItem = movieListView.SelectedItems[0];

                string id = selectedItem.SubItems[0].Text;
                string title = selectedItem.SubItems[1].Text;
                DateTime startTime = DateTime.Parse(selectedItem.SubItems[2].Text);
                DateTime endTime = DateTime.Parse(selectedItem.SubItems[3].Text);
                string room = selectedItem.SubItems[4].Text;
                string tags = selectedItem.SubItems[5].Text;
                UpdateWindow updateWindow = new UpdateWindow(id, title, startTime, endTime, room, price, tags);
                updateWindow.Owner = this;
                updateWindow.ShowDialog();

            }
            else
            {
                MessageBox.Show("Please select a single movie to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void movieListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void searchTxt_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = searchTxt.Text.Trim();
            LoadTableData(searchTerm);
        }
    }
}
