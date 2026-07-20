using fincheckup.Models.ViewM;
using System.Collections.Generic;

namespace fincheckup.Models.NKolay.UploadArea
{
    public class UploadMain : BaseModel
    {
        public static IEnumerable<YearlyUploadResult> Get_Data(int _year, long _compID)
        {
            return StaticQuery<YearlyUploadResult>("EXEC SP_GETYEARLYRESULT @nyear,@companyID", new { nyear = _year, companyID = _compID });
        }
    }
}
