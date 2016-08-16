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
    /// ModelStudent.xaml 的交互逻辑
    /// </summary>
    public partial class ModelStudent : Window
    {
        public ModelStudent()
        {
            InitializeComponent();
            /////////student Personal
            SqlCommand cmd = new SqlCommand("select * from dbo.Student where StuID = " + MainWindow.loginID, MainWindow.connection);            
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            
            //姓名
            textBlock_name.Text = reader["StuName"].ToString();
            //生日
            textBlock_birth.Text = reader["StuBirthday"].ToString();
            //专业id            
            string majorid = reader["MajorMajorID"].ToString();
            //性别
            string sexid = reader["StuSex"].ToString();
            if ( sexid == "1")
            {
                textBlock_sex.Text = "Boy";
            }
            else
                textBlock_sex.Text = "Girl";
            //平均成绩
            textBlock_avgmark.Text = reader["AvgMark"].ToString();
            reader.Close();
            //专业
            SqlCommand cmd_findMajor = new SqlCommand("select * from dbo.Major where MajorID = " + majorid, MainWindow.connection);
            SqlDataReader reader_findMajor = cmd_findMajor.ExecuteReader();
            reader_findMajor.Read();
            textBlock_major.Text = reader_findMajor["MajorName"].ToString();
            reader_findMajor.Close();
            /////////////////seleted_subject 在个人界面显示个人已选课程 
            DataTable da1 = new DataTable();
            da1.TableName = "selected_subjects";
            SqlDataAdapter sda1 = new SqlDataAdapter("select * from Mark where StudentStuID =  " + MainWindow.loginID, MainWindow.connection);

            sda1.Fill(da1);

            dataGrid_personal.ItemsSource = da1.DefaultView;
            ///////////////select_subjects 显示选课界面
            DataTable da2 = new DataTable();
            da2.TableName = "select_subjects";
            SqlDataAdapter sda2 = new SqlDataAdapter("select * from Subject where left(SubID,2) =  " + majorid, MainWindow.connection);//只显示本专业需要学的课程

            sda2.Fill(da2);

            dataGrid_selectubjects.ItemsSource = da2.DefaultView;

        }

        private void button_fixpw_Click(object sender, RoutedEventArgs e)
        {
            //////修改密码
            Model__FixPw fixpw = new Model__FixPw();
            fixpw.Show();
            
        }

        private void dataGrid2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataGrid2_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            
              
        }

        private void finifhselectsub_Click(object sender, RoutedEventArgs e)
        {
            try//works well  学生输入课程id实现选课
            {
                SqlCommand cmd = new SqlCommand("insert dbo.Mark values ('" + MainWindow.loginID + "','" + textbox_wantedsubjectid.Text + "','0','2')", MainWindow.connection);

                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
        }

        private void button_fixpw_Click_1(object sender, RoutedEventArgs e)
        {
            /////实现更改密码
            Model__FixPw fixpw = new Model__FixPw();
            fixpw.Show();
        }

        private void button_viewsubjects_Click(object sender, RoutedEventArgs e)
        {
            /////////////////seleted_subject 在个人界面显示个人已选课程 
            DataTable da1 = new DataTable();
            da1.TableName = "selected_subjects";
            SqlDataAdapter sda1 = new SqlDataAdapter("select StudentStuID,SubjectSubID,Mark from Mark where StudentStuID =  " + MainWindow.loginID, MainWindow.connection);

            sda1.Fill(da1);

            dataGrid_personal.ItemsSource = da1.DefaultView;
        }
    }
}
