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
    public partial class add : Form
    {
        user x1 = new user();
        StreamReader sr;
        StreamWriter sw;
        film c = new film();
        List<tag> l = new List<tag>();
        public add(StreamReader sr1, StreamWriter sw1, user n1, List<tag> all)
        {
            InitializeComponent();
            sr = sr1; sw = sw1; x1 = n1;
            l = all;
            for (int i = 0; i <= l.IndexOf(l.Last()); i++)
            {
                checkedListBox1.Items.Add(l[i].name);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string u = "";
            if (checkedListBox1.CheckedItems.Count == 0) { MessageBox.Show("выберите хотя бы один тэг"); return; }
            else
            {
                for (int i = 0; i <= l.IndexOf(l.Last()); i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        u += (";" + l[i].id);
                    }
                }
            }
            sw.WriteLine(x1.logi + ";" + x1.pass + ";" + "666" + ";" + "2" + ";" + textBox1.Text + ";" + textBox2.Text + ";" + richTextBox1.Text + u);
            sw.Flush();
            this.Close();
        }
    }
}
