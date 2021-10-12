using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Data.SqlClient;
using System.Security.Cryptography;


namespace server1
{
    class Program
    {
        static StreamReader sr;
        static StreamWriter sw;

        static public void alltag()
        {
            SqlConnection cnn = new SqlConnection(@"Data Source = TULENISOSUT\TIMA666; Initial Catalog = pps12; Integrated Security = True");
            string res = "";
            cnn.Open();
            SqlCommand ff1 = new SqlCommand("select * from [tag]", cnn);
            SqlDataReader dr1 = ff1.ExecuteReader();
            while (dr1.Read())
            {
                res = dr1[0] + ";" + dr1[1];
                sw.WriteLine(res);
                sw.Flush();
            }
            sw.WriteLine("все");
            sw.Flush();

        }
        static public void f_t()
        {

            SqlConnection cnn = new SqlConnection(@"Data Source = TULENISOSUT\TIMA666; Initial Catalog = pps12; Integrated Security = True");
            string res = "";
            cnn.Open();
            SqlCommand ff11 = new SqlCommand("select * from [f_t]", cnn);
            SqlDataReader dr11 = ff11.ExecuteReader();
            while (dr11.Read())
            {
                res = dr11[1] + ";" + dr11[2];
                sw.WriteLine(res);
                sw.Flush();
            }
            sw.WriteLine("все");
            sw.Flush();
        }
        static public void u_f(string a)
        {
            SqlConnection cnn = new SqlConnection(@"Data Source = TULENISOSUT\TIMA666; Initial Catalog = pps12; Integrated Security = True");
            string res = "";
            cnn.Open();

            SqlCommand ff12 = new SqlCommand("select * from [fav] where [id_user]=@p1", cnn);
            ff12.Parameters.Add("@p1", System.Data.SqlDbType.Int);
            ff12.Parameters["@p1"].Value = Convert.ToInt16(a);
            SqlDataReader dr12 = ff12.ExecuteReader();
            while (dr12.Read())
            {
                res = dr12[1] + ";" + dr12[2];
                sw.WriteLine(res);
                sw.Flush();
            }
            sw.WriteLine("все");
            sw.Flush();
        }
        static public void allfilms(string a)
        {
            SqlConnection cnn = new SqlConnection(@"Data Source = TULENISOSUT\TIMA666; Initial Catalog = pps12; Integrated Security = True");
            string res = "";
            cnn.Open();
            SqlCommand ff = new SqlCommand("select * from [film]", cnn);
            SqlDataReader dr = ff.ExecuteReader();

            while (dr.Read())
            {
                res = dr[0] + ";" + dr[1] + ";" + dr[2] + ";" + dr[3];
                sw.WriteLine(res);
                sw.Flush();
            }
            sw.WriteLine("все");
            sw.Flush();


        }
        static public int checkl(string a, string b)
        {
            SqlConnection cnn = new SqlConnection(@"Data Source = TULENISOSUT\TIMA666; Initial Catalog = pps12; Integrated Security = True");
            string res = "";
            cnn.Open();


            SqlCommand cmd = new SqlCommand("select * from [user] where [login]=@p1 and [pass]=@p2", cnn);


            cmd.Parameters.Add("@p1", System.Data.SqlDbType.VarChar);
            cmd.Parameters["@p1"].Value = a;
            cmd.Parameters.Add("@p2", System.Data.SqlDbType.VarChar);
            cmd.Parameters["@p2"].Value = hash(b);
            string j = "";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                return 1;
            }
            return 0;
        }
        static public void logi()
        {
            try
            {
                SqlConnection cnn = new SqlConnection(@"Data Source = TULENISOSUT\TIMA666; Initial Catalog = pps12; Integrated Security = True");
                string res = "";
                cnn.Open();
                res = sr.ReadLine();
                string res1 = sr.ReadLine();
                SqlCommand cmd = new SqlCommand("select * from [user] where [login]=@p1 and [pass]=@p2", cnn);


                cmd.Parameters.Add("@p1", System.Data.SqlDbType.VarChar);
                cmd.Parameters["@p1"].Value = res;
                cmd.Parameters.Add("@p2", System.Data.SqlDbType.VarChar);
                cmd.Parameters["@p2"].Value = hash(res1);
                string j = "";
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    j = dr[0] + ";" + dr[1];
                    sw.WriteLine(j);
                    sw.Flush();
                }

            }
            catch (Exception e) {; }


        }

        static public void newuser()
        {
            SqlConnection cnn = new SqlConnection(@"Data Source = TULENISOSUT\TIMA666; Initial Catalog = pps12; Integrated Security = True");
            string res = "";
            cnn.Open();
            res = sr.ReadLine();
            string res1 = sr.ReadLine();
            SqlCommand cmd = new SqlCommand("insert into [user] values(@p1,@p2)", cnn);


            cmd.Parameters.Add("@p1", System.Data.SqlDbType.VarChar);
            cmd.Parameters["@p1"].Value = res;
            cmd.Parameters.Add("@p2", System.Data.SqlDbType.VarChar);
            cmd.Parameters["@p2"].Value = hash(res1);
            try
            {
                int p = cmd.ExecuteNonQuery();
                sw.WriteLine(p.ToString());
                sw.Flush();
            }
            catch (Exception e)
            {
                sw.WriteLine(e.ToString());
                sw.Flush();
            }
        }
        static public void del(int a, int b)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(@"Data Source = TULENISOSUT\TIMA666; Initial Catalog = pps12; Integrated Security = True");
                //string res = "";
                cnn.Open();
                // res = sr.ReadLine();
                //string res1 = sr.ReadLine();
                SqlCommand cmd = new SqlCommand("delete from [fav] where [id_user]=@p1 and [id_film]=@p2", cnn);


                cmd.Parameters.Add("@p1", System.Data.SqlDbType.Int);
                cmd.Parameters["@p1"].Value = a;
                cmd.Parameters.Add("@p2", System.Data.SqlDbType.Int);
                cmd.Parameters["@p2"].Value = b;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e) {; }
        }
        static public void ins(int a, int b)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(@"Data Source = TULENISOSUT\TIMA666; Initial Catalog = pps12; Integrated Security = True");
                //string res = "";
                cnn.Open();
                // res = sr.ReadLine();
                //string res1 = sr.ReadLine();
                SqlCommand cmd = new SqlCommand("insert into [fav] values(@p1,@p2)", cnn);


                cmd.Parameters.Add("@p1", System.Data.SqlDbType.Int);
                cmd.Parameters["@p1"].Value = a;
                cmd.Parameters.Add("@p2", System.Data.SqlDbType.Int);
                cmd.Parameters["@p2"].Value = b;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e) {; }
        }

        static public void instag(int a, int b)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(@"Data Source = TULENISOSUT\TIMA666; Initial Catalog = pps12; Integrated Security = True");
                //string res = "";
                cnn.Open();
                // res = sr.ReadLine();
                //string res1 = sr.ReadLine();
                SqlCommand cmd = new SqlCommand("insert into [f_t] values(@p1,@p2)", cnn);


                cmd.Parameters.Add("@p1", System.Data.SqlDbType.Int);
                cmd.Parameters["@p1"].Value = a;
                cmd.Parameters.Add("@p2", System.Data.SqlDbType.Int);
                cmd.Parameters["@p2"].Value = b;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e) {; }
        }
        static public void changetag(int a, string b)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(@"Data Source = TULENISOSUT\TIMA666; Initial Catalog = pps12; Integrated Security = True");
                //string res = "";
                cnn.Open();
                // res = sr.ReadLine();
                //string res1 = sr.ReadLine();
                SqlCommand cmd = new SqlCommand("update [tag] set [tag].[tag_name]=@p1 where [tag].[id_tag]=@p2", cnn);


                cmd.Parameters.Add("@p1", System.Data.SqlDbType.VarChar);
                cmd.Parameters["@p1"].Value = b;
                cmd.Parameters.Add("@p2", System.Data.SqlDbType.Int);
                cmd.Parameters["@p2"].Value = a;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e) {; }
        }

        static public void deltag(int a)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(@"Data Source = TULENISOSUT\TIMA666; Initial Catalog = pps12; Integrated Security = True");
                //string res = "";
                cnn.Open();
                // res = sr.ReadLine();
                //string res1 = sr.ReadLine();
                SqlCommand cmd = new SqlCommand("delete from [tag] where [tag].[id_tag]=@p1", cnn);


                cmd.Parameters.Add("@p1", System.Data.SqlDbType.Int);
                cmd.Parameters["@p1"].Value = a;

                cmd.ExecuteNonQuery();
            }
            catch (Exception e) {; }
        }

        static public void deltag1(int a)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(@"Data Source = TULENISOSUT\TIMA666; Initial Catalog = pps12; Integrated Security = True");
                //string res = "";
                cnn.Open();
                // res = sr.ReadLine();
                //string res1 = sr.ReadLine();
                SqlCommand cmd = new SqlCommand("delete from [f_t] where [id_film]=@p1", cnn);


                cmd.Parameters.Add("@p1", System.Data.SqlDbType.Int);
                cmd.Parameters["@p1"].Value = a;

                cmd.ExecuteNonQuery();
            }
            catch (Exception e) {; }
        }

        static public void addtag(string a)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(@"Data Source = TULENISOSUT\TIMA666; Initial Catalog = pps12; Integrated Security = True");
                //string res = "";
                cnn.Open();
                // res = sr.ReadLine();
                //string res1 = sr.ReadLine();
                SqlCommand cmd = new SqlCommand("insert into [tag] values(@p1)", cnn);


                cmd.Parameters.Add("@p1", System.Data.SqlDbType.VarChar);
                cmd.Parameters["@p1"].Value = a;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e) {; }
        }

        static public int addfilm(string a, string b, string c)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(@"Data Source = TULENISOSUT\TIMA666; Initial Catalog = pps12; Integrated Security = True");
                //string res = "";
                cnn.Open();
                // res = sr.ReadLine();
                //string res1 = sr.ReadLine();
                SqlCommand cmd = new SqlCommand("insert into [film] ([film_name],[film_date],[film_about]) values(@p1,@p2,@p3)", cnn);


                cmd.Parameters.Add("@p1", System.Data.SqlDbType.VarChar);
                cmd.Parameters["@p1"].Value = a;
                cmd.Parameters.Add("@p2", System.Data.SqlDbType.VarChar);
                cmd.Parameters["@p2"].Value = b;
                cmd.Parameters.Add("@p3", System.Data.SqlDbType.VarChar);
                cmd.Parameters["@p3"].Value = c;
                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand("select * from [film] where [film_name]=@p7", cnn);
                cmd1.Parameters.Add("@p7", System.Data.SqlDbType.VarChar);
                cmd1.Parameters["@p7"].Value = a;
                string j = "";
                SqlDataReader dr77 = cmd1.ExecuteReader();
                while (dr77.Read()) j = dr77[0].ToString();
                return Convert.ToInt16(j);
            }
            catch (Exception e) { return 0; }
        }


        static public void delfilm(int a)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(@"Data Source = TULENISOSUT\TIMA666; Initial Catalog = pps12; Integrated Security = True");
                //string res = "";
                cnn.Open();
                // res = sr.ReadLine();
                //string res1 = sr.ReadLine();
                SqlCommand cmd = new SqlCommand("delete from [film] where [film].[id_film]=@p1", cnn);


                cmd.Parameters.Add("@p1", System.Data.SqlDbType.Int);
                cmd.Parameters["@p1"].Value = a;

                cmd.ExecuteNonQuery();
            }
            catch (Exception e) {; }
        }
        static public void changefilm(int a, string b, string c, string d)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(@"Data Source = TULENISOSUT\TIMA666; Initial Catalog = pps12; Integrated Security = True");
                //string res = "";
                cnn.Open();
                // res = sr.ReadLine();
                //string res1 = sr.ReadLine();
                SqlCommand cmd2 = new SqlCommand("delete from [f_t] where [id_film]=@p4", cnn);
                cmd2.ExecuteNonQuery();

                SqlCommand cmd = new SqlCommand("update into [film] set values(@p1,@p2,@p3) where [id_film]=@p4", cnn);


                cmd.Parameters.Add("@p1", System.Data.SqlDbType.VarChar);
                cmd.Parameters["@p1"].Value = b;
                cmd.Parameters.Add("@p2", System.Data.SqlDbType.VarChar);
                cmd.Parameters["@p2"].Value = c;
                cmd.Parameters.Add("@p3", System.Data.SqlDbType.VarChar);
                cmd.Parameters["@p3"].Value = d;
                cmd.Parameters.Add("@p3", System.Data.SqlDbType.Int);
                cmd.Parameters["@p3"].Value = a;

                cmd.ExecuteNonQuery();
            }
            catch (Exception e) {; }
        }

        static private string hash(string text)
        {
            byte[] data = Encoding.Default.GetBytes(text);
            var result = new SHA256Managed().ComputeHash(data);
            return BitConverter.ToString(result).Replace("-", "").ToLower();
        }


        static void Main()
        {


            string data;
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 26666);

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(ip);



            socket.Listen(10);
            Socket client = socket.Accept();
            IPEndPoint newclient = (IPEndPoint)client.RemoteEndPoint;
            Console.WriteLine("Connected with {0} at port {1}", newclient.Address, newclient.Port);

            NetworkStream ns = new NetworkStream(client);
            sr = new StreamReader(ns);
            sw = new StreamWriter(ns);
            while (true)
            {
                data = sr.ReadLine();
                string[] data1 = data.Split(';');
                try
                {
                    if (checkl(data1[0], data1[1]) == 1)
                    {
                        if (data1[2] == "1")
                        {
                            allfilms(data[0].ToString());
                        }
                        else if (data1[2] == "4") alltag();
                        else if (data1[2] == "5") f_t();
                        else if (data1[2] == "6") u_f(data1[3].ToString());

                        else if (data1[2] == "777")
                        {
                            if (data1[3] == "1") del(Convert.ToInt16(data1[4]), Convert.ToInt16(data1[5]));
                            else if (data1[3] == "2") ins(Convert.ToInt16(data1[4]), Convert.ToInt16(data1[5]));
                        }



                        else if (data1[2] == "999")
                        {
                            if (data1[3] == "3") changetag(Convert.ToInt16(data1[4]), data1[5]);
                            else if (data1[3] == "1") deltag(Convert.ToInt16(data1[4]));
                            else if (data1[3] == "2") addtag(data1[4]);

                        }
                        else if (data1[2] == "666")
                        {
                            if (data1[3] == "1") delfilm(Convert.ToInt16(data1[3]));
                            else if (data1[3] == "2")
                            {
                                int a = addfilm(data1[4], data1[5], data1[6]);
                                if (a != 0)
                                {

                                    for (int ll = 7; ll < data1.Length; ll++)
                                    {
                                        instag(a, Convert.ToInt16(data1[ll]));
                                    }
                                }
                            }
                            else if (data1[3] == "3")
                            {
                                changefilm(Convert.ToInt16(data1[4]), data1[5], data1[6], data1[7]);
                                deltag1(Convert.ToInt16(data1[4]));
                                for (int ll = 8; ll < data1.Length; ll++)
                                {
                                    instag(Convert.ToInt16(data1[4]), Convert.ToInt16(data1[ll]));
                                }

                            }
                        }


                        else
                        {
                            sw.WriteLine("ошибка");
                            sw.Flush();
                        }
                    }
                    else if (checkl(data1[0], data1[1]) != 1)
                    {
                        sw.WriteLine("ошибка");
                        sw.Flush();
                    }
                }
                catch (Exception e) {; }
                if (data == "2")
                {
                    logi();

                }
                else if (data == "3")
                {
                    newuser();
                }
            }
           
        }
    }
}
