using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AndroidMvcServer.Model
{
    /// <summary>
    /// Tb_Dept:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Tb_Dept
    {
        public Tb_Dept()
        { }
        #region Model
        private string _depid;
        private string _depname;
        private string _pardepid;
        private int? _displayindex;
        private string _directorid;
        private string _depemail;
        private int? _status;
        private int? _isleaf;
        private string _comment;
        /// <summary>
        /// 
        /// </summary>
        public string DepId
        {
            set { _depid = value; }
            get { return _depid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DepName
        {
            set { _depname = value; }
            get { return _depname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ParDepId
        {
            set { _pardepid = value; }
            get { return _pardepid; }
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
        public string DirectorId
        {
            set { _directorid = value; }
            get { return _directorid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DepEmail
        {
            set { _depemail = value; }
            get { return _depemail; }
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
        public int? IsLeaf
        {
            set { _isleaf = value; }
            get { return _isleaf; }
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