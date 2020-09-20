using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// book:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Book
    {
        public Book()
        { }
        #region Model
        private int _bookid;
        private string _duserid;
        private DateTime? _booktime;
        private int? _projectid;
        private string _projectname;
        /// <summary>
        /// auto_increment
        /// </summary>
        public int BookId
        {
            set { _bookid = value; }
            get { return _bookid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DUserId
        {
            set { _duserid = value; }
            get { return _duserid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? BookTime
        {
            set { _booktime = value; }
            get { return _booktime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ProjectId
        {
            set { _projectid = value; }
            get { return _projectid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProjectName
        {
            set { _projectname = value; }
            get { return _projectname; }
        }
        #endregion Model

    }
}
