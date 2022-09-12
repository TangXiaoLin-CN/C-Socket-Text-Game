using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;//引入Socket类
using System.Net;
using System.Threading;

namespace test1
{
    /// <summary>
    /// 用于传输至网络的指令类型
    /// </summary>
    public enum netMsgType
    {
        /// <summary>
        /// 普通的消息发送
        /// </summary>
        Msg,

        /// <summary>
        /// 执行命令
        /// </summary>
        Commond,

        /// <summary>
        /// 出错
        /// </summary>
        NULL
    }

    /// <summary>
    /// 网络指令类型
    /// </summary>
    public enum netCommondType
    {
        /// <summary>
        /// 获取客户端基本信息
        /// </summary>
        getInf,

        /// <summary>
        /// 更新客户端信息
        /// </summary>
        update,

        /// <summary>
        /// 重命名
        /// </summary>
        rename,

        /// <summary>
        /// 退出
        /// </summary>
        Exit,

        /// <summary>
        /// 出错
        /// </summary>
        NULL 
    }


    /// <summary>
    /// 队伍类型
    /// </summary>
    public enum teamType
    {
        /// <summary>
        /// 红队
        /// </summary>
        red = 0,

        /// <summary>
        /// 蓝队
        /// </summary>
        blue = 1
    }

    public struct parameter
    {
        /// <summary>
        /// 参数
        /// </summary>
        public string key;

        /// <summary>
        /// 值
        /// </summary>
        public string value;


        public parameter(string key,string value)
        {
            this.key = key;
            this.value = value;
        }
    }


    /// <summary>
    /// 传送的网络信息，可以承载很多参数信息。 网路信息格式： 信息体?type=信息类型;参数=参数;  ，第一个参数固定是信息类型枚举。
    /// </summary>
    public class NetInf
    {
        /// <summary>
        /// 信息内容
        /// </summary>
        public string msg;

        /// <summary>
        /// 信息所附带的参数集合
        /// </summary>
        public List<parameter> parameters;

