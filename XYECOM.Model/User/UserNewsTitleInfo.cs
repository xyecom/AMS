using System;
using System.Collections.Generic;

using System.Text;

namespace XYECOM.Model.User
{
    /// <summary>
    /// 企业资讯栏目信息实体类
    /// </summary>
    public class UserNewsTitleInfo
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int parentId;

        public int ParentId
        {
            get { return parentId; }
            set { parentId = value; }
        }

        private string userId;

        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        private int orderId;

        public int OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }

    }
}
