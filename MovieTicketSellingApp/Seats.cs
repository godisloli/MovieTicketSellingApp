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
    public partial class Seats : Form
    {
        private int room;
        private double price;
        private const string dbFilePath = "roomdata.db";
        private string connectionString => $"Data Source={dbFilePath};Version=3;";

        public Seats()
        {
            InitializeComponent();
        }

        public Seats(int room, double price)
        {
            InitializeComponent();
            this.room = room;
            LoadRoomData();
            this.price = price;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            run(sender, e);
        }

        private void LoadRoomData()
        {
            string tableName = $"\"Room{room}\"";

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT Seat, Status FROM {tableName}";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string seat = reader["Seat"].ToString();
                        bool status = Convert.ToBoolean(reader["Status"]);

                        var button = this.Controls.Find(seat, true).FirstOrDefault() as Button;
                        if (button != null)
                        {
                            button.BackColor = status ? Color.Green : Color.Red;
                        }
                    }
                }
            }
        }

        private void run(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                string seat = button.Name;
                string tableName = $"\"Room{room}\"";

                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string query = $"SELECT Status FROM {tableName} WHERE Seat = @Seat";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Seat", seat);

                        object result = command.ExecuteScalar();
                        if (result != null && !(bool)result)
                        {
                            MessageBox.Show("Error: This seat is already booked.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            DialogResult confirmResult = MessageBox.Show(
                            $"The price for this seat is {price:C}. Do you want to confirm the booking?",
                            "Confirm Purchase",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );

                            if (confirmResult == DialogResult.Yes)
                            {
                                string updateQuery = $"UPDATE {tableName} SET Status = 0 WHERE Seat = @Seat";
                                using (var updateCommand = new SQLiteCommand(updateQuery, connection))
                                {
                                    updateCommand.Parameters.AddWithValue("@Seat", seat);
                                    updateCommand.ExecuteNonQuery();
                                }

                                button.BackColor = Color.Red;
                                MessageBox.Show("Success: Seat has been booked!", "Booking Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Booking was cancelled.", "Booking Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
        }

        private void A2_Click(object sender, EventArgs e)
        {
            run(sender, e);
        }

        private void A3_Click(object sender, EventArgs e)
        {
            run((object)sender, e);
        }

        private void A4_Click(object sender, EventArgs e)
        {
            run(sender, e);
        }

        private void A5_Click(object sender, EventArgs e)
        {
            run(sender, e);
        }

        private void A6_Click(object sender, EventArgs e)
        {
            run(sender, e);
        }

        private void A7_Click(object sender, EventArgs e)
        {
            run(sender, e);
        }

        private void A8_Click(object sender, EventArgs e)
        {
            run(sender, e);
        }

        private void A9_Click(object sender, EventArgs e)
        {
            run(sender, e);
        }

        private void A0_Click(object sender, EventArgs e)
        {
            run(sender, e);
        }

        private void B1_Click(object sender, EventArgs e)
        {
            run(sender, e);
        }

        private void B2_Click(object sender, EventArgs e)
        {
            run(sender, e);
        }

        private void B3_Click(object sender, EventArgs e)
        {
            run(sender, e);
        }

        private void B4_Click(object sender, EventArgs e)
        {
            run(sender, e);
        }

        private void B5_Click(object sender, EventArgs e)
        {
            run(sender, e);
        }

        private void B6_Click(object sender, EventArgs e)
        {
            run(sender, e);
        }

        private void B7_Click(object sender, EventArgs e)
        {
            run(sender, e);
        }

        private void B8_Click(object sender, EventArgs e)
        {
            run(sender, e);
        }

        private void B9_Click(object sender, EventArgs e)
        {
            run(sender, e);
        }

        private void B0_Click(object sender, EventArgs e)
        {
            run(sender, e);
        }

        private void C1_Click(object sender, EventArgs e)
        {
            run(sender, e);
        }

        private void C2_Click(object sender, EventArgs e)
        {
            run(sender, e);
        }

        private void C3_Click(object sender, EventArgs e)
        {
            run(sender, e);
        }

        private void C4_Click(object sender, EventArgs e)
        {
            run(sender, e);
        }

        private void C5_Click(object sender, EventArgs e)
        {
            run(sender, e);
        }

        private void C6_Click(object sender, EventArgs e)
        {
            run(sender, e);
        }

        private void C7_Click(object sender, EventArgs e)
        {
            run(sender, e);
        }

        private void C8_Click(object sender, EventArgs e)
        {
            run(sender, e);
        }

        private void C9_Click(object sender, EventArgs e)
        {
            run(sender, e);
        }

        private void C0_Click(object sender, EventArgs e)
        {
            run(sender, e);
        }

        private void D1_Click(object sender, EventArgs e)
        {
            run(sender, e);
        }

        private void D2_Click(object sender, EventArgs e)
        {
            run(sender, e);
        }

        private void D3_Click(object sender, EventArgs e)
        {
            run(sender, e);
        }

        private void D4_Click(object sender, EventArgs e)
        {
            run(sender, e);
        }

        private void D5_Click(object sender, EventArgs e)
        {
            run(sender, e);
        }

        private void D6_Click(object sender, EventArgs e)
        {
            run(sender, e);
        }

        private void D7_Click(object sender, EventArgs e)
        {
            run(sender, e);
        }

        private void D8_Click(object sender, EventArgs e)
        {
            run(sender, e);
        }

        private void D9_Click(object sender, EventArgs e)
        {
            run(sender, e);
        }

        private void D0_Click(object sender, EventArgs e)
        {
            run(sender, e);
        }
    }
}
