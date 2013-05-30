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
    public partial class WrestlingSkills : Form
    {
        String [] starr = new  String [1] { "\t" };
        const String stmod = "\t";
        MainForm main;
        String workingKey;
        Wrestler.modifier workingMod;
        public WrestlingSkills(MainForm mf)
        {
            this.main = mf;
            this.InitializeComponent();
        }

        public void openWindow( String  key)
        {
            this.workingKey = key;
            this.workingMod = main.genericWrestlingSkills[key];
            this.populateMenus();
            this.ShowDialog();
        }

        public void openWindow()
        {
            this.workingKey = "";
            this.workingMod = new Wrestler.modifier(
                WrestlingSkills.stmod, WrestlingSkills.stmod, ref this.starr);
            String newMods = "";
            foreach ( String  str in main.genericAttributes)
            {
                newMods += (char)((int)rating.C + 66);
            }
            this.populateMenus();
            this.ShowDialog();
        }

        private void populateMenus()
        {
            this.mintext.Text = "";
            this.maxtext.Text = "";

            this.attlist.Items.Clear();
            foreach ( String  att in main.genericAttributes)
            {
                this.attlist.Items.Add(att);
            }

            this.gensklist.Items.Clear();
            foreach ( String  skill in main.genericGeneralSkills.Keys)
            {
                this.gensklist.Items.Add(skill);
            }

            this.name.Text = "";

            if (this.workingKey != "")
            {
                foreach ( String  skill in this.workingMod.skillMods)
                {
                    for (int i = 0; i < gensklist.Items.Count; i++)
                    {
                        if (skill == gensklist.Items[i])
                        {
                            this.gensklist.SetItemChecked(i, true);
                        }
                    }
                }
            }


        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sumbit_Click(object sender, EventArgs e)
        {
            if (this.name.Text == "" || this.workingMod.maxAtt == WrestlingSkills.stmod ||
                this.workingMod.minAtt == WrestlingSkills.stmod ||
                this.workingMod.skillMods == this.starr)
            {
                new Warning().ShowDialog();
            }
            else
            {
                if (this.workingKey != "")
                {
                    main.genericWrestlingSkills.Remove(this.workingKey);
                    main.genericWrestlingSkills.Add(this.name.Text, this.workingMod);
                }
                else
                {
                    main.genericWrestlingSkills.Add(this.name.Text, this.workingMod);
                }
                main.repopListThings();
                this.Close();
            }
        }

        private void attlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.mintext.Text
        }
    }
}
