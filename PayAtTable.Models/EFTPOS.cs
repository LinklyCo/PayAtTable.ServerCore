using System;

namespace PayAtTable.Server.Models
{
    public enum EftposCommandType { UpdateConfig = 0, DoTransaction = 100, DoLogon = 101, TransactionEvent = 200, LogonEvent = 201, DoKeyPress = 300, DisplayEvent = 400, PrintEvent = 401 }

    /// <summary>
    /// The current state of the command. New commands have a state of AwaitingDeviceAck. 
    /// One the command has been picked up by a device the state changes to AwaitingDeviceResponse.
    /// Once complete the state is changed to CompletedSuccessful or CompletedUnsuccessful
    /// </summary>
    public enum EftposCommandState { AwaitingDeviceAck = 0, AwaitingDeviceResponse = 10, CompletedSuccessful = 20, CompletedUnsuccessful = 30 }

    public class EftposCommandResult
    {
        public String ResponseCode { get; set; }
        public String ResponseText { get; set; }
        public bool Success { get; set; }
        public EftposCommandState State { get; set; }

        public EftposCommandResult(string responseCode, string responseText, bool success, EftposCommandState state)
        {
            ResponseCode = responseCode;
            ResponseText = responseText;
            Success = success;
            State = state;
        }


        /// <summary>
        /// Pre-defined "Approved" response
        /// </summary>
        public static EftposCommandResult ERC_00_Approved => new EftposCommandResult("00", "APPROVED", false, EftposCommandState.CompletedSuccessful);
        /// <summary>
        /// Pre-defined "Client Office" response
        /// </summary>
        public static EftposCommandResult ERC_PG_ClientOffline => new EftposCommandResult("PG", "CLIENT OFFLINE", false, EftposCommandState.CompletedUnsuccessful);
        /// <summary>
        /// Pre-defined "Command In Progress" response
        /// </summary>
        public static EftposCommandResult ERC_XB_CommandInProgress => new EftposCommandResult("XB", "COMMAND IN PROGRESS", false, EftposCommandState.CompletedUnsuccessful);
        /// <summary>
        /// Pre-defined "EFT Timeout" response
        /// </summary>
        public static EftposCommandResult ERC_XC_EFTTimeout => new EftposCommandResult("XC", "EFT TIMEOUT", false, EftposCommandState.CompletedUnsuccessful);
        /// <summary>
        /// Pre-defined "Unknown error" response
        /// </summary>
        public static EftposCommandResult ERC_XX_UnknownError => new EftposCommandResult("XX", "UNKNOWN ERROR", false, EftposCommandState.CompletedUnsuccessful);
    }

    /// <summary>
    /// Pretty much maps to an EFT-Client request 
    /// </summary>
    public class EftposCommand
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The device this command is for
        /// </summary>
        public string EftposId { get; set; }

        /// <summary>
        /// Command type
        /// </summary>
        public EftposCommandType EftposCommandType { get; set; }

        /// <summary>
        /// Current command state
        /// </summary>
        public int? EftposCommandState { get; set; }

        /// <summary>
        /// The Tender this command is linked to
        /// </summary>
        public string TenderId { get; set; }

        /// <summary>
        /// The key of the initial request if this is an event
        /// </summary>
        public string OriginalEftposCommandId { get; set; }

        /// <summary>
        /// Timestamp for when the command was picked up 
        /// </summary>
        public DateTime CommandStartDateTime { get; set; }

        /// <summary>
        /// Time stamp for when the command was completed
        /// </summary>
        public DateTime CommandEndDateTime { get; set; }

        /// <summary>
        /// Time stamp for when this command should no longer be handled
        /// </summary>
        public DateTime CommandStaleDateTime { get; set; }

        /// <summary>
        /// Timestamp for when this record was created
        /// </summary>
        public DateTime InsertionDateTime { get; set; }

        // Fields from PC-Eftpos
        public string AccountType { get; set; }
        public decimal AmtCash { get; set; }
        public decimal AmtPurchase { get; set; }
        public decimal AmtTip { get; set; }
        public decimal AmtTotal { get; set; }
        public string Application { get; set; }
        public string AuthCode { get; set; }
        public string Caid { get; set; }
        public string Catid { get; set; }
        public string CardName { get; set; }
        public string CardType { get; set; }
        public string CsdReservedString1 { get; set; }
        public string CsdReservedString2 { get; set; }
        public string CsdReservedString3 { get; set; }
        public string CsdReservedString4 { get; set; }
        public string CsdReservedString5 { get; set; }
        public bool CsdReservedBool1 { get; set; }
        public bool CutReceipt { get; set; }
        public string CurrencyCode { get; set; }
        public string DataField { get; set; }
        public string Date { get; set; }
        public string DateExpiry { get; set; }
        public string DateSettlement { get; set; }
        public string DialogPosition { get; set; }
        public string DialogTitle { get; set; }
        public string DialogType { get; set; }
        public int DialogX { get; set; }
        public int DialogY { get; set; }
        public bool EnableTip { get; set; }
        public bool EnableTopmost { get; set; }
        public string Merchant { get; set; }
        public string MessageType { get; set; }
        public char PanSource { get; set; }
        public string Pan { get; set; }
        public string PosProductId { get; set; }
        public string PurchaseAnalysisData { get; set; }
        public bool ReceiptAutoPrint { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseText { get; set; }
        public string ResponseType { get; set; }
        public string Rrn { get; set; }
        public bool Success { get; set; }
        public string STAN { get; set; }
        public string Time { get; set; }
        public string TxnRef { get; set; }
        public string TxnType { get; set; }
        public string Track1 { get; set; }
        public string Track2 { get; set; }
        

        public EftposCommand()
        {
            Reset();
        }

        public void Reset()
        {
            AccountType = "";
            AmtCash = 0.0M;
            AmtPurchase = 0.0M;
            AmtTip = 0.0M;
            AmtTotal = 0.0M;
            Application = "";
            AuthCode = "";
            Caid = "";
            Catid = "";
            CardName = "";
            CardType = "";
            CsdReservedString1 = "";
            CsdReservedString2 = "";
            CsdReservedString3 = "";
            CsdReservedString4 = "";
            CsdReservedString5 = "";
            CsdReservedBool1 = false;
            CutReceipt = false;
            CurrencyCode = "";
            DataField = "";
            Date = "";
            DateExpiry = "";
            DateSettlement = "";
            DialogPosition = "";
            DialogTitle = "";
            DialogType = "";
            DialogX = 0;
            DialogY = 0;
            EnableTip = false;
            EnableTopmost = false;
            Merchant = "";
            MessageType = "";
            PanSource = ' ';
            Pan = "";
            PosProductId = "";
            PurchaseAnalysisData = "";
            ReceiptAutoPrint = false;
            ResponseCode = "";
            ResponseText = "";
            ResponseType = "";
            Rrn = "";
            Success = false;
            STAN = "";
            Time = "";
            TxnRef = "";
            TxnType = "";
            Track1 = "";
            Track2 = "";
        }

        public void SetResult(EftposCommandResult r)
        {
            ResponseCode = r.ResponseCode;
            ResponseText = r.ResponseText;
            Success = r.Success;
            EftposCommandState = (int)r.State;
        }

        public EftposCommand DeepCopy()
        {
            return (EftposCommand)this.MemberwiseClone();
        }
    }
}