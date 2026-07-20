using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace fincheckup.Models.Hvvn
{
    public class HhvnUsers : BaseModel
    {

        public HhvnUsers()
        {
            CompanyList = new List<long>();

        }
        public int ID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Şehir Bilgisi Seçilmelidir ")]
        public int CityID { get; set; }
        public long CompanyID { get; set; }
        public bool IsDeleted { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Kullnıcı Tipi Bilgisi Seçilmelidir ")]
        public Int16 UserTypeID { get; set; }
        public List<long> CompanyList { get; set; }
        public string PasswordReset { get; set; }
        public string Password { get; set; }
        private string profilePhoto;
        public string SessionGuid { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }

        public string CityName => string.Empty;
        public string UserType => UserTypes.Get_Types(this.UserTypeID) == null ? "Customer" : UserTypes.Get_Types(this.UserTypeID).Type;
        public string ProfilePhoto
        {
            get { return profilePhoto; }

            set
            {
                if (string.IsNullOrEmpty(value))
                { profilePhoto = "https://www.fincheckup.ai/cus.png"; }
                else
                {
                    profilePhoto = value;

                }
            }
        }
        public string FullName => FirstName + " " + LastName;
        private int selectedYear { get; set; }
        public int SelectedYear
        {
            get { return selectedYear; }
            set
            {
                if (value < 2010) { selectedYear = DateTime.Now.Year; }
                else
                {
                    selectedYear = value;
                }
            }
        }

        public string qnbUserId { get; set; }
        public string qnbCorporateId { get; set; }
        public string mainPlatform { get; set; }
        public byte isAdminUser { get; set; }
        public string AccessToken { get; set; }

        public string UserGuid { get; set; }
        public static IEnumerable<HhvnUsers> Get_All()
        {
            return StaticQuery<HhvnUsers>("Select * From [User]");
        }

        public static List<int> Get_AllMAsters()
        {
            return StaticQuery<int>("Select DISTINCT(ID) From [User] where UserTypeID in (4,1001)").ToList();
        }
        public static int SetYearMain(long _compID, long _userid)
        {
            return StaticQuery<int>(@" declare @yearcount int =ISNULL((SELECT Count(DISTINCT(YEAR)) from TBLXml where CompanyID=@ID),0);
IF @yearcount = 0
BEGIN 
UPDATE   [dbo].[User] set selectedYear=(SELECT YEAR(getdate())) where ID =@userID 

END
ELSE
BEGIN 
IF @yearcount<2
BEGIN
UPDATE   [dbo].[User] set selectedYear=(SELECT TOP 1 Year from TBLXml where CompanyID=@ID) where ID =@userID 
END
END
", new { ID = _compID, userID = _userid }).FirstOrDefault();

        }
        public static int SetYear(int _year, long _userid)
        {
            return StaticQuery<int>(@"UPDATE   [dbo].[User] set selectedYear=@year where ID =@ID ", new { ID = _userid, year = _year }).FirstOrDefault();

        }
        public static int ViewCountUp(int _ID)
        {
            return StaticQuery<int>(@"UPDATE   [dbo].[User] set ViewCount=ViewCount+1   where ID =@ID ", new { ID = _ID }).FirstOrDefault();

        }
        public static IEnumerable<HhvnUsers> GetByAdminUser(long _ID)
        {
            return StaticQuery<HhvnUsers>(@"Select * from [User] Where ID in  (SELECT DISTINCT([UserID] )   FROM [dbo].[UserCompany] where[CompanyID] in (Select t.ID From[Company] as t JOIN UserCompany as u on t.ID=u.CompanyID where u.UserID=@ide))", new { ide = _ID });

        }

        public static HhvnUsers GetUserbyGuid(string gdi)
        {
            HhvnUsers hvvn = StaticQuery<HhvnUsers>(@"Select * from [User] Where AccessToken=@nguid and [IsDeleted]=0", new { nguid = gdi }).FirstOrDefault();
            // canlıda açılacak alttaki satır
            //StaticQuery<HhvnUsers>(@"UPDATE  [User] Set  AccessToken=''  Where AccessToken=@nguid", new { nguid = gdi }).FirstOrDefault();
            return hvvn;

        }
        // 
        public static int DeleteUser(long _ID)
        {
            return StaticQuery<int>("Update  [User] set IsDeleted=1 where ID=@ID ", new { ID = _ID }).FirstOrDefault();
        }
        public static (int, IEnumerable<HhvnUsers>) ListView(int page, int count, string status, int requestID = -1)
        {
            string sql = @"Select * From [User] ";


            var totalSql = "SELECT COUNT(*) FROM (" + sql + " ) QR";
            int totalCount = StaticQuery<int>(totalSql).FirstOrDefault();

            sql += " ORDER BY  ID desc OFFSET " + ((page - 1) * count).ToString() + " ROWS FETCH NEXT " + count.ToString() + " ROWS ONLY";

            var result = new List<HhvnUsers>();
            result = StaticQuery<HhvnUsers>(sql).ToList();


            return (totalCount, result);




        }
        public static HhvnUsers GetRow_User(long _ID)
        {
            return StaticQuery<HhvnUsers>("Select * From [User] where ID=@ID ", new { ID = _ID }).FirstOrDefault();
        }
        public static int GetRow_UserKonsolide(long _ID)
        {
            return StaticQuery<int>("Select Count(ID) from Company where MainCompanyID= (SELECT  [CompanyID]   FROM [EDEFTERDB].[dbo].[UserCompany] where [UserID]=@ID and [IsDefault]=1)", new { ID = _ID }).FirstOrDefault();
        }
        public static HhvnUsers GetRow_UserGuid(string _ID)
        {
            return StaticQuery<HhvnUsers>("Select * From [User] where  UserGuid=@ID ", new { ID = _ID }).FirstOrDefault();
        }
        public static HhvnUsers GetbyUrl(string pname)
        {
            return StaticQuery<HhvnUsers>("SELECT * FROM   [dbo].[User] where[AuthorUrl]=@p_name ", new { p_name = pname }).FirstOrDefault();
        }

        public static HhvnUsers GetPasswordwithAppUser(string _email)
        {
            try
            {
                return StaticQuery<HhvnUsers>("SELECT * FROM   [dbo].[User] WHERE Email=@p_email", new { p_email = _email }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                var chk = ex;
                throw;
            }

        }
        public void Save_User()
        {
            string sql = @"  INSERT INTO [User]
          ( 
        [FirstName] ,
        [LastName] , 
        [Phone] ,Email, 
        [CityID] , 
PasswordReset,Password,ProfilePhoto,IsDeleted,UserTypeID ,UserGuid
          ) 
           VALUES 
         ( 
        @FirstName ,
        @LastName , 
        @Phone ,@Email, 
        @CityID ,  @PasswordReset,@Password,@ProfilePhoto,0,@UserTypeID ,CONVERT(varchar(36), (SELECT NEWID()))
         )  ;select  Cast(SCOPE_IDENTITY() as Int)";
            this.ID = Query<int>(sql, this).FirstOrDefault();
        }

        public static bool CheckUser(long compid, long userid)
        {
            string sql = "SELECT  top 1   CASE WHEN EXISTS     (SELECT  cx.[ID]     FROM  [dbo].[UserCompany] as cx       WHERE cx.[CompanyID]=@qcomp and cx.[UserID]=@user)  THEN 1   ELSE 0   END FROM  [dbo].[UserCompany] ";
            return StaticQuery<bool>(sql, new { user = userid, qcomp = compid }).FirstOrDefault();
        }

        public bool Update_User()
        {
            try
            {
                string sql = "UPDATE   [User] SET  [FirstName]=@FirstName , [LastName]=@LastName , IsActive=@IsActive, [Phone]=@Phone ,  [CityID]=@CityID ,  SessionGuid=@SessionGuid,PasswordReset=@PasswordReset, ProfilePhoto=@ProfilePhoto,Email=@Email,IsDeleted=@IsDeleted,UserTypeID=@UserTypeID   WHERE [ID]=@ID";
                Execute(sql, this);
                return true;
            }
            catch
            {
                throw;
            }
        }

        public bool Update_Password()
        {
            try
            {
                string sql = "UPDATE  [User] SET Password=@Password WHERE [ID]=@ID";
                Execute(sql, this);
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
    public class HhvnUsersView : BaseModel
    {

        public int ID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string UserGuid { get; set; }
    }

    public class UserLogin : BaseModel
    {
        public long ID { get; set; }
        public long UserID { get; set; }
        public string UserIP { get; set; }
        public string UserBrowser { get; set; }
        public DateTime CreatedDate { get; set; }

        public void Save_User()
        {
            string sql = @"  INSERT INTO [UserLogin]
          ( 
        [UserID] ,
        [UserIP] , 
        [UserBrowser]   ,CreatedDate
          ) 
           VALUES 
         ( 
        @UserID ,
        @UserIP , 
        @UserBrowser ,getdate() 
         )  ;select  Cast(SCOPE_IDENTITY() as Int)";
            this.ID = Query<long>(sql, this).FirstOrDefault();
        }
    }
}