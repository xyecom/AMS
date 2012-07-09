using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
   public  class FaithSetInfo
    {
       private System.Int32 _f_id;
       private System.Int32 _gf_fath;
       private System.Int32 _gf_money;
       private System.Int32 _gf_errfath;
       private System.Int32  _gf_errmoney; 
       private string  _gf_remark;

       private System.Int32 _hf_fath;
       private System.Int32 _hf_money;
       private System.Int32 _hf_errfath;
       private System.Int32 _hf_errmoney;
       private string _hf_remark;

       private System.Int32 _uf_fath;
       private System.Int32 _uf_money;
       private System.Int32 _uf_errfath;
       private System.Int32 _uf_errmoney;
       private string _uf_remark;


       private System.Int32 _bf_fath;
       private System.Int32 _bf_money;
       private System.Int32 _bf_errfath;
       private System.Int32 _bf_errmoney;
       private string _bf_remark;

       private int _fs_base;
       private int _fs_hot;
       private int _fs_licence;
       private int _fs_certificate;
       public FaithSetInfo()
       { 
       
       }
       public FaithSetInfo(int F_ID, int GF_Fath, int GF_Money, int GF_ErrFath, int GF_ErrMoney, string GF_Remark, int HF_Fath, int HF_Money, int HF_ErrFath, int HF_ErrMoney, string HF_Remark, int UF_Fath, int UF_Money, int UF_ErrFath, int UF_ErrMoney, string UF_Remark, int BF_Fath, int BF_Money, int BF_ErrFath, int BF_ErrMoney, string BF_Remark,int FS_Base,int FS_Hot,int FS_Licence,int FS_Certificate)
       {
           this._f_id = F_ID;
           this._gf_fath = GF_Fath;
           this._gf_money = GF_Money;
           this._gf_remark = GF_Remark;
           this._gf_errfath = GF_ErrFath;
           this._gf_errmoney = GF_ErrMoney;

           this._hf_fath = HF_Fath;
           this._hf_money = HF_Money;
           this._hf_remark = HF_Remark;
           this._hf_errfath = HF_ErrFath;
           this._hf_errmoney = HF_ErrMoney;

           this._uf_fath = UF_Fath;
           this._uf_money = UF_Money;
           this._uf_remark = UF_Remark;
           this._uf_errfath = UF_ErrFath;
           this._uf_errmoney = UF_ErrMoney;

           this._bf_fath = BF_Fath;
           this._bf_money = BF_Money;
           this._bf_remark = BF_Remark;
           this._bf_errfath = BF_ErrFath;
           this._bf_errmoney = BF_ErrMoney;

           this._fs_base = FS_Base;
           this._fs_hot = FS_Hot;
           this._fs_licence = FS_Licence;
           this._fs_certificate = FS_Certificate;
       }
       
       /// <summary>
       /// 诚信指数设置编号
       /// </summary>
       public System.Int32 F_ID
       {
           get { return _f_id; }
           set { _f_id = value; }
       }

       /// <summary>
       /// 个人资料恶意填写处罚诚信指数
       /// </summary>
       public System.Int32 GF_Fath
       {
           get { return _gf_fath; }
           set { _gf_fath=value ; }
       }

       /// <summary>
       /// 个人资料恶意填写处罚UU币
       /// </summary>
       public System.Int32 GF_Money
       {
           get { return _gf_money; }
           set { _gf_money = value; }
       }

       /// <summary>
       /// 个人资料普通错误处罚诚信指数
       /// </summary>
       public System.Int32 GF_FrrFath
       {
           get { return _gf_errfath; }
           set { _gf_errfath = value; }
       }

       /// <summary>
       /// 个人资料普通错误处罚UU币
       /// </summary>
       public System.Int32 GF_ErrMoney
       {
           get { return _gf_errmoney; }
           set { _gf_errmoney=value ; }
       }

       /// <summary>
       /// 个人资料备注信息
       /// </summary>
       public string GF_Remark
       {
           get { return _gf_remark; }
           set { _gf_remark = value; }
       }

       /// <summary>
       /// 个人高级资料恶意错误处罚诚信指数
       /// </summary>
       public System.Int32 HF_Fath
       {
           get { return _hf_fath; }
           set { _hf_fath = value; }
       }

       /// <summary>
       /// 个人高级资料恶意错误处罚UU币
       /// </summary>
       public System.Int32 HF_Money
       {
           get { return _hf_money; }
           set { _hf_money = value; }
       }

       /// <summary>
       /// 个人高级资料普通错误处罚诚信指数
       /// </summary>
       public System.Int32 HF_FrrFath
       {
           get { return _hf_errfath; }
           set { _hf_errfath = value; }
       }

       /// <summary>
       /// 个人高级资料普通错误处罚UU币
       /// </summary>
       public System.Int32 HF_ErrMoney
       {
           get { return _hf_errmoney; }
           set { _hf_errmoney = value; }
       }

       /// <summary>
       /// 个人高级资料备注信息
       /// </summary>
       public string HF_Remark
       {
           get { return _hf_remark; }
           set { _hf_remark = value; }
       }

       /// <summary>
       /// 用户证书恶意填写处罚诚信指数
       /// </summary>
       public System.Int32 UF_Fath
       {
           get { return _uf_fath; }
           set { _uf_fath = value; }
       }

       /// <summary>
       /// 用户证书恶意填写处罚UU币
       /// </summary>
       public System.Int32 UF_Money
       {
           get { return _uf_money; }
           set { _uf_money = value; }
       }

       /// <summary>
       /// 用户证书普通错误填写处罚诚信指数
       /// </summary>
       public System.Int32 UF_FrrFath
       {
           get { return _uf_errfath; }
           set { _uf_errfath = value; }
       }

       /// <summary>
       /// 用户证书普通错误处罚UU币
       /// </summary>
       public System.Int32 UF_ErrMoney
       {
           get { return _uf_errmoney; }
           set { _uf_errmoney = value; }
       }

       /// <summary>
       /// 用户证书备注信息
       /// </summary>
       public string UF_Remark
       {
           get { return _uf_remark ; }
           set { _uf_remark = value; }
       }
       
       /// <summary>
       /// 商业信息恶意填写处罚诚信指数
       /// </summary>
       public System.Int32 BF_Fath
       {
           get { return _bf_fath; }
           set { _bf_fath = value; }
       }

       /// <summary>
       /// 商业信息恶意填写处罚UU币
       /// </summary>
       public System.Int32 BF_Money
       {
           get { return _bf_money; }
           set { _bf_money = value; }
       }

       /// <summary>
       /// 商业信息普通错误填写处罚诚信指数
       /// </summary>
       public System.Int32 BF_FrrFath
       {
           get { return _bf_errfath; }
           set { _bf_errfath = value; }
       }

       /// <summary>
       /// 商业信息普通错误处罚UU币
       /// </summary>
       public System.Int32 BF_ErrMoney
       {
           get { return _bf_errmoney; }
           set { _bf_errmoney = value; }
       }

       /// <summary>
       /// 商业信息备注信息
       /// </summary>
       public string BF_Remark
       {
           get { return _bf_remark; }
           set { _bf_remark = value; }
       }

       /// <summary>
       /// 完成基本资料必填项增加指数值
       /// </summary>
       public int FS_Base
       {
           get { return _fs_base; }
           set { _fs_base = value; }
       }

       /// <summary>
       /// 完成高级资料必填项增加指数值
       /// </summary>
       public int FS_Hot
       {
           get { return _fs_hot; }
           set { _fs_hot = value; }
       }

       /// <summary>
       /// 完成营业执照增加指数值
       /// </summary>
       public int FS_Licence
       {
           get { return _fs_licence; }
           set { _fs_licence = value; }
       }

       /// <summary>
       /// 完成其他资质证书增加指数值
       /// </summary>
       public int FS_Certificate
       {
           get { return _fs_certificate; }
           set { _fs_certificate = value; }
       }
    }
}
