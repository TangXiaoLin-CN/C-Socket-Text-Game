using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1
{
    public partial class Form1 : Form
    {
        //创建连接
        MysqlConn Conn = new MysqlConn();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new ZHMMForm().Show();
            this.Hide();
            //this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void 登录_Load(object sender, EventArgs e)
        {
            
        }

        private void close_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity >= 0.025)
                this.Opacity -= 0.025;
            else
            {
                timer1.Stop();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //SQLManage n = new SQLManage();
            //n.testconn();

            string uid = idtext.Text;
            string pwd = pwtest.Text;

            if (uid.Length == 0 || pwd.Length == 0)
            {
                MessageBox.Show("请填写完整信息", "提示");
                return;
            }

            if (checkBox1.Checked != true) 
            {
                MessageBox.Show("请勾选用户协议", "提示");
                return;
            }

            //改为统一定义，方便管理
            ////定义链接字符串
            //string connString = "server=127.0.0.1;port=3306;user=root;password=123;database=test;Charset=utf8;";
            ////创建连接对象
            //MySqlConnection conn = new MySqlConnection(connString);

            string sqlLog = "select * from user where id='" + uid + "'and password='" + pwd + "'  ";
            MySqlCommand cmd1 = new MySqlCommand(sqlLog, Conn.Conn);

            Conn.Open();//改为统一定义

            MySqlDataReader reader = cmd1.ExecuteReader();

            //判断账号是否重复
            if (reader.Read())
            {
                //存储基本信息
                Me.id = uid;
                //MessageBox.Show(Me.id);

                //MessageBox.Show("登录成功");

                Hide();
                Form3 form3 = new Form3();
                form3.ShowDialog();
                Close();

                ////用于测试
                //Hide();
                //RoomForm roomform = new RoomForm(10,8888);
                //roomform.ShowDialog();
                //Close();
                //this.Hide();




                //this.Close();

            }
            else
            {
                MessageBox.Show("账号或密码错误，请重新输入");
            }

            Conn.Close();
         
         
        }

        private void idtext_TextChanged(object sender, EventArgs e)
        {

        }

        private void pwtest_TextChanged(object sender, EventArgs e)
        {

        }

        private void register_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Form2().Show();
            this.Hide();
            //this.Close();
        }

        
    }
}
