using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorksAssign.Persistence;

namespace WorksAssign.Util.Export.DataBuilder
{
    public abstract class BaseDataModelBuilder<T>:IDataModelBuilder<T>
    {
        protected DbAgent db;
        protected HolidayWorkdayDiscriminator hwd;

        public virtual List<T> BuildData() {
            throw new NotImplementedException();
        }
    }
}
