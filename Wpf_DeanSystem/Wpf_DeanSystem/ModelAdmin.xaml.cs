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
    /// AdModel.xaml 的交互逻辑
    /// </summary>
    public partial class ModelAdmin : Window
    {
        ///parameters used for teacher part
        DataTable dt_teacher;
        SqlDataAdapter sda_teacher;
        SqlCommandBuilder scb_teacher;
        ///parameters used for subjects part
        DataTable dt_subject;
        SqlDataAdapter sda_subject;
        SqlCommandBuilder scb_subject;
        ///parameters used for students part
        DataTable dt_student;
        SqlDataAdapter sda_student;
        SqlCommandBuilder scb_student;
        ///parameteres used for mark part 
        DataTable dt_mark;
        SqlDataAdapter sda_mark;
        SqlCommandBuilder scb_mark;
        ///parameters used for admin
        DataTable dt_admin;
        SqlDataAdapter sda_admin;
        SqlCommandBuilder scb_admin;
        ///parameters used for colleges 
        DataTable dt_col;
        SqlDataAdapter sda_col;
        SqlCommandBuilder scb_col;
        ///parameters used for majors 
        DataTable dt_maj;
        SqlDataAdapter sda_maj;
        SqlCommandBuilder scb_maj;
        /// </summary>
        public ModelAdmin()
        {
            InitializeComponent();

            ///////administrator personal 
            SqlCommand cmd_admin = new SqlCommand("select * from dbo.Administrator where AdID = " + MainWindow.loginID, MainWindow.connection);
            SqlDataReader reader_admin = cmd_admin.ExecuteReader();
            reader_admin.Read();
            
            ////姓名
            textBlock_name.Text = reader_admin["AdName"].ToString();
            ////性别
            string sexid = reader_admin["AdSex"].ToString();
            if (sexid == "1")
            {
                textBlock_sex.Text = "Male";
            }
            else
                textBlock_sex.Text = "Female";
            ////生日
            textBlock_birth.Text = reader_admin["AdBirthday"].ToString();

            reader_admin.Close();
        }

        private void fixsubject_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deladmin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void addadmin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void addsubject_Click(object sender, RoutedEventArgs e)
        {

        }

        private void delsubject_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void fixteapw_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dataGrid_stu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void viewteaher_Click(object sender, RoutedEventArgs e)
        {
            /////////Admin Teacher --view teacher 显示多有的教师
            try
            {
                dt_teacher = new DataTable();
                dt_teacher.TableName = "teachers";
                sda_teacher = new SqlDataAdapter("select * from dbo.Teacher" , MainWindow.connection);

                sda_teacher.Fill(dt_teacher);

                dataGrid_tea.ItemsSource = dt_teacher.DefaultView;
            }
            catch (Exception)
            {

            }

        }
        private void fixteacher_Click(object sender, RoutedEventArgs e)
        {
            /////////Admin Teacher --fix teacher 修改教师资料
            try
            {
                scb_teacher = new SqlCommandBuilder(sda_teacher);
                sda_teacher.Update(dt_teacher);
            }
            catch (Exception)
            {
            }
        }

        private void viewsubject_Click(object sender, RoutedEventArgs e)
        {

        }

        private void fixsubject_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void viewsubject_Click_1(object sender, RoutedEventArgs e)
        {
            /////////view subject
            try
            {
                dt_subject = new DataTable();
                dt_subject.TableName = "teachers";
                sda_subject = new SqlDataAdapter("select * from dbo.Subject", MainWindow.connection);

                sda_subject.Fill(dt_subject);

                dataGrid_sub.ItemsSource = dt_subject.DefaultView;
            }
            catch (Exception)
            {
            }
        }

        private void fixsubject_Click_2(object sender, RoutedEventArgs e)
        {
            /////////fix subject 
            try
            {
                scb_subject = new SqlCommandBuilder(sda_subject);
                sda_subject.Update(dt_subject);
            }
            catch (Exception)
            {
            }

        }

        private void viewstudent_Click(object sender, RoutedEventArgs e)
        {
            ///////view students 
            try
            {
                dt_student = new DataTable();
                dt_student.TableName = "students";
                sda_student = new SqlDataAdapter("select * from dbo.Student", MainWindow.connection);

                sda_student.Fill(dt_student);

                dataGrid_stu.ItemsSource = dt_student.DefaultView;
            }
            catch (Exception)
            {

            }
        }

        private void fixstudent_Click(object sender, RoutedEventArgs e)
        {
            ///////fix students
            try
            {
                scb_student = new SqlCommandBuilder(sda_student);
                sda_student.Update(dt_student);
            }
            catch (Exception)
            {
            }
        }

        private void viewaddmin_Click(object sender, RoutedEventArgs e)
        {
            ///////view addmin
            try
            {
                dt_admin = new DataTable();
                dt_admin.TableName = "admins";
                sda_admin = new SqlDataAdapter("select * from dbo.Administrator", MainWindow.connection);

                sda_admin.Fill(dt_admin);

                dataGrid_admin.ItemsSource = dt_admin.DefaultView;
            }
            catch (Exception)
            {
            }
        }

        private void fixaddmin_Click(object sender, RoutedEventArgs e)
        {
            /////fix addmin
            try
            {
                scb_admin = new SqlCommandBuilder(sda_admin);
                sda_admin.Update(dt_admin);
            }
            catch (Exception)
            {
            }
        }

        private void viewmark_Click(object sender, RoutedEventArgs e)
        {
            ///view mark
            try
            {
                dt_mark = new DataTable();
                dt_mark.TableName = "marks";
                sda_mark = new SqlDataAdapter("select * from dbo.Mark", MainWindow.connection);

                sda_mark.Fill(dt_mark);

                dataGrid_stu.ItemsSource = dt_mark.DefaultView;
            }
            catch (Exception)
            {
            }
        }

        private void fixmark_Click(object sender, RoutedEventArgs e)
        {
            //fix mark 
            try
            {
                scb_mark = new SqlCommandBuilder(sda_mark);
                sda_mark.Update(dt_mark);
            }
            catch (Exception)
            {
            }
        }

        private void viewcolleges_Click(object sender, RoutedEventArgs e)
        {
            /////view college
            try
            {
                dt_col = new DataTable();
                dt_col.TableName = "colleges";
                sda_col = new SqlDataAdapter("select * from dbo.College", MainWindow.connection);

                sda_col.Fill(dt_col);

                dataGrid_col_naj.ItemsSource = dt_col.DefaultView;
            }
            catch (Exception)
            {
            }
        }

        private void fixcollege_Click(object sender, RoutedEventArgs e)
        {
            /////fix colleges 
            try
            {
                scb_col = new SqlCommandBuilder(sda_col);
                sda_col.Update(dt_col);
            }
            catch (Exception)
            {
            }
        }

        private void viewmajor_Click(object sender, RoutedEventArgs e)
        {
            /////view majors 
            try
            {
                dt_maj = new DataTable();
                dt_maj.TableName = "majors";
                sda_maj = new SqlDataAdapter("select * from dbo.Major", MainWindow.connection);

                sda_maj.Fill(dt_maj);

                dataGrid_col_naj.ItemsSource = dt_maj.DefaultView;
            }
            catch (Exception)
            {
            }
        }

        private void fixmajor_Click(object sender, RoutedEventArgs e)
        {
            ////fix majors 
            try
            {
                scb_maj = new SqlCommandBuilder(sda_maj);
                sda_maj.Update(dt_maj);
            }
            catch (Exception)
            {
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            /////修改密码
            Model__FixPw fixpw = new Model__FixPw();
            fixpw.Show();
        }
    }
}
