using System;
using System.Data;
using XYECOM.Business;

namespace XYECOM.Service
{
    public class Contract : BaseService
    {
        private ContractManager contractManagerBLL = new ContractManager();

        public override void Process()
        {
            ServiceUtil.Debug("开始执行已过期的合同");
            //获取已过期、已生效、未锁的合同
            DataTable contractTd = contractManagerBLL.GetObjServer(XYECOM.Model.ContractStatus.Effective);
            foreach (DataRow row in contractTd.Rows)
            {
                //获取符合条件的合同编号
                int contractId = XYECOM.Core.MyConvert.GetInt32(row["Id"].ToString());
                ServiceUtil.Info("操作已过期合同(编号" + contractId + ")");
                try
                {
                    //释放供应商缴纳的合同保证并关闭合同
                    contractManagerBLL.CloseContract(contractId);
                    //其他操作
                    System.Threading.Thread.Sleep(5);
                }
                catch (Exception ep)
                {
                    ServiceUtil.Error("ERROR:处理担保合同信息" + "====", ep);
                }
            }
            ServiceUtil.Debug("执行结束已过期的合同");
        }
    }
}
