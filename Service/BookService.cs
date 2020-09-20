using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Common;
using System.Data;

namespace Service
{
    /// <summary>
    /// 数据访问类:BookService
    /// </summary>
    public partial class BookService
    {
        public BookService()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int BookId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from book");
            strSql.Append(" where BookId=@BookId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@BookId", MySqlDbType.Int32)
            };
            parameters[0].Value = BookId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Model.Book model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into book(");
            strSql.Append("DUserId,BookTime,ProjectId,ProjectName,UserName,IsVerification)");
            strSql.Append(" values (");
            strSql.Append("@DUserId,@BookTime,@ProjectId,@ProjectName,@UserName,@IsVerification)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@DUserId", MySqlDbType.VarChar,255),
                    new MySqlParameter("@BookTime", MySqlDbType.DateTime),
                    new MySqlParameter("@ProjectId", MySqlDbType.Int32,11),
                    new MySqlParameter("@ProjectName", MySqlDbType.VarChar,255),
                    new MySqlParameter("@UserName", MySqlDbType.VarChar,255),
                    new MySqlParameter("@IsVerification", MySqlDbType.Bit)};
            parameters[0].Value = model.DUserId;
            parameters[1].Value = model.BookTime;
            parameters[2].Value = model.ProjectId;
            parameters[3].Value = model.ProjectName;
            parameters[4].Value = model.UserName;
            parameters[5].Value = model.IsVerification;

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
        public bool Update(Model.Book model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update book set ");
            strSql.Append("DUserId=@DUserId,");
            strSql.Append("BookTime=@BookTime,");
            strSql.Append("ProjectId=@ProjectId,");
            strSql.Append("ProjectName=@ProjectName,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("IsVerification=@IsVerification");
            strSql.Append(" where BookId=@BookId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@DUserId", MySqlDbType.VarChar,255),
                    new MySqlParameter("@BookTime", MySqlDbType.DateTime),
                    new MySqlParameter("@ProjectId", MySqlDbType.Int32,11),
                    new MySqlParameter("@ProjectName", MySqlDbType.VarChar,255),
                    new MySqlParameter("@UserName", MySqlDbType.VarChar,255),
                    new MySqlParameter("@IsVerification", MySqlDbType.Bit),
                    new MySqlParameter("@BookId", MySqlDbType.Int32,11)};
            parameters[0].Value = model.DUserId;
            parameters[1].Value = model.BookTime;
            parameters[2].Value = model.ProjectId;
            parameters[3].Value = model.ProjectName;
            parameters[4].Value = model.UserName;
            parameters[5].Value = model.IsVerification;
            parameters[6].Value = model.BookId;

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
        public bool Delete(int BookId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from book ");
            strSql.Append(" where BookId=@BookId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@BookId", MySqlDbType.Int32)
            };
            parameters[0].Value = BookId;

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
        public bool DeleteList(string BookIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from book ");
            strSql.Append(" where BookId in (" + BookIdlist + ")  ");
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
        public Model.Book GetModel(int BookId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BookId,DUserId,BookTime,ProjectId,ProjectName,UserName,IsVerification from book ");
            strSql.Append(" where BookId=@BookId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@BookId", MySqlDbType.Int32)
            };
            parameters[0].Value = BookId;

            Model.Book model = new Model.Book();
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
        public Model.Book DataRowToModel(DataRow row)
        {
            Model.Book model = new Model.Book();
            if (row != null)
            {
                if (row["BookId"] != null && row["BookId"].ToString() != "")
                {
                    model.BookId = int.Parse(row["BookId"].ToString());
                }
                if (row["DUserId"] != null)
                {
                    model.DUserId = row["DUserId"].ToString();
                }
                if (row["BookTime"] != null && row["BookTime"].ToString() != "")
                {
                    model.BookTime = DateTime.Parse(row["BookTime"].ToString());
                }
                if (row["ProjectId"] != null && row["ProjectId"].ToString() != "")
                {
                    model.ProjectId = int.Parse(row["ProjectId"].ToString());
                }
                if (row["ProjectName"] != null)
                {
                    model.ProjectName = row["ProjectName"].ToString();
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["IsVerification"] != null && row["IsVerification"].ToString() != "")
                {
                    if ((row["IsVerification"].ToString() == "1") || (row["IsVerification"].ToString().ToLower() == "true"))
                    {
                        model.IsVerification = true;
                    }
                    else
                    {
                        model.IsVerification = false;
                    }
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere, string orderby)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BookId,DUserId,BookTime,ProjectId,ProjectName,UserName,IsVerification ");
            strSql.Append(" FROM book ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (orderby != "")
            {
                strSql.Append(" order by " + orderby);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM book ");
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
                strSql.Append("order by T.BookId desc");
            }
            strSql.Append(")AS Row, T.*  from book T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        public DataSet GetListByPageOne(string strWhere, string orderby, int Current, int PageSize)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM book ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.AppendFormat("limit {0},{1}", (Current - 1) * PageSize, PageSize);
            if (string.IsNullOrEmpty(orderby))
            {
                strSql.Append(" order by " + orderby);
            }

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
			parameters[0].Value = "book";
			parameters[1].Value = "BookId";
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
