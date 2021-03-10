using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ComputerScienceCoursesSystem
{
    public partial class frmMain : Form
    {
        private List<Course> courses;
        private List<Student> students;

        /// <summary>
        /// Main form
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
            this.courses = new List<Course>();
            this.students = new List<Student>();

            //test data
            this.courses.Add(new Course("CMPS 480", "CS Maths", "Course Maths"));
            this.courses.Add(new Course("CMPS 580", "CS History", "Course History"));
            this.courses.Add(new Course("CMPS 680", "CS Biology", "Get a world-class education from home with online courses from Harvard University"));
            cbCourseAbbrNbr.Items.Clear();
            for (int i = 0; i < this.courses.Count; i++)
            {
                cbCourseAbbrNbr.Items.Add(this.courses[i].BbrNbr);
            }
            this.students.Add(new Student("CMPS 480","Peter Clark", 18));
            this.students.Add(new Student("CMPS 480", "Mary Smith", 19));
            this.students.Add(new Student("CMPS 680", "Mike Peterson", 20));
            
        }
        /// <summary>
        /// Add course
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCourseAbbrNbr.Text == "")
                {
                    MessageBox.Show("Enter the course Abbr and Nbr!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCourseAbbrNbr.Focus();
                    return;
                }
                if (this.courses.Where(c => c.BbrNbr == txtCourseAbbrNbr.Text).ToList().Count > 0)
                {
                    MessageBox.Show("The course Abbr and Nbr already exists!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCourseAbbrNbr.Clear();
                    txtCourseAbbrNbr.Focus();
                    return;
                }
                if (txtCourseName.Text == "")
                {
                    MessageBox.Show("Enter the course name!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCourseName.Focus();
                    return;
                }
                if (txtCourseDescription.Text == "")
                {
                    MessageBox.Show("Enter the course description!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCourseDescription.Focus();
                    return;
                }

                this.courses.Add(new Course(txtCourseAbbrNbr.Text.Trim(), txtCourseName.Text.Trim(), txtCourseDescription.Text.Trim()));
                cbCourseAbbrNbr.Items.Clear();
                for (int i = 0; i < this.courses.Count; i++)
                {
                    cbCourseAbbrNbr.Items.Add(this.courses[i].BbrNbr);
                }

                txtCourseAbbrNbr.Text = "";
                txtCourseName.Text = "";
                txtCourseDescription.Text = "";
                MessageBox.Show("A new course has been added!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) {

            }
         
        }
        /// <summary>
        /// Enroll Course button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnrollCourse_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbCourseAbbrNbr.SelectedIndex == -1)
                {
                    MessageBox.Show("Select the course Abbr and Nbr!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbCourseAbbrNbr.Focus();
                    return;
                }
                if (txtStudentName.Text == "")
                {
                    MessageBox.Show("Enter the student name!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtStudentName.Focus();
                    return;
                }
                int age = 0;
                if (txtStudentAge.Text == "" || int.TryParse(txtStudentAge.Text.Trim(), out age) == false || age < 16)
                {
                    MessageBox.Show("Enter the student age >=16!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtStudentAge.Clear();
                    txtStudentAge.Focus();
                    return;
                }

                this.students.Add(new Student(cbCourseAbbrNbr.SelectedItem.ToString().Trim(), txtStudentName.Text.Trim(), age));

                cbCourseAbbrNbr.SelectedIndex = -1;
                txtStudentName.Text = "";
                txtStudentAge.Text = "";
                MessageBox.Show("A new student has been added!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { }

            
        }
        /// <summary>
        /// Submit search for button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmitSearchFor_Click(object sender, EventArgs e)
        {
            if (txtSearchFor.Text == "")
            {
                MessageBox.Show("Enter the text to search!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSearchFor.Focus();
                return;
            }


            txtOutput.Text = "";
            int age = -1;
            int.TryParse(txtSearchFor.Text.Trim(), out age);

            var queryStudents = from s in this.students
                                where s.Name.Contains(txtSearchFor.Text) || s.Age== age
                                select s;
            if (queryStudents.ToList().Count != 0)
            {
                foreach (var student in queryStudents)
                {
                    txtOutput.Text += "The student " + student.Name + " is " + student.Age.ToString() + " years old" + Environment.NewLine;
                }
            }

            var queryCourses = from c in this.courses
                               where c.BbrNbr.Contains(txtSearchFor.Text) || c.Name.Contains(txtSearchFor.Text) || c.Description.Contains(txtSearchFor.Text)
                               select c;
            if (queryCourses.ToList().Count != 0)
            {
                foreach (var course in queryCourses)
                {
                    txtOutput.Text += "The course " + course.Name + " has " + course.BbrNbr.ToString() + " Abbr and Nbr" + Environment.NewLine;
                }
            }

            var queryStudentEnrolledCourse = from s in this.students 
                        join c in this.courses on s.CourseAbbrNbr equals c.BbrNbr
                        where s.CourseAbbrNbr.Contains(txtSearchFor.Text) || s.Name.Contains(txtSearchFor.Text) || c.Name.Contains(txtSearchFor.Text)
                        select new { student = s, course = c};
            
            if (queryStudentEnrolledCourse.ToList().Count != 0)
            {
                foreach (var studentAndCourse in queryStudentEnrolledCourse)
                {
                    txtOutput.Text += "The student " + studentAndCourse.student.Name + " is enrolled in the course \"" + studentAndCourse.course.Name + "\"" + Environment.NewLine;
                }
            }

            if (queryStudents.ToList().Count == 0  && queryStudentEnrolledCourse.ToList().Count == 0 && queryCourses.ToList().Count == 0)
            {
                txtOutput.Text += "No students and courses!";
            }
        }
        /// <summary>
        /// Starts with button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartsWith_Click(object sender, EventArgs e)
        {
            if (txtStartsWith.Text == "")
            {
                MessageBox.Show("Enter the text to search!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtStartsWith.Focus();
                return;
            }
            txtOutput.Text = "";

            var queryStudents = from s in this.students
                                where s.Name.StartsWith(txtStartsWith.Text)
                                select s;
            if (queryStudents.ToList().Count != 0)
            {
                foreach (var student in queryStudents)
                {
                    txtOutput.Text += "The student " + student.Name + " is " + student.Age.ToString() + " years old" + Environment.NewLine;
                }
            }

            var queryCourses = from c in this.courses
                               where c.BbrNbr.StartsWith(txtStartsWith.Text) || c.Name.StartsWith(txtStartsWith.Text) || c.Description.StartsWith(txtStartsWith.Text)
                               select c;
            if (queryCourses.ToList().Count != 0)
            {
                foreach (var course in queryCourses)
                {
                    txtOutput.Text += "The course " + course.Name + " has " + course.BbrNbr.ToString() + " Abbr and Nbr" + Environment.NewLine;
                }
            }

            var queryStudentEnrolledCourse = from s in this.students
                                             join c in this.courses on s.CourseAbbrNbr equals c.BbrNbr
                                             where s.CourseAbbrNbr.StartsWith(txtStartsWith.Text) || s.Name.StartsWith(txtStartsWith.Text) || c.Name.StartsWith(txtStartsWith.Text)
                                             select new { student = s, course = c };

            if (queryStudentEnrolledCourse.ToList().Count != 0)
            {
                foreach (var studentAndCourse in queryStudentEnrolledCourse)
                {
                    txtOutput.Text += "The student " + studentAndCourse.student.Name + " is enrolled in the course \"" + studentAndCourse.course.Name + "\"" + Environment.NewLine;
                }
            }

            if (queryStudents.ToList().Count == 0 && queryStudentEnrolledCourse.ToList().Count == 0 && queryCourses.ToList().Count == 0)
            {
                txtOutput.Text += "No students and courses!";
            }
        }
        /// <summary>
        /// Ends with button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEndsWith_Click(object sender, EventArgs e)
        {
            if (txtEndsWith.Text == "")
            {
                MessageBox.Show("Enter the text to search!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEndsWith.Focus();
                return;
            }
            txtOutput.Text = "";

            var queryStudents = from s in this.students
                                where s.Name.EndsWith(txtEndsWith.Text)
                                select s;
            if (queryStudents.ToList().Count != 0)
            {
                foreach (var student in queryStudents)
                {
                    txtOutput.Text += "The student " + student.Name + " is " + student.Age.ToString() + " years old" + Environment.NewLine;
                }
            }

            var queryCourses = from c in this.courses
                               where c.BbrNbr.EndsWith(txtEndsWith.Text) || c.Name.EndsWith(txtEndsWith.Text) || c.Description.EndsWith(txtEndsWith.Text)
                               select c;
            if (queryCourses.ToList().Count != 0)
            {
                foreach (var course in queryCourses)
                {
                    txtOutput.Text += "The course " + course.Name + " has " + course.BbrNbr.ToString() + " Abbr and Nbr" + Environment.NewLine;
                }
            }

            var queryStudentEnrolledCourse = from s in this.students
                                             join c in this.courses on s.CourseAbbrNbr equals c.BbrNbr
                                             where s.CourseAbbrNbr.EndsWith(txtEndsWith.Text) || s.Name.EndsWith(txtEndsWith.Text) || c.Name.EndsWith(txtEndsWith.Text)
                                             select new { student = s, course = c };

            if (queryStudentEnrolledCourse.ToList().Count != 0)
            {
                foreach (var studentAndCourse in queryStudentEnrolledCourse)
                {
                    txtOutput.Text += "The student " + studentAndCourse.student.Name + " is enrolled in the course \"" + studentAndCourse.course.Name + "\"" + Environment.NewLine;
                }
            }

            if (queryStudents.ToList().Count == 0 && queryStudentEnrolledCourse.ToList().Count == 0 && queryCourses.ToList().Count == 0)
            {
                txtOutput.Text += "No students and courses!";
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
