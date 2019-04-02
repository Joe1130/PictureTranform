using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using BaseObject;

namespace BL
{
    public class Common
    {
        private const int BufferSize = 1024;
        public static int port=GetAvailablePort();
        public static string adress=getLocalIpAdress().ToString();
        //在静态构造函数中初始化
       // static List<int> ports = new List<int>();

        //序列化
        public static byte[] SerializePicInfo(PicInfo img)
        {
            if (img == null)
                return null;
            MemoryStream memory = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(memory, img);
            return memory.ToArray();
        }

        //反序列化
        public static PicInfo DeserializePicInfo(byte[] buffer)
        {
            if (buffer.Length == 0)
                return null;
            MemoryStream memory = new MemoryStream(buffer);
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(memory) as PicInfo;
        }
        //开启服务端监听的方法
        public static string OpenListening()
        {
            byte[] data = new byte[BufferSize];
            //获取本机地址
            IPAddress localAdress = getLocalIpAdress();
            // int  LocalPort = GetAvailablePort();
            int LocalPort = 9999;
            //创建IP终结点
            IPEndPoint ipep = new IPEndPoint(localAdress, LocalPort);
            while(true)
            {
                //创建套接字，使用TCP协议
                Socket newSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                using (newSocket)
                {
                    //绑定
                    newSocket.Bind(ipep);
                    //开始监听
                    newSocket.Listen(1);
                    //如果有客户端连接
                    Socket client = newSocket.Accept();
                    IPEndPoint clientep = (IPEndPoint)client.RemoteEndPoint;
                    string StringSendByClient = "";
                    while(true)
                    {
                        byte[] receivedData = socktHelper.ReceiveVarData(client);
                        StringSendByClient = Encoding.UTF8.GetString(receivedData);
                        //if (StringSendByClient == "exit")
                        //{
                        //    client.Close();
                        //    break;
                        //}
                     
                        return StringSendByClient;
                    }
                    
                }
            }
        }


        //向服务端进行发送的方法
        public static void OpenSend(string ipAdress,string port,byte[] picInfo)
        {
            //创建套接字，使用TCP协议
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(ipAdress), Convert.ToInt32( port));
           
                //打开连接
                server.Connect(iPEndPoint);
                //发送数据
                socktHelper.SendVarData(server,picInfo);
                //关闭连接
                server.Shutdown(SocketShutdown.Both);
                server.Close();
         
        }
       
        //获得可用端口
        public static int GetAvailablePort()
        {
            int port = 0;
            int beginPort = 8081;
            int maxPort = 10000;
            bool flag = true;
            //这个ports放在外面就会报Null引用异常。
             List<int> ports = new List<int>();
            for (int i = beginPort; i < maxPort; i++)
            {
                flag = true;
                IPGlobalProperties iPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
                //这里得到的port口不全,加了个list，增加些TCP的port口
                TcpConnectionInformation[] tcpConnectionInformations = iPGlobalProperties.GetActiveTcpConnections();
                IPEndPoint[] ipsTcp = iPGlobalProperties.GetActiveTcpListeners();
                //tcp的都加入ports链表中
                foreach (TcpConnectionInformation tcp in tcpConnectionInformations)
                {
                   
                    ports.Add(tcp.LocalEndPoint.Port);
                }
                foreach(IPEndPoint ep in ipsTcp)
                {
                    ports.Add(ep.Port);
                }
                //查找当前已有的TCP连接，确保当前端口未被占用
                foreach(int p in ports )
                {
                    if(p==i)
                    {
                        flag = false;
                        break;
                    }
                }
                if(flag==true)
                {
                    port = i;
                    break;
                }
            }
            if(port==0)
            {
                return 9999;
            }
            return port;
        }

        //获取本地可用的IP地址
        public static IPAddress getLocalIpAdress()
        {
            IPHostEntry iPHost = Dns.GetHostEntry(Dns.GetHostName());
            for(int i=0;i<iPHost.AddressList.Length;i++)
            {
                if(iPHost.AddressList[i].AddressFamily==AddressFamily.InterNetwork)
                {
                    return iPHost.AddressList[i];
                }
            }
            IPAddress iP = new IPAddress(Convert.ToInt64( "127.0.0.1"));
            return iP;
        }

        //得到Image对象，具体是先保存到内存，然后存到流中，然偶后

    }
}
