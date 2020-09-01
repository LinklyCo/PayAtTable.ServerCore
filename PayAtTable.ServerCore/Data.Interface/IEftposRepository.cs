using PayAtTable.Server.Models;

namespace PayAtTable.ServerCore.Data.Interface
{
    public interface IEftposRepository
    {
        EftposCommand CreateEftposCommand(EftposCommand eftposCommand);
    }
}
