using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class CreateUserResponse
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
        ///  	员工唯一标识
        /// </summary>
        public string id { get; set; }
    }
}
