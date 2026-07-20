using fincheckup.Models.EarlyWarning.Response;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Linq;
using fincheckup.Models.EarlyWarning;

namespace fincheckup.Models.EarlyWarning
{

    public class AccountTypeStat
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public AccountTypeStat(int ID_, string Name_) { ID = ID_; Name = Name_; }

        public static List<AccountTypeStat> getList()
        {
            List<AccountTypeStat> nlist = new List<AccountTypeStat>() { new AccountTypeStat(1, "Gelir Tablosu Alt Hesap"), new AccountTypeStat(2, "Gelir Tablosu Üst Toplayıcı"), new AccountTypeStat(3, "Bilanço Alt Hesap"), new AccountTypeStat(4, "Bilanço Üst Toplayıcı") };
            return nlist;
        }



    }
    public class ReminderRuleTypeStat
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ReminderRuleTypeStat(int ID_, string Name_) { ID = ID_; Name = Name_; }

        public static List<ReminderRuleTypeStat> getList() {
            List<ReminderRuleTypeStat> nlist = new List<ReminderRuleTypeStat>() { new ReminderRuleTypeStat(1, "Artmıştır"), new ReminderRuleTypeStat(2, "Azalmıştır") };
            return nlist;
        }



    }
 
   
    public class PeriodTypeStat
    {
   

        public int ID { get; set; }
        public string Name { get; set; }

    public PeriodTypeStat(int id, string name)
    {
        ID = id;
        Name = name;
    }
    public static List<PeriodTypeStat> getList()
    {
        List<PeriodTypeStat> nlist = new List<PeriodTypeStat>() { new PeriodTypeStat(1, "Aylık"), new PeriodTypeStat(2, "Quarter"), new PeriodTypeStat(3, "Yıllık") };
        return nlist;
    }
    }
    public class JobStatusStat
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public JobStatusStat(int id, string name)
        {
            ID = id;
            Name = name;
        }
        public static List<JobStatusStat> getList()
        {
            List<JobStatusStat> nlist = new List<JobStatusStat>() { new JobStatusStat(1, "Oluşturuldu"), new JobStatusStat(2, "Çalışıyor"), new JobStatusStat(3, "Tamamlandı"), new JobStatusStat(4, "Tekrarlanacak") };
            return nlist;
        }
    }
    public class ReminderRule : BaseModel
    {
        public long ID { get; set; }
        public long AccountId { get; set; }
        public PeriodType PeriodType { get; set; }
        public double ControlValue { get; set; }
        public ControlValueType ControlValueType { get; set; }
        public DateTime? LastGenerateDate { get; set; }
        public static IEnumerable<ReminderRule> Get_ReminderRule()
        {
            return StaticQuery<ReminderRule>("Select * From [ReminderRule]");
        }
        public static ReminderRule GetRow_ReminderRule(long _ID)
        {
            return StaticQuery<ReminderRule>("Select * From [ReminderRule] where ID=@ID ", new { ID = _ID }).FirstOrDefault();
        }

        public void Save_ReminderRule()
        {
            string sql = @"  INSERT INTO [ReminderRule]
          ( 
        [AccountId] ,
        [PeriodType] ,
        [ControlValue] ,
        [ControlValueType] ,
        [LastGenerateDate] 
          ) 
           VALUES 
         ( 
        @AccountId ,
        @PeriodType ,
        @ControlValue ,
        @ControlValueType ,
        @LastGenerateDate 
         )  ;select  Cast(SCOPE_IDENTITY() as Int)";

            if (this.ID>0)
            {
                sql = "UPDATE   [ReminderRule] SET  [AccountId]=@AccountId , [PeriodType]=@PeriodType , [ControlValue]=@ControlValue , [ControlValueType]=@ControlValueType , [LastGenerateDate]=@LastGenerateDate  WHERE [ID]=@ID";
            }
            this.ID = Query<int>(sql, this).FirstOrDefault();
        }

        public bool Update_ReminderRule()
        {
            try
            {
                string sql = "UPDATE   [ReminderRule] SET  [AccountId]=@AccountId , [PeriodType]=@PeriodType , [ControlValue]=@ControlValue , [ControlValueType]=@ControlValueType , [LastGenerateDate]=@LastGenerateDate  WHERE [ID]=@ID";
                Execute(sql, this);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}