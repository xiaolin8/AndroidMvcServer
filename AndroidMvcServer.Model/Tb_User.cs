using System;
namespace AndroidMvcServer.Model
{
    /// <summary>
    /// Tb_User:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Tb_User
    {
        public Tb_User()
        { }
        #region Model
        private string _userid;
        private string _username;
        private string _englishname;
        private string _pwd;
        private int? _status;
        private string _deptid;
        private int? _gender;
        private string _signature;
        private int? _headpic;
        private string _cellphone;
        private string _officephone;
        private string _email;
        private string _position;
        private int? _displayindex;
        private string _comment;
        /// <summary>
        /// 
        /// </summary>
        public string UserId
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EnglishName
        {
            set { _englishname = value; }
            get { return _englishname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Pwd
        {
            set { _pwd = value; }
            get { return _pwd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DeptId
        {
            set { _deptid = value; }
            get { return _deptid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Gender
        {
            set { _gender = value; }
            get { return _gender; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Signature
        {
            set { _signature = value; }
            get { return _signature; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? HeadPic
        {
            set { _headpic = value; }
            get { return _headpic; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CellPhone
        {
            set { _cellphone = value; }
            get { return _cellphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OfficePhone
        {
            set { _officephone = value; }
            get { return _officephone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Position
        {
            set { _position = value; }
            get { return _position; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? DisplayIndex
        {
            set { _displayindex = value; }
            get { return _displayindex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Comment
        {
            set { _comment = value; }
            get { return _comment; }
        }
        #endregion Model

    }
}