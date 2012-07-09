using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 证书信息实体类
    /// </summary>
    public class CertificateInfo
    {
        private long _ce_id;
        private long _u_id;
        private string _ce_name;
       
        private string _ce_organ;
        private DateTime _ce_begin;
        private DateTime _ce_upto;
        private DateTime _ce_addtime;
        private int _ce_type;
      
        private bool _ce_isopen;

        /// <summary>
        /// 证书id
        /// </summary>
        public CertificateInfo()
        { }
        public CertificateInfo(long ceid, long uid, string name,string organ, DateTime begin, DateTime upto, DateTime addtime, int type, string isopen)
        {
            this._ce_id = ceid;
            this._u_id = uid;
            this._ce_name = name;
           
            this._ce_organ = organ;
            this._ce_begin = begin;
            this._ce_upto = upto;
            this._ce_addtime = addtime;
            this._ce_type = type;
            if (isopen == "true")
            {
                this._ce_isopen = true;
            }
            else
            {
                this._ce_isopen = false;
            }
        }

        public long CE_ID
        {
            get { return _ce_id; }
            set { _ce_id = value; }
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        public long U_ID
        {
            get { return _u_id; }
            set { _u_id = value; }
        }
        /// <summary>
        /// 证书名称
        /// </summary>
        public string CE_Name
        {
            get { return _ce_name; }
            set { _ce_name = value; }
        }
       
        /// <summary>
        /// 发证机构
        /// </summary>
        public string CE_Organ
        {
            set { _ce_organ = value; }
            get { return _ce_organ; }
        }
        /// <summary>
        /// 生效日期
        /// </summary>
        public DateTime CE_Begin
        {
            set { _ce_begin = value; }
            get { return _ce_begin; }
        }
        /// <summary>
        /// 截至日期
        /// </summary>
        public DateTime CE_Upto
        {
            set { _ce_upto = value; }
            get { return _ce_upto; }
        }
        /// <summary>
        /// 证书添加时间
        /// </summary>
        public DateTime CE_Addtime
        {
            get { return _ce_addtime; }
            set { _ce_addtime=value; }
        }
        /// <summary>
        /// 证书类型1税务等级2经营许可3产品证书4其它证书
        /// </summary>
        public int CE_Type
        {
            set { _ce_type = value; }
            get { return _ce_type; }
        }
        /// <summary>
        /// 是否启用true启用false
        /// </summary>
        public bool CE_Isopen
        {
            get { return _ce_isopen; }
            set { _ce_isopen = value; }
        }

        private Model.AuditingState auditingState = AuditingState.NoPass;
        /// <summary>
        /// 审核状态
        /// </summary>
        public Model.AuditingState AuditingState
        {
            get { return auditingState; }
            set { auditingState = value; }
        }
    }
}
