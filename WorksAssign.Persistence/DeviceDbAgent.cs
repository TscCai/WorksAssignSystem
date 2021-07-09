using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorksAssign.Persistence
{
    public class DeviceDbAgent:IDisposable
    {
        DeviceEntities dbCtx;
        public DeviceDbAgent() {
            dbCtx = new DeviceEntities();
        }

        public IQueryable<Vx_AllDevice> GetAllDeviceView() {
            IQueryable<Vx_AllDevice> result;
            result = dbCtx.Vx_AllDevice.OrderBy(d=>d.Id);
            return result;
        }


        public void Dispose() {
            dbCtx.Dispose();
        }
    }
}
