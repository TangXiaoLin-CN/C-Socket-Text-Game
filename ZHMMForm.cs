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
    public partial class ZHMMForm : Form
    {
        //创建连接
        MysqlConn Conn = new MysqlConn();

        public ZHMMForm()
        {
            InitializeComponent();
        }

        private void shutdown_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
            //this.Close();
        }
        
        public void c()
        {
            idtext.Text = "";
            pw1.Text = "";
            pw2.Text = "";
        }

        private void register_Click(object sender, EventArgs e)
        {
            string uid = idtext.Text.Trim();
            string pwd1 = pw1.Text;
            string pwd2 = pw2.Text;

            if (uid.Length == 0 || pwd1.Length == 0 || pwd2.Length == 0)
            {
                MessageBox.Show("请填写完整信息");
                return;
            }

            if (pwd1 != pwd2)
            {
                MessageBox.Show("密码不一致！");
                return;
            }

            ////定义链接字符串
            //string connetStr = "server=127.0.0.1;port=3306;user=root;password=123;database=test;Charset=utf8;";

            ////创建连接对象
            //MySqlConnection conn = new MySqlConnection(connetStr);

            //组合sql查询语句
            string sqlSelect = "select id from user where id='" + uid + "'";
            MySqlCommand cmd1 = new MySqlCommand(sqlSelect, Conn.Conn);
            //执行查询
            Conn.Open();
            MySqlDataReader reader = cmd1.ExecuteReader();

            //判断账号是否重复
            while (!reader.Read())//初始索引是-1，执行读取下一行数据，返回值是bool
            {
                MessageBox.Show("该账户尚未注册", "提示");
                Conn.Close();
                return;
            }
            Conn.Close();

            //添加注册信息SQL语句                        
            string sql = string.Format("update user set password = '" + pwd1 + "' where id='" + uid + "'");

            MySqlCommand cmd = new MySqlCommand(sql, Conn.Conn);
            //打开连接
            Conn.Open();
            //执行操作
            int reslt = cmd.ExecuteNonQuery();
            Conn.Close();
            //清空输入
            c();
            //注册成功
            MessageBox.Show("修改新密码成功");
            this.Close();

        }

        private void ZHMMForm_Load(object sender, EventArgs e)
        {

        }
    }
}
