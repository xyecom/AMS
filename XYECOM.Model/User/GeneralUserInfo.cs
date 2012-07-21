using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// �û���Ϣʵ����
    /// ǰ̨ģ����ã����÷�ʽΪ{useinfo.##},������ȫСд
    /// </summary>
    public class GeneralUserInfo
    {
        #region ��������
        /// <summary>
        /// ����������
        /// </summary>
        public int messagecount = 0;

        /// <summary>
        /// ϵͳδ�鿴��������
        /// </summary>
        public int noseesysmsgcount = 0;

        /// <summary>
        /// ���δͨ����ԭ��
        /// </summary>
        public string reason;
        /// <summary>
        /// ���δͨ���Ľ���
        /// </summary>
        public string advice;


        /// <summary>
        /// �û�Id
        /// </summary>
        public long userid = 0;
        /// <summary>
        /// ��¼��
        /// </summary>
        public string LoginName = "";
        
        /// <summary>
        /// ע������
        /// </summary>
        public DateTime regdate = new DateTime();

        /// <summary>
        /// �Ƿ�ͨ�����
        /// </summary>
        public bool isaudited = false;

        /// <summary>
        /// [��˾�����]�ֻ�
        /// </summary>
        public string mobile = "";

        /// <summary>
        /// [��˾�����]��������
        /// </summary>
        public string zipcode = "";

        /// <summary>
        /// [��˾�����]���ڵ�����
        /// </summary>
        public string AreaName = "";

        #endregion

        #region ��ҵ�û�ר���ֶ�
        /// <summary>
        /// �û�����ģ������
        /// </summary>
        public string template = "";
        /// <summary>
        /// ���Բ鿴��ϵ��ʽ����Ŀ��
        /// </summary>
        public int linkmannum = 0;

        /// <summary>
        /// ��ʦ������Ƭ
        /// </summary>
        public string LayerPicture = "";
        /// <summary>
        /// ��ҵbannerͼƬ��ַ
        /// </summary>
        public string banner = "";
        /// <summary>
        /// ��ҵLogoͼƬ��ַ
        /// </summary>
        public string logo = "";
        /// <summary>
        /// �û��ȼ�ͼƬ
        /// </summary>
        public string gradeimgurl = "";

        /// <summary>
        /// �û��ȼ���ͼ��ַ
        /// </summary>
        public string gradebigimgurl = "";
        /// <summary>
        /// ����������
        /// </summary>
        public int infoperfectpercent;
        /// <summary>
        /// �����Ƿ��Ѿ�����
        /// </summary>
        public bool activation = false;
        
        /// <summary>
        /// ��ҵ����
        /// </summary>
        public string CompanyName = "";

        /// <summary>
        /// �Ƿ���Ȩ�޿�������
        /// </summary>
        public bool isshop = false;

        /// <summary>
        /// �Ƿ�����Զ����Ʒ����
        /// </summary>
        public bool iscompanyprotype = false;

        /// <summary>
        /// �����ַ
        /// </summary>
        public string shopindex = "";

        /// <summary>
        /// ������ϵ����ҳ���ַ
        /// </summary>
        public string contactus = "";
        /// <summary>
        /// ����ָ��
        /// </summary>
        public int cred = 0;
        
        /// <summary>
        /// ��ҵ��ҳ
        /// </summary>
        public string homepage = "";

        /// <summary>
        /// ��˾����
        /// </summary>
        public string character = "";

        /// <summary>
        /// ��ҵ����
        /// </summary>
        public string unittype = "";

        /// <summary>
        /// ��ҵ����Id
        /// </summary>
        public int unittypeid = 0;

        /// <summary>
        /// ������ҵid
        /// </summary>
        public string tradeids = "";

        /// <summary>
        /// Ա������
        /// </summary>
        public string employeetotal = "";

        /// <summary>
        /// ��˾ע���
        /// </summary>
        public string regarea = "";

        /// <summary>
        /// ��˾ע���id
        /// </summary>
        public int regareaid = 0;

        /// <summary>
        /// ��ϸ��ַ
        /// </summary>
        private string address = "";

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        /// <summary>
        /// ��Ӫģʽ
        /// </summary>
        public string mode = "";

        /// <summary>
        /// �������
        /// </summary>
        public string regyear = "";

        /// <summary>
        /// ��Ӧ�Ĳ�Ʒ�ͷ���
        /// </summary>
        public string supplypro = "";

        /// <summary>
        /// ����Ĳ�Ʒ�ͷ���
        /// </summary>
        public string buypro = "";

        /// <summary>
        /// ע���ʱ�
        /// </summary>
        public string registeredcapital = "0";

        /// <summary>
        /// ������󴦷�����
        /// </summary>
        public int maliceerr = 0;

        /// <summary>
        /// ������д��������
        /// </summary>
        public int commonerr = 0;

        /// <summary>
        /// ְλ
        /// </summary>
        public string post = "";

        /// <summary>
        /// ���ڲ���
        /// </summary>
        public string department = "";

        /// <summary>
        /// ��ҵ������(1:����;2:��;3:���߶���)
        /// </summary>
        public short supplyorbuy = 0;

        /// <summary>
        /// IM����
        /// </summary>
        public string im = "";

        /// <summary>
        /// ���깫��
        /// </summary>
        public string shopannounce = "";

        #endregion

        #region ���˻�Աר��

        /// <summary>
        /// ���֤����
        /// </summary>
        public string idcode = "";

        /// <summary>
        /// ��ʵ����
        /// </summary>
        public string realname = "";

        #endregion

        public bool isbindingtopdomain = false;
        public string domain = "";
        public bool issubdomain = false;

        /// <summary>
        /// ƽ̨�˻����
        /// </summary>
        public int accountid;
        public decimal creditintegral;

        public Model.CreditLeavlInfo creditleavl;

        public string IdentityNumber { get; set; }

        public int DelState { get; set; }

        public Model.UserType UserType { get; set; }

        public bool IsExport { get; set; }

        public int AreaId { get; set; }

        public string LayerId { get; set; }

        public string IdNumber { get; set; }

        public bool Sex { get; set; }

        public string OtherContact { get; set; }

        public string Telphone { get; set; }

        public string Description { get; set; }

        public string LayerName { get; set; }

        public bool IsPrimary { get; set; }

        public string Email { get; set; }

        public bool IsBoundMobile { get; set; }

        public bool IsBoundEmail { get; set; }

        public int Point { get; set; }

        public bool IsReal { get; set; }

        public int GoodTimes { get; set; }

        public int MidTimes { get; set; }

        public int BadTimes { get; set; }

        public long CompanyId { get; set; }

        public string Fax { get; set; }

        public string LinkMan { get; set; }

        public string PartManagerName { get; set; }

        public string PartManagerTel { get; set; }
    }
}
