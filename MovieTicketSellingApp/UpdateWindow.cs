using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MovieTicketSellingApp
{
    public partial class UpdateWindow : Form
    {
        private string movieId;
        private static string connectionString = "Data Source=moviedata.db;Version=3;";
        public UpdateWindow()
        {
            InitializeComponent();
        }

        public UpdateWindow(string id, string title, DateTime startTime, DateTime endTime, string room, double price, string tags)
        {
            InitializeComponent();

            movieId = id;

            titleTxt.Text = title;
            roomTxt.Text = room;
            priceTxt.Text = price.ToString();
            tagsTxt.Text = tags;
        }

        private void returnBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (titleTxt.Text.Length <= 0 ||
                roomTxt.Text.Length <= 0 ||
                !double.TryParse(priceTxt.Text, out double price))
            {
                MessageBox.Show("Please fill in all fields correctly.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string updateQuery = @"
                    UPDATE Movies
                    SET Title = @Title,
                        StartTime = @StartTime,
                        EndTime = @EndTime,
                        Room = @Room,
                        Price = @Price,
                        Tags = @Tags
                    WHERE Id = @Id;";

                using (var command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Title", titleTxt.Text.Trim());
                    command.Parameters.AddWithValue("@StartTime", startTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.Parameters.AddWithValue("@EndTime", endTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.Parameters.AddWithValue("@Room", roomTxt.Text.Trim());
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@Tags", tagsTxt.Text.Trim());
                    command.Parameters.AddWithValue("@Id", movieId);

                    command.ExecuteNonQuery();
                }
            }

            var parentForm = (UpdateStatus)this.Owner;
            parentForm.LoadTableData();

            MessageBox.Show("Movie details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
