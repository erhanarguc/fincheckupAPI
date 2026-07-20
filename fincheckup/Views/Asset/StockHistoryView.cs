using System;
using System.Collections.Generic;

namespace fincheckup.Views.Asset
{
    public class StockHistoryView : BaseModel
    {
        public int StockHistoryID { get; set; }
        public int Piece { get; set; }
        public string InStoreName { get; set; }
        public string OutStoreName { get; set; }
        public string SerialNumber { get; set; }
        public DateTime ModifiedDate { get; set; }


        public static IEnumerable<StockHistoryView> StockHistoryList(string serialNumber)
        {
            return StaticQuery<StockHistoryView>("SELECT StockHistoryID,SerialNumber,(select StoreName from [AssetManagement].[Store] where StoreID=InStoreID)as InStoreName,(select StoreName from [AssetManagement].[Store] where StoreID=OutStoreID)as OutStoreName, Piece ,ModifiedDate FROM [AssetManagement].[StockHistory] (NOLOCK) where SerialNumber=@p_serialNumber and Piece!=0 ", new { p_serialNumber = serialNumber });
        }
    }
}
