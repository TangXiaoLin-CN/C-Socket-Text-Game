using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1
{
    public partial class RoomForm : Form
    {
        //创建连接
        MysqlConn Conn = new MysqlConn();

        /// <summary>
        /// 游戏的最大人数，1v1则为2，5v5 则为10
        /// </summary>
        public int maxNum = 8;

        /// <summary>
        /// 端口号
        /// </summary>
        public int part = 8888;

        /// <summary>
        /// 是否房主
        /// </summary>
        public bool isHost = false;

        /// <summary>
        /// 作为服务器端时的服务器对象
        /// </summary>
        Socket Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        /// <summary>
        /// 作为客户端时的客户端对象
        /// </summary>
        Socket Client;

        /// <summary>
        /// 逻辑用户库
        /// </summary>
        UserInf users;

        /// <summary>
        /// 程序是否正在运行
        /// </summary>
        bool isRuning = true;


        /// <summary>
        /// 初始化服务器端
        /// </summary>
        public void InitServer()
        {

            //创建终结点
            IPAddress ipa = IPAddress.Parse("127.0.0.1");
            IPEndPoint ipe = new IPEndPoint(ipa, part);

            //绑定终结点
            Server.Bind(ipe);

            //监听终结点 等于最大用户数-1，因为自己承担了服务器
            Server.Listen(maxNum - 1);

            //SendLog("服务器开启成功");

            //开启监听
            Thread listenthread = new Thread(new ParameterizedThreadStart(ListenClient));
            listenthread.IsBackground = true;//设为后台线程，防止进程残留
            listenthread.Start(Server);


            

            Me.me = new User(ipe.ToString(),users.getTeam(), Me.id, true);

            //将自身加入房间
            addUser(Me.me);

           
            
        }
        /// <summary>
        /// 初始化客户端
        /// </summary>
        public void InitClient()
        {
            //初始化客户端对象
            Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //创建连接终结点
            IPAddress ipa = IPAddress.Parse("127.0.0.1");
            IPEndPoint ipe = new IPEndPoint(ipa, part);

            try
            {
                //连接服务器端
                Client.Connect(ipe);

                Thread receive = new Thread(new ParameterizedThreadStart(Receive_c));
                //Thread send = new Thread(new ParameterizedThreadStart(Send_c));
                //send.Start(Client);
                receive.Start(Client);

                //上传客户端基本信息
                Client.Send(Encoding.UTF8.GetBytes(NetInf.GetFormat(Me.id, new parameter("type", "Commond"), new parameter("Commond", "getInf"))));

                SendLog("上传基本信息");



                //SendLog(Client.LocalEndPoint.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("服务器未开启或不存在，连接失败!");

                //销毁房间
                delRoom(part);

                //通过委托销毁窗体
                CloseForm(TalkBox);

            }

        }

        /// <summary>
        /// 销毁房间
        /// </summary>
        /// <param name="part"></param>
        private void delRoom(int part)
        {
            //打开连接
            Conn.Open();

            //删除空房间
            string sql = string.Format("delete from room where rnum=" + part);

            MySqlCommand cmd = new MySqlCommand(sql, Conn.Conn);

            //执行操作
            int reslt = cmd.ExecuteNonQuery();

            //关闭连接
            Conn.Close();
        }

        /// <summary>
        /// 客户端接收消息
        /// </summary>
        /// <param name="ClientObj"></param>
        private void Receive_c(Object ClientObj)
        {
            Socket client = ClientObj as Socket;
            while (isRuning)
            {
                byte[] buffer = new byte[255];//缓冲区
                int recv = 0;
                NetInf Inf;
                string data = "";

                try
                {
                    recv = client.Receive(buffer);//接收数据
                    Inf = NetInf.GetKeys(Encoding.UTF8.GetString(buffer).Substring(0, recv));
                    data = Inf.msg;
                    //data = data.Substring(0, recv);//缓存区转换为字符串后，长度为缓存区大小，因此会多出很多空格，取出空格
                    //SendLog("接收到：" + Inf.ToString());
                    dealCommond_c(Inf);

                    //SendLog(Encoding.UTF8.GetString(buffer).Substring(0, recv));

                }
                catch (Exception)
                {
                    Console.WriteLine("服务器关闭！");
                    client.Close();
                    break;
                }
            }
        }

        /// <summary>
        /// 客户端处理接收到的网络信息
        /// </summary>
        /// <param name="inf"></param>
        void dealCommond_c(NetInf inf)
        {
            //存储信息
            string msg = inf.msg;

            //获取信息类型
            netMsgType netType = inf.GetNetMsgType();

            //指令处理
            switch (netType)
            {
                //如果是接收到消息，那么处理消息
                case netMsgType.Msg:
                    //客户端收到消息直接上屏
                    SendTalkMsg(inf.ToString());
                    //SendLog("收到广播信息:" + inf.ToString());

                    break;
                case netMsgType.Commond:
                    //如果是命令，那么处理命令:
                    netCommondType commondType = inf.GetnetCommondType();
                    //("参数类型：" + commondType.ToString());
                    switch (commondType)
                    {
                        case netCommondType.getInf:
                            //向服务器发送基本信息
                            //Client.Send(Encoding.UTF8.GetBytes(NetInf.GetFormat(Me.id, new parameter("type", "Commond"), new parameter("Commond", "getInf"))));
                            //SendLog("上传基本信息");
                            break;
                        case netCommondType.update:
                            //SendLog("收到广播信息:" + inf.ToString());
                            //先清空库
                            users.Clear();

                            //接收用户信息
                            users.loadUsers(inf);

                            //更新界面
                            updateList();

                            //更新各人信息
                            User user = users.getUser(Client.LocalEndPoint.ToString());

                            if (user == null)
                            {
                                SendLog("客户端更新个人信息失败：" + Client.LocalEndPoint.ToString());
                                break;
                            }

                            Me.me = user;


                            break;
                        case netCommondType.rename:
                            //更名用户昵称
                            Client.Send(Encoding.UTF8.GetBytes(NetInf.GetFormat(Me.id, new parameter("type", "Commond"), new parameter("Commond", "rename"))));

                            break;
                        case netCommondType.Exit:
                            //退出
                            Client.Close();
                            break;
                        case netCommondType.NULL:
                            //丢弃空信息
                            break;
                        default:
                            break;
                    }

                    break;
                case netMsgType.NULL:
                    //信息出错，暂时丢弃不处理
                    break;
                default:
                    break;
            }




            //如果有直接指令，那么处理直接指令
            //if (inf.parameter.ContainsKey("Commond"))
            //{
            //    string Commond = inf.parameter["Commond"];//获取指令

            //    if (Commond == "GetInf")
            //    {

            //    }
            //}
        }


        private  void Send_c(Object ClientObj)
        {

            Socket client = ClientObj as Socket;
            byte[] buffer = null;//缓冲区
            string data = "";
            while (isRuning)
            {
                try
                {
                    Console.WriteLine("给服务器发送消息：");
                    data = Console.ReadLine();//持续读入数据
                    buffer = Encoding.UTF8.GetBytes(data);//存入缓存区
                    if (data != "Exit")
                    {
                        client.Send(buffer);
                        Console.WriteLine("发送消息：{0}", data);
                    }
                    else
                    {
                        Console.WriteLine("退出客户端！");
                        client.Close();
                        break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("服务器关闭！");
                    client.Close();
                    break;
                }
            }
        }




        private void ListenClient(Object ServerObj)
        {
            //用于监听客户端连接的线程

            Socket server = ServerObj as Socket;
            Socket Client = null;//客户端
            //Dictionary<string, string> Clientinf = new Dictionary<string, string>();//用于接收Client传过来的各个参数
            while (isRuning)
            {
                try
                {
                    Client = server.Accept();
                    if (Client != null)//接收到用户连接
                    {
                        //AddClien("匿名用户", Client);//注册客户端,默认名称为匿名用户
                        //Console.WriteLine("接收到用户连接：{0}", Client.RemoteEndPoint.ToString());//打印连接客户端的终结点

                        //添加用户并更新界面,暂时默认为蓝队
                        addUser(Client.RemoteEndPoint.ToString(), "匿名用户", false, Client);

                        //SendLog(string.Format("接收到用户连接：{0}", Client.RemoteEndPoint.ToString()));//打印连接客户端的终结点


                        //Client.Send(Encoding.UTF8.GetBytes(NetInf.GetFormat("",new parameter("type","Commond"),new parameter("Commond","getInf"))));//尝试获取客户端信息，改为默认由客户端发送
                        Client = null;//等待下一次连接
                    }
                }
                catch (Exception)
                {

                    delRoom(part);
                }
            }


        }

        private void Receive_s(object ClientObj)
        {
            Socket client = ClientObj as Socket;

            //获取对应的用户对象
            User user = users.getUser(client.RemoteEndPoint.ToString());
            if (user == null)
            {
                SendLog("查找用户失败");
            }



            while (isRuning)
            {
                //NetInf Clientinf = new NetInf();//用于接收Client传过来的各个参数，及其信息本体
                //byte[] buffer = new byte[255];//缓冲区，255大小
                //int Recv = 0;
                //string date = "";

                byte[] buffer = new byte[255];//缓冲区
                int recv = 0;
                NetInf Inf;
                string data = "";

                try
                {
                    recv = client.Receive(buffer);//接收消息，并获取消息的字节长度
                    Inf = NetInf.GetKeys(Encoding.UTF8.GetString(buffer).Substring(0, recv));
                    data = Inf.msg;

                    //获取信息类型
                    netMsgType netType = Inf.GetNetMsgType();

                    if (recv > 0)//接收到消息
                    {

                        switch (netType)
                        {
                            //如果是接收到消息，那么处理消息
                            case netMsgType.Msg:
                                //服务器端收到消息直接转发
                                sendNetMsg(Inf.ToString());
                                break;
                            case netMsgType.Commond:
                                //如果是命令，那么处理命令:
                                netCommondType commondType = Inf.GetnetCommondType();
                                //("参数类型：" + commondType.ToString());
                                switch (commondType)
                                {
                                    case netCommondType.getInf:

                                        //更新客户端基本信息
                                        addUser(user.getIpEndPoint(), Inf.msg);
                                        // SendLog("更新基本信息并发回信息给客户端");


                                        string temp = NetInf.GetFormat("", new parameter("type", "Commond"), new parameter("Commond", "update")) + ";" + users.writeUsers();
                                        //SendLog(temp);


                                        //发送用户信息
                                        sendUpadate();


                                        break;
                                    case netCommondType.rename:
                                        //更名用户昵称

                                        break;
                                    case netCommondType.Exit:
                                        //退出
                                        client.Close();
                                        break;
                                    case netCommondType.NULL:
                                        break;
                                    default:
                                        break;
                                }

                                break;
                            case netMsgType.NULL:
                                //信息出错，暂时丢弃不处理
                                break;
                            default:
                                break;
                        }

                    }
                }
                catch (Exception)
                {
                    SendLog("用户:" + UiInf.toUiString(user) + "关闭连接！");

                    //更新服务器库与UI界面
                    delUser(UiInf.toUiString(user,false,true));

                    //更新客户端
                    sendUpadate();

                    client.Close();
                    break;
                }
            }
        }

        /// <summary>
        /// 生成网络信息原文, 格式： 信息内容?type=Msg;name=终结点|昵称|队伍|房主或玩家;time=时间
        /// </summary>
        /// <param name="content"></param>
        public string getNetMsg(string content)
        {
            string temp = string.Format("{0}?type=Msg;name={1};time={2}",content,UiInf.toUiString(Me.me,true,true), DateTime.Now.ToString());
            return temp;
        }


        public void sendUpadate(string to = "all")
        {
            foreach (var item in users.Users)
            {
                if (to == "all")
                {
                    if (!item.isHost)
                    {
                        if (item.getClientObj() == null)
                        {
                            SendLog("尝试发送更新信息时，客户端对象不存在！："+item.getIpEndPoint());
                            return;
                        }
                        item.getClientObj().Send(Encoding.UTF8.GetBytes(
                            NetInf.GetFormat("", new parameter("type", "Commond"), new parameter("Commond", "update")) + ";" + users.writeUsers()
                            ));
                    }
                }
                else
                {
                    if (item.getIpEndPoint() == to)
                    {
                        if (item.getClientObj() == null || item.isHost)
                        {
                            SendLog("尝试发送更新信息时，客户端对象不存在 或 对象为主机！");
                            return;
                        }
                        item.getClientObj().Send(Encoding.UTF8.GetBytes(
                            NetInf.GetFormat("", new parameter("type", "Commond"), new parameter("Commond", "update")) + ";" + users.writeUsers()
                            ));

                    }
                }
            }
            
        }

        /// <summary>
        /// 在网络上给指定对象发送消息，默认给所有人发送
        /// </summary>
        /// <param name="content">字符串原文，格式： 信息内容?type=Msg;name=终结点|昵称|队伍|房主或玩家;time=时间</param>
        /// <param name="host">发送源，默认为主机</param>
        /// <param name="to">目标，默认为 所有人</param>
        public void sendNetMsg(string content, string to = "all")
        {
            foreach (var item in users.Users)
            {
                //如果需要给所有人发送
                if (to == "all")
                {
                    //如果当前要给服务器端发送消息，那么直接给UI发送消息
                    if (item.getIsHost())
                    {
                        SendTalkMsg(content);
                    }
                    else
                    {
                        //否则全部转发给客户端
                        if (item.getClientObj() == null)
                        {
                            SendLog("客户端对象为空，客户端信息 "+ UiInf.toUiString(item));
                            return;
                        }
                        item.getClientObj().Send(Encoding.UTF8.GetBytes(content));
                        //SendLog("内存长度：" + Encoding.UTF8.GetBytes(content).Length);
                    }
                }
                else
                {
                    //否则给指定用户发送
                    if (item.getIpEndPoint() == to)
                    {
                        //发送网络消息
                        item.getClientObj().Send(Encoding.UTF8.GetBytes(content));

                        break;
                    }

                }



            }
        }


        private delegate void SendMsgdlg(TextBox msgbox, object concent);//使用委托，线程外修改控件
        private delegate void VoidDlg(Control obj);//委托，用于执行普通事件

        public void CloseForm(Control obj)
        {
            if (obj.InvokeRequired)
            {
                VoidDlg close = CloseForm;
                obj.Invoke(close,obj);
            }
            else
            {
                Close();
            }
        }

        /// <summary>
        /// 给指定文本框发送消息
        /// </summary>
        /// <param name="msgbox">文本框</param>
        /// <param name="concent">消息</param>
        public void SendMsg(TextBox msgbox, object concent)
        {
            if (msgbox.InvokeRequired)
            {
                SendMsgdlg send = SendMsg;
                msgbox.Invoke(send, msgbox, concent);
            }
            else
            {
                msgbox.Text += concent as string;
            }
        }

        public void SendLog(string log)
        {
            printLog(LogBox, log);
        }

        /// <summary>
        /// 根据字符串原文在窗口UI上发送信息
        /// </summary>
        /// <param name="inf">字符串原文，格式： 信息内容?type=Msg;name=终结点|昵称|队伍|房主或玩家;time=时间</param>
        public void SendTalkMsg(string inf)
        {
            printTalk(TalkBox,inf);
        }


        /// <summary>
        /// 利用委托在窗体UI生成消息
        /// </summary>
        /// <param name="textbox"></param>
        /// <param name="log">字符串原文，格式： 信息内容?type=Msg;name=终结点|昵称|队伍|房主或玩家;time=时间</param>
        public void printTalk(TextBox textbox, object log)
        {
            if (textbox.InvokeRequired)
            {
                SendMsgdlg senlog = printTalk;
                textbox.Invoke(senlog, textbox, log);
            }
            else
            {
                //拆分信息
                NetInf inf = NetInf.GetKeys(log as string);

                //防止信息出错
                if (inf.parameters.Count !=3)
                {
                    SendLog("发送信息出错！");
                    return;
                }

                //防止重复调用
                // "\r\n" + DateTime.Now.ToString() + "：" + "\r\n" + log as string + "\r\n";

                string templog = string.Format("\r\n{0}：\r\n{1}：\r\n{2}\r\n", inf.parameters[1].value, inf.parameters[2].value
                    ,inf.msg);

                SendMsg(textbox, templog);

                textbox.SelectionLength = textbox.Text.Length;
                textbox.ScrollToCaret();
            }
        }

        /// <summary>
        /// 利用委托在窗体UI生成日志
        /// </summary>
        /// <param name="log">日志内容</param>
        public void printLog(TextBox textbox,object log)
        { 
            if (textbox.InvokeRequired)
            {
                SendMsgdlg senlog = printLog;
                textbox.Invoke(senlog, textbox, log);
            }
            else
            {
                //防止重复调用
                string templog = "\r\n" + DateTime.Now.ToString() + "：" + "\r\n" + log as string + "\r\n";
                SendMsg(textbox, templog);

                //更新光标位置
                textbox.SelectionLength = textbox.Text.Length;
                textbox.ScrollToCaret();
            }
        }

        /// <summary>
        /// 用于使用委托再主线程向用户列表写入值
        /// </summary>
        /// <param name="UserList"></param>
        /// <param name="UserName"></param>
        private delegate void Listdlg(ListBox UserList, object UserName);

        /// <summary>
        /// 清空指定列表框
        /// </summary>
        /// <param name="UserList"></param>
        /// <param name="UserName"></param>
        public void ClearList(ListBox UserList, object UserName = null)
        {
            if (UserList.InvokeRequired)
            {
                Listdlg userlist = ClearList;
                UserList.Invoke(userlist, UserList, UserName);
            }
            else
            {
                UserList.Items.Clear();
            }
        }

        /// <summary>
        /// 向指定列表写入值
        /// </summary>
        /// <param name="UserList">需要写入列表值的列表框</param>
        /// <param name="UserName">用户昵称, 格式 ： 昵称|终结点</param>
        public void Addlist(ListBox UserList,object UserName)
        {
            if (UserList.InvokeRequired)
            {
                Listdlg userlist = Addlist;
                UserList.Invoke(userlist, UserList, UserName);
            }
            else
            {
                UserList.Items.Add(UserName as string);//显示在窗口上的名称格式: 名称:终结点
                //SendLog("用户：" + UserName as string + " 登录");
            }

        }


        /// <summary>
        /// 在指定列表中删除指定名称项目
        /// </summary>
        /// <param name="UserList"></param>
        /// <param name="UserName">用户昵称, 格式 ： 昵称|终结点</param>
        public void Dellist(ListBox UserList, object UserName)
        {
            if (UserList.InvokeRequired)
            {
                Listdlg userlist = Dellist;
                UserList.Invoke(userlist, UserList, UserName);
            }
            else
            {
                //查找指定对象，并删除
                for (int i = 0; i < UserList.Items.Count; i++)
                {
                    if (UserList.Items[i].ToString() == UserName as string)
                    {
                        UserList.Items.RemoveAt(i);
                        break;
                    }
                }

            }
        }


        /// <summary>
        /// 根据用户信息，更新窗体队伍列表
        /// </summary>
        void updateList()
        {
            //首先删除
            ClearList(redList);
            ClearList(blueList);

            //再清空用户库
            //users.Clear();

            //redList.Items.Clear();
            //blueList.Items.Clear();

            foreach (var item in users.getTeam(teamType.red))
            {
                //redList.Items.Add(UiInf.toUiString(item));
                Addlist(redList, UiInf.toUiString(item,false,true));
            }

            foreach (var item in users.getTeam(teamType.blue))
            {
                Addlist(blueList, UiInf.toUiString(item, false, true));
            }

        }
        
        /// <summary>
        /// 通过用户对象添加用户，同时更新界面
        /// </summary>
        /// <param name="user"></param>
        void addUser(User user)
        {
            if (user == null)
            {
                return;
            }

            //MessageBox.Show("最大人数:" + users.maxNum + "当前人数：" + users.count());


            //如果不存在用户，那么添加用户并添加监听事件
            if (!users.contains(user))
            {
                if (users.canJoin())
                {
                    //添加或更新用户库
                    users.addUser(user);

                    //更新界面
                    updateList();
                    //如果传入了客户端对象 且 自身为服务器，则监听
                    if (user.clientObj != null && Me.me.isHost)
                    {
                        Thread receivethread = new Thread(new ParameterizedThreadStart(Receive_s));
                        receivethread.IsBackground = true;//设为后台线程，防止进程残留
                        receivethread.Start(user.clientObj);
                        SendLog(string.Format("接收到用户连接：{0}|{1}", user.name, user.ipEndPoint));//打印连接客户端的终结点
                    }

                }
                else
                {
                    MessageBox.Show("房间以满！");
                }
            }
            else//否则仅更新
            {
                //添加或更新用户库
                users.addUser(user);

                //更新界面
                updateList();
            }
        }

        /// <summary>
        /// 添加用户的同时更新界面
        /// </summary>
        void addUser(string ipEndPoint, string name = "匿名用户", bool isHost = false, Socket clientObj = null)
        {
            //MessageBox.Show("最大人数:" +users.maxNum + "当前人数：" + users.count());


            //如果不存在用户，那么添加用户并添加监听事件
            if (!users.contains(ipEndPoint))
            {
                if (users.canJoin())
                {
                    //添加或更新用户库
                    users.addUser(ipEndPoint, users.getTeam(), name, isHost, clientObj);

                    //更新界面
                    updateList();
                    //如果传入了客户端对象 且 自身为服务器，则监听
                    if (clientObj != null && Me.me.isHost)
                    {
                        Thread receivethread = new Thread(new ParameterizedThreadStart(Receive_s));
                        receivethread.IsBackground = true;//设为后台线程，防止进程残留
                        receivethread.Start(clientObj);
                        SendLog(string.Format("接收到用户连接：{0}|{1}", name, ipEndPoint));//打印连接客户端的终结点
                    }
                }
                else
                {
                    MessageBox.Show("房间以满！");
                }

            }
            else//否则仅更新
            {
                //添加或更新用户库
                users.addUser(ipEndPoint, users.getTeam(), name, isHost, clientObj);

                //更新界面
                updateList();
            }
        }


        /// <summary>
        /// 删除用户的同时更新界面
        /// </summary>
        /// <param name="UserName">这里是用户名是UI用户格式，即： 终结点|用户名|其他 </param>
        void delUser(string UserName)
        {
            //获取用户
            User temp = users.getUser(UiInf.getipEndPoint(UserName));

            if (temp == null)
            {
                SendLog("尝试删除时未找到对象："+ UiInf.getipEndPoint(UserName));
                return;
            }

            //关闭连接
            //temp.getClientObj().Close();

            //关闭连接后会触发UI删除，并更新UI
            delUserUI(UserName);

            //删除用户库
            users.delUser(temp);
            }


        /// <summary>
        /// 仅仅从UI界面中删除用户对象
        /// </summary>
        /// <param name="UserName">这里是用户名是UI用户格式，即： 用户名|终结点 </param>
        void delUserUI(string UserName)
        {
            //尝试从蓝队删除
            Dellist(blueList,UserName);

            //尝试从红队删除
            Dellist(redList, UserName);
        }






























        public RoomForm(int maxNum,int part,bool isHost = true)
        {
            //传入最大人数和端口号还要用户类型
            this.maxNum = maxNum;
            this.part = part;
            this.isHost = isHost;

            InitializeComponent();
        }


        private void RoomForm_Load(object sender, EventArgs e)
        {
            //设置聊天空内容为只读，防止修改
            TalkBox.ReadOnly = true;

            //防止日志框内容被修改
            LogBox.ReadOnly = true;

            //创建用户库
            users = new UserInf(maxNum);

            //初始化
            if (isHost)
            {
                InitServer();
            }
            else
            {
                InitClient();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void UserMsgBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //sendNetMsg(getNetMsg(SendBox.Text));
            //SendLog(getNetMsg(SendBox.Text));

            //SendTalkMsg(getNetMsg(SendBox.Text));

            if (Me.me.isHost)
            {
                //服务器向所有用户发送消息
                sendNetMsg(getNetMsg(SendBox.Text));
            }
            else
            {
                //客户端单方面服务器端发送消息
                Client.Send(Encoding.UTF8.GetBytes(getNetMsg(SendBox.Text)));
            }
        }

        private void TalkBox_TextChanged(object sender, EventArgs e)
        {
            
        }


        //关闭时，销毁房间
        private void RoomForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            isRuning = false;

            if (isHost)
            {
                Server.Close();
                //delRoom(part);
            }
            else
            {
                Client.Close();
            }
        }
    }



}
