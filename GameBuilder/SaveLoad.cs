using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using WFWF;

namespace GameBuilder
{
    public partial class SaveLoad : Form
    {
        MainForm parent;

        FileStream fs;    

        string attPath;
        string genskPath;
        string wrskPath;
        string bdpPath;
        string folder;

        public SaveLoad(MainForm par)
        {
            this.parent = par;

            this.folder = "generic";

            this.attPath = this.folder + "/attributes.txt";
            this.genskPath = this.folder + "/generalskills.txt";
            this.wrskPath = this.folder + "/wrestlingskills.txt";
            this.bdpPath = this.folder + "/bodyparts.txt";

            this.InitializeComponent();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void closewithoutsaving_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Close();
        }

        private void closeandsave_Click(object sender, EventArgs e)
        {
            
            
            this.Close();
            parent.Close();
        }

        private void load_Click(object sender, EventArgs e)
        {
            

            this.Close();
        }
    }
}
