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
    /// <summary>
    /// Class used to determine body parts for the wrestlers
    /// </summary>
    public partial class BodyParts : Form
    {
        MainForm main;
        int workingId;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mf"></param>
        public BodyParts(MainForm mf)
        {
            main = mf;
            InitializeComponent();
        }

        /// <summary>
        /// Opens the window with an id for editing
        /// </summary>
        /// <param name="id"></param>
        public void openWindow(int id)
        {
            workingId = id;
            this.input.Text = main.genericBodyParts[id];
            this.ShowDialog();
        }

        /// <summary>
        /// Opens the window without an id, so we add a new item
        /// </summary>
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

        /// <summary>
        /// Closes the screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Adds the new item after making sure that the form is filled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
