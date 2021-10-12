using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace client
{
    public class film
    {
        public int id;
        public string name;
        public string year;
        public string about;
    }
    public class user
    {
        public int id;
        public string logi;
        public string pass;
    }
    public class tag
    {
        public int id;
        public string name;

    }
    public class f_t
    {
        public int id_f;
        public int id_t;
    }
    public class u_f
    {
        public int id_u;
        public int id_f;
    }
    static class Program
    {

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());
        }
    }
}