        /// <summary>
        /// 用于获取接收到的信息附带的参数列表以及信息本体
        /// </summary>
        /// <param name="text">参数文本 ，格式  xxx?aa=aa;bb=bb;cc=cc  类似于网络Get传输</param>
        /// <returns>信息附带的参数列表</returns>
        public static NetInf GetKeys(string text)
        {
            NetInf tempInf = new NetInf();

            tempInf.parameters = new List<parameter>();
            string temp = "";
            string[] i = null;//用于第一次分割文本
            temp = text.Trim();
            i = temp.Split('?');
            if (i != null && i.Length >= 2)
            {
                tempInf.msg = i[0];//获取信息本体
                string[] ii = i[1].Split(';');//分割成参数
                if (ii != null)
                {
                    foreach (var item in ii)//遍历并分割参数
                    {
                        string[] iii = item.Split('=');
                        if (iii != null && iii.Length == 2)
                        {
                            string key = iii[0];
                            string value = iii[1];

                            key = key.Replace("\n", "");
                            key = key.Replace("\t", "");
                            key = key.Replace("\r", "");
                            key = key.Replace("\0", "");

                            value = value.Replace("\n", "");
                            value = value.Replace("\t", "");
                            value = value.Replace("\r", "");
                            value = value.Replace("\0", "");

                            tempInf.parameters.Add(new parameter(key, value));
                        }
                        else
                        {
                            Console.WriteLine("尝试获取客户端参数时出错0x2");
                            return null;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("尝试获取客户端参数时出错0x1");
                    return null;
                }
            }
            else
            {
                Console.WriteLine("尝试获取客户端参数时出错0x0");
                return null;
            }

            return tempInf;
        }

        /// <summary>
        /// 获取用于发送的带参数网络信息
        /// </summary>
        /// <param name="msg">信息</param>
        /// <param name="parameters">指定参数</param>
        /// <returns></returns>
        public static string GetFormat(string msg, params parameter[] parameters)
        {
            string inf = msg + "?";

            foreach (var item in parameters)
            {
                inf += item.key + "=" + item.value + ";";
            }

            inf = inf.Substring(0,inf.Length-1);

            return inf;
        }


        /// <summary>
        /// 根据字符串获取对应的网络指令枚举
        /// </summary>
        /// <param name="netmsg"></param>
        /// <returns></returns>
        public static netMsgType GetNetMsgType(string netmsg)
        {

            foreach (netMsgType msgtype in Enum.GetValues(typeof(netMsgType)))
            {
                if (netmsg == msgtype.ToString())
                {
                    return msgtype;
                }
            }

            return netMsgType.NULL;
        }


        /// <summary>
        /// 根据字符串获取对应的网络命令类型枚举
        /// </summary>
        /// <param name="netmsg"></param>
        /// <returns></returns>
        public static netCommondType GetnetCommondType(string netcommond)
        {

            foreach (netCommondType commondtype in Enum.GetValues(typeof(netCommondType)))
            {
                if (netcommond == commondtype.ToString())
                {
                    return commondtype;
                }
            }   

            return netCommondType.NULL;
        }




        /// <summary>
        /// 直接获取对应的网络指令枚举
        /// </summary>
        /// <param name="netmsg"></param>
        /// <returns></returns>
        public netMsgType GetNetMsgType()
        {
            if (parameters == null || parameters.Count == 0)
            {
                return netMsgType.NULL;
            }

            foreach (netMsgType msgtype in Enum.GetValues(typeof(netMsgType)))
            {
                if (parameters[0].value == msgtype.ToString())
                {
                    return msgtype;
                }
            }

            return netMsgType.NULL;
        }


        /// <summary>
        /// 直接获取对应的网络命令类型枚举
        /// </summary>
        /// <param name="netmsg"></param>
        /// <returns></returns>
        public  netCommondType GetnetCommondType()
        {
            if (parameters == null || parameters.Count <2 )
            {
                return netCommondType.NULL;
            }

            foreach (netCommondType commondtype in Enum.GetValues(typeof(netCommondType)))
            {
                if (parameters[1].value == commondtype.ToString())
                {
                    return commondtype;
                }
            }

            return netCommondType.NULL;
        }

        /// <summary>
        /// 将网络信息还原为字符串原文
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string temp = msg + "?";

            foreach (var item in parameters)
            {
                temp += item.key + "=" + item.value + ";";
            }

            //去除结尾分号
            temp = temp.Substring(0,temp.Length - 1);

            return temp;
        }
    }



    /// <summary>
    /// 用户类，用于标识一个网络用户
    /// </summary>
    public class User
    {
        /// <summary>
        /// 终结点字段，主键，必填
        /// </summary>
        public string ipEndPoint;

        /// <summary>
        /// 队伍字段,必填
        /// </summary>
        public teamType team;

        /// <summary>
        /// 用户名称字段，必填，默认为匿名用户
        /// </summary>
        public string name;

        /// <summary>
        /// 是否为房主，必填
        /// </summary>
        public bool isHost;

        /// <summary>
        /// 客户端对象，选填，仅服务器端记录
        /// </summary>
        public Socket clientObj;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="ipEndPoint"></param>
        /// <param name="team"></param>
        /// <param name="name"></param>
        /// <param name="isHost"></param>
        /// <param name="clientObj"></param>
        public User(string ipEndPoint, teamType team, string name = "匿名用户", bool isHost = false, Socket clientObj = null)
        {
            this.ipEndPoint = ipEndPoint;
            this.team = team;
            this.name = name;
            this.isHost = isHost;
            this.clientObj = clientObj;
        }


