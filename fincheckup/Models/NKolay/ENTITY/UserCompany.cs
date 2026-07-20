using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace fincheckup.ENTITY
{
    public class UserCompany : BaseModel
    {

        public int ID { get; set; }
        public long CompanyID { get; set; }
        public long UserID { get; set; }
        public int IsDefault { get; set; }

        public static IEnumerable<UserCompany> Get_All(string ide)
        {
            return StaticQuery<UserCompany>("Select * From [UserCompany]  where  CompanyID=@ID", new { ID = ide });
        }

        public static int setUpdateUser(long useride, long comide)
        {
            StaticQuery<int>("UPDATE   [UserCompany] set IsDefault=0 where  UserID=@ID ", new { ID = useride }).FirstOrDefault();
            return StaticQuery<int>("UPDATE   [UserCompany] set IsDefault=1 where  UserID=@ID  and CompanyID=@compid", new { ID = useride, compid = comide }).FirstOrDefault();
        }
        public static int DeleteUser(string ide)
        {
            return StaticQuery<int>("Delete From [UserCompany]  where  ID=@ID and IsAdmin='0'", new { ID = ide }).FirstOrDefault();
        }
        public static bool Update_UserCompany(long Userid_, List<long> companyid_)
        {
            try
            {
                var mreqListCompanyx = Companies.Getby_User(Userid_).Select(x => x.ID).ToList();
                var list3 = companyid_.Except(mreqListCompanyx).ToList();
                var list4 = mreqListCompanyx.Except(companyid_).ToList();
                if (companyid_.Count() > 0 && Userid_ > 0 && (list3.Count() > 0 || list4.Count() > 0))
                {
                    string sql = "DELETE FROM   [UserCompany]  WHERE UserID=@userid ";
                    StaticExecute(sql, new { userid = Userid_ });
                    sql = "INSERT INTO   [UserCompany](CompanyID,UserID) VALUES(@companyid,@userid)";
                    foreach (var item in companyid_)
                    {
                        StaticExecute(sql, new { userid = Userid_, companyid = item });
                    }

                    sql = "UPDATE   [UserCompany] SET  [IsDefault]=1  WHERE [CompanyID]=@companyid and UserID=@userid";
                    StaticExecute(sql, new { userid = Userid_, companyid = companyid_.FirstOrDefault() });
                }

                return true;
            }
            catch
            {
                throw;
            }
        }
        public static bool Update_UserDefault(long Userid_, int companyid_)
        {
            try
            {
                string sql = "UPDATE   [UserCompany] SET  [IsDefault]=0  WHERE UserID=@userid ;UPDATE   [UserCompany] SET  [IsDefault]=1  WHERE [CompanyID]=@companyid and UserID=@userid ; ";
                StaticExecute(sql, new { userid = Userid_, companyid = companyid_ });
                return true;
            }
            catch
            {
                throw;
            }
        }
        public bool Update_User()
        {
            try
            {
                string sql = "UPDATE   [UserCompany] SET  [CompanyID]=@CompanyID , [UserID]=@UserID , [IsDefault]=@IsDefault WHERE [ID]=@ID";
                Execute(sql, this);
                return true;
            }
            catch
            {
                throw;
            }
        }

        public void Save_User()
        {
            string sql = @"  INSERT INTO [UserCompany]
          (  
        [CompanyID] ,
        [UserID] ,
        [IsDefault]    
          ) 
           VALUES 
         (  
        @CompanyID ,
        @UserID ,
        @IsDefault   
         )  ;select  Cast(SCOPE_IDENTITY() as Int)";
            this.ID = Query<int>(sql, this).FirstOrDefault();
        }
        public static string HashText(string text, HashAlgorithm hasher)
        {
            byte[] textWithSaltBytes = Encoding.UTF8.GetBytes(string.Concat(text, "MySecretSalt"));
            byte[] hashedBytes = hasher.ComputeHash(textWithSaltBytes);
            hasher.Clear();
            return Convert.ToBase64String(hashedBytes);
        }
    }
}
