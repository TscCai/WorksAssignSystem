using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorksAssign.Persistence {
    public class DbService {
        WorksAssignEntities db;
        public DateTime StartDate;
        public V_AllPoints DefaultWorkScore;
        public IQueryable<ExWorkdays> HolidaysWorkdays;
        public DbService():this(new WorksAssignEntities())
        {
        }

        public DbService(WorksAssignEntities db)
        {
            this.db = db;
            HolidaysWorkdays = db.ExWorkdays;

            // TODO: StartDate、DefaultWorkScore还未初始化
        }

        #region Table Employee

        public IQueryable<Employee> GetEmpolyee()
        {
            return db.Employee;
        }

        public Employee GetEmployee(string name)
        {
            return db.Employee.FirstOrDefault(e => e.Name == name);
        }

        #endregion

        #region Table Substation
        public IQueryable<Substations> GetSubstation()
        {
            return db.Substations;
        }

        public IQueryable<Substations> GetSubstation(string location)
        {
            return db.Substations.Where(s => s.Location == location);
        }

        public Substations GetSubstation(long id)
        {
            return db.Substations.SingleOrDefault(s => s.Id == id);
        }

        #endregion

        #region Table WorkContent
        public long AddWorkContent(DateTime workDate, string content, long TId)
        {
            WorkContent wc = new WorkContent();
            wc.Content = content;
            wc.WorkDate = workDate;
            wc.TID = TId;
            db.WorkContent.Add(wc);
            db.SaveChanges();
            return wc.ID;
        }
        public WorkContent GetWorkContent(long id)
        {
            return db.WorkContent.SingleOrDefault(w => w.ID == id);
        }

        public IQueryable<WorkContent> GetWorkContent(DateTime date)
        {
            return db.WorkContent.Where(w => w.WorkDate == date);
        }

        public IQueryable<WorkContent> GetWorkContent(DateTime start, DateTime end)
        {
            return db.WorkContent.Where(w => w.WorkDate >= start && w.WorkDate <= end);
        }

        public void UpdateWorkContent(WorkContent wc)
        {
            db.WorkContent.Add(wc);
            db.SaveChanges();
        }

        /// <summary>
        /// throw exception if id not exist
        /// </summary>
        /// <param name="id"></param>
        public void DelWorkContent(long id)
        {
            var i = GetWorkContent(id);
            db.WorkInvolve.RemoveRange(i.WorkInvolve);  // remove their involves cascadly
            db.WorkContent.Remove(i);
            db.SaveChanges();
        }
        #endregion

        #region TableWorkInvolve

        public IQueryable<WorkInvolve> GetWorkInvolve()
        {
            return db.WorkInvolve;
        }

        public WorkInvolve GetWorkInvolve(long id)
        {
            return db.WorkInvolve.SingleOrDefault(w => w.ID == id);
        }

        public IQueryable<WorkInvolve> GetWorkInvolveByWorkId(long wid)
        {
            return db.WorkInvolve.Where(w => w.WID == wid);
        }

        public WorkInvolve GetWorkInvole(long wid, long eid)
        {
            return db.WorkInvolve.SingleOrDefault(w => w.WID == wid && w.EID == eid);
        }

        public long AddWorkInvolve(long wid, long eid, long rid)
        {
            WorkInvolve wi = new WorkInvolve();
            wi.EID = eid;
            wi.RID = rid;
            wi.WID = wid;
            db.WorkInvolve.Add(wi);
            db.SaveChanges();
            return wi.ID;
        }

        /// <summary>
        /// throw exception if the ids are not exist
        /// </summary>
        /// <param name="wid"></param>
        /// <param name="eid"></param>
        public void DelWorkInvolve(long wid, long eid)
        {
            var i = GetWorkInvole(wid, eid);
            db.WorkInvolve.Remove(i);
            db.SaveChanges();
        }

        #endregion

        #region Table WorkTypes
        public IQueryable<WorkType> GetWorkType()
        {
            return db.WorkType;
        }

        public WorkType GetWorkType(long id)
        {
            return db.WorkType.SingleOrDefault(t => t.ID == id);
        }

        public long AddWorkType(string content,double wgt)
        {
            WorkType i = new WorkType();
            i.Content = content;
            i.TypeWgt = wgt;
            db.WorkType.Add(i);
            db.SaveChanges();
            return i.ID;
        }

        public void UpdateWorkType(WorkType wt)
        {
            db.SaveChanges();
        }
        
        #endregion

        #region View V_AllPoints
        public IQueryable<V_AllPoints> GetWorkScoreById(long id)
        {
            return db.V_AllPoints.Where(p => p.EmpId == id);
        }
        #endregion

    }
}