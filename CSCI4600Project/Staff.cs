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
        public int staffId { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public Staff(int sid, string fname, string lname)
        {
            this.staffId = sid;
            this.firstname = fname;
            this.lastname = lname;
        }

        public Staff()
        {

        }

        public string info()
        {
            string s = firstname + " " + lastname;
            return s;
        }
    }
}
