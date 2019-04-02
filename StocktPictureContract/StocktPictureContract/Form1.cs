using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseObject;
using BL;
using System.Net;
using System.Net.Sockets;
using System.Drawing.Imaging;

namespace StocktPictureContract
{
    public partial class Form1 : Form
    {
        private PicInfo picInfo;
        private string data;
        private Thread thread;
        private const int BufferSize = 1024;
        Socket client;
        string StringSendByClient = "";
        public Form1()
        {

            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Form1_Close);
            //先把界面加载完成在进行init(),因为里面有监听有死循环
            init();
        }
        private void init()
        {
            try
            {
                thread = new Thread(() =>
                {
                    try {
                        data = OpenListening();
                    } catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
                //设置为后台线程，和主线程同时关闭，不设真的很炸了
                thread.IsBackground = true;
                thread.Start();
                string s = Common.adress;
                string m = Common.port.ToString();
                labShow.Text = "在" + Common.adress + "地址，" + Common.port + "口监听";
            }
            catch (Exception e)
            {
                thread.Abort();
            }

        }


        private void btnChoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\\Users\SinevaHZC\Pictures\Camera Roll";
            openFileDialog.Filter = "图片文件(*.jpg)|*.jpg|*.jpge|*.png|所有文件(*.*)|*.*";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string adress = openFileDialog.FileName;
                System.Drawing.Image image = System.Drawing.Image.FromFile(adress);
                Image img = GetImage(image);
                using (MemoryStream memory = new MemoryStream(img.image))
                {
                    PicBoxShow.Image = System.Drawing.Image.FromStream(memory);
                }
                txtAdress.Text = adress;
                picInfo = new PicInfo(img, adress);
            }
        }
        //得到BaseObject中的Image对象
        public Image GetImage(System.Drawing.Image image)
        {

            ImageFormat format = image.RawFormat;
            Image img;
            using (MemoryStream ms = new MemoryStream())
            {
                if (format.Equals(ImageFormat.Jpeg))
                {
                    image.Save(ms, ImageFormat.Jpeg);
                } else if (format.Equals(ImageFormat.Png))
                {
                    image.Save(ms, ImageFormat.Png);
                }
                byte[] buffer = new byte[ms.Length];
                //Image.save()会改变MemoryStream的position,需要重新Seek到Begin
                ms.Seek(0, SeekOrigin.Begin);
                ms.Read(buffer, 0, buffer.Length);
                img = new Image(buffer);
            }
            return img;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string ip = txtIP.Text;
                string port = txtPort.Text;
                byte[] buffer = Common.SerializePicInfo(picInfo);
                Common.OpenSend(ip, port, buffer);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Form1_Close(object sender, EventArgs e)
        {
            //不管了，不abort也不考虑卡死了（以后做完再考虑是否卡死吧），反正后台线程和主线程一起关闭
            //client.Close();
            //thread.Abort();
        }

        //开启服务端监听的方法
        public string OpenListening()
        {
            byte[] data = new byte[BufferSize];
            //获取本机地址
            IPAddress localAdress = Common.getLocalIpAdress();
            int LocalPort = Common.GetAvailablePort();
            //创建IP终结点
            IPEndPoint ipep = new IPEndPoint(localAdress, LocalPort);
            while (true)
            {
                //创建套接字，使用TCP协议
                Socket newSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                using (newSocket)
                {
                    //绑定
                    newSocket.Bind(ipep);
                    //开始监听
                    newSocket.Listen(2);
                    //如果有客户端连接
                    client = newSocket.Accept();
                   // IPEndPoint clientep = (IPEndPoint)client.RemoteEndPoint;

                   // while (true)
                    //{
                        byte[] receivedData = socktHelper.ReceiveVarData(client);
                        // StringSendByClient = Encoding.UTF8.GetString(receivedData);
                        Action del=() =>{
                            PicInfo pic = Common.DeserializePicInfo(receivedData);
                            MemoryStream stream = new MemoryStream(pic.Picture.image);
                            PicBoxShow.Image = System.Drawing.Image.FromStream(stream);
                            txtAdress.Text = pic.Information;
                        };
                        //跨线程显示UI
                        this.Invoke(del);

                   // }

                }
            }
        }

       

    }
}

