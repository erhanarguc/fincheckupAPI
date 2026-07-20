using System.Collections.Generic;
using System.Linq;

namespace fincheckup.Models.Hvvn
{
    public class UserTypes : BaseModel
    {
        public int ID { get; set; }
        public string Type { get; set; }

        public static List<UserTypes> Get_Types()
        {
            return StaticQuery<UserTypes>("Select * From   [dbo].[UserType]").ToList();
        }

        public static UserTypes Get_Types(int id)
        {
            return StaticQuery<UserTypes>("Select * From   [dbo].[UserType] where ID=@ide", new { ide = id }).FirstOrDefault();
        }
    }
}
