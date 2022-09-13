using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace test1
{
    /// <summary>
    /// 用于连接数据库，防止代码重复 
    /// </summary>
    class MysqlConn
    {
        //定义链接字符串
        string connString = "server=127.0.0.1;port=3306;user=root;password=123;database=test;Charset=utf8;"; //Modify it to your own database. Please ensure that the required tables are created

        //创建连接对象,创建类时自动创建SQL连接
        public MySqlConnection Conn;

        public MysqlConn()
        {
            Conn = new MySqlConnection(connString);
            //Conn.Open();
        }

        public void Close()
        {
            Conn.Close();
        }

        public void Open()
        {
            Conn.Open();
        }
    }


    /// <summary>
    /// 用于存储读取到的基本信息
    /// </summary>
    static class Me
    {
        public static string id;
        public static User me;
    }
}
