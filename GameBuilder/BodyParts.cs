using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameBuilder
{
    public partial class BodyParts : Form
    {
        MainForm main;
        int workingId;
        public BodyParts(MainForm mf)
        {
            main = mf;
            InitializeComponent();
        }

        public void openWindow(int id)
        {
            workingId = id;
            this.input.Text = main.genericBodyParts[id];
            this.ShowDialog();
        }

        public void openWindow()
        {
            this.input.Text = "";
            String[] newArr = new String [main.genericBodyParts.Length + 1];
            int n = 0;
            foreach (String i in main.genericBodyParts)
            {
                newArr[n] = i;
                n++;
            }
            main.genericBodyParts = newArr;
            workingId = newArr.Length - 1;
            this.ShowDialog();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sumbit_Click(object sender, EventArgs e)
        {
            if (this.input.Text == "")
            {
                new Warning().ShowDialog();
            }
            else
            {
                main.genericBodyParts[workingId] = this.input.Text;
                main.repopListThings();
                this.Close();
            }
        }
    }
}
