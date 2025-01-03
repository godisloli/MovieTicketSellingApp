using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MovieTicketSellingApp
{
    public partial class Master : Form
    {
        private static string roomDbFilePath = "roomdata.db";
        private static string roomConnectionString => $"Data Source={roomDbFilePath};Version=3;";

        public Master()
        {
            InitializeComponent();
        }

        private void moviesBtn_Click(object sender, EventArgs e)
        {
            new MoviesMod().Visible = true;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void statusUpdateBtn_Click(object sender, EventArgs e)
        {
            new UpdateStatus().Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!File.Exists(roomDbFilePath))
            {
                SQLiteConnection.CreateFile(roomDbFilePath);
            }

            using (var connection = new SQLiteConnection(roomConnectionString))
            {
                connection.Open();

                for (int i = 1; i <= 5; i++)
                {
                    string tableName = $"Room{i}";

                    string createTableQuery = $@"
                CREATE TABLE IF NOT EXISTS {tableName} (
                    Seat TEXT NOT NULL,
                    Status BOOLEAN NOT NULL
                );";

                    using (var createCommand = new SQLiteCommand(createTableQuery, connection))
                    {
                        createCommand.ExecuteNonQuery();
                    }

                    string checkTableQuery = $"SELECT COUNT(*) FROM {tableName};";
                    int rowCount;
                    using (var checkCommand = new SQLiteCommand(checkTableQuery, connection))
                    {
                        rowCount = Convert.ToInt32(checkCommand.ExecuteScalar());
                    }

                    if (rowCount == 0)
                    {
                        using (var transaction = connection.BeginTransaction())
                        {
                            string insertSeatQuery = $@"
                        INSERT INTO {tableName} (Seat, Status)
                        VALUES (@Seat, @Status);";

                            using (var insertCommand = new SQLiteCommand(insertSeatQuery, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@Status", true);

                                for (char row = 'A'; row <= 'D'; row++)
                                {
                                    for (int seat = 0; seat < 10; seat++)
                                    {
                                        string seatLabel = $"{row}{seat}";
                                        insertCommand.Parameters.AddWithValue("@Seat", seatLabel);
                                        insertCommand.ExecuteNonQuery();
                                        insertCommand.Parameters.Clear();
                                        insertCommand.Parameters.AddWithValue("@Status", true);
                                    }
                                }
                            }

                            transaction.Commit();
                        }
                    }
                }
            }

            MessageBox.Show("Room tables created and populated successfully in roomdata.db.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void runBtn_Click(object sender, EventArgs e)
        {
            new LoginUI().Visible = true;
        }
    }
}
