/******************************************************************************
 * WorksAssign.Persistence 工作安排数据库访问组件
 * CopyRight (C) 2020-2021 TscCai.
 * E-Mail：caijiran@hotmail.com
 *
 * GitHub: https://github.com/TscCai/WorksAssignSystem
 *
 ******************************************************************************
 * 文件名称: DbAgent.cs
 * 文件说明: 数据库访问器
 * 当前版本: 
 * 创建日期: 2020-11-28
 * 2020-01-23: 增加文件说明
******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;

namespace WorksAssign.Persistence
{
    public class DbAgent : IDisposable {
        /// <summary>
        /// 数据库访问实体
        /// </summary>
        WorksAssignEntities dbCtx;

        /// <summary>
        /// 外部人员EmployeeId
        /// </summary>
        public const long OUTSIDER = 1;

        /// <summary>
        /// 无管理人员标记
        /// </summary>
        public const long NO_MANAGER = 0;

        /// <summary>
        /// 无变电站标记
        /// </summary>
        public const long NOT_SUBSTATION = 0;


        public DbAgent() {
            dbCtx = new WorksAssignEntities();
        }

        /// <summary>
        /// 关闭数据库连接，释放dbCtx对象。此方法后调用后必须再次实例化才可操作数据库
        /// </summary>
        public void Dispose() {
            dbCtx.Dispose();
        }

        #region Table Employee

        /// <summary>
        /// 返回所有班组成员，包括1个内置的默认外部人员（Id=1）
        /// </summary>
        /// <returns></returns>
        public IQueryable<Employee> GetEmployee() {
            return GetEmployee(true);
        }


        public IQueryable<Employee> GetEmployee(bool includeOutsider) {
            if (includeOutsider) {
                return dbCtx.Employee;
            }
            else {
                return dbCtx.Employee.Where(e => e.Id > 1);
            }
        }


        public Employee GetEmployee(string name) {
            return dbCtx.Employee.FirstOrDefault(e => e.Name == name);
        }

        public Employee GetEmployee(long id) {
            return dbCtx.Employee.SingleOrDefault(e => e.Id == id);
        }
        #endregion

        #region Table Substation
        public IQueryable<Substations> GetSubstation() {
            return dbCtx.Substations;
        }

        public IQueryable<Substations> GetSubstation(string location) {
            return dbCtx.Substations.Where(s => s.Location == location);
        }

        public Substations GetSubstation(long id) {
            return dbCtx.Substations.SingleOrDefault(s => s.Id == id);
        }

        #endregion

        #region Table WorkContent

        public long AddWorkContent(DateTime workDate, string content, long substationId, long typeId, string shortType, string exMember = null, string comment = null) {
            WorkContent wc = new WorkContent();
            wc.Content = content;
            wc.WorkDate = workDate;
            wc.SubstationId = substationId;
            wc.TypeId = typeId;
            wc.ShortType = shortType;
            wc.ExMember = exMember;
            wc.Comment = comment;
            dbCtx.WorkContent.Add(wc);
            dbCtx.SaveChanges();
            return wc.Id;
        }
        public WorkContent GetWorkContent(long id) {
            return dbCtx.WorkContent.SingleOrDefault(w => w.Id == id);
        }

        public IQueryable<WorkContent> GetWorkContent(DateTime date) {
            return dbCtx.WorkContent.Where(w => w.WorkDate == date);
        }

        public IQueryable<WorkContent> GetWorkContent(DateTime start, DateTime end) {
            return dbCtx.WorkContent.Where(w => w.WorkDate >= start && w.WorkDate <= end);
        }

        public void UpdateWorkContent(WorkContent wc) {
            dbCtx.WorkContent.Add(wc);
            dbCtx.SaveChanges();
        }

        /// <summary>
        /// 将级联删除与之关联的全部Work Involve，且无需显式事务。id不存在时抛出异常
        /// </summary>
        /// <param name="id"></param>
        public void DelWorkContent(long id) {
            var i = GetWorkContent(id);
            dbCtx.WorkInvolve.RemoveRange(i.WorkInvolve);  // remove their involves cascadly
            dbCtx.WorkContent.Remove(i);
            dbCtx.SaveChanges();
        }
        #endregion

        #region TableWorkInvolve

        public IQueryable<WorkInvolve> GetWorkInvolve() {
            return dbCtx.WorkInvolve;
        }

        public IQueryable<WorkInvolve> GetWorkInvolve(DateTime start, DateTime end, long employeeId) {
            return dbCtx.WorkInvolve.Where(wi => wi.WorkContent.WorkDate >= start && wi.WorkContent.WorkDate <= end && wi.EmployeeId == employeeId);
        }

        public WorkInvolve GetWorkInvolve(string id) {
            return dbCtx.WorkInvolve.SingleOrDefault(w => w.Id == id);
        }

        public IQueryable<WorkInvolve> GetWorkInvolveByWorkId(long wid) {
            return dbCtx.WorkInvolve.Where(w => w.WorkId == wid);
        }

        public WorkInvolve GetWorkInvolve(long wid, long eid) {
            return dbCtx.WorkInvolve.SingleOrDefault(w => w.WorkId == wid && w.EmployeeId == eid);
        }

        public string AddWorkInvolve(long wid, long eid, long rid) {
            WorkInvolve wi = new WorkInvolve();
            wi.EmployeeId = eid;
            wi.RoleId = rid;
            wi.WorkId = wid;

            return AddWorkInvolve(wi);
        }

        /// <summary>
        /// 增加一个WorkInvolve，其主键Id将自动生成一个GUID
        /// </summary>
        /// <param name="wi"></param>
        /// <returns></returns>
        public string AddWorkInvolve(WorkInvolve wi) {
            string id = Guid.NewGuid().ToString();
            wi.Id = id;
            dbCtx.WorkInvolve.Add(wi);
            dbCtx.SaveChanges();
            return wi.Id;
        }

        /// <summary>
        /// throw exception if the ids are not exist
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="eid"></param>
        public void DelWorkInvolve(long wid, long eid) {
            var i = GetWorkInvolve(wid, eid);
            dbCtx.WorkInvolve.Remove(i);
            dbCtx.SaveChanges();
        }

        /// <summary>
        /// Delelte workInvolves by workId
        /// </summary>
        /// <param name="wid">WorkContent Id</param>
        public void DelWorkInvolve(long wid) {
            var i = GetWorkInvolveByWorkId(wid);
            dbCtx.WorkInvolve.RemoveRange(i);
            dbCtx.SaveChanges();
        }

        #endregion

        #region Table WorkTypes
        public IQueryable<WorkType> GetWorkType() {
            return dbCtx.WorkType;
        }

        public WorkType GetWorkType(string typeName) {
            return dbCtx.WorkType.SingleOrDefault(t => t.Content == typeName);
        }

        public WorkType GetWorkType(long id) {
            return dbCtx.WorkType.SingleOrDefault(t => t.Id == id);
        }

        public long AddWorkType(string content, double wgt) {
            WorkType i = new WorkType();
            i.Content = content;
            i.TypeWgt = wgt;
            dbCtx.WorkType.Add(i);
            dbCtx.SaveChanges();
            return i.Id;
        }

        public void UpdateWorkType(WorkType wt) {
            dbCtx.SaveChanges();
        }

        #endregion

        #region Table Role

        public IQueryable<Role> GetRole() {
            return dbCtx.Role;
        }

        public IQueryable<Role> GetRole(long workTypeId) {
            return dbCtx.Role.Where(r => r.WorkType.Id == workTypeId);
        }

        //public Role GetRole(long id) {
        //	return db.Role.SingleOrDefault(r => r.ID == id);
        //}

        public Role GetRole(long workTypeId, string roleName) {
            return dbCtx.Role.SingleOrDefault(r => r.TypeId == workTypeId && r.RoleName == roleName);
        }
        #endregion

        #region Table ExWorkdays
        public IQueryable<ExWorkdays> GetHolidaysWorkdays() {
            return dbCtx.ExWorkdays;
        }

        public IQueryable<ExWorkdays> GetHolidaysWorkdays(int year) {
            return dbCtx.ExWorkdays.Where(d => d.Date.Year == year);
        }
        #endregion

        #region View V_AllPoints
        public IQueryable<V_AllPoints> GetWorkPoint(long employeeId) {
            return dbCtx.V_AllPoints.Where(p => p.EmpId == employeeId);
        }

        public IQueryable<V_AllPoints> GetWorkPoint(long employeeId, DateTime start, DateTime end){
            return dbCtx.V_AllPoints.Where(p => p.EmpId == employeeId && p.WorkDate >= start && p.WorkDate <= end).OrderBy(o=>o.WorkDate);
        }




        #endregion

        #region Table AbstractInfo
        public string GetAbstractInfo(string key) {
            return dbCtx.AbstractInfo.SingleOrDefault(k => k.Key == key).Value;
        }
        #endregion

        #region Table Formula
        public string GetFormula(string name) {
            var result = dbCtx.Formula.FirstOrDefault(f=>f.Name == name);
            if (result != null) {
                return result.Expression;
            }
            else {
                return null;
            }
        }


        #endregion

        #region Transactions
        /// <summary>
        /// 增加一项工作安排，将使用数据库事务
        /// </summary>
        /// <param name="substationId">变电站Id</param>
        /// <param name="typeId">工作类型Id</param>
        /// <param name="workContent">工作内容详细</param>
        /// <param name="workDate">工作时间</param>
        /// <param name="shortType">工作短类型</param>
        /// <param name="involves">人员安排</param>
        /// <param name="exMember">外部人员，含厂家、民工、非本班组负责人和管理人员</param>
        /// <param name="workComment">备注</param>
        public void AddWork(long substationId, long typeId, string workContent, DateTime workDate, string shortType,
            List<WorkInvolve> involves, string exMember = null, string workComment = null) {
            using (var transcation = dbCtx.Database.BeginTransaction()) {
                long wid = AddWorkContent(workDate, workContent, substationId, typeId, shortType, exMember, workComment);
                foreach (var i in involves) {
                    i.WorkId = wid;
                    AddWorkInvolve(i);
                }
                transcation.Commit();
            }
        }

        /// <summary>
        /// 更新工作概况及人员安排，将使用数据库事务
        /// </summary>
        /// <param name="wc">工作内容概况</param>
        /// <param name="list">人员安排</param>
        /// <param name="needUpdateList">是否需要更新人员安排</param>
        public void UpdateWork(WorkContent wc, List<WorkInvolve> list, bool needUpdateList = false) {
            using (var transcation = dbCtx.Database.BeginTransaction()) {
                if (needUpdateList) {
                    DelWorkInvolve(wc.Id);
                    foreach (var item in list) {
                        item.WorkId = wc.Id;
                        AddWorkInvolve(item);
                    }
                }
                dbCtx.SaveChanges();
                transcation.Commit();
            }
        }
        #endregion

        /// <summary>
        /// 更新工作概况，而不更新人员安排
        /// </summary>
        /// <param name="wc">工作内容概况</param>
        public void UpdateWork(WorkContent wc) {
            dbCtx.SaveChanges();
        }
    }

    


}