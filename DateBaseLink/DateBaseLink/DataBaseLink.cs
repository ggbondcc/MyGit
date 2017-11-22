using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows;

namespace DateBaseLink
{
    class DataBaseLink
    {
        //连接数据库的字段
        private string sqllink = "";
        //数据库对象
        private MySqlConnection MysqlCon;
        private MySqlCommand MysqlCom = new MySqlCommand();
        //通过传入数据库字符串初始化数据库连接
        public DataBaseLink(string sqllink)
        {
            this.sqllink = sqllink;
            MysqlCon = new MySqlConnection(this.sqllink);
        }
        //通过传入数据库对象初始化数据库连接
        public DataBaseLink(MySqlConnection MysqlCon)
        {
            if(MysqlCon == null)
            {
                try
                {
                    this.MysqlCon.Open();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.ErrorCode);
                    throw;
                }
                finally
                {
                    this.MysqlCon.Close();
                }
            }
            else
            {
                this.MysqlCon = MysqlCon;
            }
        }
        //插入数据
        public int Insert(string SQL)
        {
            try
            {
                //MysqlCom = new MySqlCommand(SQL, MysqlCon);
                MysqlCom.CommandText = SQL;
                MysqlCom.Connection = MysqlCon;
                MysqlCon.Open();
                if(MysqlCom.ExecuteNonQuery()>0)
                {
                    MysqlCon.Close();
                    return 1;
                }
                else
                {
                    MysqlCon.Close();
                    return 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ErrorCode);
                throw;
            }
            

            //return 0;
        }
        //插入数据Object替换
        public int Insert(Object[] data ,string SQL)
        {
            int i = 0;
            foreach (Object a in data)
            {
                SQL = SQL.Replace("{" + i + "}","'"+ a.ToString()+"'");
                i++;
            }
            try
            {
                MysqlCom.CommandText = SQL;
                MysqlCom.Connection = MysqlCon;
                MysqlCon.Open();
                //Console.WriteLine(SQL);
                if (MysqlCom.ExecuteNonQuery() > 0)
                {
                    MysqlCon.Close();
                    return 1;
                }
                else
                {
                    MysqlCon.Close();
                    return 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ErrorCode);
                throw;
            }
            
            
        }
        //更新数据
        public int Updata(string SQL)
        {
            try
            {
                //MysqlCom = new MySqlCommand(SQL, MysqlCon);
                MysqlCom.CommandText = SQL;
                MysqlCom.Connection = MysqlCon;
                MysqlCon.Open();
                if (MysqlCom.ExecuteNonQuery() > 0)
                {
                    MysqlCon.Close();
                    return 1;
                }
                else
                {
                    MysqlCon.Close();
                    return 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ErrorCode);
                throw;
            }
            
        }
        //更新数据Object替换
        public int Updata(Object[] data , string SQL)
        {
            int i = 0;
            foreach (Object a in data)
            {
                SQL = SQL.Replace("{" + i + "}", "'" + a.ToString() + "'");
                i++;
            }
            try
            {
                MysqlCom.CommandText = SQL;
                MysqlCom.Connection = MysqlCon;
                MysqlCon.Open();
            //Console.WriteLine(SQL);
            
                if (MysqlCom.ExecuteNonQuery() > 0)
                {
                    MysqlCon.Close();
                    return 1;
                }
                else
                {
                    MysqlCon.Close();
                    return 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ErrorCode);
                throw;
            }
        }
        //删除数据
        public int Delete(string SQL)
        {
            /* string sql1 = "UPDATE user SET username=@username,userpassword=@userpassword where username='wyh";
             MysqlCom.CommandText = sql1;
             MysqlCom.Parameters.AddWithValue("@username", "wyh");
             MysqlCom.Parameters.AddWithValue("@userpassword", "123456");
             Console.WriteLine(MysqlCom.CommandText);*/
            try
            {
                //MysqlCom = new MySqlCommand(SQL, MysqlCon);
                MysqlCom.CommandText = SQL;
                MysqlCom.Connection = MysqlCon;
                MysqlCon.Open();
                if (MysqlCom.ExecuteNonQuery() > 0)
                {
                    MysqlCon.Close();
                    return 1;
                }
                else
                {
                    MysqlCon.Close();
                    return 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ErrorCode);
                throw;
            }
        }
        //删除数据Object替换
        public int Delete(Object[] data ,string SQL)
        {
            int i = 0;
            foreach (Object a in data)
            {
                SQL = SQL.Replace("{" + i + "}", "'" + a.ToString() + "'");
                i++;
            }
            try
            {
                MysqlCom.CommandText = SQL;
                MysqlCom.Connection = MysqlCon;
                MysqlCon.Open();
                //Console.WriteLine(SQL);

                if (MysqlCom.ExecuteNonQuery() > 0)
                {
                    MysqlCon.Close();
                    return 1;
                }
                else
                {
                    MysqlCon.Close();
                    return 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ErrorCode);
                throw;
            }
        }
        
    }
}
