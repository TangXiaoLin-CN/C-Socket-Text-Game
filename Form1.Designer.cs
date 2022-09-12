
namespace test1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.shutdown = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.idtext = new System.Windows.Forms.TextBox();
            this.pwtest = new System.Windows.Forms.TextBox();
            this.login = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lostpw = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.register = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // shutdown
            // 
            this.shutdown.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
            this.shutdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shutdown.Image = ((System.Drawing.Image)(resources.GetObject("shutdown.Image")));
            this.shutdown.Location = new System.Drawing.Point(860, 26);
            this.shutdown.Name = "shutdown";
            this.shutdown.Size = new System.Drawing.Size(58, 57);
            this.shutdown.TabIndex = 0;
            this.shutdown.UseVisualStyleBackColor = true;
            this.shutdown.Click += new System.EventHandler(this.close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(241, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "用户名:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(241, 342);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "密 码:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // idtext
            // 
            this.idtext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.idtext.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold);
            this.idtext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
            this.idtext.Location = new System.Drawing.Point(246, 294);
            this.idtext.Name = "idtext";
            this.idtext.Size = new System.Drawing.Size(448, 36);
            this.idtext.TabIndex = 3;
            this.idtext.Text = "test";
            this.idtext.TextChanged += new System.EventHandler(this.idtext_TextChanged);
            // 
            // pwtest
            // 
            this.pwtest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.pwtest.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold);
            this.pwtest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
            this.pwtest.Location = new System.Drawing.Point(246, 382);
            this.pwtest.Name = "pwtest";
            this.pwtest.Size = new System.Drawing.Size(448, 36);
            this.pwtest.TabIndex = 4;
            this.pwtest.Text = "123456";
            this.pwtest.TextChanged += new System.EventHandler(this.pwtest_TextChanged);
            // 
            // login
            // 
            this.login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
            this.login.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
            this.login.FlatAppearance.BorderSize = 0;
            this.login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.login.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold);
            this.login.Location = new System.Drawing.Point(246, 446);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(448, 38);
            this.login.TabIndex = 0;
            this.login.Text = "登 录";
            this.login.UseVisualStyleBackColor = false;
            this.login.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Font = new System.Drawing.Font("楷体", 10F, System.Drawing.FontStyle.Bold);
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(246, 520);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(236, 21);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "我已经知晓软件相关政策";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // lostpw
            // 
            this.lostpw.AutoSize = true;
            this.lostpw.Font = new System.Drawing.Font("楷体", 10F, System.Drawing.FontStyle.Bold);
            this.lostpw.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lostpw.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
            this.lostpw.Location = new System.Drawing.Point(616, 522);
            this.lostpw.Name = "lostpw";
            this.lostpw.Size = new System.Drawing.Size(84, 17);
            this.lostpw.TabIndex = 6;
            this.lostpw.TabStop = true;
            this.lostpw.Text = "忘记密码";
            this.lostpw.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(378, 48);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(205, 193);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // register
            // 
            this.register.AutoSize = true;
            this.register.Font = new System.Drawing.Font("楷体", 10F, System.Drawing.FontStyle.Bold);
            this.register.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.register.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
            this.register.Location = new System.Drawing.Point(518, 522);
            this.register.Name = "register";
            this.register.Size = new System.Drawing.Size(84, 17);
            this.register.TabIndex = 8;
            this.register.TabStop = true;
            this.register.Text = "注册用户";
            this.register.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.register_LinkClicked_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(19)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(940, 610);
            this.Controls.Add(this.register);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lostpw);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.pwtest);
            this.Controls.Add(this.idtext);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.login);
            this.Controls.Add(this.shutdown);
            this.Name = "Form1";
            this.Text = "登录";
            this.Load += new System.EventHandler(this.登录_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button shutdown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox idtext;
        private System.Windows.Forms.TextBox pwtest;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.LinkLabel lostpw;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.LinkLabel register;
    }
}

