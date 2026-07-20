using System.Collections.Generic;
using System.Linq;

namespace fincheckup.Models.Hvvn
{
    public class Districts : BaseModel
    {

        public int ID { get; set; }
        public string District { get; set; }
        public int CityID { get; set; }

        public static IEnumerable<Districts> Get_Districts()
        {
            return StaticQuery<Districts>("Select * From [Districts]");
        }
        public static Districts GetRow_Districts(int _ID)
        {
            return StaticQuery<Districts>("Select * From [Districts] where ID=@ID ", new { ID = _ID }).FirstOrDefault();
        }
        public static List<Districts> GetbyCityID(int _ID)
        {
            return StaticQuery<Districts>("Select * From [Districts] where CityID=@ID ", new { ID = _ID }).ToList();
        }
        public void Save_Districts()
        {
            string sql = @"  INSERT INTO [Districts]
          ( 
        [District] ,
        [CityID] 
          ) 
           VALUES 
         ( 
        @District ,
        @CityID 
         )  ;select  Cast(SCOPE_IDENTITY() as Int)";
            this.ID = Query<int>(sql, this).FirstOrDefault();
        }

        public bool Update_Districts()
        {
            try
            {
                string sql = "UPDATE   [Districts] SET  [District]=@District , [CityID]=@CityID  WHERE [ID]=@ID";
                Execute(sql, this);
                return true;
            }
            catch
            {
                throw;
            }
        }
    }

}