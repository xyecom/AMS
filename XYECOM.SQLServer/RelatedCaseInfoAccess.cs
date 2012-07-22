using System;
using System.Collections.Generic;
using System.Text;
using XYECOM.Core.Data;
using System.Data;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// 这个类是  档案信息 和 债权，抵债相关联的数据库操作类，也就是专门用来操作那个抵债信息关联了那个档案信息，删除，获取相关档案信息的类。
    /// </summary>
    public class RelatedCaseInfoAccess
    {
        /// <summary>
        ///根据表的类型，这里定义了一个枚举，枚举的值分别表示抵债信息和债权信息，该方法用来插入一条关联数据。
        /// </summary>
        /// <param name="infoType">信息类型</param>
        /// <param name="infoId">债权或抵债信息编号</param>
        /// <param name="partId">部门编号，抵债或债权信息所属的部门编号</param>
        /// <param name="compayId">公司编号，抵债或债权信息所属的公司编号</param>
        /// <param name="caseId">所选择的档案信息编号</param>
        /// <returns></returns>
        public int RelatedInfo(Model.TableInfoType infoType, long infoId, long partId, long compayId, int caseId)
        {
            string sqlFmt = @"INSERT INTO [RelatedCaseInfo]
           (InfoId
           ,CaseId
           ,FilePath
           ,PartId
           ,CompanyId
           ,InfoType)
     VALUES
           ({0}
           ,{1}
           ,'{2}'
           ,{3}
           ,{4}
           ,{5})";

            string sql = string.Format(sqlFmt, infoId, caseId, "", partId, compayId, (int)infoType);

            return SqlHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 该方法与上面的方法功能基本一致，只是用来插入多条关联数据，不在写注释了
        /// </summary>
        /// <param name="infoType"></param>
        /// <param name="infoId"></param>
        /// <param name="partId"></param>
        /// <param name="compayId"></param>
        /// <param name="ids"></param>
        public void RelatedInfo(Model.TableInfoType infoType, long infoId, long partId, long compayId, string[] ids)
        {
            foreach (string str in ids)
            {
                if (string.IsNullOrEmpty(str)) { continue; }
                int caseId = XYECOM.Core.MyConvert.GetInt32(str);
                if (caseId < 1) continue;
                RelatedInfo(infoType, infoId, partId, compayId, caseId);
            }
        }

        /// <summary>
        /// 根据 债权或者抵债信息编号，信息类型获取该信息所有关联的文档路径集合。
        /// </summary>
        /// <param name="infoId"></param>
        /// <param name="infoType"></param>
        /// <returns></returns>
        public IList<string> GetFilePaths(long infoId, Model.TableInfoType infoType)
        {
            string sql = "select Id,FilePath from CaseInfo where Id in (select Id from RelatedCaseInfo where InfoType='" + (int)infoType + "' and InfoId=" + infoId + ")";

            DataTable table = SqlHelper.ExecuteTable(sql);

            IList<string> list = new List<string>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(row["FilePath"].ToString());
            }

            return list;
        }
        /// <summary>
        /// 该方法与上面的方法基本一致，只是这个仅仅返回一条文档路径。
        /// </summary>
        /// <param name="infoId"></param>
        /// <param name="infoType"></param>
        /// <returns></returns>
        public string GetFilePath(long infoId, Model.TableInfoType infoType)
        {
            string sql = "select top 1 Id,FilePath from CaseInfo where Id in (select Id from RelatedCaseInfo where InfoType='" + (int)infoType + "' and InfoId=" + infoId + ")";

            DataTable table = SqlHelper.ExecuteTable(sql);

            return table.Rows[0]["FilePath"].ToString();
        }

        /// <summary>
        ///当页面上使用档案选择控件时，并且是修改的时候，需要列出之前信息所选择的档案信息，该方法就是又拿过来获取  债权或抵债信息 所用到的所有抵债信息编号，逗号间隔的，如：1，2，3
        /// </summary>
        /// <param name="infoId"></param>
        /// <param name="infoType"></param>
        /// <returns></returns>
        public string GetSelectCaseIds(long infoId, Model.TableInfoType infoType)
        {
            string sql = "select CaseId from RelatedCaseInfo where InfoType='" + (int)infoType + "' and InfoId=" + infoId;

            DataTable table = SqlHelper.ExecuteTable(sql);
            string ids = string.Empty;

            foreach (DataRow row in table.Rows)
            {
                ids += row["CaseId"].ToString();
                ids += ",";
            }

            return ids.Trim(new char[] { ',' });
        }

        /// <summary>
        /// 删除某条债权或抵债信息相关联的档案数据
        /// </summary>
        /// <param name="infoId"></param>
        /// <param name="infoType"></param>
        /// <returns></returns>
        public int DeleteRelatedCaseInfo(long infoId, Model.TableInfoType infoType) 
        {
            string sql = "delete RelatedCaseInfo where InfoType='" + (int)infoType + "' and InfoId=" + infoId;

            return SqlHelper.ExecuteNonQuery(sql);
        }
    }
}
