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
        /// 
       //3-1-2021 Saung NEW 1L:Constructor for Student and initializing strings
        public Student(string courseAbbrNbr, string name, int age) {
            this.courseAbbrNbr = courseAbbrNbr;
            this.name = name;
            this.age = age;
        }

        //3-1-2021 Saung NEW 6L: get and set CourseAbbrNbr
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
        //3-1-2021 Saung NEW 6L: get and set Name
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
        //3-1-2021 Saung NEW 6L: get and set Age
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
