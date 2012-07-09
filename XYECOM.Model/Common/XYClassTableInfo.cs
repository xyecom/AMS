using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 分类表信息
    /// </summary>
    public class XYClassTableInfo
    {
        public int ModuleValue;

        public string Caption;
        /// <summary>
        /// 分类表名称
        /// </summary>
        public string TableName;
        /// <summary>
        /// 分类表ID字段名称
        /// </summary>
        public string IdFieldName;
        /// <summary>
        /// 分类表分类名称字段名称
        /// </summary>
        public string NameFieldName;
        /// <summary>
        /// 分类表父级Id字段名称
        /// </summary>
        public string ParentIdFieldName;
        /// <summary>
        /// 分类表模块字段名称
        /// </summary>
        public string ModuleFieldName;

        /// <summary>
        /// 信息表(视图)名称
        /// </summary>
        public string InfoTableName;
        /// <summary>
        /// 信息表类型ID字段名称
        /// </summary>
        public string InfoTableTypeIDFieldName;

        /// <summary>
        /// 信息标题字段名称
        /// </summary>
        public string InfoTableTitleFieldName;
        /// <summary>
        /// 信息添加时间字段名称
        /// </summary>
        public string InfoTableAddTimeFieldName;
        /// <summary>
        /// 信息表是否暂停字段名称
        /// </summary>
        public string InfoTableIsSupplyFieldName;
        /// <summary>
        /// 信息表信息结束时间字段名称
        /// </summary>
        public string InfoTableEndTimeFieldName;
        /// <summary>
        /// 信息表标识字段名称
        /// </summary>
        public string InfoTableFlagFieldName = "";


        public string LinkFlag;

        public XYClassTableInfo(string caption, string tableName, string IdFieldName, string nameFieldName, string parentIdFieldName, string moduleFieldName, int moduleValue, string linkFlag, string infoTableName, string infoTableTypeIDFieldName, string infoTableTitleFieldName, string infoTableAddTimeFieldName, string infoTableIsSupplyFieldName, string infoTableEndTimeFieldName)
        {
            this.Caption = caption;
            this.TableName = tableName;
            this.IdFieldName = IdFieldName;
            this.NameFieldName = nameFieldName;
            this.ParentIdFieldName = parentIdFieldName;
            this.ModuleFieldName = moduleFieldName;
            this.LinkFlag = linkFlag;
            this.InfoTableName = infoTableName;
            this.InfoTableTypeIDFieldName = infoTableTypeIDFieldName;
            this.InfoTableTitleFieldName = infoTableTitleFieldName;
            this.InfoTableAddTimeFieldName = infoTableAddTimeFieldName;
            this.InfoTableIsSupplyFieldName = infoTableIsSupplyFieldName;
            this.InfoTableEndTimeFieldName = infoTableEndTimeFieldName;
        }

        public XYClassTableInfo(string caption, string tableName, string IdFieldName, string nameFieldName, string parentIdFieldName, string moduleFieldName, int moduleValue, string linkFlag, string infoTableName,string infoTableTypeIDFieldName, string infoTableTitleFieldName, string infoTableAddTimeFieldName, string infoTableIsSupplyFieldName)
            : this(caption, tableName, IdFieldName, nameFieldName, parentIdFieldName, moduleFieldName, moduleValue, linkFlag, infoTableName, infoTableTypeIDFieldName, infoTableTitleFieldName, infoTableAddTimeFieldName, infoTableIsSupplyFieldName, "")
        {

        }

        public XYClassTableInfo(string caption, string tableName, string IdFieldName, string nameFieldName, string parentIdFieldName, string moduleFieldName, int moduleValue, string linkFlag, string infoTableName, string infoTableTypeIDFieldName, string infoTableTitleFieldName, string infoTableAddTimeFieldName)
            : this(caption, tableName, IdFieldName, nameFieldName, parentIdFieldName, moduleFieldName, moduleValue, linkFlag, infoTableName, infoTableTypeIDFieldName, infoTableTitleFieldName, infoTableAddTimeFieldName, "", "")
        {

        }

        public XYClassTableInfo(string caption, string tableName, string IdFieldName, string nameFieldName, string parentIdFieldName, string moduleFieldName, int moduleValue, string linkFlag)
            : this(caption, tableName, IdFieldName, nameFieldName, parentIdFieldName, moduleFieldName, moduleValue, linkFlag, "", "", "", "", "", "")
        {

        }

        public override string ToString()
        {
            return this.Caption;
        }
    }
}
