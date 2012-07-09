//------------------------------------------------------------------------------
//
// file name：SlidesManager.cs
// author: wangzhen
// create date：2011-6-1 17:01:53
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// Business logic for dbo.XY_Slides.
    /// </summary>
    public partial class SlidesManager
    {
        public XYECOM.Model.SlidesInfo GetItem(int infoId, int userId)
        {
            return access.GetItem(infoId, userId);
        }



        public DataTable SelectByUserId(int userId)
        {
            return access.SelectByUserId(userId);
        }
    }
}