        /// <summary>
        /// 允许通过参数文本创建对象 ，格式  终结点 = 队伍类型(0或1)&名字&是否主机(0或1 1代表真)
        /// </summary>
        /// <param name="ipEndPoint">终结点</param>
        /// <param name="userInf">参数信息文本 ，格式队伍类型(0或1)&名字&是否主机(0或1 1代表真) </param>
        public User(string ipEndPoint, string userInf)
        {
            this.ipEndPoint = ipEndPoint;

            //分割
            string[] i = userInf.Split('&');

            if (i.Length != 3)
            {
                Console.WriteLine("尝试通过参数文本创建用户对象时出错！");
                return;
            }

            if (i[0] == "0")
            {
                this.team = teamType.red;
            }
            else
            {
                if (i[0] == "1")
                {
                    this.team = teamType.blue;
                }
                else
                {
                    Console.WriteLine("接收到的队伍参数出错，应为0 或1 ，值为：" + i[0]);
                    return;
                }
            }

            this.name = i[1];


            if (i[2] == "0")
            {
                this.isHost = false;
            }
            else
            {
                if (i[2] == "1")
                {
                    this.isHost = true;
                }
                else
                {
                    Console.WriteLine("接收到的主机标识参数出错，应为0 或1 ，值为：" + i[2]);
                    return;
                }
            }

        }



        public string getIpEndPoint()
        {
            return ipEndPoint;
        }

        public void setIpEndPoint(string ipEndPoint)
        {
            this.ipEndPoint = ipEndPoint;
        }

        public teamType getTeam()
        {
            return team;
        }

        public void setTeam(teamType team)
        {
            this.team = team;
        }

        public string getName()
        {
            return name;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public bool getIsHost()
        {
            return isHost;
        }

        public void setIsHost(bool isHost)
        {
            this.isHost = isHost;
        }

        public Socket getClientObj()
        {
            return clientObj;
        }

        public void setClientObj(Socket clientObj)
        {
            this.clientObj = clientObj;
        }


        /// <summary>
        /// 将User对象以参数文本打印 格式  终结点 = 队伍类型(0或1)&名字&是否主机(0或1 1代表真)
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string inf = string.Format("{0}={1}&{2}&{3}", ipEndPoint.ToString(), ((int)team).ToString(), name, Convert.ToInt32(isHost).ToString());
            return inf;
        }


    }

    /// <summary>
    /// 用户信息集合，由若干个User类组成，并通过提供一系列处理方法
    /// </summary>
    public class UserInf
    {
        //使用列表作为用户存储逻辑数据库，因为列表带索引，方便顺序输出。
        public List<User> Users = new List<User>();

        /// <summary>
        /// 游戏的最大人数
        /// </summary>
        public int maxNum;

        /// <summary>
        /// 初始化用户库
        /// </summary>
        /// <param name="maxNum">用户库的最大人数</param>
        public UserInf(int maxNum)
        {
            this.maxNum = maxNum;
        }

