using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Net;


namespace DateBaseLink
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Net.IPAddress[] address = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            foreach(IPAddress a in address)
            {
                Console.WriteLine(a);
            }
            Console.ReadKey();
            /*string sql = "INSERT INTO user(username,userpassword) values({0},{1})";
            string sql2 = "UPDATE user SET username={0},userpassword={1}where username='wyh'";
            string sql3 = "SELECT * FROM user";
            string sql4 = "DELETE FROM user WHERE username='aaa'";
            Object[] data = { "haha", "asdfgh" };
            string sqllink = "Host =localhost;Database=socket;Username=root;Password=123456";
            DataBaseLink dbl = new DataBaseLink(sqllink);
            MySqlDataReader re = dbl.Select(data, sql3);
            /*while(re.Read())
            {
                Console.WriteLine(re[0].ToString() + re[1].ToString() + re[2].ToString());
            }
            re.Close();
            dbl.DataBaseClose();
            /*if(dbl.Updata(data, sql2)>0)
            {
                Console.WriteLine("成功");
            }
            else
            {
                Console.WriteLine("失败");
            }*/
            //Console.WriteLine( dbl.Delete(sql4));
        }

        
    }
}
