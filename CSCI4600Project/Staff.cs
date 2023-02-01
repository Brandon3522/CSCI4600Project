using System;
using System.Collections.Generic;

namespace CSCI4600Project
{
    [Serializable]
    public class Staff
    {
        public Guid StaffId { get; set; }  // Global Unique Identifier
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public bool Permission { get; set; }
        public string Password { get; set; }

        public Staff(string fname, string lname, string gender, bool permission = true)
        {
            this.StaffId = Guid.NewGuid();
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
