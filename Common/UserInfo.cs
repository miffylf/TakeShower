using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class UserInfo
    {
        public string errcode { get; set; }

        public string unionid { get; set; }
        public string remark { get; set; }
        public string userid { get; set; }
        //public string isLeaderInDepts { get; set; }
        public string isBoss { get; set; }
        public string hiredDate { get; set; }
        public string isSenior { get; set; }
        public string tel { get; set; }
        //public string department { get; set; }
        public string workPlace { get; set; }
        public string email { get; set; }
        public string orderInDepts { get; set; }
        public string mobile { get; set; }
        public string errmsg { get; set; }
        public string active { get; set; }
        public string avatar { get; set; }
        public string isAdmin { get; set; }
        public string isHide { get; set; }
        public string jobnumber { get; set; }
        public string name { get; set; }
        //public string extattr { get; set; }
        public string stateCode { get; set; }
        public string position { get; set; }
        //public Roles roles { get; set; }

    }

    public class Roles
    {
        public int id { get; set; }
        public string name { get; set; }
        public string groupName { get; set; }
    }
}
