namespace PayAtTable.Server.Models
{
    public class PatRequest
    {
        public Tender Tender { get; set; }
        public EftposCommand EftposCommand { get; set; }
    }
}