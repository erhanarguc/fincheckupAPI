namespace fincheckup.Models.Qnb
{
    public class LoginInputModel
    {
        public string clientId { get; set; }
        public string clientSecret { get; set; }
        public string grantType { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public LoginInputModel(string clientId_, string clientSecret_, string grantType_, string username_, string password_)
        {

            clientId = clientId_;
            clientSecret = clientSecret_;
            grantType = grantType_;
            username = username_;
            password = password_;


        }
    }

    public class SubmissionModel
    {
        public string identityNumber { get; set; }


        public SubmissionModel(string identityNumber_)
        {

            identityNumber = identityNumber_;
        }
    }
    public class SubmissionModelT
    {
        public string vknTckn { get; set; }
        public string identityNumber { get; set; }


        public SubmissionModelT(string identityNumber_, string vknTcknr_)
        {

            identityNumber = identityNumber_;
            vknTckn = vknTcknr_;
        }
    }
    public class GetTokenResponse
    {
        public string requestId { get; set; }
        public string statusCode { get; set; }
        public string resultCode { get; set; }
        public string exceptionCode { get; set; }
        public string resultDescription { get; set; }
        public string expDescription { get; set; }
        public string accessToken { get; set; }
    }


    public class SubmissionResponse
    {
        public string requestId { get; set; }
        public string statusCode { get; set; }
        public string resultCode { get; set; }
        public string exceptionCode { get; set; }
        public string resultDescription { get; set; }
        public string expDescription { get; set; }
    }

}
