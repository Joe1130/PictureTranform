using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
  public   class socktHelper
    {
        //接收边长的数据,要求其打头的4字节代表有效数据的长度
        public static byte[] ReceiveVarData(Socket s)
        {
            if (s == null)
                throw new ArgumentNullException("S");
            int total = 0;  //已经接收的字节数
            int recv;
            //接收4个字节，得到“消息长度”
            byte[] datasize = new byte[4];
            recv = s.Receive(datasize, 0, 4, 0);
            int size = BitConverter.ToInt32(datasize,0);
            //按消息长度接收数据
            int dataleft = size;
            byte[] data = new byte[size];
            while(total<size)
            {
                recv = s.Receive(data,total,dataleft,0);
                if(recv==0)
                {
                    break;
                }
                total += recv;
                dataleft -= recv;
            }
            return data;
        }

        //发送边长数据，将数据长度附加于数据开头
        public static int SendVarData(Socket s,byte[] data )
        {
            int total = 0;
            int size = data.Length; //要发送的消息
            int dataleft = size;//剩余的消息
            int sent;
            //将消息长度（int类型)的，转为字节数组
            byte[] datasize = new byte[4];
            datasize = BitConverter.GetBytes(size);
            //将消息长度发送出去
            sent = s.Send(datasize);
            //发送消息剩余的部分
            while(total<size)
            {
                sent = s.Send(data,total,dataleft,SocketFlags.None);
                total += sent;
                dataleft -= sent;
            }

            return total;
        }
    }
}
