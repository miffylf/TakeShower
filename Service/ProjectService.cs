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
    /// 数据访问类:ProjectService
    /// </summary>
    public partial class ProjectService
    {
        public ProjectService()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ProjectId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from project");
            strSql.Append(" where ProjectId=@ProjectId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@ProjectId", MySqlDbType.Int32)
            };
            parameters[0].Value = ProjectId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Project model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into project(");
            strSql.Append("ProjectName,ProjectStartTime,ProjectEndTime,ProjectCount)");
            strSql.Append(" values (");
            strSql.Append("@ProjectName,@ProjectStartTime,@ProjectEndTime,@ProjectCount)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@ProjectName", MySqlDbType.VarChar,255),
                    new MySqlParameter("@ProjectStartTime", MySqlDbType.DateTime),
                    new MySqlParameter("@ProjectEndTime", MySqlDbType.DateTime),
                    new MySqlParameter("@ProjectCount", MySqlDbType.Int32,11)};
            parameters[0].Value = model.ProjectName;
            parameters[1].Value = model.ProjectStartTime;
            parameters[2].Value = model.ProjectEndTime;
            parameters[3].Value = model.ProjectCount;

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
        public bool Update(Project model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update project set ");
            strSql.Append("ProjectName=@ProjectName,");
            strSql.Append("ProjectStartTime=@ProjectStartTime,");
            strSql.Append("ProjectEndTime=@ProjectEndTime,");
            strSql.Append("ProjectCount=@ProjectCount");
            strSql.Append(" where ProjectId=@ProjectId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@ProjectName", MySqlDbType.VarChar,255),
                    new MySqlParameter("@ProjectStartTime", MySqlDbType.DateTime),
                    new MySqlParameter("@ProjectEndTime", MySqlDbType.DateTime),
                    new MySqlParameter("@ProjectCount", MySqlDbType.Int32,11),
                    new MySqlParameter("@ProjectId", MySqlDbType.Int32,11)};
            parameters[0].Value = model.ProjectName;
            parameters[1].Value = model.ProjectStartTime;
            parameters[2].Value = model.ProjectEndTime;
            parameters[3].Value = model.ProjectCount;
            parameters[4].Value = model.ProjectId;

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
        public bool Delete(int ProjectId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from project ");
            strSql.Append(" where ProjectId=@ProjectId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@ProjectId", MySqlDbType.Int32)
            };
            parameters[0].Value = ProjectId;

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
        public bool DeleteList(string ProjectIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from project ");
            strSql.Append(" where ProjectId in (" + ProjectIdlist + ")  ");
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
        public Project GetModel(int ProjectId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ProjectId,ProjectName,ProjectStartTime,ProjectEndTime,ProjectCount from project ");
            strSql.Append(" where ProjectId=@ProjectId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@ProjectId", MySqlDbType.Int32)
            };
            parameters[0].Value = ProjectId;

            Project model = new Project();
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
        public Project DataRowToModel(DataRow row)
        {
            Project model = new Project();
            if (row != null)
            {
                if (row["ProjectId"] != null && row["ProjectId"].ToString() != "")
                {
                    model.ProjectId = int.Parse(row["ProjectId"].ToString());
                }
                if (row["ProjectName"] != null)
                {
                    model.ProjectName = row["ProjectName"].ToString();
                }
                if (row["ProjectStartTime"] != null && row["ProjectStartTime"].ToString() != "")
                {
                    model.ProjectStartTime = DateTime.Parse(row["ProjectStartTime"].ToString());
                }
                if (row["ProjectEndTime"] != null && row["ProjectEndTime"].ToString() != "")
                {
                    model.ProjectEndTime = DateTime.Parse(row["ProjectEndTime"].ToString());
                }
                if (row["ProjectCount"] != null && row["ProjectCount"].ToString() != "")
                {
                    model.ProjectCount = int.Parse(row["ProjectCount"].ToString());
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
            strSql.Append("select ProjectId,ProjectName,ProjectStartTime,ProjectEndTime,ProjectCount ");
            strSql.Append(" FROM project ");
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
            strSql.Append("select count(1) FROM project ");
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
                strSql.Append("order by T.ProjectId desc");
            }
            strSql.Append(")AS Row, T.*  from project T ");
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
			parameters[0].Value = "project";
			parameters[1].Value = "ProjectId";
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
