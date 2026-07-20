using System.Collections.Generic;
using System.Linq;

namespace fincheckup.Models.Hvvn
{
    public class Cities : BaseModel
    {

        public int ID { get; set; }
        public string City { get; set; }

        public static IEnumerable<Cities> Get_Cities()
        {
            return StaticQuery<Cities>("Select * From [Cities]");
        }
        public static Cities GetRow_Cities(int _ID)
        {
            return StaticQuery<Cities>("Select * From [Cities] where ID=@ID ", new { ID = _ID }).FirstOrDefault();
        }

        public void Save_Cities()
        {
            string sql = @"  INSERT INTO [Cities]
          ( 
        [City] 
          ) 
           VALUES 
         ( 
        @City 
         )  ;select  Cast(SCOPE_IDENTITY() as Int)";
            this.ID = Query<int>(sql, this).FirstOrDefault();
        }

        public bool Update_Cities()
        {
            try
            {
                string sql = "UPDATE   [Cities] SET  [City]=@City  WHERE [ID]=@ID";
                Execute(sql, this);
                return true;
            }
            catch
            {
                throw;
            }
        }
    }

    public class NaceCode : BaseModel
    {

        public int ID { get; set; }
        public string Code { get; set; }
        public string MainDescription { get; set; }
        public string Description { get; set; }
        public string ManCode { get; set; }

        public static IEnumerable<NaceCode> Get_NaceCode()
        {
            return StaticQuery<NaceCode>("Select * From NACECODEMain");
        }
        public static NaceCode GetRow_NaceCodes(int _ID)
        {
            return StaticQuery<NaceCode>("Select * From [NACECODEMain] where ID=@ID ", new { ID = _ID }).FirstOrDefault();
        }
        public static string Get_Description(string _nacecode)
        {
            return StaticQuery<string>("Select top 1 Description From [NACECODEMain] where ID=@ID ", new { ID = _nacecode }).FirstOrDefault();
        }

    }

}