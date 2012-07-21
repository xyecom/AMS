using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Business
{
    public class RelatedCaseInfoManager
    {
        private static readonly XYECOM.SQLServer.RelatedCaseInfoAccess DAL = new XYECOM.SQLServer.RelatedCaseInfoAccess();
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
            return DAL.RelatedInfo(infoType, infoId, partId, compayId, caseId);
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
            DAL.RelatedInfo(infoType, infoId, partId, compayId, ids);
        }

        /// <summary>
        /// 根据 债权或者抵债信息编号，信息类型获取该信息所有关联的文档路径集合。
        /// </summary>
        /// <param name="infoId"></param>
        /// <param name="infoType"></param>
        /// <returns></returns>
        public IList<string> GetFilePaths(long infoId, Model.TableInfoType infoType)
        {
            return DAL.GetFilePaths(infoId, infoType);
        }
        /// <summary>
        /// 该方法与上面的方法基本一致，只是这个仅仅返回一条文档路径。
        /// </summary>
        /// <param name="infoId"></param>
        /// <param name="infoType"></param>
        /// <returns></returns>
        public string GetFilePath(long infoId, Model.TableInfoType infoType)
        {
            return DAL.GetFilePath(infoId, infoType);
        }

        /// <summary>
        ///当页面上使用档案选择控件时，并且是修改的时候，需要列出之前信息所选择的档案信息，该方法就是又拿过来获取  债权或抵债信息 所用到的所有抵债信息编号，逗号间隔的，如：1，2，3
        /// </summary>
        /// <param name="infoId"></param>
        /// <param name="infoType"></param>
        /// <returns></returns>
        public string GetSelectCaseIds(long infoId, Model.TableInfoType infoType)
        {
            return DAL.GetSelectCaseIds(infoId, infoType);
        }

        /// <summary>
        /// 删除某条债权或抵债信息相关联的档案数据
        /// </summary>
        /// <param name="infoId"></param>
        /// <param name="infoType"></param>
        /// <returns></returns>
        public int DeleteRelatedCaseInfo(long infoId, Model.TableInfoType infoType)
        {
            return DAL.DeleteRelatedCaseInfo(infoId, infoType);
        }
    }
}
