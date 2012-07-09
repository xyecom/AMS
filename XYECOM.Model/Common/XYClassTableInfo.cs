using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// �������Ϣ
    /// </summary>
    public class XYClassTableInfo
    {
        public int ModuleValue;

        public string Caption;
        /// <summary>
        /// ���������
        /// </summary>
        public string TableName;
        /// <summary>
        /// �����ID�ֶ�����
        /// </summary>
        public string IdFieldName;
        /// <summary>
        /// �������������ֶ�����
        /// </summary>
        public string NameFieldName;
        /// <summary>
        /// �������Id�ֶ�����
        /// </summary>
        public string ParentIdFieldName;
        /// <summary>
        /// �����ģ���ֶ�����
        /// </summary>
        public string ModuleFieldName;

        /// <summary>
        /// ��Ϣ��(��ͼ)����
        /// </summary>
        public string InfoTableName;
        /// <summary>
        /// ��Ϣ������ID�ֶ�����
        /// </summary>
        public string InfoTableTypeIDFieldName;

        /// <summary>
        /// ��Ϣ�����ֶ�����
        /// </summary>
        public string InfoTableTitleFieldName;
        /// <summary>
        /// ��Ϣ���ʱ���ֶ�����
        /// </summary>
        public string InfoTableAddTimeFieldName;
        /// <summary>
        /// ��Ϣ���Ƿ���ͣ�ֶ�����
        /// </summary>
        public string InfoTableIsSupplyFieldName;
        /// <summary>
        /// ��Ϣ����Ϣ����ʱ���ֶ�����
        /// </summary>
        public string InfoTableEndTimeFieldName;
        /// <summary>
        /// ��Ϣ���ʶ�ֶ�����
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
