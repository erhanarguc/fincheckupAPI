using System.Collections.Generic;
using System.Linq;

namespace fincheckup.Models.NKolay.ENTITY.Beyanname
{

    public class BeyannameResult : BaseModel
    {
        public static List<TBLBeyanname> Get_MizanResult()
        {
            return StaticQuery<TBLBeyanname>("SELECT * FROM [dbo].[TBLBeyanname]  ").ToList();
        }
    }
    public class TBLBeyanname
    {
        public int ID { get; set; }
        public string MainID { get; set; }
        public string SubID { get; set; }
        public char FirstChar { get; set; }
        public string MainDescription { get; set; }
        public string CodeNCode { get; set; }
        public byte IsRevenue { get; set; }
    }
}
