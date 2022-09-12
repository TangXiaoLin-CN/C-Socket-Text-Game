
namespace test1
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.panelside = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panelhead = new System.Windows.Forms.Panel();
            this.shutdown = new System.Windows.Forms.Button();
            this.roomList = new System.Windows.Forms.ListBox();
            this.panelside.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelhead.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelside
            // 
            this.panelside.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.panelside.Controls.Add(this.pictureBox1);
            this.panelside.Controls.Add(this.button3);
            this.panelside.Controls.Add(this.button2);
            this.panelside.Controls.Add(this.button1);
            this.panelside.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelside.Location = new System.Drawing.Point(0, 50);
            this.panelside.Name = "panelside";
            this.panelside.Size = new System.Drawing.Size(200, 400);
            this.panelside.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pictureBox1.Location = new System.Drawing.Point(54, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold);
            this.button3.Location = new System.Drawing.Point(44, 310);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 41);
            this.button3.TabIndex = 5;
            this.button3.Text = "刷新房间";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(44, 251);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 41);
            this.button2.TabIndex = 4;
            this.button2.Text = "加入房间";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(44, 194);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 41);
            this.button1.TabIndex = 3;
            this.button1.Text = "创建房间";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelhead
            // 
            this.panelhead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.panelhead.Controls.Add(this.shutdown);
            this.panelhead.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelhead.Location = new System.Drawing.Point(0, 0);
            this.panelhead.Name = "panelhead";
            this.panelhead.Size = new System.Drawing.Size(800, 50);
            this.panelhead.TabIndex = 1;
            // 
            // shutdown
            // 
            this.shutdown.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
            this.shutdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shutdown.Image = ((System.Drawing.Image)(resources.GetObject("shutdown.Image")));
            this.shutdown.Location = new System.Drawing.Point(746, 1);
            this.shutdown.Name = "shutdown";
            this.shutdown.Size = new System.Drawing.Size(53, 47);
            this.shutdown.TabIndex = 1;
            this.shutdown.UseVisualStyleBackColor = true;
            this.shutdown.Click += new System.EventHandler(this.shutdown_Click);
            // 
            // roomList
            // 
            this.roomList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.roomList.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold);
            this.roomList.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.roomList.FormattingEnabled = true;
            this.roomList.ItemHeight = 20;
            this.roomList.Location = new System.Drawing.Point(205, 51);
            this.roomList.Name = "roomList";
            this.roomList.Size = new System.Drawing.Size(592, 384);
            this.roomList.TabIndex = 3;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(19)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.roomList);
            this.Controls.Add(this.panelside);
            this.Controls.Add(this.panelhead);
            this.Name = "Form3";
            this.Text = "查找房间";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.panelside.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelhead.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelside;
        private System.Windows.Forms.Panel panelhead;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button shutdown;
        private System.Windows.Forms.ListBox roomList;
    }
}