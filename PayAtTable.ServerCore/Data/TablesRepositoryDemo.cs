using PayAtTable.Server.Data;
using PayAtTable.ServerCore.Data.Interface;
using System.Collections.Generic;


namespace PayAtTable.Server.DemoRepository
{
    public class TableRepositoryDemo: ITableRepository
    {
        public IEnumerable<Models.Table> GetTables()
        {
            return SampleData.Current.Tables;
        }
    }
}
