using Common;
using Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    /// <summary>
    /// 数据访问类:UserinfoService
    /// </summary>
    public partial class UserinfoService
    {
        public UserinfoService()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from userinfo");
            strSql.Append(" where UserId=@UserId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@UserId", MySqlDbType.Int32)
            };
            parameters[0].Value = UserId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Userinfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into userinfo(");
            strSql.Append("UserName,UserPwd,Email)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@UserPwd,@Email)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@UserName", MySqlDbType.VarChar,255),
                    new MySqlParameter("@UserPwd", MySqlDbType.VarChar,255),
            new MySqlParameter("@Email", MySqlDbType.VarChar,255)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.UserPwd;
            parameters[2].Value = model.Email;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Userinfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update userinfo set ");
            strSql.Append("UserName=@UserName,");
            strSql.Append("Email=@Email,");
            strSql.Append("UserPwd=@UserPwd");
            strSql.Append(" where UserId=@UserId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@UserName", MySqlDbType.VarChar,255),
                      new MySqlParameter("@Email", MySqlDbType.VarChar,255),
                    new MySqlParameter("@UserPwd", MySqlDbType.VarChar,255),
                    new MySqlParameter("@UserId", MySqlDbType.Int32,11)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.Email;
            parameters[2].Value = model.UserPwd;
            parameters[3].Value = model.UserId;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int UserId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from userinfo ");
            strSql.Append(" where UserId=@UserId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@UserId", MySqlDbType.Int32)
            };
            parameters[0].Value = UserId;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string UserIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from userinfo ");
            strSql.Append(" where UserId in (" + UserIdlist + ")  ");
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Userinfo GetModel(int UserId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserId,UserName,UserPwd,Email from userinfo ");
            strSql.Append(" where UserId=@UserId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@UserId", MySqlDbType.Int32)
            };
            parameters[0].Value = UserId;

            Userinfo model = new Userinfo();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Userinfo DataRowToModel(DataRow row)
        {
            Userinfo model = new Userinfo();
            if (row != null)
            {
                if (row["UserId"] != null && row["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(row["UserId"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["UserPwd"] != null)
                {
                    model.UserPwd = row["UserPwd"].ToString();
                }
                if (row["Email"] != null)
                {
                    model.UserPwd = row["Email"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserId,UserName,UserPwd,Email ");
            strSql.Append(" FROM userinfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM userinfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperMySQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.UserId desc");
            }
            strSql.Append(")AS Row, T.*  from userinfo T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			MySqlParameter[] parameters = {
					new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@PageSize", MySqlDbType.Int32),
					new MySqlParameter("@PageIndex", MySqlDbType.Int32),
					new MySqlParameter("@IsReCount", MySqlDbType.Bit),
					new MySqlParameter("@OrderType", MySqlDbType.Bit),
					new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "userinfo";
			parameters[1].Value = "UserId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
