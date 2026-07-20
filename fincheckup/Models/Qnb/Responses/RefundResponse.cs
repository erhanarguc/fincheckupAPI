

namespace fincheckup.Models.Responses
{
    public class RefundResponse : ResponseWrapper
    {
        public string order_no { get; set; }
        public string invoice_id { get; set; }
        public string ref_no { get; set; }
    }
}

