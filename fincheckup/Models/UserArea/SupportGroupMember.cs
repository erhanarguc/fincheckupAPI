using System;
using System.Collections.Generic;
using System.Linq;

namespace fincheckup.Models.UserArea
{
    public class SupportGroupMember : BaseModel
    {
        public Int32 SupportGroupMemberID { get; set; }
        public Int32 SupportGroupID { get; set; }
        public Int32 UserID { get; set; }
        public DateTime ModifiedDate { get; set; }

        public SupportGroupMember()
        {

        }

        public static SupportGroupMember GetRow(Int32 _supportgroupmemberid)
        {
            return StaticQuery<SupportGroupMember>("SELECT * FROM [Users].[SupportGroupMember] WHERE SupportGroupMemberID=@p_supportgroupmemberid", new { p_supportgroupmemberid = _supportgroupmemberid }).FirstOrDefault();
        }


        public Int32 Upsert()
        {
            string isql = @"INSERT INTO [Users].[SupportGroupMember]
			([SupportGroupID],
			[UserID] ) 
			VALUES 
			(@SupportGroupID,
			@UserID );
			select cast(scope_identity() as int);";

            string usql = @"UPDATE Users.SupportGroupMember
			SET [SupportGroupID] = @SupportGroupID,
			[UserID] = @UserID,
			[ModifiedDate] = GETDATE()
			 WHERE SupportGroupMemberID = @SupportGroupMemberID";

            if (SupportGroupMemberID == 0)
            {
                this.SupportGroupMemberID = StaticQuery<Int32>(isql, this).FirstOrDefault();
            }
            else
            {
                Execute(usql, this);
            }

            return SupportGroupMemberID;
        }




        public static IEnumerable<SupportGroupMember> ToList
        {
            get
            {
                return StaticQuery<SupportGroupMember>("SELECT *  FROM [Users].[SupportGroupMember] (NOLOCK)");
            }
        }
    }
}

