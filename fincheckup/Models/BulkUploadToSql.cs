using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace fincheckup.Models
{
    public class BulkUploadToSql<T>
    {
        public IList<T> InternalStore { get; set; }
        public string TableName { get; set; }
        public int CommitBatchSize { get; set; } = 1000;
        public string ConnectionString { get; set; }

        public void Commit()
        {
            if (InternalStore.Count > 0)
            {
                DataTable dt;
                int numberOfPages = (InternalStore.Count / CommitBatchSize) + (InternalStore.Count % CommitBatchSize == 0 ? 0 : 1);
                for (int pageIndex = 0; pageIndex < numberOfPages; pageIndex++)
                {
                    dt = InternalStore.Skip(pageIndex * CommitBatchSize).Take(CommitBatchSize).ToDataTable();
                    BulkInsert(dt);
                }

            }
        }
        public static void AutoMapColumns(SqlBulkCopy sbc, DataTable dt)
        {
            foreach (DataColumn column in dt.Columns)
            {
                sbc.ColumnMappings.Add(column.ColumnName, column.ColumnName);
            }
        }

        public void BulkInsert(DataTable dt)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                // make sure to enable triggers
                // more on triggers in next post
                SqlBulkCopy bulkCopy =
                    new SqlBulkCopy
                    (
                    connection,
                    SqlBulkCopyOptions.TableLock |
                    SqlBulkCopyOptions.FireTriggers |
                    SqlBulkCopyOptions.UseInternalTransaction,
                    null
                    );
                bulkCopy.ColumnMappings.Add("StartDate", "StartDate");
                bulkCopy.ColumnMappings.Add("EndDate", "EndDate");
                bulkCopy.ColumnMappings.Add("EnteredBy", "EnteredBy");
                bulkCopy.ColumnMappings.Add("EnteredDate", "EnteredDate");
                bulkCopy.ColumnMappings.Add("EntryNumber", "EntryNumber");
                bulkCopy.ColumnMappings.Add("EntryComment", "EntryComment");
                bulkCopy.ColumnMappings.Add("BatchID", "BatchID");
                bulkCopy.ColumnMappings.Add("BatchDescription", "BatchDescription");
                bulkCopy.ColumnMappings.Add("TotalDebit", "TotalDebit");
                bulkCopy.ColumnMappings.Add("TotalCredit", "TotalCredit");
                bulkCopy.ColumnMappings.Add("DocumentType", "DocumentType");
                bulkCopy.ColumnMappings.Add("DocumentTypeDescription", "DocumentTypeDescription");
                bulkCopy.ColumnMappings.Add("DocumentNumber", "DocumentNumber");
                bulkCopy.ColumnMappings.Add("DocumentDate", "DocumentDate");
                bulkCopy.ColumnMappings.Add("PaymentMethod", "PaymentMethod");
                bulkCopy.ColumnMappings.Add("AccountMainID", "AccountMainID");
                bulkCopy.ColumnMappings.Add("AccountMainDescription", "AccountMainDescription");
                bulkCopy.ColumnMappings.Add("AccountSubDescription", "AccountSubDescription");
                bulkCopy.ColumnMappings.Add("AccountSubID", "AccountSubID");
                bulkCopy.ColumnMappings.Add("Amount", "Amount");
                bulkCopy.ColumnMappings.Add("DebitCreditCode", "DebitCreditCode");
                bulkCopy.ColumnMappings.Add("PostingDate", "PostingDate");
                bulkCopy.ColumnMappings.Add("DetailComment", "DetailComment");
                bulkCopy.ColumnMappings.Add("CsvID", "CsvID");
                bulkCopy.ColumnMappings.Add("IsPassedEntry", "IsPassedEntry");
                bulkCopy.ColumnMappings.Add("CompanyDocumentId", "CompanyDocumentId");
                bulkCopy.ColumnMappings.Add("IsFailed", "IsFailed");
                // set the destination table name
                bulkCopy.DestinationTableName = TableName;
                bulkCopy.BulkCopyTimeout = 100;
                connection.Open();

                // write the data in the "dataTable"
                bulkCopy.WriteToServer(dt);
                connection.Close();
            }
            // reset
            //this.dataTable.Clear();
        }

    }

    public static class BulkUploadToSqlHelper
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
    }

}
