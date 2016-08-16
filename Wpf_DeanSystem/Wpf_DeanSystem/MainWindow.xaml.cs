using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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


namespace Wpf_DeanSystem
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            main.Title = "Welcome to DeanSystem!";
            
        }

        public static string loginID = " ";//登陆ID，全局静态变量
        public static SqlConnection connection;//登陆连接
        public static SqlDataReader sqlreader;
        public static string loginType;
        public static string loginPW;
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //数据库连接字符串                 服务器名                     数据库名                         
            //string connString = @"Data Source=LENOVO-PC;Initial Catalog=dean_system;User ID = sa ;PWD = daleixiamen2014";
            //string connstring = @"Data Source=LENOVO-PC;Initial Catalog=dean_system;Persist Security Info=True;User ID=sa;Password=***********";
            //azure云服务器端连接语句
            string connString = @"Data Source=dalei1994.database.windows.net;Initial Catalog=dean_system;User ID = lucas;PWD = #daleixiamen2014";
            connection = new SqlConnection(connString);
            connection.Open();
            string selectSql = " ";

            loginType = loginselect.Text;//为修改密码界面提供登陆类型
            loginPW = textBox2.Text; //提供密码

            if (loginselect.Text == "Student")
            {
                selectSql = "select * from Student where StuID ='" + textBox.Text + "'and StuPW = '" + textBox2.Text + "'";
            }
            else if (loginselect.Text == "Teacher")
            {
                selectSql = "select * from Teacher where TeaID ='" + textBox.Text + "'and TeaPW = '" + textBox2.Text + "'";
            }
            else if (loginselect.Text == "Administrator") //注意此处缩写
            {
                selectSql = "select * from Administrator where AdID ='" + textBox.Text + "'and AdPW = '" + textBox2.Text + "'";
            }
            else
                selectSql = " ";

            loginID = textBox.Text; //获取登陆ID 
            //表名
            SqlCommand cmd = new SqlCommand(selectSql, connection);

            cmd.CommandType = CommandType.Text;

            sqlreader = cmd.ExecuteReader();
        
            if (sqlreader.Read())
            {
                MessageBox.Show("Link Succesful!");
                sqlreader.Close();
                if(loginselect.Text == "Student")
                {
                    ModelStudent ms = new ModelStudent();                                      
                    ms.Show();
                    this.Close();
                }
                else if (loginselect.Text == "Teacher")
                {
                    ModelTeacher mt = new ModelTeacher();
                    mt.Show();
                    this.Close();
                }
                else
                {
                    ModelAdmin ma = new ModelAdmin();
                    ma.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Link Failed!");
            }
        }
       
        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
