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
        /// Constructor
        /// </summary>
        public Course() { }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="bbrNbr"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public Course(string bbrNbr, string name, string description) {
            this.bbrNbr = bbrNbr;
            this.name = name;
            this.description = description;
        }

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
