using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Bath:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Bath
    {
        public Bath()
        { }
        #region Model
        private int _bathid;
        private string _bathname;
        /// <summary>
        /// auto_increment
        /// </summary>
        public int BathId
        {
            set { _bathid = value; }
            get { return _bathid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BathName
        {
            set { _bathname = value; }
            get { return _bathname; }
        }
        #endregion Model
    }
}
