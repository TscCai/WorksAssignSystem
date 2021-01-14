using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorksAssign.Persistence
{
    public class DatabaseUpdater
    {
        public static string GetDatabaseVersion() {
            using (DbAgent db = new DbAgent()) {
                string dbVer = db.GetAbstractInfo("Version");
                return dbVer;
                
            }
        }
    }
}
