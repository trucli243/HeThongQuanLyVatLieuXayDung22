using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyVatTuXayDung22.Common.Req
{
    public class SearchCategoryReq
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public string Keyword { get; set; }
    }
}
