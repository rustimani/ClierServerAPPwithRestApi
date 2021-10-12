using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System;
using System.IO;
using System.Security.Cryptography;

namespace client
{
    public partial class Form2 : Form
    {
        StreamReader sr;
        StreamWriter sw;
        user n1 = new user();
        Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public Form2()
        {
            InitializeComponent();

        }

        public void userlog(string h)
        {
            if (h != "")
            {
                if (h == "ошибка") { MessageBox.Show("4et neverno vveli"); return; }
                string[] K = h.Split(';');
                n1.id = Convert.ToInt16(K[0]);
                n1.logi = K[1];
                n1.pass = textBox2.Text;
                //server.Close();
                Form1 m = new Form1(n1, sr, sw);
                m.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("нет такого юзера");
            }
        }
        public void connect()
        {
            int u = Convert.ToInt16(textBox4.Text);
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse(textBox3.Text), u);


            try
            {
                server.Connect(ip);
            }
            catch (SocketException e)
            {
                Console.WriteLine("Unable to connect to server.");
                return;
            }
            NetworkStream ns = new NetworkStream(server);
            sr = new StreamReader(ns);
            sw = new StreamWriter(ns);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            connect();
            sw.WriteLine("2");

            sw.Flush();
            sw.WriteLine(textBox1.Text); sw.Flush();
            sw.WriteLine(textBox2.Text);
            sw.Flush();
            string h = sr.ReadLine();
            userlog(h);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connect();
            sw.WriteLine("3");
            sw.Flush();
            sw.WriteLine(textBox2.Text);
            sw.Flush();
            sw.WriteLine(textBox1.Text);
            sw.Flush();
            string h = sr.ReadLine();
            if (h == "1")
            {
                MessageBox.Show("юзер добавлен");
            }
            else
            {
                MessageBox.Show(h);
            }
        }
    }
}

