using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DateBaseLink;
using MySql.Data.MySqlClient;

namespace LoginPage
{

    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        public string LoginUserName = "";
        public Login()
        {
            InitializeComponent();
        }
        //失去焦点时查询用户名是否存在
        private void UserName_LostFocus(object sender, RoutedEventArgs e)
        {
            if(UserName.Text=="")
            {

            }
            else
            {
                string DbLink = "Host = localhost; Database = socket; Username = root; Password = 123456";
                DataBaseLink DBA = new DataBaseLink(DbLink);
                string SQL = "SELECT username FROM user WHERE username ={0}";
                object[] Value = { UserName.Text };
                MySqlDataReader Read = null;
                Read = DBA.Select(Value, SQL);
                if (Read.Read())
                {
                    UseNameSelect.Content = "√";
                }
                else
                {
                    UseNameSelect.Content = "×";
                }
                DBA.DataBaseClose();
            }
        }
        //返回点击时事件
        private void UserName_IsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            UseNameSelect.Content = "";
        }
        //回车登录
        private void UserName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                this.LoginBut_Click(new object { } ,new RoutedEventArgs());
            }
        }
        //登录
        private void LoginBut_Click(object sender, RoutedEventArgs e)
        {
            if(UserName.Text=="")
            {
                notlog.Content = "请输入用户名";
            }
            else if(UserPassword.Text == "")
            {
                notlog.Content = "请输入密码";
            }
            else
            {
                string DbLink = "Host = localhost; Database = socket; Username = root; Password = 123456";
                DataBaseLink DBA = new DataBaseLink(DbLink);
                string SQL = "SELECT username,userpassword FROM user WHERE username={0} AND userpassword={1}";
                object[] value = { UserName.Text, UserPassword.Text };
                MySqlDataReader Read = DBA.Select(value, SQL);
                if (Read.Read())
                {
                    LoginUserName = UserName.Text;
                    MessageBox.Show("yes");
                }
                else
                {
                    notlog.Content = "用户名或者密码错误";
                }
            }
        }
    }
}
