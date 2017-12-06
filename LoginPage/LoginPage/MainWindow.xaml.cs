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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LoginPage
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        //private string loginUserName = "";
        public MainWindow()
        {
            InitializeComponent();
            Login LogPag = new Login();
            LogPag.ShowDialog();
            this.Close();
        }
        public MainWindow(string LoginUserName = "")
        {
            InitializeComponent();
            Login LogPag = new Login();
            if(LoginUserName.Equals(""))
            {
                LogPag.ShowDialog();
                this.Close();
               
            }
            //this.Close();
            //LogPag.ShowDialog();
            //string a = LogPag.LoginUserName;
            else
            {
                MessageBox.Show(LoginUserName);
            }
        }

        
    }
}
