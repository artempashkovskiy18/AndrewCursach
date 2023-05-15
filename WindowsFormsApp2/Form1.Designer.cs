namespace WindowsFormsApp2
{
    partial class Form1
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
            this.button3DS = new System.Windows.Forms.Button();
            this.buttonAnimate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonAutoCad = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // button3DS
            // 
            this.button3DS.Location = new System.Drawing.Point(93, 49);
            this.button3DS.Name = "button3DS";
            this.button3DS.Size = new System.Drawing.Size(75, 23);
            this.button3DS.TabIndex = 1;
            this.button3DS.Text = "button2";
            this.button3DS.UseVisualStyleBackColor = true;
            this.button3DS.Click += new System.EventHandler(this.button3DS_Click);
            // 
            // buttonAnimate
            // 
            this.buttonAnimate.Location = new System.Drawing.Point(174, 49);
            this.buttonAnimate.Name = "buttonAnimate";
            this.buttonAnimate.Size = new System.Drawing.Size(87, 23);
            this.buttonAnimate.TabIndex = 2;
            this.buttonAnimate.Text = "button3";
            this.buttonAnimate.UseVisualStyleBackColor = true;
            this.buttonAnimate.Click += new System.EventHandler(this.buttonAnimate_Click);
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 35);
            this.label1.TabIndex = 3;
            this.label1.Text = " презентація з AutoCad ";
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.Location = new System.Drawing.Point(93, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 35);
            this.label2.TabIndex = 4;
            this.label2.Text = " презентація з 3DS Max";
            // 
            // label3
            // 
            this.label3.AutoEllipsis = true;
            this.label3.Location = new System.Drawing.Point(174, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 35);
            this.label3.TabIndex = 5;
            this.label3.Text = " презентація з Adobe animate";
            // 
            // buttonAutoCad
            // 
            this.buttonAutoCad.Location = new System.Drawing.Point(12, 49);
            this.buttonAutoCad.Name = "buttonAutoCad";
            this.buttonAutoCad.Size = new System.Drawing.Size(75, 23);
            this.buttonAutoCad.TabIndex = 6;
            this.buttonAutoCad.Text = "button1";
            this.buttonAutoCad.UseVisualStyleBackColor = true;
            this.buttonAutoCad.Click += new System.EventHandler(this.buttonAutoCad_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(367, 11);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(97, 41);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Edit mode";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(12, 303);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(190, 135);
            this.listView1.TabIndex = 10;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.buttonAutoCad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAnimate);
            this.Controls.Add(this.button3DS);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ListView listView1;

        private System.Windows.Forms.CheckBox checkBox1;

        private System.Windows.Forms.Button buttonAnimate;
        private System.Windows.Forms.Button button3DS;

        private System.Windows.Forms.Button buttonAutoCad;

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

        #endregion
    }
}