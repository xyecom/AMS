using System;
using System.Collections.Generic;

using System.Text;

namespace XYECOM.Model
{
    public class UserPublic
    {
        private int accountId;

        public int AccountId
        {
            get { return accountId; }
            set { accountId = value; }
        }
        private int gradeId;

        public int GradeId
        {
            get { return gradeId; }
            set { gradeId = value; }
        }
    }
}
