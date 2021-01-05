using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorksAssign.Persistence.Adapter;

namespace WorksAssign.Persistence
{
    public class DbAgent : IDisposable
    {
        
        Entities dbCtx;
        //public DateTime StartDate;
        //public V_AllPoints DefaultWorkPoint;
        //public IQueryable<ExWorkdays> HolidaysWorkdays;

        public const long OUTSIDER = 1;
        public const long NO_MANAGER = 0;
        public const long NOT_SUBSTATION = 0;


        public DbAgent() : this(new Entities()) {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctx"></param>
        public DbAgent(Entities ctx) {
            this.dbCtx = ctx;
        }

        public void Dispose() {
            dbCtx.Dispose();
        }

        #region Table Employee

        public IQueryable<Employee> GetEmployee() {
            return dbCtx.Employee;
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

        public long AddWorkContent(DateTime workDate, string content, long substationId, long typeId, string exMember = null, string comment = null) {
            WorkContent wc = new WorkContent();
            wc.Content = content;
            wc.WorkDate = workDate;
            wc.SubstationId = substationId;
            wc.TypeId = typeId;
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

        public WorkInvolve GetWorkInvolve(long id) {
            return dbCtx.WorkInvolve.SingleOrDefault(w => w.Id == id);
        }

        public IQueryable<WorkInvolve> GetWorkInvolveByWorkId(long wid) {
            return dbCtx.WorkInvolve.Where(w => w.WorkId == wid);
        }

        public WorkInvolve GetWorkInvolve(long wid, long eid) {
            return dbCtx.WorkInvolve.SingleOrDefault(w => w.WorkId == wid && w.EmployeeId == eid);
        }

        public long AddWorkInvolve(long wid, long eid, long rid) {
            WorkInvolve wi = new WorkInvolve();
            wi.EmployeeId = eid;
            wi.RoleId = rid;
            wi.WorkId = wid;
            dbCtx.WorkInvolve.Add(wi);
            dbCtx.SaveChanges();
            return wi.Id;
        }

        public long AddWorkInvolve(WorkInvolve wi) {
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
        public IQueryable<V_AllPoints> GetWorkPointById(long id) {
            return dbCtx.V_AllPoints.Where(p => p.EmpId == id);
        }

        public V_AllPoints GetDefaultWorkPoint() {
            V_AllPoints result = new V_AllPoints();

            result.WorkContent = DefaultConstant.WorkContent;
            result.WorkType = DefaultConstant.WorkType;
            result.TypeWgt = GetWorkType(result.WorkType).TypeWgt;
            result.RoleName = DefaultConstant.RoleName;
            result.RoleWgt = DefaultConstant.RoleWgt;
            return result;
        }


        #endregion

        #region Transactions
        public void AddWork(long substationId, long typeId, string workContent, DateTime workDate,
            List<WorkInvolve> involves, string exMember = null, string workComment = null) {
            using (var transcation = dbCtx.Database.BeginTransaction()) {
                long wid = AddWorkContent(workDate, workContent, substationId, typeId, exMember, workComment);
                foreach (var i in involves) {
                    i.WorkId = wid;
                    AddWorkInvolve(i);
                }
                transcation.Commit();
            }
        }

        public void UpdateWork(WorkContent wc, List<WorkInvolve> list, bool needUpdateList=false) {
            using (var transcation = dbCtx.Database.BeginTransaction()) {
                if (needUpdateList) {
                    DelWorkInvolve(wc.Id);
                    foreach (var item in list) {
                        item.WorkId = wc.Id;
                        AddWorkInvolve(item);
                    }
                }
                transcation.Commit();
            }
        }

        //public void UpdateWork(WorkContent wc, List<WorkInvolve> list) {
        //    using (var transcation = dbCtx.Database.BeginTransaction()) {

        //        DelWorkInvolve(wc.ID);
        //        foreach (var item in list) {
        //            item.WID = wc.ID;
        //            AddWorkInvolve(item);
        //        }
        //        transcation.Commit();
        //    }
        //}

        #endregion

    }
}