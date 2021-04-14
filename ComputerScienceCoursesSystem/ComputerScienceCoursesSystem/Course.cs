using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerScienceCoursesSystem
{
    public class Course
    {
        private string bbrNbr;
        private string name;
        private string description;
        /// <summary>
        /// //3-1-2021 Saung NEW 1L:Constructor for course
        /// </summary>
        public Course() { }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="bbrNbr"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// 

        //3-1-2021 Saung NEW 1L:Constructor for course and initializing strings
        public Course(string bbrNbr, string name, string description) {
            this.bbrNbr = bbrNbr;
            this.name = name;
            this.description = description;
        }
        //3-1-2021 Saung NEW 6L: get and set BbrNbr
        public string BbrNbr
        {
            get
            {
                return bbrNbr;
            }

            set
            {
                bbrNbr = value;
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
        //3-1-2021 Saung NEW 6L: get and set Description
        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }
    }
}
