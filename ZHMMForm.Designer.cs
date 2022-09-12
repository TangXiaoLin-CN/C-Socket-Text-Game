
namespace test1
{
    partial class ZHMMForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZHMMForm));
            this.register = new System.Windows.Forms.Button();
            this.pw2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pw1 = new System.Windows.Forms.TextBox();
            this.idtext = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.shutdown = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // register
            // 
            this.register.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
            this.register.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
            this.register.FlatAppearance.BorderSize = 0;
            this.register.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.register.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold);
            this.register.Location = new System.Drawing.Point(231, 389);
            this.register.Name = "register";
            this.register.Size = new System.Drawing.Size(448, 38);
            this.register.TabIndex = 18;
            this.register.Text = "修 改 密 码";
            this.register.UseVisualStyleBackColor = false;
            this.register.Click += new System.EventHandler(this.register_Click);
            // 
            // pw2
            // 
            this.pw2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.pw2.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold);
            this.pw2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
            this.pw2.Location = new System.Drawing.Point(231, 311);
            this.pw2.Name = "pw2";
            this.pw2.Size = new System.Drawing.Size(448, 36);
            this.pw2.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(226, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 25);
            this.label3.TabIndex = 16;
            this.label3.Text = "确认密码:";
            // 
            // pw1
            // 
            this.pw1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.pw1.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold);
            this.pw1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
            this.pw1.Location = new System.Drawing.Point(231, 221);
            this.pw1.Name = "pw1";
            this.pw1.Size = new System.Drawing.Size(448, 36);
            this.pw1.TabIndex = 15;
            // 
            // idtext
            // 
            this.idtext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.idtext.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold);
            this.idtext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
            this.idtext.Location = new System.Drawing.Point(231, 133);
            this.idtext.Name = "idtext";
            this.idtext.Size = new System.Drawing.Size(448, 36);
            this.idtext.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(226, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "新 密 码:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(226, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "用户名:";
            // 
            // shutdown
            // 
            this.shutdown.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
            this.shutdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shutdown.Image = ((System.Drawing.Image)(resources.GetObject("shutdown.Image")));
            this.shutdown.Location = new System.Drawing.Point(808, 32);
            this.shutdown.Name = "shutdown";
            this.shutdown.Size = new System.Drawing.Size(58, 57);
            this.shutdown.TabIndex = 19;
            this.shutdown.UseVisualStyleBackColor = true;
            this.shutdown.Click += new System.EventHandler(this.shutdown_Click);
            // 
            // ZHMMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(19)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(904, 516);
            this.Controls.Add(this.shutdown);
            this.Controls.Add(this.register);
            this.Controls.Add(this.pw2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pw1);
            this.Controls.Add(this.idtext);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ZHMMForm";
            this.Text = "找回密码";
            this.Load += new System.EventHandler(this.ZHMMForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button register;
        private System.Windows.Forms.TextBox pw2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox pw1;
        private System.Windows.Forms.TextBox idtext;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button shutdown;
    }
}