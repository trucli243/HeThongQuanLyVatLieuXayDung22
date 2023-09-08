using HeThongQuanLyVatTuXayDung22.Common.Req;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyVatTuXayDung22.Common.BLL
{
    public class UserScv : IUserSvc
    {
       
        public Task<bool> Authencate(LoginReq request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Register(RegisterReq request)
        {
            throw new NotImplementedException();
        }
    }
}

