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
    public partial class Attributes : Form
    {
        public Attributes()
        {
            InitializeComponent();
        }

        private void sumbit_Click(object sender, EventArgs e)
        {

        }
  
        public void openWindow(string name = "")
        {
            Application.Run(this);
        }
    }
}
