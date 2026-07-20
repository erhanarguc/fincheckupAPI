using fincheckup.Models.NKolay.json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace fincheckup.Models.NKolay.ENTITY
{
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
    public class bulten : BaseModel
#pragma warning restore CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
    {



        public int ID { get; set; }
        public string Title { get; set; }

        private string titleShort { get; set; }
        public string TitleShort
        {
            get
            {
                if (!String.IsNullOrEmpty(Title))
                {
                    titleShort = Title.Length > 25 ? Title.Substring(0, 24) : Title;
                    return titleShort;
                }
                else
                {
                    titleShort = string.Empty;
                    return titleShort;
                }
            }
            set
            {
            }
        }


        public string SubTitle { get; set; }
        public string Kapsam { get; set; }
        public DateTime YururlulukTarih { get; set; }
        public string DuzenleyenKurum { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedUser { get; set; }

        public static bulten Get_bulten(int ide)
        {
            return StaticQuery<bulten>("Select * From  [dbo].[BULTEN] where ID=@ID", new { ID = ide }).FirstOrDefault();
        }

        public static IEnumerable<BWarn> Get_BWarn()
        {
            return StaticQuery<BWarn>("Select * From  [dbo].[BWarn]" );
        }

        public static IEnumerable<BWarn> Get_BWarnCPM()
        {
            return StaticQuery<BWarn>("Select * From  [dbo].[BWarnSil]");
        }
        public static IEnumerable<bulten> Get_All(int year_)
        {
            return StaticQuery<bulten>("Select * FROM  [dbo].[BULTEN] where YEAR([YururlulukTarih])=@year", new { year = year_ });
        }

        public void Save_()
        {
            string sql = @"  INSERT INTO  [dbo].[BULTEN]
          (  
        [Title] ,
        [SubTitle] ,
        [Kapsam] ,
        [YururlulukTarih] ,
        [DuzenleyenKurum] ,
        [Description] , 
        [CreatedUser]  
          ) 
           VALUES 
         (  
        @Title ,
        @SubTitle ,
        @Kapsam ,
        @YururlulukTarih,
        @DuzenleyenKurum,
        @Description , 
        @CreatedUser  

         )  ;select  Cast(SCOPE_IDENTITY() as Int)";
            this.ID = Query<int>(sql, this).FirstOrDefault();
        }
        public static void Save_Apintment(Appointment apnt)
        {
            string sql = @"  INSERT INTO  [dbo].[Appointment]
          (  
        [Text] ,
        [Description] ,
        [StartDate] ,
        [EndDate] ,
        [AllDay] ,
        [PriorityId] , 
        [Status]  
          ) 
           VALUES 
         (  
        @Text ,
        @Description ,
        @StartDate ,
        @EndDate,
        @AllDay,
        @PriorityId , 
        @Status  

         )  ;select  Cast(SCOPE_IDENTITY() as Int)";
            StaticQuery<int>(sql, apnt).FirstOrDefault();


        }
        public static void UpdateApintment(Appointment apnt)
        {
            string sql = @" UPDATE [dbo].[Appointment]
         SET  Text=@Text, Description=@Description, StartDate=@StartDate, EndDate=@EndDate, AllDay=@AllDay, PriorityId=@PriorityId, Status=@Status WHERE AppointmentId=@AppointmentId";
            StaticQuery<int>(sql, apnt).FirstOrDefault();


        }
        public static Appointment Getapintment(int apnt_)
        {
            string sql = @" SELECT * from  [dbo].[Appointment] WHERE AppointmentId=@apnt";
            return StaticQuery<Appointment>(sql, new { apnt = apnt_ }).FirstOrDefault();


        }
        public static void DELETEApintment(int apnt_)
        {
            string sql = @" DELETE from  [dbo].[Appointment] WHERE AppointmentId=@apnt";
            StaticQuery<int>(sql, new { apnt = apnt_ }).FirstOrDefault();


        }
        public void Update_()
        {
            string sql = @"UPDATE  [dbo].[BULTEN] SET 
        [Title] =@Title,
        [SubTitle] = @SubTitle,
        [Kapsam] =@Kapsam,
        [YururlulukTarih]=@YururlulukTarih,
        [DuzenleyenKurum]=@DuzenleyenKurum,
        [Description]=@Description , 
        [CreatedUser]=@CreatedUser
        WHERE ID=@ID ";
            Query<int>(sql, this).FirstOrDefault();
        }

    }

    public class BWarn
    {

        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
