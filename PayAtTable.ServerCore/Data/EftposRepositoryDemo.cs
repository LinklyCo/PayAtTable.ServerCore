using PayAtTable.Server.Data;
using PayAtTable.ServerCore.Data.Interface;

namespace PayAtTable.Server.DemoRepository
{
    public class EftposRepositoryDemo: IEftposRepository
    {
        public Models.EftposCommand CreateEftposCommand(Models.EftposCommand eftposCommand)
        {
            // Write EFTPOS command to the database
            eftposCommand.Id = (SampleData.Current.LastEFTPOSCommandId++).ToString();
            SampleData.Current.EftposCommands.Add(eftposCommand);
            return eftposCommand;
        }
    }
}
