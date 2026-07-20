using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace fincheckup.Models.NKolay.json
{
    public class XMlook
    {

        public int id { get; set; }
        public string ide { get; set; }
        public string idexml { get; set; }
        public List<IFormFile> file { get; set; } = new List<IFormFile>();
        public string Caption { get; set; }

    }


    public class XMlookUpdate
    {
        public string caplist { get; set; }
        public long companyid { get; set; }
        public int month { get; set; }
        public int year { get; set; }

    }
}
