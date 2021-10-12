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
    public partial class Form3 : Form
    {
        user x1 = new user();
        StreamReader sr;
        StreamWriter sw;
        film c = new film();
        List<u_f> l = new List<u_f>();
        public Form3(film x, List<u_f> k, StreamWriter sw1, StreamReader sr1, user n)
        {
            x1 = n;
            sr = sr1; sw = sw1;
            c.id = x.id;
            c.name = x.name;
            c.year = x.year;
            c.about = x.about;
            l = k;
            InitializeComponent();
            textBox1.Text = x.name.ToString();
            textBox2.Text = x.year;
            richTextBox1.Text = x.about;
            //if (n.logi == "admin" && n.pass == "ziga1488")
            //{
            //    button3.Enabled = true; button1.Enabled = false; button2.Enabled = false;
            //}
            //else
            //{
            button1.Enabled = true;
            button2.Enabled = false;// button3.Enabled = false;

            if (l.Count != 0)
            {
                for (int i = 0; i <= l.IndexOf(l.Last()); i++)
                {
                    if (l[i].id_f == c.id)
                    {
                        button1.Enabled = false;
                        button2.Enabled = true;
                    }
                }
            }
            // }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            sw.WriteLine(x1.logi + ";" + x1.pass + ";" + "777" + ";" + "1" + ";" + x1.id.ToString() + ";" + c.id.ToString());
            sw.Flush();
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sw.WriteLine(x1.logi + ";" + x1.pass + ";" + "777" + ";" + "2" + ";" + x1.id.ToString() + ";" + c.id.ToString());
            sw.Flush();
            button2.Enabled = true;
            button1.Enabled = false;
        }

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    sw.WriteLine(x1.logi + ";" + x1.pass + ";" + "667" + ";" + c.id.ToString() + ";" + textBox1.Text+";"+textBox2.Text+";"+richTextBox1.Text);
        //    sw.Flush();
        //    this.Close();
        //}
    }
}
