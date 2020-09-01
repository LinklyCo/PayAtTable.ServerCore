using PayAtTable.Server.Models;
using System.Collections.Generic;

namespace PayAtTable.ServerCore.Data.Interface
{
    public interface ITableRepository
    {
        IEnumerable<Table> GetTables();
    }
}
