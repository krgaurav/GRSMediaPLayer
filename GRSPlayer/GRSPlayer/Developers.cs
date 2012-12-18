using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GRSPlayer
{
    public partial class Developers : Form
    {
        public Developers()
        {
            InitializeComponent();
        }

        private void btn_sadik_Click(object sender, EventArgs e)
        {
            btn_sadik.BackColor = Color.White;
            btn_gaurav.BackColor = Color.LightGray;
            btn_rakhi.BackColor = Color.LightGray;
            DeveloperContent.Show();
            DeveloperContent.Text = "Hello,Sadik Rupani";

        }

        private void btn_gaurav_Click(object sender, EventArgs e)
        {
            btn_gaurav.BackColor = Color.White;
            btn_sadik.BackColor = Color.LightGray;
            btn_rakhi.BackColor = Color.LightGray;
            DeveloperContent.Show();
            DeveloperContent.Text = "Hello,Gaurav Singh";
        }

        private void btn_rakhi_Click(object sender, EventArgs e)
        {
            btn_rakhi.BackColor = Color.White;
            btn_gaurav.BackColor = Color.LightGray;
            btn_sadik.BackColor = Color.LightGray;
            DeveloperContent.Show();
            DeveloperContent.Text = "Hello,Rakhi ";
        }

        private void Developers_Load(object sender, EventArgs e)
        {
            btn_rakhi.BackColor = Color.LightGray;
            btn_gaurav.BackColor = Color.LightGray;
            btn_sadik.BackColor = Color.LightGray;
            DeveloperContent.Hide();
        }

        private void DeveloperContent_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
