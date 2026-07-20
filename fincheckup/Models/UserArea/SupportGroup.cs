using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace fincheckup.Models.UserArea
{
    public class SupportGroup : BaseModel
    {
        public Int32 SupportGroupID { get; set; }
        [Required(ErrorMessage = "Bu alan gerekli")]
        public string SupportGroupName { get; set; }
        public string SupportGroupDescription { get; set; }
        public Int32 ImpactID { get; set; }
        public Int32 UserID { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string TechnicanFullName { get; set; }
        public string ImpactName { get; set; }

        public SupportGroup()
        {

        }

        public static SupportGroup GetRow(Int32 _supportgroupid)
        {
            return StaticQuery<SupportGroup>("SELECT * FROM [Users].[SupportGroup] WHERE SupportGroupID=@p_supportgroupid", new { p_supportgroupid = _supportgroupid }).FirstOrDefault();
        }
        public static IEnumerable<SupportGroup> SupportGroupView
        {
            get
            {
                return StaticQuery<SupportGroup>("SELECT *  FROM [dbo].[User_SupportGroupView] (NOLOCK) WHERE IsDeleted=0");
            }
        }
        public static bool Delete(Int32 _supportgroupid)
        {
            return StaticQuery<bool>("UPDATE  [Users].[SupportGroup]  SET IsDeleted=1 WHERE SupportGroupID=@p_supportgroupid", new { p_supportgroupid = _supportgroupid }).FirstOrDefault();
        }

        public Int32 Upsert()
        {
            string isql = @"INSERT INTO [Users].[SupportGroup]
			([SupportGroupName],
			[SupportGroupDescription],
			[ImpactID],
			[UserID] ) 
			VALUES 
			(@SupportGroupName,
			@SupportGroupDescription,
			@ImpactID,
			@UserID );
			select cast(scope_identity() as int);";

            string usql = @"UPDATE Users.SupportGroup
			SET [SupportGroupName] = @SupportGroupName,
			[SupportGroupDescription] = @SupportGroupDescription,
			[ImpactID] = @ImpactID,
			[UserID] = @UserID,
			[ModifiedDate] = GETDATE()
			 WHERE SupportGroupID = @SupportGroupID";

            if (SupportGroupID == 0)
            {
                this.SupportGroupID = StaticQuery<Int32>(isql, this).FirstOrDefault();
            }
            else
            {
                Execute(usql, this);
            }

            return SupportGroupID;
        }




        public static IEnumerable<SupportGroup> ToList
        {
            get
            {
                return StaticQuery<SupportGroup>("SELECT *  FROM [Users].[SupportGroup] (NOLOCK)");
            }
        }
    }
}

