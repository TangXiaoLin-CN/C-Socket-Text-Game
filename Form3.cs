using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1
{
    public partial class Form3 : Form
    {
        //创建连接
        MysqlConn Conn = new MysqlConn();

        public Form3()
        {
            InitializeComponent();
        }

        private void shutdown_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            Hide();
            CJFJForm createroom = new CJFJForm();

            createroom.ShowDialog();
            Show();
            
        }


        public ListView InitListView(ListView lv)
        {
            ColumnHeader c1 = new ColumnHeader();
            c1.Width = 100;
            c1.Text = "姓名";
            ColumnHeader c2 = new ColumnHeader();
            c2.Width = 100;
            c2.Text = "性别";
            ColumnHeader c3 = new ColumnHeader();
            c3.Width = 100;
            c3.Text = "电话";
            //设置属性
            lv.GridLines = true;  //显示网格线
            lv.FullRowSelect = true;  //显示全行
            lv.MultiSelect = false;  //设置只能单选
            lv.View = View.Details;  //设置显示模式为详细
            lv.HoverSelection = true;  //当鼠标停留数秒后自动选择
            //把列名添加到listview中
            lv.Columns.Add(c1);
            lv.Columns.Add(c2);
            lv.Columns.Add(c3);
            lv.Columns.Add("籍贯", 100);  //相当于上面的添加列名的步骤
            return lv;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Conn.Open();//改为统一定义

            string sqlLog = "select model from room where  rnum = " + roomList.SelectedItem.ToString();
            MySqlCommand cmd1 = new MySqlCommand(sqlLog, Conn.Conn);

            //读取查询命令结果
            MySqlDataReader reader = cmd1.ExecuteReader();
            if (!reader.Read())
            {
                Conn.Close();
                MessageBox.Show("尝试加入房间时，未找到游戏模式。");
                return;
            }
            

            int model =int.Parse(reader["model"].ToString());
            int part = int.Parse(roomList.SelectedItem.ToString());

            Conn.Close();
            //窗口跳转
            Hide();
            RoomForm roomform = new RoomForm(model * 2, part,false);//最大游戏人数 = 模式 x 2，端口 = 写入端口
            roomform.ShowDialog();
            Show();

            //重新更新
            RreshRoom();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            RreshRoom();
        }


        /// <summary>
        /// 刷新房间
        /// </summary>
        void RreshRoom()
        {
            //先清空
            roomList.Items.Clear();

            Conn.Open();//改为统一定义

            string sqlLog = "select rnum from room";
            MySqlCommand cmd1 = new MySqlCommand(sqlLog, Conn.Conn);

            //读取查询命令结果
            MySqlDataReader reader = cmd1.ExecuteReader();

            while (reader.Read())
            {
                roomList.Items.Add(reader["rnum"].ToString().Trim());
            }


            Conn.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            RreshRoom();
        }
    }
}
