using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorksAssign.Persistence;

namespace WorksAssign.Util.Export.DataBuilder
{
    public interface IDataModelBuilder<T>
    {
        
         List<T> BuildData();

    }
}
