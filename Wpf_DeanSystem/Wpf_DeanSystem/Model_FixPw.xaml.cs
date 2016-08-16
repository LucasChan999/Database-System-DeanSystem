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

using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace Wpf_DeanSystem
{
    /// <summary>
    /// Model__FixPw.xaml 的交互逻辑
    /// </summary>
    public partial class Model__FixPw : Window
    {
        public Model__FixPw()
        {
            InitializeComponent();
        }

        private void button_Confirm_Click(object sender, RoutedEventArgs e)
        {
            ///////确认修改密码
            string pw1 = textBox_pw1.Text;
            string pw2 = textBox_pw2.Text;

            if (pw1 != pw2)
            {
                MessageBox.Show("Error:pw1 not equal to pw2!");
                this.Close();
            }
            else
            {              
                    if (MainWindow.loginType == "Student")
                    {
                        SqlCommand cmd_fixpw = new SqlCommand("update dbo.Student set StuPW ='" + pw1 + "' where StuID = '" + MainWindow.loginID + "' ", MainWindow.connection);                        
                        cmd_fixpw.ExecuteNonQuery();                        
                    }
                    else if(MainWindow.loginType == "Teacher"){
                        SqlCommand cmd_fixpw = new SqlCommand("update dbo.Teacher set TeaPW ='" + pw1 + "' where TeaID='" + MainWindow.loginID + "' ", MainWindow.connection);
                        cmd_fixpw.ExecuteNonQuery();                        
                    }
                    else if (MainWindow.loginType == "Administrator")
                    {
                        SqlCommand cmd_fixpw = new SqlCommand("update dbo.Administrator set AdPW ='" + pw1 + "' where AdID='" + MainWindow.loginID + "' ", MainWindow.connection);
                        cmd_fixpw.ExecuteNonQuery();                      
                    }   
                            
             if(pw1 == MainWindow.loginPW )
                {
                    MessageBox.Show("PassWord not Changed!");
                    this.Close();
                }
                MessageBox.Show("PassWord Changed Successful!");
                this.Close();
            }
        }

        private void textBox_pw1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_pw2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
