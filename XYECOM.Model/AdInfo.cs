using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// ��������ʵ����
    /// </summary>
    public class AdInfo
    {

        private int _ad_id;
        private long _ap_id;
        private string _ad_name;
        private string _ad_linkurl;
        private short _ad_type;
        private bool _ad_opentype;
        private string _ad_notetext;
        private string _ad_picurl;
        private string _ad_alt;
        private int _ad_width;
        private int _ad_high;
        private string _ad_letter;
        private string _ad_font; 
        private int _ad_size;
        private string _ad_color;
        private string _ad_jsname;
        private string _ad_codecontent;
        private DateTime _ad_StartDate;
        private DateTime _ad_EndDate;
        private int _ad_Traffic;

        public int Ad_Traffic
        {
            get { return _ad_Traffic; }
            set { _ad_Traffic = value; }
        }
        
        

        public AdInfo()
        {
            _ad_id = 0;
            _ap_id = 0;
            _ad_name = "";
            _ad_linkurl = "";
            _ad_type = 0;
            _ad_opentype = false;
            _ad_notetext = "";
            _ad_picurl = "";
            _ad_alt = "";
            _ad_width = 0;
            _ad_high = 0;
            _ad_letter = "";
            _ad_font = "";
            _ad_size = 0;
            _ad_color = "";
            _ad_jsname = "";
            _ad_codecontent = "";
            _ad_StartDate = DateTime.Now;

        }

        /// <summary>
        /// ��������
        /// </summary>
        public int AD_ID
        {
            set { _ad_id = value; }
            get { return _ad_id; }
        }
        /// <summary>
        /// ���������
        /// </summary>
        public string AD_Name
        {
            set { _ad_name = value; }
            get { return _ad_name; }
        }
        public long AP_ID
        {
            set { _ap_id = value; }
            get { return _ap_id; }
        }
        /// <summary>
        /// ��������ӵ�ַ
        /// </summary>
        public string AD_LinkURL
        {
            set { _ad_linkurl = value; }
            get { return _ad_linkurl; }
        }
        /// <summary>
        /// ���������
        /// </summary>
        public short AD_Type
        {
            set { _ad_type = value; }
            get { return _ad_type; }
        }
        /// <summary>
        /// ������򿪷�ʽ
        /// </summary>
        public bool AD_OpenType
        {
            set { _ad_opentype = value; }
            get { return _ad_opentype; }
        }
        /// <summary>
        /// ���ֹ������
        /// </summary>
        public string AD_NoteText
        {
            set { _ad_notetext = value; }
            get { return _ad_notetext; }
        }
        /// <summary>
        /// ͼƬ/�������URL
        /// </summary>
        public string AD_PicURL
        {
            set { _ad_picurl = value; }
            get { return _ad_picurl; }
        }
        /// <summary>
        /// �����ע��
        /// </summary>
        public string AD_Alt
        {
            set { _ad_alt = value; }
            get { return _ad_alt; }
        }
        /// <summary>
        /// ͼƬflash ���
        /// </summary>
        public int AD_Width
        {
            set { _ad_width = value; }
            get { return _ad_width; }
        }
        /// <summary>
        /// ͼƬflash �ĸ߶�
        /// </summary>
        public int AD_High
        {
            set { _ad_high = value; }
            get { return _ad_high; }
        }
        /// <summary>
        /// ͼƬ���� �滻����
        /// </summary>
        public string AD_Letter
        {
            set { _ad_letter = value; }
            get { return _ad_letter; }

        }
        /// <summary>
        /// ���ֹ��������ʽ1����2����3����4Ĭ��
        /// </summary>
        public string AD_Font
        {
            set { _ad_font = value; }
            get { return _ad_font; }
        }
        /// <summary>
        /// ���ֹ��������С
        /// </summary>
        public int AD_Size
        {
            set { _ad_size = value; }
            get { return _ad_size; }
        }
        /// <summary>
        /// ���ֹ����ɫ
        /// </summary>
        public string AD_Color
        {
            set { _ad_color = value; }
            get { return _ad_color; }
        }
        /// <summary>
        /// JS�ļ�����
        /// </summary>
        public string AD_JSname
        {
            set { _ad_jsname = value; }
            get { return _ad_jsname; }
        }

        /// <summary>
        /// ����������
        /// </summary>
        public string AD_CodeContent
        {
            set { _ad_codecontent = value; }
            get { return _ad_codecontent; }
        }



        /// <summary>
        /// ��濪ʼʱ��
        /// </summary>
        public DateTime Ad_StartDate
        {
            get { return _ad_StartDate; }
            set { _ad_StartDate = value; }
        }

        /// <summary>
        /// ������ʱ��
        /// </summary>
        public DateTime Ad_EndDate
        {
            get { return _ad_EndDate; }
            set { _ad_EndDate = value; }
        }

    }
}