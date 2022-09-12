using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Collections;
using MySql.Data.MySqlClient;

namespace test1
{
    public partial class CJFJForm : Form
    {
        //创建连接
        MysqlConn Conn = new MysqlConn();

        //端口号
        int count;

        public CJFJForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            //房间类型
            int model = 1;

            if (radioButton2.Checked)
            {
                model = 2;
            }
            if (radioButton3.Checked)
            {
                model = 5;
            }

            Conn.Open();//改为统一定义

            string sqlLog = "select * from room where rnum=" + int.Parse(partBox.Text);
            MySqlCommand cmd1 = new MySqlCommand(sqlLog, Conn.Conn);
            MySqlDataReader reader = cmd1.ExecuteReader();
           

            if (reader.Read())
            {
                Conn.Close();
                MessageBox.Show("该端口已有房间，请重新输入！");
                return;
            }

            Conn.Close();



            //添加房间信息SQL语句
            string sql = string.Format("insert into room(rnum,model) values({0},{1})",count,model);  //生成端口号与房间类型，rnum取值（端口号）：1-65535 ； model取值（房间类型）：1 2  5，分别表示1v1 2v2 5v5            


            MySqlCommand cmd = new MySqlCommand(sql, Conn.Conn);
            //打开连接
            Conn.Open();

            //执行操作
            int reslt = cmd.ExecuteNonQuery();
            Conn.Close();

            //Hide();

            ////窗口跳转

            Hide();
            RoomForm roomform = new RoomForm(model * 2, count);//最大游戏人数 = 模式 x 2，端口 = 写入端口
            roomform.ShowDialog();
            Close();

            //this.Close();

        }

        private void CJFJForm_Load(object sender, EventArgs e)
        {
            Random sj = new Random();
            count = sj.Next(1, 65535);
            partBox.Text = count.ToString();
        }

        private void partBox_TextChanged(object sender, EventArgs e)
        {
            count = int.Parse(partBox.Text);
        }
    }
}
