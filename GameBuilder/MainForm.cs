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
    enum choice { attribute, general, wrestling, body };

    public partial class MainForm : Form
    {
        private static string[] genericAttributes;
        private static Dictionary<string, string> genericGeneralSkills;
        private static Dictionary<string, Wrestler.modifier> genericWrestlingSkills;
        private string[] genericBodyParts;
        private choice formchoice;

        public MainForm()
        {
            this.formchoice = choice.attribute;
            InitializeComponent();
        }

        private void attributes_Click(object sender, EventArgs e)
        {
            this.listthings.Items.Clear();
            if (genericAttributes.Length != 0)
            {
                foreach (string att in genericAttributes)
                {
                    this.listthings.Items.Add(att);
                }
            }

            this.formchoice = choice.attribute;
        }

        private void gskills_Click(object sender, EventArgs e)
        {
            this.listthings.Items.Clear();
            if (genericWrestlingSkills.Count != 0)
            {
                foreach (string skills in genericWrestlingSkills.Keys)
                {
                    this.listthings.Items.Add(skills);
                }
            }

            this.formchoice = choice.general;
        }

        private void wskills_Click(object sender, EventArgs e)
        {
            this.listthings.Items.Clear();
            if (genericGeneralSkills.Count != 0)
            {
                foreach (string skills in genericGeneralSkills.Keys)
                {
                    this.listthings.Items.Add(skills);
                }
            }

            this.formchoice = choice.wrestling;
        }

        private void bparts_Click(object sender, EventArgs e)
        {
            this.listthings.Items.Clear();
            if (genericBodyParts.Length != 0)
            {
                foreach (string att in genericBodyParts)
                {
                    this.listthings.Items.Add(att);
                }
            }

            this.formchoice = choice.body;
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (this.formchoice == choice.attribute)
            {
                new Attributes().openWindow(listthings.Text);
            }

            else if (this.formchoice == choice.body)
            {
                new BodyParts().openWindow(listthings.Text);
            }

            else if (this.formchoice == choice.general)
            {
                //new GeneralSkills().openWindow(listthings.Text);
            }

            else if (this.formchoice == choice.wrestling)
            {
               // WrestlingSkills.openWindow(listthings.Text);
            }
        }
    }
}
