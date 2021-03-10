using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerScienceCoursesSystem
{
    public class Student
    {
        private string courseAbbrNbr;
        private string name;
        private int age;
        /// <summary>
        /// Constructor
        /// </summary>
        public Student() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="courseAbbrNbr"></param>
        /// <param name="name"></param>
        /// <param name="age"></param>
        public Student(string courseAbbrNbr, string name, int age) {
            this.courseAbbrNbr = courseAbbrNbr;
            this.name = name;
            this.age = age;
        }


        public string CourseAbbrNbr
        {
            get
            {
                return courseAbbrNbr;
            }

            set
            {
                courseAbbrNbr = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                age = value;
            }
        }
    }
}
