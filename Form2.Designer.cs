
namespace test1
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.pw1 = new System.Windows.Forms.TextBox();
            this.idtext = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pw2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.register = new System.Windows.Forms.Button();
            this.shutdown = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pw1
            // 
            this.pw1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.pw1.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold);
            this.pw1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
            this.pw1.Location = new System.Drawing.Point(236, 224);
            this.pw1.Name = "pw1";
            this.pw1.Size = new System.Drawing.Size(448, 36);
            this.pw1.TabIndex = 8;
            // 
            // idtext
            // 
            this.idtext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.idtext.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold);
            this.idtext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
            this.idtext.Location = new System.Drawing.Point(236, 136);
            this.idtext.Name = "idtext";
            this.idtext.Size = new System.Drawing.Size(448, 36);
            this.idtext.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(231, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "密 码:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(231, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "用户名:";
            // 
            // pw2
            // 
            this.pw2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.pw2.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold);
            this.pw2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
            this.pw2.Location = new System.Drawing.Point(236, 314);
            this.pw2.Name = "pw2";
            this.pw2.Size = new System.Drawing.Size(448, 36);
            this.pw2.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(231, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "确认密码:";
            // 
            // register
            // 
            this.register.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
            this.register.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
            this.register.FlatAppearance.BorderSize = 0;
            this.register.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.register.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold);
            this.register.Location = new System.Drawing.Point(236, 392);
            this.register.Name = "register";
            this.register.Size = new System.Drawing.Size(448, 38);
            this.register.TabIndex = 11;
            this.register.Text = "注 册";
            this.register.UseVisualStyleBackColor = false;
            this.register.Click += new System.EventHandler(this.register_Click);
            // 
            // shutdown
            // 
            this.shutdown.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
            this.shutdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shutdown.Image = ((System.Drawing.Image)(resources.GetObject("shutdown.Image")));
            this.shutdown.Location = new System.Drawing.Point(829, 29);
            this.shutdown.Name = "shutdown";
            this.shutdown.Size = new System.Drawing.Size(58, 57);
            this.shutdown.TabIndex = 12;
            this.shutdown.UseVisualStyleBackColor = true;
            this.shutdown.Click += new System.EventHandler(this.shutdown_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(19)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(922, 563);
            this.Controls.Add(this.shutdown);
            this.Controls.Add(this.register);
            this.Controls.Add(this.pw2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pw1);
            this.Controls.Add(this.idtext);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pw1;
        private System.Windows.Forms.TextBox idtext;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pw2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button register;
        private System.Windows.Forms.Button shutdown;
    }
}