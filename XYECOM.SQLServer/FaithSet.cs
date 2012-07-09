using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using XYECOM.Model;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// ����ָ�����ݴ�����
    /// </summary>
    public class FaithSet
    {
        /// <summary>
        /// ��ӳ���ָ������
        /// </summary>
        /// <param name="cn">��ӳ���ָ������</param>
        /// <returns>����,���ڻ����0��ɹ�,�����ʧ��</returns>
        public int Insert(FaithSetInfo fs)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@GF_Fath",fs.GF_Fath  ),
                new SqlParameter("@GF_Money",fs.GF_Money  ),
                new SqlParameter("@GF_ErrFath",fs.GF_FrrFath ),
                new SqlParameter("@GF_ErrMoney",fs.GF_ErrMoney ),
                new SqlParameter("@GF_Remark",fs.GF_Remark ),
                new SqlParameter("@HF_Fath",fs.HF_Fath ),
                new SqlParameter("@HF_Money",fs.HF_Money ),
                new SqlParameter("@HF_ErrFath",fs.HF_FrrFath ),
                new SqlParameter("@HF_ErrMoney",fs.UF_ErrMoney),
                new SqlParameter("@HF_Remark",fs.HF_Remark ),
                new SqlParameter("@UF_Fath",fs.UF_Fath ),
                new SqlParameter("@UF_Money",fs.UF_Money ),
                new SqlParameter("@UF_ErrFath",fs.UF_FrrFath ),
                new SqlParameter("@UF_ErrMoney",fs.UF_ErrMoney ),
                new SqlParameter("@UF_Remark",fs.UF_Remark ),
                new SqlParameter("@BF_Fath",fs.BF_Fath ),
                new SqlParameter("@BF_Money",fs.BF_Money  ),
                new SqlParameter("@BF_ErrFath",fs.BF_FrrFath ),
                new SqlParameter("@BF_ErrMoney",fs.BF_ErrMoney ),
                new SqlParameter("@BF_Remark",fs.BF_Remark ),
                new SqlParameter("@FS_Base",fs.FS_Base),              //���ӻ���������ָ��
                new SqlParameter("@FS_Hot",fs.FS_Hot),                //���Ӹ߼�������ָ��
                new SqlParameter("@FS_Licence",fs.FS_Licence),        //�ϴ�Ӫҵִ������ָ��
                new SqlParameter("@FS_Certificate",fs.FS_Certificate) //�ϴ�������������ָ��
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"XYP_InsertFaithset", param);
        }
        /// <summary>
        /// �޸ĳ���ָ������
        /// </summary>
        /// <param name="cn">�޸ĳ���ָ������</param>
        /// <returns>����,���ڻ����0��ɹ�,�����ʧ��</returns>
        public int Update(FaithSetInfo fs)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@F_ID",fs.F_ID),
                new SqlParameter("@GF_Fath",fs.GF_Fath  ),
                new SqlParameter("@GF_Money",fs.GF_Money  ),
                new SqlParameter("@GF_ErrFath",fs.GF_FrrFath ),
                new SqlParameter("@GF_ErrMoney",fs.GF_ErrMoney ),
                new SqlParameter("@GF_Remark",fs.GF_Remark ),
                new SqlParameter("@HF_Fath",fs.HF_Fath ),
                new SqlParameter("@HF_Money",fs.HF_Money ),
                new SqlParameter("@HF_ErrFath",fs.HF_FrrFath ),
                new SqlParameter("@HF_ErrMoney",fs.HF_ErrMoney ),
                new SqlParameter("@HF_Remark",fs.HF_Remark ),
                new SqlParameter("@UF_Fath",fs.UF_Fath ),
                new SqlParameter("@UF_Money",fs.UF_Money ),
                new SqlParameter("@UF_ErrFath",fs.UF_FrrFath ),
                new SqlParameter("@UF_ErrMoney",fs.UF_ErrMoney ),
                new SqlParameter("@UF_Remark",fs.UF_Remark ),
                new SqlParameter("@BF_Fath",fs.BF_Fath ),
                new SqlParameter("@BF_Money",fs.BF_Money  ),
                new SqlParameter("@BF_ErrFath",fs.BF_FrrFath ),
                new SqlParameter("@BF_ErrMoney",fs.BF_ErrMoney ),
                new SqlParameter("@BF_Remark",fs.BF_Remark ),
                new SqlParameter("@FS_Base",fs.FS_Base),              //���ӻ���������ָ��
                new SqlParameter("@FS_Hot",fs.FS_Hot),                //���Ӹ߼�������ָ��
                new SqlParameter("@FS_Licence",fs.FS_Licence),        //�ϴ�Ӫҵִ������ָ��
                new SqlParameter("@FS_Certificate",fs.FS_Certificate) //�ϴ�������������ָ��
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateFaithSet", param);
        }

        /// <summary>
        /// ɾ��ָ������ָ����ż��ĳ��󷽷�
        /// </summary>
        /// <param name="kiids">Ҫɾ���ĳ���ָ����ż�</param>
        /// <returns>����,���ڻ����0��ɾ���ɹ�</returns>
        public int Delete(string kiids)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere","where F_ID in ("+kiids+")"),
                new SqlParameter("@strTableName","b_FaithSet")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }
        /// <summary>
        /// ��ȡ����ָ�������ĳ���ָ������ĳ��󷽷�
        /// </summary>
        /// <param name="strWhere">ָ����strWhere����</param>
        /// <param name="strOrderBy">ָ����OrderBy����</param>
        /// <returns>������������ĳ���ָ����������ݼ�</returns>
        public  DataTable GetDataTable()
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere",""),
                new SqlParameter("@strTableName","b_FaithSet"),
                new SqlParameter("@strOrder","")
            };

            return XYECOM.Core.Data.SqlHelper.GetDataTable("XYP_SelectByWhere", param);
        }
    }
}
