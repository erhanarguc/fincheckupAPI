using fincheckup.Models.Mizan;
using fincheckup.Models.NKolay.MizanView;
using fincheckup.Models.ViewM;
using Microsoft.Data.SqlClient.Server;
using System.Collections.Generic;
using System.Data;

namespace fincheckup.ENTITY
{
    public class DataCollection : List<Dataz>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {

            var sqlRow = new SqlDataRecord(
                       new SqlMetaData("StartDate", SqlDbType.VarChar, 150),
                       new SqlMetaData("EndDate", SqlDbType.DateTime),
                       new SqlMetaData("EnteredBy", SqlDbType.VarChar, 100),
                       new SqlMetaData("EnteredDate", SqlDbType.VarChar, 100),
                       new SqlMetaData("EntryNumber", SqlDbType.VarChar, 10),
                       new SqlMetaData("EntryComment", SqlDbType.VarChar, 450),
                       new SqlMetaData("BatchID", SqlDbType.VarChar, 100),
                       new SqlMetaData("BatchDescription", SqlDbType.VarChar, 100),
                       new SqlMetaData("TotalDebit", SqlDbType.Float),
                       new SqlMetaData("TotalCredit", SqlDbType.Float),
                       new SqlMetaData("DocumentType", SqlDbType.VarChar, 150),
                       new SqlMetaData("DocumentTypeDescription", SqlDbType.VarChar, 400),
                       new SqlMetaData("DocumentNumber", SqlDbType.VarChar, 100),
                       new SqlMetaData("DocumentDate", SqlDbType.VarChar, 110),
                       new SqlMetaData("PaymentMethod", SqlDbType.VarChar, 150),
                       new SqlMetaData("AccountMainID", SqlDbType.VarChar, 100),
                       new SqlMetaData("AccountMainDescription", SqlDbType.VarChar, 400),
                       new SqlMetaData("AccountSubDescription", SqlDbType.VarChar, 440),
                       new SqlMetaData("AccountSubID", SqlDbType.VarChar, 100),
                       new SqlMetaData("Amount", SqlDbType.Float),
                       new SqlMetaData("DebitCreditCode", SqlDbType.VarChar, 150),
                       new SqlMetaData("PostingDate", SqlDbType.VarChar, 100),
                       new SqlMetaData("DetailComment", SqlDbType.VarChar, 400),
                       new SqlMetaData("CsvID", SqlDbType.Int));
            foreach (Dataz cust in this)
            {
                sqlRow.SetString(0, cust.StartDate);
                sqlRow.SetDateTime(1, cust.EndDate);
                sqlRow.SetString(2, cust.EnteredBy);
                sqlRow.SetString(3, cust.EnteredDate);
                sqlRow.SetString(4, cust.EntryNumber);
                sqlRow.SetString(5, cust.EntryComment);
                sqlRow.SetString(6, cust.BatchID);
                sqlRow.SetString(7, cust.BatchDescription);
                sqlRow.SetDouble(8, cust.TotalDebit);
                sqlRow.SetDouble(9, cust.TotalCredit);
                sqlRow.SetString(10, cust.DocumentType);
                sqlRow.SetString(11, cust.DocumentTypeDescription);
                sqlRow.SetString(12, cust.DocumentNumber);
                sqlRow.SetString(13, cust.DocumentDate);
                sqlRow.SetString(14, cust.PaymentMethod);
                sqlRow.SetString(15, cust.AccountMainID);
                sqlRow.SetString(16, cust.AccountMainDescription);
                sqlRow.SetString(17, cust.AccountSubDescription);
                sqlRow.SetString(18, cust.AccountSubID);
                sqlRow.SetDouble(19, cust.Amount);
                sqlRow.SetString(20, cust.DebitCreditCode);
                sqlRow.SetString(21, cust.PostingDate);
                sqlRow.SetString(22, cust.DetailComment);
                sqlRow.SetInt64(23, cust.CsvID);
                yield return sqlRow;
            }
        }
    }

    public class DataCollectionBlnc : List<DashBilancoView>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {

            var sqlRow = new SqlDataRecord(
                       new SqlMetaData("AccountMainID", SqlDbType.VarChar, 50),
                       new SqlMetaData("AccountMainDescription", SqlDbType.VarChar, 350),
                       new SqlMetaData("DebitCreditCode", SqlDbType.VarChar, 15),
                       new SqlMetaData("Acilis", SqlDbType.Float),
                       new SqlMetaData("January", SqlDbType.Float),
                       new SqlMetaData("February", SqlDbType.Float),
                       new SqlMetaData("March", SqlDbType.Float),
                       new SqlMetaData("April", SqlDbType.Float),
                       new SqlMetaData("May", SqlDbType.Float),
                       new SqlMetaData("June", SqlDbType.Float),
                       new SqlMetaData("July", SqlDbType.Float),
                       new SqlMetaData("August", SqlDbType.Float),
                       new SqlMetaData("September", SqlDbType.Float),
                       new SqlMetaData("October", SqlDbType.Float),
                       new SqlMetaData("November", SqlDbType.Float),
                       new SqlMetaData("December", SqlDbType.Float),
                       new SqlMetaData("CompanyID", SqlDbType.BigInt),
                       new SqlMetaData("Year", SqlDbType.Int),
                       new SqlMetaData("GroupName", SqlDbType.VarChar, 350),
                       new SqlMetaData("CounterZone", SqlDbType.Int),
                       new SqlMetaData("TypeID", SqlDbType.Int),
                       new SqlMetaData("IsHidden", SqlDbType.Int)
                       );
            foreach (DashBilancoView cust in this)
            {
                sqlRow.SetString(0, cust.AccountMainID == null ? string.Empty : cust.AccountMainID);
                sqlRow.SetString(1, cust.AccountMainDescription == null ? string.Empty : cust.AccountMainDescription);
                sqlRow.SetString(2, string.Empty);
                sqlRow.SetDouble(3, cust.Acilis);
                sqlRow.SetDouble(4, cust.January);
                sqlRow.SetDouble(5, cust.February);
                sqlRow.SetDouble(6, cust.March);
                sqlRow.SetDouble(7, cust.April);
                sqlRow.SetDouble(8, cust.May);
                sqlRow.SetDouble(9, cust.June);
                sqlRow.SetDouble(10, cust.July);
                sqlRow.SetDouble(11, cust.August);
                sqlRow.SetDouble(12, cust.September);
                sqlRow.SetDouble(13, cust.October);
                sqlRow.SetDouble(14, cust.November);
                sqlRow.SetDouble(15, cust.December);
                sqlRow.SetInt64(16, cust.CompanyID);
                sqlRow.SetInt32(17, cust.Year);
                sqlRow.SetString(18, cust.GroupName);
                sqlRow.SetInt32(19, cust.CounterZone);
                sqlRow.SetInt32(20, cust.TypeID);
                sqlRow.SetInt32(21, cust.IsHidden);
                yield return sqlRow;
            }
        }
    }
    public class DataCollectionBlncMzn : List<DashBilancoViewMizan>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {

            var sqlRow = new SqlDataRecord(
                       new SqlMetaData("AccountMainID", SqlDbType.VarChar, 50),
                       new SqlMetaData("AccountMainDescription", SqlDbType.VarChar, 350),
                       new SqlMetaData("DebitCreditCode", SqlDbType.VarChar, 15),
                       new SqlMetaData("Amount", SqlDbType.Float),
                       new SqlMetaData("CompanyID", SqlDbType.BigInt),
                       new SqlMetaData("Year", SqlDbType.Int),
                       new SqlMetaData("GroupName", SqlDbType.VarChar, 350),
                       new SqlMetaData("CounterZone", SqlDbType.Int),
                       new SqlMetaData("TypeID", SqlDbType.Int),
                       new SqlMetaData("IsHidden", SqlDbType.Int)
                       );
            foreach (DashBilancoViewMizan cust in this)
            {
                sqlRow.SetString(0, cust.AccountMainID == null ? string.Empty : cust.AccountMainID);
                sqlRow.SetString(1, cust.AccountMainDescription == null ? string.Empty : cust.AccountMainDescription);
                sqlRow.SetString(2, string.Empty);
                sqlRow.SetDouble(3, cust.Amount);
                sqlRow.SetInt64(4, cust.CompanyID);
                sqlRow.SetInt32(5, cust.Year);
                sqlRow.SetString(6, cust.GroupName);
                sqlRow.SetInt32(7, cust.CounterZone);
                sqlRow.SetInt32(8, cust.TypeID);
                sqlRow.SetInt32(9, cust.IsHidden);
                yield return sqlRow;
            }
        }
    }
    public class DataCollectionBlncQnb : List<DashBilancoViewQnb>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {


            var sqlRow = new SqlDataRecord(
                       new SqlMetaData("AccountMainID", SqlDbType.VarChar, 50),
                       new SqlMetaData("AccountMainDescription", SqlDbType.VarChar, 350),
                       new SqlMetaData("DebitCreditCode", SqlDbType.VarChar, 15),
                       new SqlMetaData("Amount", SqlDbType.Float),
                       new SqlMetaData("CompanyID", SqlDbType.BigInt),
                       new SqlMetaData("Year", SqlDbType.Int),
                       new SqlMetaData("GroupName", SqlDbType.VarChar, 350),
                       new SqlMetaData("CounterZone", SqlDbType.Int),
                       new SqlMetaData("TypeID", SqlDbType.Int),
                       new SqlMetaData("IsHidden", SqlDbType.Int),
                       new SqlMetaData("MainTypeID", SqlDbType.TinyInt)
                       );
            foreach (DashBilancoViewQnb cust in this)
            {
                sqlRow.SetString(0, cust.AccountMainID == null ? string.Empty : cust.AccountMainID);
                sqlRow.SetString(1, cust.AccountMainDescription == null ? string.Empty : cust.AccountMainDescription);
                sqlRow.SetString(2, string.Empty);
                sqlRow.SetDouble(3, cust.Amount);
                sqlRow.SetInt64(4, cust.CompanyID);
                sqlRow.SetInt32(5, cust.Year);
                sqlRow.SetString(6, cust.GroupName);
                sqlRow.SetInt32(7, cust.CounterZone);
                sqlRow.SetInt32(8, cust.TypeID);
                sqlRow.SetInt32(9, cust.IsHidden);
                sqlRow.SetByte(10, cust.MainTypeID);
                yield return sqlRow;
            }
        }
    }
    public class DataCollectionBlncMznExcel : List<XmlExcel>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            var sqlRow = new SqlDataRecord(
                       new SqlMetaData("AccountMainID", SqlDbType.VarChar, 50),
                       new SqlMetaData("AccountMainDescription", SqlDbType.VarChar, 350),
                       new SqlMetaData("AmountBakiyeFloat", SqlDbType.Float),
                       new SqlMetaData("DebitBakiyeFloat", SqlDbType.Float),
                       new SqlMetaData("CreditBakiyeFloat", SqlDbType.Float),
                       new SqlMetaData("DebitBakiyeMainFloat", SqlDbType.Float),
                       new SqlMetaData("CreditBakiyeMainFloat", SqlDbType.Float),
                       new SqlMetaData("CompanyID", SqlDbType.BigInt),
                       new SqlMetaData("Year", SqlDbType.Int),
                       new SqlMetaData("MainMonth", SqlDbType.Int)
                       );
            foreach (XmlExcel cust in this)
            {
                sqlRow.SetString(0, cust.AccountMainID == null ? string.Empty : cust.AccountMainID.Trim());
                sqlRow.SetString(1, cust.AccountMainDescription == null ? string.Empty : cust.AccountMainDescription.Trim());
                sqlRow.SetDouble(2, cust.AmountBakiyeFloat);
                sqlRow.SetDouble(3, cust.DebitAmountFloat);
                sqlRow.SetDouble(4, cust.CreditAmountFloat);
                sqlRow.SetDouble(5, cust.DebitBakiyeMainFloat);
                sqlRow.SetDouble(6, cust.CreditBakiyeMainFloat);
                sqlRow.SetInt64(7, cust.CompanyID);
                sqlRow.SetInt32(8, cust.Year);
                sqlRow.SetInt32(9, cust.MainMonth);
                yield return sqlRow;
            }
        }
    }
    public class DataCollectionBlncMznExcelNew : List<XmlExcel>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            var sqlRow = new SqlDataRecord(
                       new SqlMetaData("AccountMainID", SqlDbType.VarChar, 50),
                       new SqlMetaData("AccountMainDescription", SqlDbType.VarChar, 350),
                       new SqlMetaData("AmountBakiyeFloat", SqlDbType.Float),
                       new SqlMetaData("DebitBakiyeFloat", SqlDbType.Float),
                       new SqlMetaData("CreditBakiyeFloat", SqlDbType.Float),
                       new SqlMetaData("DebitBakiyeMainFloat", SqlDbType.Float),
                       new SqlMetaData("CreditBakiyeMainFloat", SqlDbType.Float),
                       new SqlMetaData("CompanyID", SqlDbType.BigInt),
                       new SqlMetaData("Year", SqlDbType.Int),
                       new SqlMetaData("Month", SqlDbType.Int),
                       new SqlMetaData("CsvID", SqlDbType.BigInt)

                       );
            foreach (XmlExcel cust in this)
            {
                sqlRow.SetString(0, cust.AccountMainID == null ? string.Empty : cust.AccountMainID.Trim());
                sqlRow.SetString(1, cust.AccountMainDescription == null ? string.Empty : cust.AccountMainDescription.Trim());
                sqlRow.SetDouble(2, cust.AmountBakiyeFloat);
                sqlRow.SetDouble(3, cust.DebitAmountFloat);
                sqlRow.SetDouble(4, cust.CreditAmountFloat);
                sqlRow.SetDouble(5, cust.DebitBakiyeMainFloat);
                sqlRow.SetDouble(6, cust.CreditBakiyeMainFloat);
                sqlRow.SetInt64(7, cust.CompanyID);
                sqlRow.SetInt32(8, cust.Year);
                sqlRow.SetInt32(9, cust.MainMonth);
                sqlRow.SetInt64(10, cust.CsvID);
                yield return sqlRow;
            }
        }
    }

    public class DataCollectionBlncMznExcelPdf : List<TBLXMLSCheckpdfMizan>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            var sqlRow = new SqlDataRecord(
                       new SqlMetaData("AccountMainID", SqlDbType.VarChar, 50),
                       new SqlMetaData("AccountMainDescription", SqlDbType.VarChar, 250),
                       new SqlMetaData("Amount1", SqlDbType.Float),
                       new SqlMetaData("Amount1Diff", SqlDbType.Int),
                       new SqlMetaData("Amount2", SqlDbType.Float),
                       new SqlMetaData("Amount2Diff", SqlDbType.Int),
                       new SqlMetaData("Amount3", SqlDbType.Float),
                       new SqlMetaData("Amount3Diff", SqlDbType.Int),
                       new SqlMetaData("Amount4", SqlDbType.Float),
                       new SqlMetaData("Amount4Diff", SqlDbType.Int),
                       new SqlMetaData("CompanyID", SqlDbType.BigInt),
                       new SqlMetaData("Year", SqlDbType.Int),
                       new SqlMetaData("PageID", SqlDbType.Int),
                       new SqlMetaData("MainMonth", SqlDbType.TinyInt)
                       );
            foreach (TBLXMLSCheckpdfMizan cust in this)
            {
                sqlRow.SetString(0, cust.AccountMainID == null ? string.Empty : cust.AccountMainID.Trim());
                sqlRow.SetString(1, cust.AccountMainDescription == null ? string.Empty : cust.AccountMainDescription.Trim());
                sqlRow.SetDouble(2, cust.Amount1);
                sqlRow.SetInt32(3, cust.Amount1Diff);
                sqlRow.SetDouble(4, cust.Amount2);
                sqlRow.SetInt32(5, cust.Amount2Diff);
                sqlRow.SetDouble(6, cust.Amount3);
                sqlRow.SetInt32(7, cust.Amount3Diff);
                sqlRow.SetDouble(8, cust.Amount4);
                sqlRow.SetInt32(9, cust.Amount4Diff);
                sqlRow.SetInt64(10, cust.CompanyID);
                sqlRow.SetInt32(11, cust.Year);
                sqlRow.SetInt32(12, cust.PageID);
                sqlRow.SetByte(13, cust.MainMonth);
                yield return sqlRow;
            }
        }
    }
    public class DataCollectionBlncMznExcelSub : List<XmlExcel>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            var sqlRow = new SqlDataRecord(
                       new SqlMetaData("AccountMainID", SqlDbType.VarChar, 50),
                       new SqlMetaData("AccountSubID", SqlDbType.VarChar, 50),
                       new SqlMetaData("AccountSubDescription", SqlDbType.VarChar, 350),
                       new SqlMetaData("AmountBakiyeFloat", SqlDbType.Float),
                       new SqlMetaData("DebitBakiyeFloat", SqlDbType.Float),
                       new SqlMetaData("CreditBakiyeFloat", SqlDbType.Float),
                       new SqlMetaData("DebitBakiyeMainFloat", SqlDbType.Float),
                       new SqlMetaData("CreditBakiyeMainFloat", SqlDbType.Float),
                       new SqlMetaData("CompanyID", SqlDbType.BigInt),
                       new SqlMetaData("Year", SqlDbType.Int)
                       );
            foreach (XmlExcel cust in this)
            {
                sqlRow.SetString(0, cust.AccountMainIDMain == null ? string.Empty : cust.AccountMainIDMain.Trim());
                sqlRow.SetString(1, cust.AccountMainID == null ? string.Empty : cust.AccountMainID.Trim());
                sqlRow.SetString(2, cust.AccountMainDescription == null ? string.Empty : cust.AccountMainDescription.Trim());
                sqlRow.SetDouble(3, cust.AmountBakiyeFloat);
                sqlRow.SetDouble(4, cust.DebitAmountFloat);
                sqlRow.SetDouble(5, cust.CreditAmountFloat);
                sqlRow.SetDouble(6, cust.DebitBakiyeMainFloat);
                sqlRow.SetDouble(7, cust.CreditBakiyeMainFloat);
                sqlRow.SetInt64(8, cust.CompanyID);
                sqlRow.SetInt32(9, cust.Year);
                yield return sqlRow;
            }
        }
    }

    public class DataCollectionBlncMznPDFExcelSub : List<TBLXMLSCheckpdfMizan>, IEnumerable<SqlDataRecord>
    {
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            var sqlRow = new SqlDataRecord(
                       new SqlMetaData("AccountMainID", SqlDbType.VarChar, 50),
                       new SqlMetaData("AccountMainDescription", SqlDbType.VarChar, 250),
                       new SqlMetaData("Amount1", SqlDbType.Float),
                       new SqlMetaData("Amount2", SqlDbType.Float),
                       new SqlMetaData("Amount3", SqlDbType.Float),
                       new SqlMetaData("Amount4", SqlDbType.Float),
                       new SqlMetaData("Amount1Diff", SqlDbType.Int),
                       new SqlMetaData("Amount2Diff", SqlDbType.Int),
                       new SqlMetaData("Amount3Diff", SqlDbType.Int),
                       new SqlMetaData("Amount4Diff", SqlDbType.Int),
                       new SqlMetaData("CompanyID", SqlDbType.BigInt),
                       new SqlMetaData("Year", SqlDbType.Int)
                       );
            foreach (TBLXMLSCheckpdfMizan cust in this)
            {
                sqlRow.SetString(0, cust.AccountMainID == null ? string.Empty : cust.AccountMainID.Trim());
                sqlRow.SetString(1, cust.AccountMainDescription == null ? string.Empty : cust.AccountMainDescription.Trim());
                sqlRow.SetDouble(2, cust.Amount1);
                sqlRow.SetDouble(3, cust.Amount2);
                sqlRow.SetDouble(4, cust.Amount3);
                sqlRow.SetDouble(5, cust.Amount4);
                sqlRow.SetInt32(6, cust.Amount1Diff);
                sqlRow.SetInt32(7, cust.Amount2Diff);
                sqlRow.SetInt32(8, cust.Amount3Diff);
                sqlRow.SetInt32(9, cust.Amount4Diff);
                sqlRow.SetInt64(10, cust.CompanyID);
                sqlRow.SetInt32(11, cust.Year);
                yield return sqlRow;
            }
        }
    }

}
