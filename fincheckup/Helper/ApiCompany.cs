using DevExpress.XtraRichEdit.Commands;
using fincheckup.ENTITY;
using fincheckup.Models.Hvvn;
using System;

namespace fincheckup.Helper
{
    public class ApiCompany
    {
        public string taxPayer { get; set; }
        public int documentType { get; set; }
        public string accessStartDate { get; set; }
        public string accessEndDate { get; set; }
        public string companyWebPassword { get; set; }
        public string companyWebUser { get; set; }
        public string permissionTargetCode { get; set; }
        public string companyPortalUser { get; set; }
        public string companyPortalPassword { get; set; }
        public compannyUser companyUser { get; set; }
        public companny company { get; set; }

        public static ApiCompany CreateNew(Companies com, HhvnUsers usr)
        {
            ApiCompany ncom = new ApiCompany();
            compannyUser nusr = new compannyUser();
            companny ncomm = new companny();

            ncom.documentType = 1;
            ncom.accessStartDate = DateTime.Now.ToString("yyyy-MM-dd");
            ncom.accessEndDate = DateTime.Now.AddYears(1).ToString("yyyy-MM-dd");
            nusr.email=usr.Email;
            nusr.name =usr.FirstName;
            nusr.phoneNumber = usr.Phone;
            nusr.surName=usr.LastName;
            ncomm.phoneNumber = com.ContactGSM;
            ncomm.mail = com.ContactMail;
            ncomm.taxNumber = com.TaxID;
            ncomm.address = com.Adress;
            ncomm.title = com.CompanyName;
            ncomm.taxOffice = com.TaxOffice;
            ncomm.district = "string";
            nusr.birthDate = "string";
            nusr.identityNumber = "string";
            nusr.userPosition = "string";
            ncom.taxPayer = com.TaxID;
            ncom.companyPortalPassword = "string";
            ncom.companyPortalUser = "string";
            ncom.companyWebPassword = "string";
            ncom.companyWebUser = "string";
            ncom.permissionTargetCode = "NEF";
            ncom.company=ncomm;
            ncom.companyUser=nusr;
            return ncom;



        }
    }

 

public class compannyUser
{
    public string name { get; set; }
    public string surName { get; set; }
    public string phoneNumber { get; set; }
    public string birthDate { get; set; }
    public string identityNumber { get; set; }
    public string email { get; set; }
    public string userPosition { get; set; }
}

public class companny
{
    public string title { get; set; }
    public string taxNumber { get; set; }
    public string taxOffice { get; set; }
    public string address { get; set; }
    public string district { get; set; }
    public string phoneNumber { get; set; }
    public string mail { get; set; }
}


}