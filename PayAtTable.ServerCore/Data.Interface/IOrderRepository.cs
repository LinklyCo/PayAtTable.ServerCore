using PayAtTable.Server.Models;
using System.Collections.Generic;

namespace PayAtTable.ServerCore.Data.Interface
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrdersFromTable(string tableId);
        Order GetOrder(string orderId);
        Receipt GetCustomerReceiptFromOrderId(string orderId, string receiptOptionId);
    }
}
