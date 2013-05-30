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
    public enum choice { attribute, general, wrestling, body };

    public partial class MainForm : Form
    {
        public String[] genericAttributes;
        public Dictionary<String, String> genericGeneralSkills;
        public Dictionary<String, Wrestler.modifier> genericWrestlingSkills;
        public String[] genericBodyParts;
        public choice formchoice;

        Attributes attWindow;
        BodyParts bdptWindow;
        GeneralSkills gnskWindow;
        WrestlingSkills wrskWindow;

        public MainForm()
        {
            this.genericAttributes = new String[0];
            this.genericGeneralSkills = new Dictionary<String,String>();
            this.genericWrestlingSkills = new Dictionary<String,Wrestler.modifier>();
            this.genericBodyParts = new String[0];
            this.formchoice = choice.attribute;
            this.attWindow = new Attributes(this);
            this.bdptWindow = new BodyParts(this);
            this.gnskWindow = new GeneralSkills(this);
            this.wrskWindow = new WrestlingSkills(this);
            
            InitializeComponent();

            this.attributes_Click(new object(), new EventArgs());
        }

        public void repopListThings()
        {
            if (this.formchoice == choice.attribute)
            {
                this.attributes_Click(new object(), new EventArgs());
            }
            else if (this.formchoice == choice.body)
            {
                this.bparts_Click(new object(), new EventArgs());
            }
            else if (this.formchoice == choice.general)
            {
                this.gskills_Click(new object(), new EventArgs());
            }
            else if (this.formchoice == choice.wrestling)
            {
                this.wskills_Click(new object(), new EventArgs());
            }
            else
            {
                throw new Exception("Tried to repopulate list, but no attribute was found");
            }
            
        }

        private void attributes_Click(object sender, EventArgs e)
        {
            this.listthings.Items.Clear();
            if (genericAttributes.Length != 0)
            {
                foreach ( String  att in genericAttributes)
                {
                    this.listthings.Items.Add(att);
                }
            }

            this.formchoice = choice.attribute;

            this.attributesButton.FlatStyle = FlatStyle.Flat;
            this.bpartsButton.FlatStyle = FlatStyle.Standard;
            this.gskillsButton.FlatStyle = FlatStyle.Standard;
            this.wskillsButton.FlatStyle = FlatStyle.Standard;
        }

        private void gskills_Click(object sender, EventArgs e)
        {
            this.listthings.Items.Clear();
            if (this.genericGeneralSkills.Count != 0)
            {
                foreach ( String  skills in this.genericGeneralSkills.Keys)
                {
                    this.listthings.Items.Add(skills);
                }
            }

            this.formchoice = choice.general;

            this.attributesButton.FlatStyle = FlatStyle.Standard;
            this.bpartsButton.FlatStyle = FlatStyle.Standard;
            this.gskillsButton.FlatStyle = FlatStyle.Flat;
            this.wskillsButton.FlatStyle = FlatStyle.Standard;
        }

        private void wskills_Click(object sender, EventArgs e)
        {
            this.listthings.Items.Clear();
            if (this.genericWrestlingSkills.Count != 0)
            {
                foreach ( String  skills in this.genericWrestlingSkills.Keys)
                {
                    this.listthings.Items.Add(skills);
                }
            }

            this.formchoice = choice.wrestling;

            this.attributesButton.FlatStyle = FlatStyle.Standard;
            this.bpartsButton.FlatStyle = FlatStyle.Standard;
            this.gskillsButton.FlatStyle = FlatStyle.Standard;
            this.wskillsButton.FlatStyle = FlatStyle.Flat;
        }

        private void bparts_Click(object sender, EventArgs e)
        {
            this.listthings.Items.Clear();
            if (genericBodyParts.Length != 0)
            {
                foreach ( String  att in genericBodyParts)
                {
                    this.listthings.Items.Add(att);
                }
            }

            this.formchoice = choice.body;

            this.attributesButton.FlatStyle = FlatStyle.Standard;
            this.bpartsButton.FlatStyle = FlatStyle.Flat;
            this.gskillsButton.FlatStyle = FlatStyle.Standard;
            this.wskillsButton.FlatStyle = FlatStyle.Standard;
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (this.formchoice == choice.attribute)
            {
                this.attWindow.openWindow();
            }

            else if (this.formchoice == choice.body)
            {
                this.bdptWindow.openWindow();
            }

            else if (this.formchoice == choice.general)
            {
                this.gnskWindow.openWindow();
            }

            else if (this.formchoice == choice.wrestling)
            {
                this.wrskWindow.openWindow();
            }

            else
            {
                throw new Exception("Somehow the mainform does not have a choice to use?");
            }
        }

        public int getID( String  val, ref  String [] list)
        {
            int retval = -1;

            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] == val)
                {
                    retval = i;
                }
            }

            return retval;
        }

        private void edit_Click(object sender, EventArgs e)
        {
            if (this.listthings.Text == "")
            {
                return;
            }
            else if (this.formchoice == choice.attribute)
            {
                this.attWindow.openWindow(this.getID(this.listthings.Text, ref this.genericAttributes));
            }

            else if (this.formchoice == choice.body)
            {
                this.bdptWindow.openWindow(this.getID(listthings.Text, ref this.genericBodyParts));
            }

            else if (this.formchoice == choice.general)
            {
                this.gnskWindow.openWindow(this.listthings.Text);
            }

            else if (this.formchoice == choice.wrestling)
            {
                this.wrskWindow.openWindow(this.listthings.Text);
            }

            else
            {
                throw new Exception("Somehow the mainform does not have a choice to use?");
            }
        }
    }
}
