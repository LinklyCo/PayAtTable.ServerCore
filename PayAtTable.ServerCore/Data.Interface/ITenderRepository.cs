using PayAtTable.Server.Models;

namespace PayAtTable.ServerCore.Data.Interface
{
    public interface ITenderRepository
    {
        Tender CreateTender(Tender tender);
        Tender UpdateTender(Tender tender);
    }
}
