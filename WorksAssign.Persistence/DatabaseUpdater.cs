/******************************************************************************
 * WorksAssign.Persistence 工作安排数据库访问组件
 * CopyRight (C) 2020-2021 TscCai.
 * E-Mail：caijiran@hotmail.com
 *
 * GitHub: https://github.com/TscCai/WorksAssignSystem
 *
 ******************************************************************************
 * 文件名称: DatabaseUpdater.cs
 * 文件说明: 数据库更新器
 * 当前版本: 
 * 创建日期: 2021-02-03
 * 2021-02-03: 增加文件说明
******************************************************************************/
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
            using (WasDbAgent db = new WasDbAgent()) {
                string dbVer = db.GetAbstractInfo("Version");
                return dbVer;
                
            }
        }
    }
}
