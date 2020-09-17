using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Project:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Project
    {
        public Project()
        { }
        #region Model
        private int _projectid;
        private string _projectname;
        private DateTime? _projectstarttime;
        private DateTime? _projectendtime;
        private int? _projectcount;
        /// <summary>
        /// auto_increment
        /// </summary>
        public int ProjectId
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
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ProjectStartTime
        {
            set { _projectstarttime = value; }
            get { return _projectstarttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ProjectEndTime
        {
            set { _projectendtime = value; }
            get { return _projectendtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ProjectCount
        {
            set { _projectcount = value; }
            get { return _projectcount; }
        }
        #endregion Model

    }
}
