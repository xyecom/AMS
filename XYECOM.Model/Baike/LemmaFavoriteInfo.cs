using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    public class LemmaFavoriteInfo
    {
        private long favId;

        public long FavId
        {
            get { return favId; }
            set { favId = value; }
        }
        private long userId;

        public long UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        private long lemmaId;

        public long LemmaId
        {
            get { return lemmaId; }
            set { lemmaId = value; }
        }
        private string tags;

        public string Tags
        {
            get { return tags; }
            set { tags = value; }
        }
    }
}
