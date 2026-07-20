

namespace fincheckup.Models.Responses
{
    public class TokenResponse : ResponseWrapper
    {
        public TokenData Data { get; set; }
        public class TokenData
        {
            public string token { get; set; }
            public string is_3d { get; set; }

        }
    }
}
