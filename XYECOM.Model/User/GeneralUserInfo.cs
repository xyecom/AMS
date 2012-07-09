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
        /// <summary>
        /// �û����� true ��ҵ��Ա false ���˻�Ա
        /// </summary>
        public bool usertype = true;

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
        public int userid = 0;
        /// <summary>
        /// ��¼��
        /// </summary>
        public string loginname = "";
        /// <summary>
        /// �Ա�
        /// </summary>
        public string sex = "";
        /// <summary>
        /// �Ա�bool��
        /// </summary>
        public bool sexbool = true;
        /// <summary>
        /// �ʼ�
        /// </summary>
        public string email = "";

        /// <summary>
        /// ע������
        /// </summary>
        public DateTime regdate = new DateTime();

        /// <summary>
        /// �Ƿ�ͨ�����
        /// </summary>
        public bool isaudited = false;

        /// <summary>
        /// [��˾�����]�绰
        /// </summary>
        public string telephone = "";
        /// <summary>
        /// [��˾�����]�ֻ�
        /// </summary>
        public string mobile = "";

        /// <summary>
        /// [��˾�����]��������
        /// </summary>
        public string zipcode = "";

        /// <summary>
        /// [��˾�����]���ڵ�Id
        /// </summary>
        public int areaid = 0;

        /// <summary>
        /// [��˾�����]���ڵ�����
        /// </summary>
        public string areaname = "";

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
        /// ����
        /// </summary>
        public int mark = 0;
        /// <summary>
        /// �ȼ�����
        /// </summary>
        public string gradename = "";

        /// <summary>
        /// �ȼ�Id
        /// </summary>
        public int gradeid = 0;

        /// <summary>
        /// ��ǰ��Ա�ȼ��ڼ���
        /// </summary>
        public string years = "";
        /// <summary>
        /// ��ҵ����ͼƬ
        /// </summary>
        public string imgurl = "";
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
        public string unitname = "";

        /// <summary>
        /// ��ҵ����(����ȡ��unitname)
        /// </summary>
        public string name = "";
        /// <summary>
        /// ��ϵ��
        /// </summary>
        public string linkman = "";

        /// <summary>
        /// ����
        /// </summary>
        public string fax = "";

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
        /// ��ҵ���
        /// </summary>
        public string synopsis = "";

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
        public string address = "";

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
        /// ��Ӫ��ַ
        /// </summary>
        public string manageaddress = "";

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
    }
}
