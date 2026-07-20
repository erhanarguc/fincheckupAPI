using DevExpress.CodeParser;
using fincheckup.ENTITY;
using fincheckup.Models.NKolay.ENTITY.NwEntity;
using fincheckup.Models.NKolay.ViewM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fincheckup.Services
{
    public class XmlControlResult
    {
        private List<Dataz> _xMLSourceRow;
        private List<TBLErrzoneInsideXMLRow> _tBLErrzoneInsideXMLRow;
        private List<ErrorCheckSet> _errorCheckSet;
        private List<TBLErrzoneRow> _errorCheckSetList;
        private List<XmlCheckGroupRow>  xmlCheckGroups;

        public XmlControlResult(List<Dataz> xMLSourceRow, List<TBLErrzoneInsideXMLRow>  tBLErrzoneInsideXMLRow, List<ErrorCheckSet>  errorCheckSet, List<TBLErrzoneRow>  errorCheckSetList)
        {
            _xMLSourceRow = xMLSourceRow;
            _tBLErrzoneInsideXMLRow= tBLErrzoneInsideXMLRow;
            _errorCheckSet=errorCheckSet;
            _errorCheckSetList=errorCheckSetList;
             xmlCheckGroups= _xMLSourceRow
     .GroupBy(x => new { x.EntryNumber, x.TotalCredit, x.CsvID })
     .Select(g => new XmlCheckGroupRow
     {
         EntryNumber = g.Key.EntryNumber,
         TotalCredit = g.Key.TotalCredit,
         CsvID = g.Key.CsvID,
         AccountMainIDList = string.Join(",",
             g.Select(s => s.AccountMainID)
              .Where(id => !string.IsNullOrWhiteSpace(id))
              .Select(id => id.Trim())
              .Distinct(StringComparer.Ordinal)
              .OrderBy(id => id, StringComparer.Ordinal)
         ) 
     })
     .ToList();

        }
        public async Task<List<ErrzoneInsideDto>> ProcessXmlGroup(long CsvID)
        {
                         var query =
             from xt in _tBLErrzoneInsideXMLRow
             join tb in _xMLSourceRow
              on new { xt.CsvID, EntryNo = xt.EntryNo }
              equals new { tb.CsvID, EntryNo = tb.EntryNumber }
             join tt in _errorCheckSet
              on xt.ErrorInsideID equals tt.ID
             where tb.CsvID == CsvID
             && xt.CsvID == CsvID      
             && tb.IsPassedEntry == 0
             && tt.ColorDesc == 0
             && ((tt.ColorDescTax) > 0 || (tt.ColorDescInside) > 0)
             select new ErrzoneInsideDto(
             tb.EntryNumber,
             tt.ID,
             tb.DocumentDate,
             tb.EnteredBy,
             tb.AccountMainID,
             tb.AccountMainDescription,
             tb.AccountSubID,
             tb.AccountSubDescription,
             tb.DebitCreditCode,
             tb.Amount,
             tb.DetailComment,
             tb.PaymentMethod,
             tb.DocumentTypeDescription,
             tb.EndDate,
             tb.EntryComment,
             (byte)(tt.ColorDescTax),
             tt.DescriptionTax,
             (byte)(tt.ColorDescInside),
             tt.DescriptionInside
             );
                          
                         var resultyyyy = query
                .GroupBy(x => x)    
                .Select(g => g.Key)
                .ToList();


   //         var queryb =
   //  from xt in _tBLErrzoneInsideXMLRow
   //  join tb in _xMLSourceRow
   //   on new { xt.CsvID, EntryNo = xt.EntryNo }
   //   equals new { tb.CsvID, EntryNo = tb.EntryNumber }
   //  join tt in _errorCheckSet
   //   on xt.ErrorInsideID equals tt.ID
   //  where tb.CsvID == CsvID
   //  && xt.CsvID == CsvID
   //  && tb.IsPassedEntry == 0
   //  && tt.ColorDesc == 0
   //  && ((tt.ColorDescTax) > 0 || (tt.ColorDescInside) > 0)
   //  select new ErrzoneInsideDto(
   //  tb.EntryNumber,
   //  tt.ID,
   //  tb.DocumentDate,
   //  tb.EnteredBy,
   //  tb.AccountMainID,
   //  tb.AccountMainDescription,
   //  tb.AccountSubID,
   //  tb.AccountSubDescription,
   //  tb.DebitCreditCode,
   //  tb.Amount,
   //  tb.DetailComment,
   //  tb.PaymentMethod,
   //  tb.DocumentTypeDescription,
   //  tb.EndDate,
   //  tb.EntryComment,
   //  (byte)(tt.ColorDescTax),
   //  tt.DescriptionTax,
   //  (byte)(tt.ColorDescInside),
   //  tt.DescriptionInside
   //  );

   //         var resultyyyyb = queryb
   //.GroupBy(x => x)
   //.Select(g => g.Key)
   //.ToList();
            return resultyyyy;
        }
        public async Task<List<ErrzoneInsideDto>> ProcessXmlGroupA(long CsvID)
        {
            var queryb =
       from xt in xmlCheckGroups
       join tb in _xMLSourceRow
        on new { xt.CsvID, EntryNo = xt.EntryNumber }
        equals new { tb.CsvID, EntryNo = tb.EntryNumber }
       join tt in _errorCheckSetList
        on xt.AccountMainIDList equals tt.MainDescription
       where tb.CsvID == CsvID
       && xt.CsvID == CsvID
       && ((tt.ColorDescInside) > 0 || (tt.ColorDescTax) > 0  )
       select new ErrzoneInsideDto(
       tb.EntryNumber,
       tt.ID,
       tb.DocumentDate,
       tb.EnteredBy,
       tb.AccountMainID,
       tb.AccountMainDescription,
       tb.AccountSubID,
       tb.AccountSubDescription,
       tb.DebitCreditCode,
       tb.Amount,
       tb.DetailComment,
       tb.PaymentMethod,
       tb.DocumentTypeDescription,
       tb.EndDate,
       tb.EntryComment,
       (byte)(tt.ColorDescTax),
       tt.DescriptionTax,
       (byte)(tt.ColorDescInside),
       tt.DescriptionInside
       );

            var result = queryb
   .GroupBy(x => x)
   .Select(g => g.Key)
   .ToList();
            return result;
        }
        public async Task<List<ErrzoneInsideDto>> ProcessXmlGroupII(long CsvID)
        {
            var query =
from xt in _tBLErrzoneInsideXMLRow
join tb in _xMLSourceRow
 on new { xt.CsvID, EntryNo = xt.EntryNo }
 equals new { tb.CsvID, EntryNo = tb.EntryNumber }
join tt in _errorCheckSet
 on xt.ErrorInsideID equals tt.ID
where tb.CsvID == CsvID
&& xt.CsvID == CsvID
&& tb.IsPassedEntry == 0 
&& ((tt.ColorDesc) > 0 )
select new ErrzoneInsideDto(
tb.EntryNumber,
tt.ID,
tb.DocumentDate,
tb.EnteredBy,
tb.AccountMainID,
tb.AccountMainDescription,
tb.AccountSubID,
tb.AccountSubDescription,
tb.DebitCreditCode,
tb.Amount,
tb.DetailComment,
tb.PaymentMethod,
tb.DocumentTypeDescription,
tb.EndDate,
tb.EntryComment,
(byte)(tt.ColorDescTax),
tt.DescriptionTax,
(byte)(tt.ColorDescInside),
tt.DescriptionInside
);

            var resultyyyy = query
   .GroupBy(x => x)
   .Select(g => g.Key)
   .ToList();
            return resultyyyy;
        }

        public async Task<List<ErrzoneInsideDto>> ProcessXmlGroupIIA(long CsvID)
        {
  
            var queryb =
     from xt in xmlCheckGroups
     join tb in _xMLSourceRow
      on new { xt.CsvID, EntryNo = xt.EntryNumber }
      equals new { tb.CsvID, EntryNo = tb.EntryNumber }
     join tt in _errorCheckSetList
      on xt.AccountMainIDList equals tt.MainDescription
     where tb.CsvID == CsvID
     && xt.CsvID == CsvID 
     && ((tt.ColorDesc) > 0 )
     select new ErrzoneInsideDto(
     tb.EntryNumber,
     tt.ID,
     tb.DocumentDate,
     tb.EnteredBy,
     tb.AccountMainID,
     tb.AccountMainDescription,
     tb.AccountSubID,
     tb.AccountSubDescription,
     tb.DebitCreditCode,
     tb.Amount,
     tb.DetailComment,
     tb.PaymentMethod,
     tb.DocumentTypeDescription,
     tb.EndDate,
     tb.EntryComment,
     (byte)(tt.ColorDescTax),
     tt.DescriptionTax,
     (byte)(tt.ColorDescInside),
     tt.DescriptionInside
     );

            var result  = queryb
   .GroupBy(x => x)
   .Select(g => g.Key)
   .ToList();
            return result;
        }
    }
}
