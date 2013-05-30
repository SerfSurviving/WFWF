using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WFWF;

namespace GameBuilder
{
    public partial class GeneralSkills : Form
    {
        String workingKey;
        bool edit;
        MainForm main;
        public GeneralSkills(MainForm mf)
        {
            main = mf;
            InitializeComponent();
        }

        public void openWindow( String  key)
        {
            this.edit = true;
            this.workingKey = key;
            this.populateMenus();
            this.ShowDialog();
        }

        public void openWindow()
        {
            this.edit = false;
            this.workingKey = "";
            this.textBox.Text = workingKey;
            this.populateMenus();
            this.ShowDialog();
        }

        private void populateMenus()
        {
            this.textBox.Text = this.workingKey;
            this.attlist.Items.Clear();
            foreach ( String  attribute in main.genericAttributes)
            {
                this.attlist.Items.Add(attribute);
            }
            if (this.workingKey != "")
            {
                this.selectedatt.Text = main.genericGeneralSkills[this.workingKey];
            }
            else
            {
                this.selectedatt.Text = "";
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sumbit_Click(object sender, EventArgs e)
        {
            if (this.textBox.Text == "" || this.selectedatt.Text == "")
            {
                new Warning().ShowDialog();
            }
            else
            {
                if (this.edit)
                {
                    if (this.textBox.Text != workingKey)
                    {
                        main.genericGeneralSkills.Remove(workingKey);
                        main.genericGeneralSkills.Add(this.textBox.Text, this.selectedatt.Text);
                    }

                    else
                    {
                        main.genericGeneralSkills[workingKey] = this.selectedatt.Text;
                    }
                }

                else
                {
                    main.genericGeneralSkills.Add((String)this.textBox.Text, (String)this.selectedatt.Text);
                }

                main.repopListThings();
                this.Close();
            }
        }

        private void attlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.selectedatt.Text = this.attlist.Text;

        }
    }
}
