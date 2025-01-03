using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MovieTicketSellingApp
{
    public partial class ViewDetails : Form
    {
        private int room;
        private double price;
        public ViewDetails()
        {
            InitializeComponent();
        }

        public ViewDetails(String tilte, String startTime, String endTime, int room, double price)
        {
            InitializeComponent();
            titleTxt.Text = tilte;
            startTimeTxt.Text = startTime.ToString();
            endTimeTxt.Text = endTime.ToString();
            roomTxt.Text = room.ToString();
            this.room = room;
            this.price = price;
        }

        private void returnBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            new Seats(room, price).Visible = true;
            this.Close();
        }
    }
}
