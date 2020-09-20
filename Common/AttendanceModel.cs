using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class AttendanceModel
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
        /// 分页返回参数，表示是否还有更多数据
        /// </summary>
        public string hasMore { get; set; }
        /// <summary>
        /// 唯一标示
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 考勤组ID
        /// </summary>
        public string groupId { get; set; }
        /// <summary>
        /// 排班ID
        /// </summary>
        public string planId { get; set; }
        /// <summary>
        /// 打卡记录ID
        /// </summary>
        public string recordId { get; set; }
        /// <summary>
        /// 工作日
        /// </summary>
        public string workDate { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public string userId { get; set; }
        /// <summary>
        /// 考勤类型（OnDuty：上班，OffDuty：下班）
        /// </summary>
        public string checkType { get; set; }
        /// <summary>
        /// 时间结果（Normal:正常;Early:早退; Late:迟到;SeriousLate:严重迟到；Absenteeism:旷工迟到； NotSigned:未打卡）
        /// </summary>
        public string timeResult { get; set; }
        /// <summary>
        /// 位置结果（Normal:范围内；Outside:范围外；NotSigned:未打卡）
        /// </summary>
        public string locationResult { get; set; }
        /// <summary>
        /// 关联的审批id
        /// </summary>
        public string approveId { get; set; }
        /// <summary>
        /// 关联的审批实例id
        /// </summary>
        public string procInstId { get; set; }
        /// <summary>
        /// 计算迟到和早退，基准时间
        /// </summary>
        public string baseCheckTime { get; set; }

        /// <summary>
        /// 实际打卡时间
        /// </summary>
        public string userCheckTime { get; set; }

        /// <summary>
        /// 数据来源 （ATM:考勤机;BEACON:IBeacon;DING_ATM:钉钉考勤机;APP_USER:用户打卡;APP_BOSS:老板改签;APP_APPROVE:审批系统;SYSTEM:考勤系统;APP_AUTO_CHECK:自动打卡）
        /// </summary>
        public string sourceType { get; set; }
    }
}
