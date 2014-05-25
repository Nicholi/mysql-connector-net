using System;
using System.Web.Security;

namespace MySql.Web
{
    public class MySqlMembershipUser : MembershipUser
    {
        protected DateTime m_CreationDate;
        protected DateTime m_LastLoginDate;
        protected DateTime m_LastActivityDate;
        protected DateTime m_LastPasswordChangedDate;
        protected DateTime m_LastLockoutDate;

        public MySqlMembershipUser(String providerName, String name, Object providerUserKey, String email, 
            String passwordQuestion, String comment, bool isApproved, bool isLockedOut, 
            DateTime creationDate, DateTime lastLoginDate, DateTime lastActivityDate, 
            DateTime lastPasswordChangedDate, DateTime lastLockoutDate)
            : base(providerName, name, providerUserKey, email, passwordQuestion, comment, 
            isApproved, isLockedOut, 
            creationDate, lastLoginDate, lastActivityDate, lastPasswordChangedDate, lastLockoutDate)
        {
            m_CreationDate = creationDate;
            m_LastLoginDate = lastLoginDate;
            m_LastActivityDate = lastActivityDate;
            m_LastPasswordChangedDate = lastPasswordChangedDate;
            m_LastLockoutDate = lastLockoutDate;
        }

        public override DateTime CreationDate
        {
            get
            {
                return m_CreationDate;
            }
        }

        public override DateTime LastLoginDate
        {
            get
            {
                return m_LastLoginDate;
            }
        }

        public override DateTime LastActivityDate
        {
            get
            {
                return m_LastActivityDate;
            }
        }

        public override DateTime LastPasswordChangedDate
        {
            get
            {
                return m_LastPasswordChangedDate;
            }
        }

        public override DateTime LastLockoutDate
        {
            get
            {
                return m_LastLockoutDate;
            }
        }
    }
}
