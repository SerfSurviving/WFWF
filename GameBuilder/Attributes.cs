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
    public partial class Attributes : Form
    {
        MainForm main;
        int workid;
        bool edit;
        public Attributes(MainForm mf)
        {
            this.main = mf;
            this.InitializeComponent();
        }

        /// <summary>
        /// For editing an attribute, opens the dialog window that lets one do that
        /// </summary>
        /// <param name="att">The reference to the attribute name we're editing</param>
        public void openWindow(int id)
        {
            this.edit = true;
            this.workid = id;
            this.input.Text = main.genericAttributes[id];
            this.ShowDialog();
        }

        /// <summary>
        /// For adding a new attribute, opens the dialog after resizing the attribute array
        /// to one longer, giving the last space to the new attribute.
        /// </summary>
        /// <param name="addarr">The attribute array</param>
        public void openWindow()
        {
            this.edit = false;
            this.input.Text = "";
             String [] newArr = new  String [main.genericAttributes.Length + 1];
            int n = 0;
            foreach ( String  i in main.genericAttributes)
            {
                newArr[n] = i;
                n++;
            }
            main.genericAttributes = newArr;
            this.workid = newArr.Length - 1;
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
                if (this.edit /*&& this.usedInOther()*/)
                {
                }
                else if(!this.edit && main.genericGeneralSkills.Count > 0)
                {
                }
                else
                {
                    main.genericAttributes[workid] = (String)this.input.Text;
                    main.repopListThings();
                    this.Close();
                }
            }

        }
    }
}
