using PayAtTable.Server.Data;
using PayAtTable.Server.Models;
using PayAtTable.ServerCore.Data.Interface;
using System.Collections.Generic;


namespace PayAtTable.Server.DemoRepository
{
    public class SettingsRepositoryDemo : ISettingsRepository
    {
        public Settings GetSettings()
        {
            // Create tender options and add a default value
            var tenderOptions = new List<TenderOption>();
            tenderOptions.Add(new TenderOption()
            {
                Id = string.Empty,
                TenderType = TenderType.EFTPOS,
                Merchant = "00",
                DisplayName = "EFTPOS",
                EnableSplitTender = true
            });
            tenderOptions.Add(new TenderOption()
            {
                Id = "GC",
                TenderType = TenderType.EFTPOS,
                Merchant = "03",
                DisplayName = "GiftCard",
                EnableSplitTender = true,
            });
            tenderOptions.Add(new TenderOption()
            {
                Id = "AMEX",
                TenderType = TenderType.EFTPOS,
                Merchant = "06",
                DisplayName = "Amex",
                EnableSplitTender = false,
            });
            // Create receipt options and add a default value
            var receiptOptions = new List<ReceiptOption>();
            receiptOptions.Add(new ReceiptOption()
            {
                Id = string.Empty,
                ReceiptType = ReceiptType.Order,
                DisplayName = "Customer"
            });
            receiptOptions.Add(new ReceiptOption()
            {
                Id = "1",
                ReceiptType = ReceiptType.Order,
                DisplayName = "Extended"
            });

            //Create Header printer options
            var printerOption = new PrinterOption()
            {
                PrintMode = PrinterMode.PCEFTPOS,
                Location = Location.None,
                StaticReceipt = new List<string>()
                {
                    "------------------------",
                    "Some generic text",
                    "that will print before",
                    "every eftpos receipt",
                    "if PrintMode = STATIC",
                    "and location = header",
                }
            };

            return new Settings()
            {
                TenderOptions = tenderOptions,
                ReceiptOptions = receiptOptions,
                PrinterOption = printerOption,

                CsdReservedString2 = "EFTPOS",
                TxnType = "P"
            };
        }
    }
}
