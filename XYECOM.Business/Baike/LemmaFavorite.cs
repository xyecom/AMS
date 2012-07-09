using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace XYECOM.Business
{
    public class LemmaFavorite
    {
        private static readonly XYECOM.SQLServer.LemmaFavorite DAL = new XYECOM.SQLServer.LemmaFavorite();

        public int Insert(XYECOM.Model.LemmaFavoriteInfo ef)
        {
            return DAL.Insert(ef);
        }

        public DataTable GetListByUserId(long userId) 
        {
            return DAL.GetListByUserId(userId);
        }

        public int Deletes(string infoids)
        {
            return DAL.Deletes(infoids);
        }
    }
}
