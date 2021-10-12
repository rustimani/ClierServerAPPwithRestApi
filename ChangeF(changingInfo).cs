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
    public partial class changef : Form
    {

        user x1 = new user();
        StreamReader sr;
        StreamWriter sw;
        film c = new film();
        List<f_t> l = new List<f_t>();
        List<tag> t1 = new List<tag>();
        public changef(film x, List<f_t> k, StreamWriter sw1, StreamReader sr1, user n, List<tag> t)
        {
            InitializeComponent();
            x1 = n;
            sr = sr1; sw = sw1;
            c.id = x.id;
            c.name = x.name;
            c.year = x.year;
            c.about = x.about;
            l = k;
            t1 = t;
            textBox1.Text = c.name.ToString();
            textBox2.Text = c.year;
            richTextBox1.Text = c.about;
            for (int i = 0; i <= t1.IndexOf(t1.Last()); i++)
            {
                checkedListBox1.Items.Add(t1[i].name);
            }

            for (int i = 0; i <= l.IndexOf(l.Last()); i++)
            {
                if (l[i].id_f == c.id)
                {
                    for (int j = 0; j <= t1.IndexOf(t1.Last()); j++)
                    {
                        if (l[i].id_t == t1[j].id)
                            checkedListBox1.SetItemChecked(j, true);
                    }
                }
            }




        }

        private void button1_Click(object sender, EventArgs e)
        {
            string u = "";
            if (checkedListBox1.CheckedItems.Count == 0) { MessageBox.Show("выберите хотя бы один тэг"); return; }
            else
            {
                for (int i = 0; i <= t1.IndexOf(t1.Last()); i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        u += (";" + t1[i].id);
                    }
                }
            }
            sw.WriteLine(x1.logi + ";" + x1.pass + ";" + "666" + ";" + "3" + ";" + c.id + ";" + textBox1.Text + ";" + textBox2.Text + ";" + richTextBox1.Text + u);
            sw.Flush();
            this.Close();
        }
    }
}
