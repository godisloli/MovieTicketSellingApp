using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace MovieTicketSellingApp
{
    public partial class MoviesMod : Form
    {
        private static string dbFilePath = "moviedata.db";
        private static string connectionString => $"Data Source={dbFilePath};Version=3;";

        public MoviesMod()
        {
            InitializeComponent();

            if (!File.Exists(dbFilePath))
            {
                CreateDatabase();
            }
            else
            {
                EnsureTableExists();
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (titleTxt.Text.Length <= 0 ||
                priceTxt.Text.Length <= 0 ||
                roomTxt.Text.Length <= 0 ||
                tagsTxt.Text.Length <= 0)
            {
                MessageBox.Show("Please fill all fields before adding a movie.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (startTime.Value < DateTime.Now || endTime.Value < DateTime.Now)
            {
                MessageBox.Show("Invalid time inserted", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(roomTxt.Text, out int roomNumber) || roomNumber < 1 || roomNumber > 5)
            {
                MessageBox.Show("Room must be a number between 1 and 5.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                InsertMovieData(
                    titleTxt.Text,
                    startTime.Value,
                    endTime.Value,
                    roomTxt.Text,
                    Convert.ToDouble(priceTxt.Text),
                    tagsTxt.Text
                );

                MessageBox.Show("Movie added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateDatabase()
        {
            SQLiteConnection.CreateFile(dbFilePath);

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Movies (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Title TEXT NOT NULL,
                        StartTime TEXT NOT NULL,
                        EndTime TEXT NOT NULL,
                        Room TEXT NOT NULL,
                        Price REAL NOT NULL,
                        Tags TEXT NOT NULL
                    );";

                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void EnsureTableExists()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string checkTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Movies (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Title TEXT NOT NULL,
                        StartTime TEXT NOT NULL,
                        EndTime TEXT NOT NULL,
                        Room TEXT NOT NULL,
                        Price REAL NOT NULL,
                        Tags TEXT NOT NULL
                    );";

                using (var command = new SQLiteCommand(checkTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void InsertMovieData(string title, DateTime startTime, DateTime endTime, string room, double price, string tags)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string insertQuery = @"
                    INSERT INTO Movies (Title, StartTime, EndTime, Room, Price, Tags)
                    VALUES (@Title, @StartTime, @EndTime, @Room, @Price, @Tags);";

                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@StartTime", startTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.Parameters.AddWithValue("@EndTime", endTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.Parameters.AddWithValue("@Room", room);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@Tags", tags);

                    command.ExecuteNonQuery();
                }
            }
        }

        private void returnBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
