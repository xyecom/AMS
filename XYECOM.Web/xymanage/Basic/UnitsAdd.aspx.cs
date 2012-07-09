using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XYECOM.Web.xymanage.Basic
{
    public partial class UnitsAdd : XYECOM.Web.BasePage.ManagePage
    {
        int id = XYECOM.Core.XYRequest.GetQueryInt("infoid", 0);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (id > 0)
                {
                    XYECOM.Business.MeasuringUnitManager mu = new Business.MeasuringUnitManager();
                    XYECOM.Model.MeasuringUnitInfo info = mu.GetItem(id);
                    if (info != null)
                    {
                        this.tbName.Text = info.MeasuringUnitName;
                    }
                    else
                    {
                        Alert("参数错误", "UnitsList.aspx");
                    }

                }
            }
        }

        protected void btnok_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                XYECOM.Business.MeasuringUnitManager mu = new Business.MeasuringUnitManager();
                XYECOM.Model.MeasuringUnitInfo info = new Model.MeasuringUnitInfo();
                info.MeasuringUnitName = this.tbName.Text;
                string TypeName = tbName.Text.Trim().Replace("，", ",");

                string[] arr = TypeName.Split(',');
              
                bool isall = true;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (!mu.CheckUnitNmae(arr[i]))
                    {
                        info.MeasuringUnitName = arr[i];
                        mu.Insert(info);
                    }
                    else
                    {
                        isall = false;
                    }

                }
                if (isall)
                {
                    Alert("添加成功！", "UnitsList.aspx");
                }
                else
                {
                    Alert("添加成功！部分单位已存在，不能重复添加", "UnitsList.aspx");
                }
            }
            else if (id > 0)
            {
                XYECOM.Business.MeasuringUnitManager mu = new Business.MeasuringUnitManager();
                XYECOM.Model.MeasuringUnitInfo info = new Model.MeasuringUnitInfo();
                info.MeasuringUnitName = this.tbName.Text;
                info.Id = id;
                int num = mu.Update(info);
                if (num > 0)
                {
                    Alert("修改成功！", "UnitsList.aspx");
                }
            }
        }

    }
}