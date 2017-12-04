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
        //sqllink的get，set方法
        public string Sqllink
        {
            get
            {
                return sqllink;
            }

            set
            {
                sqllink = value;
            }
        }
        //mysqlcon的get，set方法
        public MySqlConnection MysqlCon1
        {
            get
            {
                return MysqlCon;
            }

            set
            {
                MysqlCon = value;
            }
        }

        //通过传入数据库字符串初始化数据库连接
        public DataBaseLink(string sqllink)
        {
            this.Sqllink = sqllink;
            MysqlCon1 = new MySqlConnection(this.Sqllink);
        }
        //通过传入数据库对象初始化数据库连接
        public DataBaseLink(MySqlConnection MysqlCon)
        {
            if(MysqlCon == null)
            {
                try
                {
                    this.MysqlCon1.Open();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.ErrorCode);
                    throw;
                }
                finally
                {
                    this.MysqlCon1.Close();
                }
            }
            else
            {
                this.MysqlCon1 = MysqlCon;
            }
        }
        //插入数据
        public int Insert(string SQL)
        {
            try
            {
                //MysqlCom = new MySqlCommand(SQL, MysqlCon);
                MysqlCom.CommandText = SQL;
                MysqlCom.Connection = MysqlCon1;
                MysqlCon1.Open();
                if(MysqlCom.ExecuteNonQuery()>0)
                {
                    MysqlCon1.Close();
                    return 1;
                }
                else
                {
                    MysqlCon1.Close();
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
                MysqlCom.Connection = MysqlCon1;
                MysqlCon1.Open();
                //Console.WriteLine(SQL);
                if (MysqlCom.ExecuteNonQuery() > 0)
                {
                    MysqlCon1.Close();
                    return 1;
                }
                else
                {
                    MysqlCon1.Close();
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
                MysqlCom.Connection = MysqlCon1;
                MysqlCon1.Open();
                if (MysqlCom.ExecuteNonQuery() > 0)
                {
                    MysqlCon1.Close();
                    return 1;
                }
                else
                {
                    MysqlCon1.Close();
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
                MysqlCom.Connection = MysqlCon1;
                MysqlCon1.Open();
            //Console.WriteLine(SQL);
            
                if (MysqlCom.ExecuteNonQuery() > 0)
                {
                    MysqlCon1.Close();
                    return 1;
                }
                else
                {
                    MysqlCon1.Close();
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
            try
            {
                //MysqlCom = new MySqlCommand(SQL, MysqlCon);
                MysqlCom.CommandText = SQL;
                MysqlCom.Connection = MysqlCon1;
                MysqlCon1.Open();
                if (MysqlCom.ExecuteNonQuery() > 0)
                {
                    MysqlCon1.Close();
                    return 1;
                }
                else
                {
                    MysqlCon1.Close();
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
                MysqlCom.Connection = MysqlCon1;
                MysqlCon1.Open();
                //Console.WriteLine(SQL);

                if (MysqlCom.ExecuteNonQuery() > 0)
                {
                    MysqlCon1.Close();
                    return 1;
                }
                else
                {
                    MysqlCon1.Close();
                    return 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ErrorCode);
                throw;
            }
        }

        //查找数据
        public MySqlDataReader Select(string SQL)
        {
            try
            {
                MysqlCom.CommandText = SQL;
                MysqlCom.Connection = MysqlCon;
                MySqlDataReader reader = null;
                MysqlCon.Open();
                reader = MysqlCom.ExecuteReader();
                return reader;

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ErrorCode);
                throw;
            }
        }

        //查找数据Object替换
        public MySqlDataReader Select(Object[] data,string SQL)
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
                MysqlCom.Connection = MysqlCon1;
                MySqlDataReader reader = null;
                MysqlCon1.Open();
                reader = MysqlCom.ExecuteReader();
                //MysqlCon.Close();
                return reader;

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ErrorCode);
                throw;
            }
            //return reader;
        }
        //关闭数据库
        public void DataBaseClose()
        {
            MysqlCon1.Close();
        }
    }
}
