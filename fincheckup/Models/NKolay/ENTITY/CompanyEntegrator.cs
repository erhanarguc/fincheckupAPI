
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace fincheckup.ENTITY
{
    public class CompanyEntegrator : BaseModel
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactMail { get; set; }
        public string ContactGSM { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Şehir Bilgisi Seçilmelidir ")]
        public string City { get; set; }
        public int CityID { get; set; }
        public string State { get; set; }
        public string NaceCode { get; set; }
        public string Adress { get; set; }
        public string TaxID { get; set; }
        public string TaxOffice { get; set; }
        public string Notes { get; set; }
        public byte IsVisible { get; set; }

        public CompanyEntegrator(string companyName, string contactName, string contactMail, string contactGSM, string city, int cityID, string state, string naceCode, string adress, string taxID, string taxOffice, string notes, byte isVisible)
        {
            CompanyName = companyName;
            ContactName = contactName;
            ContactMail = contactMail;
            ContactGSM = contactGSM;
            City = city;
            CityID = cityID;
            State = state;
            NaceCode = naceCode;
            Adress = adress;
            TaxID = taxID;
            TaxOffice = taxOffice;
            Notes = notes;
            IsVisible = isVisible;
        }

        public static CompanyEntegrator Get_Company(long ide)
        {
            return StaticQuery<CompanyEntegrator>("SELECT Company.* ,Cities.City  FROM [dbo].[CompanyEntegrator] LEFT JOIN Cities on Company.CityID = Cities.ID  where  Company.ID=@ID", new { ID = ide }).FirstOrDefault();
        }
        public static Companies Get_CompanyRow(long ide)
        {
            return StaticQuery<Companies>("SELECT *  FROM [dbo].[CompanyEntegrator] where ID=@ID", new { ID = ide }).FirstOrDefault();
        }
        public static IEnumerable<CompanyEntegrator> Get_All()
        {
            return StaticQuery<CompanyEntegrator>("SELECT Company.* ,Cities.City  FROM [dbo].[CompanyEntegrator] LEFT JOIN Cities on Company.CityID = Cities.ID");
        }
        public void Save_Company()
        {
            string sql = @" 
IF NOT EXISTS
(
  SELECT
    *
  FROM
   [CompanyEntegrator]
  WHERE
    CompanyName = @CompanyName
    TaxID =@TaxID
)
BEGIN
INSERT INTO [CompanyEntegrator]
          (  
        [CompanyName] ,
        [ContactName] ,
        [ContactMail] ,
        [ContactGSM] ,
        [CityID] ,
        [State] ,
        [Adress] ,
        [TaxID] ,
        [TaxOffice] ,
        [Notes]  ,IsVisible
          ) 
           VALUES 
         (  
        @CompanyName ,
        @ContactName ,
        @ContactMail ,
        @ContactGSM ,
        @CityID ,
        @State ,
        @Adress ,
        @TaxID ,
        @TaxOffice ,
        @Notes  ,@IsVisible

         )  ;select  Cast(SCOPE_IDENTITY() as Int)

END

";
            this.ID = Query<int>(sql, this).FirstOrDefault();
        }

        public bool Update_Company()
        {
            try
            {
                string sql = "UPDATE   [CompanyEntegrator] SET    [CompanyName]=@CompanyName , [ContactName]=@ContactName , [ContactMail]=@ContactMail , [ContactGSM]=@ContactGSM , [CityID]=@CityID , [State]=@State , [Adress]=@Adress , [TaxID]=@TaxID , [TaxOffice]=@TaxOffice , [Notes]=@Notes, IsVisible=@IsVisible  WHERE [ID]=@ID";
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