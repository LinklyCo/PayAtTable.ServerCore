﻿using PayAtTable.Server.Models;
using System.Collections.Generic;

namespace PayAtTable.Server.DemoRepository
{
    public class SampleData
    {
        private static readonly SampleData _current = new SampleData();

        public List<Table> Tables { get; set; }
        public List<Order> Orders { get; set; }
        public List<Tender> Tenders { get; set; }
        public List<EftposCommand> EftposCommands { get; set; }
        public int LastTenderId { get; set; }
        public int LastEFTPOSCommandId { get; set; }

        public static SampleData Current
        {
            get
            {
                return _current;
            }
        }

        private SampleData()
        {
            Tables = new List<Table>();
            Orders = new List<Order>();
            Tenders = new List<Tender>();
            EftposCommands = new List<EftposCommand>();
            LastTenderId = 0;
            LastEFTPOSCommandId = 0;


            Tables.Add(new Table() { Id = "50", DisplayNumber = 1, DisplayName = "TABLE 1", ServerName = "Caitlyn" });
            Tables.Add(new Table() { Id = "51", DisplayNumber = 2, DisplayName = "TABLE 2", ServerName = "Sonya" });
            Tables.Add(new Table() { Id = "52", DisplayNumber = 3, DisplayName = "TABLE 3", ServerName = "Fail" });
            Tables.Add(new Table() { Id = "53", DisplayNumber = 4, DisplayName = "TABLE 4", ServerName = "Donatello" });
            Tables.Add(new Table() { Id = "54", DisplayNumber = 5, DisplayName = "TABLE 5", ServerName = "Michelangelo" });
            Tables.Add(new Table() { Id = "55", DisplayNumber = 11, DisplayName = "TABLE 11" });
            Tables.Add(new Table() { Id = "56", DisplayNumber = 12, DisplayName = "TABLE 12" });
            Tables.Add(new Table() { Id = "57", DisplayNumber = 13, DisplayName = "TABLE 13" });
            Tables.Add(new Table() { Id = "58", DisplayNumber = 14, DisplayName = "TABLE 14" });
            //adding 3 orders to process table 1
            Orders.Add(new Order() { Id = "101", TableId = "50", AmountOwing = 108.00M, DisplayName = "Elsa" });
            Orders.Add(new Order() { Id = "102", TableId = "50", AmountOwing = 1.08M, DisplayName = "Signature" }); // signature
            Orders.Add(new Order() { Id = "103", TableId = "50", AmountOwing = 350.00M, DisplayName = "Olaf" });

            // 6 buttons or 3 buttons displays
            Orders.Add(new Order() { Id = "104", TableId = "51", AmountOwing = 20.00M, DisplayName = "Kristoff" });
            Orders.Add(new Order() { Id = "105", TableId = "51", AmountOwing = 15.00M, DisplayName = "Hans" });
            Orders.Add(new Order() { Id = "106", TableId = "51", AmountOwing = 96.00M, DisplayName = "Duke" });
            Orders.Add(new Order() { Id = "107", TableId = "51", AmountOwing = 520.00M, DisplayName = "Oaken" });

            Orders.Add(new Order() { Id = "108", TableId = "51", AmountOwing = 756.00M, DisplayName = "Gerda" });
            Orders.Add(new Order() { Id = "109", TableId = "50", AmountOwing = 60.00M, DisplayName = "N. Scamander" });
            Orders.Add(new Order() { Id = "110", TableId = "50", AmountOwing = 70.00M, DisplayName = "R. Weasley" });
            Orders.Add(new Order() { Id = "111", TableId = "51", AmountOwing = 50.00M, DisplayName = "H. Potter" });
            Orders.Add(new Order() { Id = "112", TableId = "52", AmountOwing = 55.00M, DisplayName = "H. Granger" });

        }

    }
}
