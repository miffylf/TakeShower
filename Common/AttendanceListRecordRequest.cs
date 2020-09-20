using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class AttendanceListRecordRequest
    {
        /// <summary>
        /// 调用接口凭证
        /// </summary>
        public string access_token { get; set; }
        /// <summary>
        ///  员工UserID列表。列表长度在1到20之间
        /// </summary>
        public List<string> userIds { get; set; }
        /// <summary>
        /// 查询考勤打卡记录的起始工作日
        /// </summary>
        public string checkDateFrom { get; set; }
        /// <summary>
        ///  	查询考勤打卡记录的结束工作日。注意，起始与结束工作日最多相隔7天
        /// </summary>
        public string checkDateTo { get; set; }

        public string GetParam(AttendanceListRecordRequest attendanceListRecordRequest)
        {
            string userlist = string.Empty;
            for (int i = 0; i < userIds.Count; i++)
            {
                if (userIds.Count > 0)
                {
                    userlist += "\"" + userIds[i] + "\",";
                }
                if (userIds.Count == 0)
                {
                    userlist += "\"" + userIds[i] + "\"";
                }
                if (i == userIds.Count - 1)
                {
                    userlist += "\"" + userIds[i] + "\"";
                }
            }
            string param = "{\"access_token\":\"" + attendanceListRecordRequest.access_token + "\",\"userIds\":[" + userIds + "],\"checkDateFrom\":\"" + attendanceListRecordRequest.checkDateFrom + "\",\"checkDateTo\":\"" + attendanceListRecordRequest.checkDateTo + "\"}";
            return param;
        }
    }
}
