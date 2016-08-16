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
    /// TeaModel.xaml 的交互逻辑
    /// </summary>
    public partial class ModelTeacher : Window
    {
        ////////Update Mark :parameters: used in button_click and button1_click
        DataTable dt_view_uploadmark;
        SqlDataAdapter sda_view_uploadmark;
        SqlCommandBuilder scb_view_uploadmark;
        //////parameters for teaching analysis:used in avgmark_click and goodrate_click
        string teaching_analysis_classID;
        /// </summary>
        public ModelTeacher()
        {
            InitializeComponent();
            ///////teacher personal 
            SqlCommand cmd_tea = new SqlCommand("select * from dbo.Teacher where TeaID = " + MainWindow.loginID, MainWindow.connection);
            SqlDataReader reader_tea = cmd_tea.ExecuteReader();
            reader_tea.Read();

            ////姓名
            textBlock_name.Text = reader_tea["TeaName"].ToString();
            ////性别
            string sexid = reader_tea["TeaSex"].ToString();
            if (sexid == "1")
            {
               textBlock_sex.Text = "Male";
            }
            else
                textBlock_sex.Text = "Female";
            ////生日
            textBlock_birth.Text = reader_tea["TeaBirthday"].ToString();
            ////职称
            textBlock_rank.Text = reader_tea["TeaRank"].ToString();
            ////学院id
            textBlock_college.Text = reader_tea["CollegeCollegeID"].ToString();
            /////职称
            textBlock_rank.Text = reader_tea["TeaRank"].ToString();
            reader_tea.Close();//关闭
            //学院
            if(textBlock_college.Text == "25")
            {
                textBlock_college.Text = "Computer";//区分学院的名称
            }
            else
            {
                textBlock_college.Text = "Economic";
            }
            //获取教师自己的授课目录
           
            SqlCommand cmd = new SqlCommand("select b.SubName from dbo.TeachingSubjects a left join dbo.Subject b  on a.SubjectSubID = b.SubID where a.TeacherTeaID = " + MainWindow.loginID, MainWindow.connection);

            using (SqlDataReader reader = cmd.ExecuteReader()) //将授课目录放到combox中
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        comboBox_subtea.Items.Add(reader["SubName"].ToString());
                        comboBox_teaching_analysis.Items.Add(reader["SubName"].ToString());
                    }
                }
                reader.Close();
            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ////////uploadmark 教师输入学生的成=成绩后点击确认修改
            try
            { 
                scb_view_uploadmark = new SqlCommandBuilder(sda_view_uploadmark);
                sda_view_uploadmark.Update(dt_view_uploadmark);
            }
            catch(Exception) 
            {                
            }
        }

        private void comboBox_subtea_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string showclass_classID = null;
            try
            {
                SqlCommand cmd_showclass = new SqlCommand("select SubID,SubName,SubScore,SubHour,SubIntro from dbo.Subject where SubName = '" + comboBox_subtea.Text + "'", MainWindow.connection);
                SqlDataReader reader_showclass = cmd_showclass.ExecuteReader();
                reader_showclass.Read();

                showclass_classID = reader_showclass["SubID"].ToString();
                reader_showclass.Close();

                //////////////////////////////////教师界面：显示选了自己课程的学生表(学号 课程号 成绩) finished
                dt_view_uploadmark = new DataTable();
                dt_view_uploadmark.TableName = "select_subjects";
                sda_view_uploadmark = new SqlDataAdapter("select StudentStuID,SubjectSubID,Mark from dbo.Mark where SubjectSubID =  " + showclass_classID, MainWindow.connection);//只显示本专业需要学的课程

                sda_view_uploadmark.Fill(dt_view_uploadmark);

                dataGrid_showclass.ItemsSource = dt_view_uploadmark.DefaultView;

            }
            catch (Exception)
            {

            }
        }

        private void subjectplan_Click(object sender, RoutedEventArgs e)
        {
            /////////显示教师自己的课程安排 finished
            DataTable da = new DataTable();
            da.TableName = "subjectplan";
            SqlDataAdapter sda = new SqlDataAdapter("select SubjectSubID,ClassRoom,TeachTime from dbo.TeachingSubjects where TeacherTeaID =  " + MainWindow.loginID, MainWindow.connection);//只显示本专业需要学的课程

            sda.Fill(da);

            dataGrid_showclass.ItemsSource = da.DefaultView;
           
        }

        private void comboBox_show_analysis_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void comboBox_show_avgmark_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void avgmark_Click(object sender, RoutedEventArgs e)
        {
            ///////显示对应的对应需要分析的课程的ID
            teaching_analysis_classID = null;
            try
            {
                SqlCommand cmd_teaching_analysis = new SqlCommand("select * from dbo.Subject where SubName = '" +  comboBox_teaching_analysis.Text + "'", MainWindow.connection);
                SqlDataReader reader_show_analysis = cmd_teaching_analysis.ExecuteReader();
                reader_show_analysis.Read();

                teaching_analysis_classID = reader_show_analysis["SubID"].ToString();
                reader_show_analysis.Close();
                //////平均成绩
                SqlCommand cmd_show_avgmark = new SqlCommand("select avg(Mark) as AvgMark from dbo.Mark where SubjectSubID = '" + teaching_analysis_classID + "'", MainWindow.connection);
                SqlDataReader reader_show_avgmark = cmd_show_avgmark.ExecuteReader();
                reader_show_avgmark.Read();

                textBlock_avgmark.Text = reader_show_avgmark["AvgMark"].ToString(); //显示平均成绩
                reader_show_avgmark.Close();

            }
            catch (Exception)
            {

            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
           



        }

        private void goodrate_Click(object sender, RoutedEventArgs e)
        {
            ////////goodtare 根据成绩 显示对应班级的优秀率
            try
            {
                SqlCommand cmd_show_gooditems = new SqlCommand("select count(Mark) as GoodItems from dbo.Mark where SubjectSubID = '" + teaching_analysis_classID + "' and Mark >=80", MainWindow.connection);
                SqlDataReader reader_show_gooditems = cmd_show_gooditems.ExecuteReader();
                reader_show_gooditems.Read();
                string gooditems = reader_show_gooditems["GoodItems"].ToString();
                reader_show_gooditems.Close();

                SqlCommand cmd_show_goodsum = new SqlCommand("select count(Mark) as GoodSum from dbo.Mark where SubjectSubID = '" + teaching_analysis_classID +"'", MainWindow.connection);
                SqlDataReader reader_show_goodsum = cmd_show_goodsum.ExecuteReader();
                reader_show_goodsum.Read();
                string goodsum = reader_show_goodsum["GoodSum"].ToString();
                reader_show_goodsum.Close();
         
                textBlock_goodrate.Text = gooditems+"/"+goodsum;
            }
            catch (Exception)
            {

            }
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            Model__FixPw fixpw = new Model__FixPw();
            fixpw.Show();
        }

        private void dataGrid_showclass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
