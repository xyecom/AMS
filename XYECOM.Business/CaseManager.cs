using System;
using System.Collections.Generic;
using System.Text;
using XYECOM.Model;

namespace XYECOM.Business
{
    public class CaseManager
    {
        private static readonly XYECOM.SQLServer.CaseAccess DAL = new XYECOM.SQLServer.CaseAccess();

        public CaseInfo GetItem(int infoId)
        {
            return DAL.GetItem(infoId);
        }

        public int Update(CaseInfo info)
        {
            return DAL.Update(info);
        }

        public int Insert(CaseInfo info)
        {
            return DAL.Insert(info);
        }

        public int Delete(string infoids)
        {
            return DAL.Delete(infoids);
        }
    }
}
