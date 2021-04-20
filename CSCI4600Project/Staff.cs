﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI4600Project
{
    [Serializable]
    public class Staff
    {
        public int StaffId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Staff(int sid, string fname, string lname)
        {
            this.StaffId = sid;
            this.Firstname = fname;
            this.Lastname = lname;
        }

        public Staff()
        {

        }

        public string info()
        {
            string s = Firstname + " " + Lastname;
            return s;
        }
    }
}
