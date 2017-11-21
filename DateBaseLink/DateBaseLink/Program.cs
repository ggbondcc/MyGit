using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateBaseLink
{
    class Program
    {
        static void Main(string[] args)
        {
            string sql = "INSERT INTO user(username,userpassword) values({0},{1})";
            string sql2 = "UPDATE user SET username={0},userpassword={1}where username='wyh'";
            Object[] data = { "haha", "asdfgh" };
            string sqllink = "Host =localhost;Database=socket;Username=root;Password=123456";
            DataBaseLink dbl = new DataBaseLink(sqllink);
            if(dbl.Updata(data, sql2)>0)
            {
                Console.WriteLine("成功");
            }
            else
            {
                Console.WriteLine("失败");
            }
        }
    }
}
