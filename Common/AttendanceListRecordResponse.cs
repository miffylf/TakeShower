using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class AttendanceListRecordResponse
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
        /// 唯一标示ID
        /// </summary>


        public string id { get; set; }
        /// <summary>
        ///  	考勤组ID
        /// </summary>
        public string groupId { get; set; }
        /// <summary>
        /// 排班ID
        /// </summary>
        public string planId { get; set; }
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
        /// 数据来源 （ATM:考勤机;BEACON:IBeacon;DING_ATM:钉钉考勤机;APP_USER:用户打卡;APP_BOSS:老板改签;APP_APPROVE:审批系统;SYSTEM:考勤系统;APP_AUTO_CHECK:自动打卡）
        /// </summary>
        public string sourceType { get; set; }
        /// <summary>
        /// 时间结果（Normal:正常;Early:早退; Late:迟到;SeriousLate:严重迟到；Absenteeism:旷工迟到；NotSigned:未打卡）
        /// </summary>
        public string timeResult { get; set; }
        /// <summary>
        /// 位置结果（Normal:范围内；Outside:范围外）
        /// </summary>
        public string locationResult { get; set; }
        /// <summary>
        ///  	关联的审批id
        /// </summary>
        public string approveId { get; set; }
        /// <summary>
        /// 关联的审批实例id，可以审批数据获取接口配合使用
        /// </summary>
        public string procInstId { get; set; }
        /// <summary>
        ///  	计算迟到和早退，基准时间
        /// </summary>
        public string baseCheckTime { get; set; }
        /// <summary>
        /// 实际打卡时间
        /// </summary>
        public string userCheckTime { get; set; }
        /// <summary>
        /// 考勤班次id，没有的话表示该次打卡不在排班内
        /// </summary>
        public string classId { get; set; }
        /// <summary>
        /// 是否合法
        /// </summary>
        public string isLegal { get; set; }
        /// <summary>
        /// 定位方法
        /// </summary>
        public string locationMethod { get; set; }
        /// <summary>
        /// 设备id
        /// </summary>
        public string deviceId { get; set; }
        /// <summary>
        /// 用户打卡地址
        /// </summary>
        public string userAddress { get; set; }
        /// <summary>
        /// 用户打卡经度
        /// </summary>
        public string userLongitude { get; set; }
        /// <summary>
        /// 用户打卡纬度
        /// </summary>
        public string userLatitude { get; set; }
        /// <summary>
        /// 用户打卡定位精度
        /// </summary>
        public string userAccuracy { get; set; }
        /// <summary>
        /// 用户打卡wifi SSID
        /// </summary>
        public string userSsid { get; set; }
        /// <summary>
        /// 用户打卡wifi Mac地址
        /// </summary>
        public string userMacAddr { get; set; }
        /// <summary>
        /// 排班打卡时间
        /// </summary>
        public string planCheckTime { get; set; }
        /// <summary>
        /// 基准地址
        /// </summary>
        public string baseAddress { get; set; }
        /// <summary>
        /// 基准经度
        /// </summary>
        public string baseLongitude { get; set; }
        /// <summary>
        /// 基准纬度
        /// </summary>
        public string baseLatitude { get; set; }
        /// <summary>
        /// 基准定位精度
        /// </summary>
        public string baseAccuracy { get; set; }
        /// <summary>
        /// 基准wifi ssid
        /// </summary>
        public string baseSsid { get; set; }
        /// <summary>
        /// 基准 Mac 地址
        /// </summary>
        public string baseMacAddr { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string gmtCreate { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public string gmtModified { get; set; }
        /// <summary>
        /// 打卡备注
        /// </summary>
        public string outsideRemark { get; set; }
    }
}
