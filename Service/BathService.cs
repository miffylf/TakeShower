using Common;
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
    /// 数据访问类:BathService
    /// </summary>
    public partial class BathService
    {
        public BathService()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int BathId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from bath");
            strSql.Append(" where BathId=@BathId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@BathId", MySqlDbType.Int32)
            };
            parameters[0].Value = BathId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Model.Bath model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into bath(");
            strSql.Append("BathName)");
            strSql.Append(" values (");
            strSql.Append("@BathName)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@BathName", MySqlDbType.VarChar,255)};
            parameters[0].Value = model.BathName;

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
        public bool Update(Model.Bath model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update bath set ");
            strSql.Append("BathName=@BathName");
            strSql.Append(" where BathId=@BathId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@BathName", MySqlDbType.VarChar,255),
                    new MySqlParameter("@BathId", MySqlDbType.Int32,11)};
            parameters[0].Value = model.BathName;
            parameters[1].Value = model.BathId;

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
        public bool Delete(int BathId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from bath ");
            strSql.Append(" where BathId=@BathId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@BathId", MySqlDbType.Int32)
            };
            parameters[0].Value = BathId;

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
        public bool DeleteList(string BathIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from bath ");
            strSql.Append(" where BathId in (" + BathIdlist + ")  ");
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
        public Model.Bath GetModel(int BathId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BathId,BathName from bath ");
            strSql.Append(" where BathId=@BathId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@BathId", MySqlDbType.Int32)
            };
            parameters[0].Value = BathId;

            Model.Bath model = new Model.Bath();
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
        public Model.Bath DataRowToModel(DataRow row)
        {
            Model.Bath model = new Model.Bath();
            if (row != null)
            {
                if (row["BathId"] != null && row["BathId"].ToString() != "")
                {
                    model.BathId = int.Parse(row["BathId"].ToString());
                }
                if (row["BathName"] != null)
                {
                    model.BathName = row["BathName"].ToString();
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
            strSql.Append("select BathId,BathName ");
            strSql.Append(" FROM bath ");
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
            strSql.Append("select count(1) FROM bath ");
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
                strSql.Append("order by T.BathId desc");
            }
            strSql.Append(")AS Row, T.*  from bath T ");
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
			parameters[0].Value = "bath";
			parameters[1].Value = "BathId";
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
