using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class EnterpriseBusiness
    {
        /// <summary>
        /// 拿到企业令牌
        /// </summary>
        /// <param name="CorpId"></param>
        /// <param name="CorpSecret"></param>
        /// <returns></returns>
        public static TokenModel GetToken(string CorpId, string CorpSecret)
        {
            string tagUrl = "https://oapi.dingtalk.com/gettoken?corpid=" + CorpId + "&corpsecret=" + CorpSecret;
            string result = HttpHelper.Get(tagUrl);

            var tokenModel = JsonConvert.DeserializeObject<TokenModel>(result);
            return tokenModel;
        }

        /// <summary>
        /// 拿到企业令牌(新版)
        /// </summary>
        /// <param name="CorpId"></param>
        /// <param name="CorpSecret"></param>
        /// <returns></returns>
        public static TokenModel GetTokenNew(string AppKey, string AppSecret)
        {
            string tagUrl = "https://oapi.dingtalk.com/gettoken?appkey=" + AppKey + "&appsecret=" + AppSecret;
            string result = HttpHelper.Get(tagUrl);

            var tokenModel = JsonConvert.DeserializeObject<TokenModel>(result);
            return tokenModel;
        }

        /// <summary>
        /// 拿到企业令牌(新版)
        /// </summary>
        /// <param name="CorpId"></param>
        /// <param name="CorpSecret"></param>
        /// <returns></returns>
        public static JsTicket GetJsApiTicket(string access_token)
        {
            string tagUrl = "https://oapi.dingtalk.com/get_jsapi_ticket?access_token=" + access_token;
            string result = HttpHelper.Get(tagUrl);

            var tokenModel = JsonConvert.DeserializeObject<JsTicket>(result);
            return tokenModel;
        }

        /// <summary>
        /// 拿到当前登录的用户
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static UserModel GetCurrentUser(string access_token, string code)
        {
            string tagUrl = "https://oapi.dingtalk.com/user/getuserinfo?access_token=" + access_token + "&code=" + code;
            string result = HttpHelper.Get(tagUrl);

            var userModel = JsonConvert.DeserializeObject<UserModel>(result);
            return userModel;
        }



        /// <summary>
        /// 拿到当前登录的用户
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static UserInfo GetUserInfo(string access_token, string userid)
        {
            string tagUrl = "https://oapi.dingtalk.com/user/get?access_token=" + access_token + "&userid=" + userid;
            string result = HttpHelper.Get(tagUrl);

            var userModel = JsonConvert.DeserializeObject<UserInfo>(result);
            return userModel;
        }


        public static List<AttendanceListRecordResponse> GetAttendanceList(string access_token, string param)
        {
            List<AttendanceListRecordResponse> attendanceListRecordResponse = new List<AttendanceListRecordResponse>();
            string tagUrl = "https://oapi.dingtalk.com/attendance/listRecord?access_token=" + access_token + "";
            string result = HttpHelper.Post(tagUrl, param);
            JObject jObject = JObject.Parse(result);
            JToken jToken = jObject["recordresult"];


            if (jToken == null) return attendanceListRecordResponse;
            foreach (var jp in jToken)
            {
                AttendanceListRecordResponse temp = new AttendanceListRecordResponse();
                temp.userId = jp["userId"].ToString();
                temp.userAddress = jp["userAddress"] == null ? string.Empty : jp["userAddress"].ToString();
                System.DateTime time = System.DateTime.MinValue;
                System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
                time = startTime.AddMilliseconds(Convert.ToDouble(jp["userCheckTime"]));
                temp.userCheckTime = time.ToString();
                attendanceListRecordResponse.Add(temp);
            }

            //var attendanceListRecordResponse = JsonConvert.DeserializeObject<AttendanceListRecordResponse>(jToken.ToString());
            return attendanceListRecordResponse;
        }

        public static CreateUserResponse CreateUserResponse(string access_token, string param)
        {
            string tagUrl = "https://oapi.dingtalk.com/user/create?access_token=" + access_token + "";
            string result = HttpHelper.Post(tagUrl, param);

            var createUserResponse = JsonConvert.DeserializeObject<CreateUserResponse>(result);
            return createUserResponse;
        }

        /// <summary>
        /// 拿到Tickets
        /// </summary>
        /// <param name="CorpId"></param>
        /// <param name="CorpSecret"></param>
        /// <returns></returns>
        public static AttendanceModel GetTickets(string access_token)
        {
            string url = "https://oapi.dingtalk.com/get_jsapi_ticket?access_token={0}&type=jsapi";
            url = string.Format(url, access_token);
            string result = HttpHelper.Get(url);
            var attendanceModel = JsonConvert.DeserializeObject<AttendanceModel>(result);

            return attendanceModel;
        }


        public static AttendanceModel GetAttendance(string access_token)
        {
            string url = "https://oapi.dingtalk.com/attendance/list?access_token={0}";
            url = string.Format(url, access_token);
            string result = HttpHelper.Get(url);
            var attendanceModel = JsonConvert.DeserializeObject<AttendanceModel>(result);
            return attendanceModel;
        }


        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userid">用户id</param>
        /// <returns></returns>
        public static DeteleUserResponse DeleteUser(string access_token, string userid)
        {
            string tagUrl = "https://oapi.dingtalk.com/user/delete?access_token={0}&userid={1}";
            tagUrl = string.Format(tagUrl, access_token, userid);
            string result = HttpHelper.Get(tagUrl);
            var deleteUserResponse = JsonConvert.DeserializeObject<DeteleUserResponse>(result);
            return deleteUserResponse;
        }


        /// <summary>
        /// 创建部门
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="param">用户id</param>
        /// <returns></returns>
        public static DepartmentCreateResponse CreateDepart(string access_token, string param)
        {
            string tagUrl = "https://oapi.dingtalk.com/department/create?access_token=" + access_token + "";
            tagUrl = string.Format(tagUrl, param);
            string result = HttpHelper.Get(tagUrl);
            var deleteUserResponse = JsonConvert.DeserializeObject<DepartmentCreateResponse>(result);
            return deleteUserResponse;
        }

        /// <summary>
        /// 获取部门信息
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public static List<GetDepartmentResponse> GetGetDepartment(string access_token)
        {
            List<GetDepartmentResponse> lstgetDepartmentResponses = new List<GetDepartmentResponse>();
            string tagUrl = "https://oapi.dingtalk.com/department/list?access_token=" + access_token + "";
            //tagUrl = string.Format(tagUrl, param);
            string result = HttpHelper.Get(tagUrl);
            JObject jObject = JObject.Parse(result);
            JToken jToken = jObject["department"];


            if (jToken == null) return lstgetDepartmentResponses;
            foreach (var jp in jToken)
            {
                GetDepartmentResponse temp = new GetDepartmentResponse();
                temp.id = jp["id"].ToString();
                temp.name = jp["name"].ToString();
                //System.DateTime time = System.DateTime.MinValue;
                //System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
                //time = startTime.AddMilliseconds(Convert.ToDouble(jp["userCheckTime"]));
                //temp.userCheckTime = time.ToString();
                lstgetDepartmentResponses.Add(temp);
            }


            //var getdepartment = JsonConvert.DeserializeObject<GetDepartmentResponse>(result);
            return lstgetDepartmentResponses;
        }

        /// <summary>
        /// 获取部门信息
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public static List<GetUsersResponse> GetUserResponse(string access_token, string departmentid)
        {
            List<GetUsersResponse> lstgetUserResponse = new List<GetUsersResponse>();
            string tagUrl = "https://oapi.dingtalk.com/user/simplelist?access_token=" + access_token + "&department_id=" + departmentid + "";
            //tagUrl = string.Format(tagUrl, param);
            string result = HttpHelper.Get(tagUrl);
            JObject jObject = JObject.Parse(result);
            JToken jToken = jObject["userlist"];


            if (jToken == null) return lstgetUserResponse;
            foreach (var jp in jToken)
            {
                GetUsersResponse temp = new GetUsersResponse();
                temp.userid = jp["userid"].ToString();
                temp.username = jp["name"].ToString();
                //System.DateTime time = System.DateTime.MinValue;
                //System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
                //time = startTime.AddMilliseconds(Convert.ToDouble(jp["userCheckTime"]));
                //temp.userCheckTime = time.ToString();
                lstgetUserResponse.Add(temp);
            }


            //var getdepartment = JsonConvert.DeserializeObject<GetDepartmentResponse>(result);
            return lstgetUserResponse;
        }
    }
}