        /// <summary>
        /// 用户是否可以加入
        /// </summary>
        /// <returns></returns>
        public bool canJoin()
        {
            //如果还有空位则可以加入
            if (count()<maxNum)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 申请一个队伍,默认加入红队，否则蓝队
        /// </summary>
        /// <returns></returns>
        public teamType getTeam()
        {
            if (getTeam(teamType.blue).Count < maxNum / 2)
            {
                return teamType.red;
            }
            return teamType.blue;
        }


        /// <summary>
        /// 根据终结点查找对应用户
        /// </summary>
        /// <param name="ipEndPoint"></param>
        /// <returns>找到则返回User,否则返回NULL</returns>
        public User getUser(string ipEndPoint)
        {
            //User temp = null;

            foreach (var item in Users)
            {
                if (item.getIpEndPoint() == ipEndPoint)
                {
                    return item;
                }
            }

            return null;
        }


        /// <summary>
        /// 获取指定队伍的所有用户
        /// </summary>
        /// <param name="team"></param>
        /// <returns></returns>
        public List<User> getTeam(teamType team)
        {
            List<User> temp = new List<User>();

            foreach (var item in Users)
            {
                if (item.getTeam() == team)
                {
                    temp.Add(item);
                }
            }

            return temp;
        }


        /// <summary>
        /// 获取所有客户端用户
        /// </summary>
        /// <returns></returns>
        public List<User> getGuest()
        {
            List<User> temp = new List<User>();

            foreach (var item in Users)
            {
                if (!item.getIsHost())
                {
                    temp.Add(item);
                }
            }

            return temp;
        }

        /// <summary>
        /// 获取服务器对象
        /// </summary>
        /// <returns></returns>
        public User getHost()
        {
            //List<User> temp = new List<User>();

            foreach (var item in Users)
            {
                if (item.getIsHost())
                {
                    return item;
                }
            }

            return null;
        }


        /// <summary>
        /// 根据用户对象判断某个用户是否已经存在
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool contains(User user)
        {
            if (user == null)
            {
                Console.WriteLine("尝试检查用户是否存在时，对象为空，请检查！");
                return false;
            }

            foreach (var item in Users)
            {
                if (item.getIpEndPoint() == user.getIpEndPoint())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 根据终结点判断某个用户是否已经存在
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool contains(string ipEndPoint)
        {
            if (getUser(ipEndPoint) != null)
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// 更新指定用户的信息
        /// </summary>
        /// <param name="ipEndPoint"></param>
        /// <param name="team"></param>
        /// <param name="name"></param>
        /// <param name="isHost"></param>
        /// <param name="clientObj"></param>
        public void updateUser(string ipEndPoint, teamType team, string name = "匿名用户", bool isHost = false, Socket clientObj = null)
        {
            //查找用户
            User tempuser = getUser(ipEndPoint);

            if (tempuser == null)
            {
                Console.WriteLine("更新指定终结点的用户信息");
                return;
            }

            //更新信息
            if (clientObj !=null)
            {
                tempuser.setClientObj(clientObj);
            }

            tempuser.setName(name);
            tempuser.setTeam(team);


            //如果要更换服务器
            if (isHost)
            {
                setHost(ipEndPoint);
            }
        }

        /// <summary>
        /// 通过用户对象添加用户，如果已经存在则更新用户
        /// </summary>
        /// <param name="user"></param>
        public void addUser(User user)
        {
            //如果已经存在，则更新
            if (getUser(user.ipEndPoint) != null)
            {
                updateUser(user.ipEndPoint, user.team, user.name, user.isHost, user.clientObj);
                return;
            }

            //否则添加新节点
            Users.Add(new User(user.ipEndPoint, user.team, user.name,user.isHost, user.clientObj));

            //如果是主机节点，那么设置
            if (user.isHost)
            {
                setHost(user.ipEndPoint);
            }
        }

        /// <summary>
        /// 通过基本信息添加用户，如果用户已经存在则更新用户
        /// </summary>
        /// <param name="ipEndPoint"></param>
        /// <param name="team"></param>
        /// <param name="name"></param>
        /// <param name="isHost"></param>
        /// <param name="clientObj"></param>
        public void addUser(string ipEndPoint, teamType team, string name = "匿名用户", bool isHost = false, Socket clientObj = null)
        {
            // User tempuser = getUser(ipEndPoint);

            //如果已经存在，则更新
            if (getUser(ipEndPoint) != null)
            {
                updateUser(ipEndPoint, team, name, isHost, clientObj);
                return;
            }


            //否则添加新节点
            Users.Add(new User(ipEndPoint, team, name, isHost, clientObj));

            //如果是主机节点，那么设置
            if (isHost)
            {
                setHost(ipEndPoint);
            }


        }

        /// <summary>
        /// 通过用户对象删除用户
        /// </summary>
        /// <param name="user"></param>
        public void delUser(User user)
        {
            //如果已经存在，则更新
            User temp = getUser(user.ipEndPoint);

            if (temp != null)
            {
                Users.Remove(temp);
            }

        }

        /// <summary>
        /// 通过终结点删除用户
        /// </summary>
        /// <param name="user"></param>
        public void delUser(string ipEndPoint)
        {
            //如果已经存在，则更新
            User temp = getUser(ipEndPoint);

            if (temp != null)
            {
                Users.Remove(temp);
            }

        }



        /// <summary>
        /// 将指定节点设为服务器
        /// </summary>
        /// <param name="ipEndPoint"></param>
        public void setHost(string ipEndPoint)
        {
            //主机仅有一个，因此其他节点全部设为客户端
            foreach (var item in Users)
            {
                if (item.getIpEndPoint() == ipEndPoint)
                {
                    item.setIsHost(true);
                }
                else
                {
                    item.setIsHost(false);
                }
            }
        }

        /// <summary>
        /// 返回用户数量
        /// </summary>
        /// <returns></returns>
        public int count()
        {
            return Users.Count;
        }


        /// <summary>
        /// 清空用户库
        /// </summary>
        public void Clear()
        {
            Users.Clear();
        }


        /// <summary>
        /// 从参数信息中读取用户信息，并添加
        /// </summary>
        /// <param name="inf">参数文本 ，格式 ?type=Commond;Commond=update;终结点 = 队伍类型(0或1)&名字&是否主机(0或1 1代表真)</param>
        /// /// <param name="cover">是否需要覆盖原表，默认为覆盖 </param>
        public void loadUsers(NetInf inf, bool cover = true)
        {
            NetInf temp = inf;

            if (temp == null || temp.parameters.Count < 3)
            {
                Console.WriteLine("尝试读入用户信息时，信息错误，请检查！");
                return;
            }

            //复制一份
            List<parameter> userinf = new List<parameter>(temp.parameters);


            //前两个是命令识别符，后面都是对象
            for (int i = 2; i < userinf.Count; i++)
            {
                Users.Add(new User(userinf[i].key, userinf[i].value));
            }

            //foreach (var item in userinf)
            //{
            //    Users.Add(new User(item.key, item.value));
            //}


        }

        public string writeUsers()
        {
            string inf = "";
            foreach (var item in Users)
            {
                inf += item.ToString() + ";";
            }
            inf = inf.Substring(0, inf.Length - 1);//去除结尾分号，防止读入失败
            return inf;
        }
    }

    /// <summary>
    /// 用于与UI进行交互
    /// </summary>
    class UiInf
    {
        /// <summary>
        /// 输出UI显示格式用户对象，将用户对象以 格式： 终结点| 昵称[|队伍] [|玩家 或 房主] 输出，用于UI显示
        /// </summary>
        /// <param name="user">需要输出的对象</param>
        /// <param name="team">是否需要输出队伍</param>
        /// <param name="host">是否需要房主信息</param>
        /// <returns></returns>
        public static string toUiString(User user,bool team = false,bool host = false)
        {
            if (user == null)
            {
                return "";
            }

            string inf = "";

            if (user != null)
            {
                inf = user.ipEndPoint + "|" + user.name ;
            }

            if (team)
            {
                switch (user.team)
                {
                    case teamType.red:
                        inf += "|" + "[红队]";
                        break;
                    case teamType.blue:
                        inf += "|" + "[蓝队]";
                        break;
                    default:
                        inf += "|" + "[红队]";
                        break;
                }
            }

            if (host)
            {
                if (user.isHost)
                {
                    inf += "|" + "[房主]";
                }
                else
                {
                    inf += "|" + "[玩家]";
                }
            }

            return inf;
        }


        /// <summary>
        /// 根据UI显示格式用户对象读取终结点
        /// </summary>
        /// <param name="inf"></param>
        /// <returns>读取失败返回空字符</returns>
        public static string getipEndPoint(string inf)
        {
            string[] i = inf.Split('|');

            if (i.Length < 2)
            {
                return "";
            }

            return i[0];
        }

    }
}
