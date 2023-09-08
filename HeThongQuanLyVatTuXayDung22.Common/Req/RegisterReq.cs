using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyVatTuXayDung22.Common.Req
{
   public class RegisterReq
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DoB { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
}
