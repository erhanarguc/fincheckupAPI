using System.Collections.Generic;

namespace fincheckup.Models.Hvvn
{
    public class EmailTemplates : BaseModel
    {

        public int ID { get; set; }

        public string EmailTemp { get; set; }

        public string EmailType { get; set; }

        public static IEnumerable<EmailTemplates> Get_All()
        {
            return StaticQuery<EmailTemplates>("Select * From [EmailTemplates]");
        }

    }
}