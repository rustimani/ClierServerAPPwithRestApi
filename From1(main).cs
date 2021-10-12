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

namespace client
{
    public partial class Form1 : Form
    {
        string adl = "admin";
        string adp = "ziga1488";
        user n1;
        StreamReader sr;
        StreamWriter sw;
        List<film> lf = new List<film>();
        List<tag> lt = new List<tag>();
        List<f_t> lf_t = new List<f_t>();
        List<u_f> lu_f = new List<u_f>();
        public void connect()
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 26666);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

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

        public void getallfilms(string h)
        {

            string[] X = h.Split(';');
            film n = new film();
            if (X[0] != null)
            {
                n.id = Convert.ToInt16(X[0]);
                n.name = X[1];
                n.year = X[2];
                n.about = X[3];
                lf.Add(n);
            }


        }
        public void getalltag(string h)
        {
            string[] X = h.Split(';');
            tag n = new tag();
            n.id = Convert.ToInt16(X[0]);
            n.name = X[1];
            lt.Add(n);
        }
        public void getf_t(string h)
        {
            string[] X = h.Split(';');
            f_t n = new f_t();
            n.id_f = Convert.ToInt16(X[0]);
            n.id_t = Convert.ToInt16(X[1]);
            lf_t.Add(n);
        }
        public void getu_f(string h)
        {
            string[] X = h.Split(';');
            u_f n = new u_f();
            n.id_u = Convert.ToInt16(X[0]);
            n.id_f = Convert.ToInt16(X[1]);
            lu_f.Add(n);
        }

        public Form1(user m, StreamReader sr1, StreamWriter sw1)
        {
            InitializeComponent();
            n1 = m;
            label1.Text = n1.logi;
            sr = sr1; sw = sw1;
            if (n1.logi == adl && n1.pass == adp)
            {
                button5.Enabled = false; button5.Hide();
            }
            else
            {
                textBox1.Enabled = false; textBox1.Hide();
                button6.Enabled = false; button8.Enabled = false; button6.Hide(); button8.Hide();
                button7.Enabled = false; button10.Enabled = false; button11.Enabled = false;
                button7.Hide(); button10.Hide(); button11.Hide();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            comboBox1.Items.Clear(); comboBox1.SelectedItem = null;

            comboBox2.Items.Clear(); comboBox2.SelectedItem = null; textBox1.Clear();
            lf.Clear(); lt.Clear(); lf_t.Clear(); lu_f.Clear();
            //connect();
            sw.WriteLine(n1.logi + ";" + n1.pass + ";" + '1');
            sw.Flush();
            string h;
            while (true)
            {
                h = sr.ReadLine();
                if (h != "все")
                {
                    if (h != "")
                        getallfilms(h);
                    else continue;
                }
                else break;

            }
            h = "";
            sw.WriteLine(n1.logi + ";" + n1.pass + ";" + '4');
            sw.Flush();
            while (true)
            {
                h = sr.ReadLine();

                if (h != "все")
                {
                    if (h != "")
                        getalltag(h);
                    else continue;
                }
                else break;
            }
            h = "";
            sw.WriteLine(n1.logi + ";" + n1.pass + ";" + '5');
            sw.Flush();
            while (true)
            {
                h = sr.ReadLine();
                if (h != "все")
                {
                    if (h != "")
                        getf_t(h);
                    else continue;
                }
                else break;
            }
            h = "";
            sw.WriteLine(n1.logi + ";" + n1.pass + ";" + '6' + ";" + n1.id.ToString());
            sw.Flush();
            while (true)
            {
                h = sr.ReadLine();
                if (h != "все")
                {
                    if (h != "")
                        getu_f(h);
                    else continue;
                }
                else break;
            }
            for (int i = 0; i <= lf.IndexOf(lf.Last()); i++)
            {
                listBox1.Items.Add(lf[i].name);
                comboBox1.Items.Add(lf[i].year);
            }

            for (int i = 0; i <= lt.IndexOf(lt.Last()); i++)
                comboBox2.Items.Add(lt[i].name);


        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null && textBox1.Text != null)
            {
                for (int i = 0; i <= lt.IndexOf(lt.Last()); i++)
                {
                    if (lt[i].name == comboBox2.SelectedItem.ToString())
                    {
                        sw.WriteLine(n1.logi + ";" + n1.pass + ";" + "999" + ";" + "3" + ";" + lt[i].id.ToString() + ";" + textBox1.Text);
                        sw.Flush();
                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                for (int i = 0; i <= lt.IndexOf(lt.Last()); i++)
                {
                    if (lt[i].name == comboBox2.SelectedItem.ToString())
                    {
                        sw.WriteLine(n1.logi + ";" + n1.pass + ";" + "999" + ";" + "1" + ";" + lt[i].id.ToString());
                        sw.Flush();
                    }
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            bool k = false;
            if (textBox1.Text != null)
            {
                for (int i = 0; i <= lt.IndexOf(lt.Last()); i++)
                {
                    if (textBox1.Text == lt[i].name)
                    {
                        k = true;
                    }
                }
            }
            if (!k)
            {
                sw.WriteLine(n1.logi + ";" + n1.pass + ";" + "999" + ";" + "2" + ";" + textBox1.Text);
                sw.Flush();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            add A = new add(sr, sw, n1, lt);
            A.Show();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                for (int i = 0; i <= lf.IndexOf(lf.Last()); i++)
                {
                    if (listBox1.SelectedItem.ToString() == lf[i].name)
                    {
                        sw.WriteLine(n1.logi + ";" + n1.pass + ";" + "666" + ";" + "1" + ";" + lf[i].id.ToString());
                        sw.Flush();
                        return;
                    }
                }
            }
            // button1_Click(sender,e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (lu_f.Count != 0)
            {
                for (int i = 0; i <= lu_f.IndexOf(lu_f.Last()); i++)
                {
                    for (int j = 0; j <= lf.IndexOf(lf.Last()); j++)
                    {
                        if (lu_f[i].id_f == lf[j].id)
                            listBox1.Items.Add(lf[j].name);
                    }
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                listBox1.Items.Clear();
                for (int i = 0; i <= lf.IndexOf(lf.Last()); i++)
                {
                    if (lf[i].year == comboBox1.SelectedItem.ToString())
                        listBox1.Items.Add(lf[i].name);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                listBox1.Items.Clear(); int p = 0;
                for (int i = 0; i <= lt.IndexOf(lt.Last()); i++)
                {
                    if (lt[i].name == comboBox2.SelectedItem.ToString())
                    {
                        for (int j = 0; j <= lf_t.IndexOf(lf_t.Last()); j++)
                        {
                            if (lf_t[j].id_t == lt[i].id)
                            {
                                for (int i1 = p; i1 <= lf.IndexOf(lf.Last()); i1++)
                                {
                                    if (lf[i1].id == lf_t[j].id_f)
                                    { listBox1.Items.Add(lf[i1].name); }
                                }
                            }
                        }

                    }
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            if (listBox1.SelectedItem != null)
            {
                for (int i = 0; i <= lf.IndexOf(lf.Last()); i++)
                {
                    if (lf[i].name == listBox1.SelectedItem.ToString())
                    {
                        if (n1.logi == adl && n1.pass == adp)
                        {
                            changef kk = new changef(lf[i], lf_t, sw, sr, n1, lt);
                            kk.Show();
                        }
                        else
                        {
                            Form3 kk = new Form3(lf[i], lu_f, sw, sr, n1);
                            kk.Show();
                        }
                    }
                }
            }

        }
    }
}
