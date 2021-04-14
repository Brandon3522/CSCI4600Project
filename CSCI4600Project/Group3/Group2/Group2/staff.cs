using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group2
{
    class Staff
    {
        public int staffId;
        public string firstname;
        public string lastname;
        public Staff(int sid, string fname, string lname)
        {
            this.staffId = sid;
            this.firstname = fname;
            this.lastname = lname;
        }
        
        public string info()
        {
            string s = firstname + " " + lastname;
            return s;
        }
    }
}
