namespace GameBuilder
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.attributes = new System.Windows.Forms.Button();
            this.gskills = new System.Windows.Forms.Button();
            this.wskills = new System.Windows.Forms.Button();
            this.bparts = new System.Windows.Forms.Button();
            this.infobox = new System.Windows.Forms.TextBox();
            this.listthings = new System.Windows.Forms.ListBox();
            this.listlabel = new System.Windows.Forms.Label();
            this.add = new System.Windows.Forms.Button();
            this.edit = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // attributes
            // 
            this.attributes.Location = new System.Drawing.Point(9, 8);
            this.attributes.Name = "attributes";
            this.attributes.Size = new System.Drawing.Size(87, 25);
            this.attributes.TabIndex = 0;
            this.attributes.Text = "Attributes";
            this.attributes.UseVisualStyleBackColor = true;
            this.attributes.Click += new System.EventHandler(this.attributes_Click);
            // 
            // gskills
            // 
            this.gskills.Location = new System.Drawing.Point(102, 8);
            this.gskills.Name = "gskills";
            this.gskills.Size = new System.Drawing.Size(87, 25);
            this.gskills.TabIndex = 1;
            this.gskills.Text = "G. Skills";
            this.gskills.UseVisualStyleBackColor = true;
            this.gskills.Click += new System.EventHandler(this.gskills_Click);
            // 
            // wskills
            // 
            this.wskills.Location = new System.Drawing.Point(195, 8);
            this.wskills.Name = "wskills";
            this.wskills.Size = new System.Drawing.Size(87, 25);
            this.wskills.TabIndex = 2;
            this.wskills.Text = "W. Skills";
            this.wskills.UseVisualStyleBackColor = true;
            this.wskills.Click += new System.EventHandler(this.wskills_Click);
            // 
            // bparts
            // 
            this.bparts.Location = new System.Drawing.Point(288, 8);
            this.bparts.Name = "bparts";
            this.bparts.Size = new System.Drawing.Size(87, 25);
            this.bparts.TabIndex = 3;
            this.bparts.Text = "B. Parts";
            this.bparts.UseVisualStyleBackColor = true;
            this.bparts.Click += new System.EventHandler(this.bparts_Click);
            // 
            // infobox
            // 
            this.infobox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.infobox.Location = new System.Drawing.Point(9, 39);
            this.infobox.Multiline = true;
            this.infobox.Name = "infobox";
            this.infobox.Size = new System.Drawing.Size(273, 149);
            this.infobox.TabIndex = 4;
            this.infobox.Text = resources.GetString("infobox.Text");
            // 
            // listthings
            // 
            this.listthings.FormattingEnabled = true;
            this.listthings.Location = new System.Drawing.Point(288, 40);
            this.listthings.Name = "listthings";
            this.listthings.Size = new System.Drawing.Size(117, 186);
            this.listthings.Sorted = true;
            this.listthings.TabIndex = 5;
            // 
            // listlabel
            // 
            this.listlabel.AutoSize = true;
            this.listlabel.Location = new System.Drawing.Point(405, 14);
            this.listlabel.Name = "listlabel";
            this.listlabel.Size = new System.Drawing.Size(0, 13);
            this.listlabel.TabIndex = 6;
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(12, 194);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(87, 25);
            this.add.TabIndex = 7;
            this.add.Text = "Add";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // edit
            // 
            this.edit.Location = new System.Drawing.Point(105, 194);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(87, 25);
            this.edit.TabIndex = 8;
            this.edit.Text = "Edit";
            this.edit.UseVisualStyleBackColor = true;
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(195, 194);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(87, 25);
            this.delete.TabIndex = 9;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(378, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 22);
            this.button1.TabIndex = 10;
            this.button1.Text = "L";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 236);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.edit);
            this.Controls.Add(this.add);
            this.Controls.Add(this.listlabel);
            this.Controls.Add(this.listthings);
            this.Controls.Add(this.infobox);
            this.Controls.Add(this.bparts);
            this.Controls.Add(this.wskills);
            this.Controls.Add(this.gskills);
            this.Controls.Add(this.attributes);
            this.Name = "MainForm";
            this.Text = "Game Maker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button attributes;
        private System.Windows.Forms.Button gskills;
        private System.Windows.Forms.Button wskills;
        private System.Windows.Forms.Button bparts;
        private System.Windows.Forms.TextBox infobox;
        private System.Windows.Forms.ListBox listthings;
        private System.Windows.Forms.Label listlabel;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button button1;


    }
}

