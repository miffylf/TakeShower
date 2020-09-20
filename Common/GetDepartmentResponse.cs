using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class GetDepartmentResponse
    {
        /// <summary>
		/// 返回码
		/// </summary>
		public string errcode { get; set; }
        /// <summary>
        /// 对返回码的文本描述内容
        /// </summary>
        public string errmsg { get; set; }
        /// <summary>
        ///  	创建的部门id
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 部门列表数据，以部门的order字段从小到大排列
        /// </summary>
        public string departmenet { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 父部门id，根部门为1
        /// </summary>
        public string parentid { get; set; }
        /// <summary>
        /// 是否同步创建一个关联此部门的企业群，true表示是，false表示不是
        /// </summary>
        public string createDeptGroup { get; set; }
        /// <summary>
        /// 当群已经创建后，是否有新人加入部门会自动加入该群, true表示是，false表示不是
        /// </summary>
        public string autoAddUser { get; set; }
    }
}
