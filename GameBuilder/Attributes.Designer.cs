﻿namespace GameBuilder
{
    partial class Attributes
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
            this.name = new System.Windows.Forms.Label();
            this.sumbit = new System.Windows.Forms.Button();
            this.input = new System.Windows.Forms.TextBox();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(12, 9);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(77, 13);
            this.name.TabIndex = 0;
            this.name.Text = "Attribute Name";
            // 
            // sumbit
            // 
            this.sumbit.Location = new System.Drawing.Point(12, 51);
            this.sumbit.Name = "sumbit";
            this.sumbit.Size = new System.Drawing.Size(70, 30);
            this.sumbit.TabIndex = 1;
            this.sumbit.Text = "Submit";
            this.sumbit.UseVisualStyleBackColor = true;
            this.sumbit.Click += new System.EventHandler(this.sumbit_Click);
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(12, 25);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(173, 20);
            this.input.TabIndex = 2;
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(115, 51);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(70, 30);
            this.cancel.TabIndex = 5;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // Attributes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(201, 95);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.input);
            this.Controls.Add(this.sumbit);
            this.Controls.Add(this.name);
            this.Name = "Attributes";
            this.Text = "Attributes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Button sumbit;
        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.Button cancel;
    }
}