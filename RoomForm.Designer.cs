
namespace test1
{
    partial class RoomForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.redList = new System.Windows.Forms.ListBox();
            this.blueList = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SendBox = new System.Windows.Forms.TextBox();
            this.TalkBox = new System.Windows.Forms.TextBox();
            this.LogBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("楷体", 25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(5, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 42);
            this.label1.TabIndex = 2;
            this.label1.Text = "红队";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("楷体", 25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(312, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 42);
            this.label2.TabIndex = 3;
            this.label2.Text = "蓝队";
            // 
            // redList
            // 
            this.redList.FormattingEnabled = true;
            this.redList.ItemHeight = 15;
            this.redList.Location = new System.Drawing.Point(12, 55);
            this.redList.MultiColumn = true;
            this.redList.Name = "redList";
            this.redList.Size = new System.Drawing.Size(286, 319);
            this.redList.TabIndex = 4;
            this.redList.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // blueList
            // 
            this.blueList.FormattingEnabled = true;
            this.blueList.ItemHeight = 15;
            this.blueList.Location = new System.Drawing.Point(319, 55);
            this.blueList.MultiColumn = true;
            this.blueList.Name = "blueList";
            this.blueList.Size = new System.Drawing.Size(286, 319);
            this.blueList.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.SendBox);
            this.groupBox1.Controls.Add(this.TalkBox);
            this.groupBox1.ForeColor = System.Drawing.Color.OrangeRed;
            this.groupBox1.Location = new System.Drawing.Point(618, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(486, 548);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "公共消息：";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 13.91597F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(351, 491);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 45);
            this.button1.TabIndex = 2;
            this.button1.Text = "发送";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SendBox
            // 
            this.SendBox.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.SendBox.ForeColor = System.Drawing.SystemColors.Window;
            this.SendBox.Location = new System.Drawing.Point(6, 374);
            this.SendBox.Multiline = true;
            this.SendBox.Name = "SendBox";
            this.SendBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.SendBox.ShortcutsEnabled = false;
            this.SendBox.Size = new System.Drawing.Size(474, 111);
            this.SendBox.TabIndex = 1;
            this.SendBox.Text = "在这里输入内容.....";
            this.SendBox.TextChanged += new System.EventHandler(this.UserMsgBox_TextChanged);
            // 
            // TalkBox
            // 
            this.TalkBox.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.TalkBox.ForeColor = System.Drawing.SystemColors.Window;
            this.TalkBox.Location = new System.Drawing.Point(6, 19);
            this.TalkBox.Multiline = true;
            this.TalkBox.Name = "TalkBox";
            this.TalkBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TalkBox.ShortcutsEnabled = false;
            this.TalkBox.Size = new System.Drawing.Size(474, 349);
            this.TalkBox.TabIndex = 0;
            this.TalkBox.Text = "匿名用户:";
            this.TalkBox.TextChanged += new System.EventHandler(this.TalkBox_TextChanged);
            // 
            // LogBox
            // 
            this.LogBox.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.LogBox.ForeColor = System.Drawing.SystemColors.Window;
            this.LogBox.Location = new System.Drawing.Point(12, 386);
            this.LogBox.Multiline = true;
            this.LogBox.Name = "LogBox";
            this.LogBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogBox.ShortcutsEnabled = false;
            this.LogBox.Size = new System.Drawing.Size(593, 174);
            this.LogBox.TabIndex = 7;
            this.LogBox.Text = "系统消息：";
            // 
            // RoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(1116, 572);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.blueList);
            this.Controls.Add(this.redList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RoomForm";
            this.Text = "RoomForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RoomForm_FormClosing);
            this.Load += new System.EventHandler(this.RoomForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox redList;
        private System.Windows.Forms.ListBox blueList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TalkBox;
        private System.Windows.Forms.TextBox SendBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox LogBox;
    }
}