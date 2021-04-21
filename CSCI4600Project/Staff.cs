using System;
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
        public string Gender { get; set; }
        public bool Permission { get; set; }
        public Staff(int sid, string fname, string lname, string gender, bool permission = true)
        {
            StaffId += 100;
            this.StaffId = sid;
            this.Firstname = fname;
            this.Lastname = lname;
            this.Gender = gender;
            this.Permission = permission;
        }

        public Staff()
        {

        }

        public string GetLastName()
        {
            return Lastname;
        }

        public string GetGender()
        {
            return Gender;
        }

        public string GetFirstName()
        {
            return Firstname;
        }

        public string info()
        {
            string s = Firstname;
            return s;
        }
    }
}
