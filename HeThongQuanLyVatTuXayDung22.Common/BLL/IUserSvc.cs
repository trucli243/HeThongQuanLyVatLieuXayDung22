using HeThongQuanLyVatTuXayDung22.Common.Req;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyVatTuXayDung22.Common.BLL
{
   public interface IUserSvc
    {
        Task<bool> Authencate(LoginReq request);

        Task<bool> Register(RegisterReq request);
    }
}
