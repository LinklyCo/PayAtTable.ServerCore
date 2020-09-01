using PayAtTable.Server.Data;
using PayAtTable.Server.Models;
using PayAtTable.ServerCore.Data.Interface;
using System;


namespace PayAtTable.Server.DemoRepository
{
    public class TenderRepositoryDemo: ITenderRepository
    {
        public Models.Tender CreateTender(Models.Tender tender)
        {
            // Validate the order id
            if (SampleData.Current.Orders.Find((order) => order.Id.Equals(tender.OrderId)) == null)
                throw new InvalidRequestException(String.Format("Order id {0} not found", tender.OrderId));

            // Give the tender and id and add it to our tender list
            tender.Id = (SampleData.Current.LastTenderId++).ToString();
            SampleData.Current.Tenders.Add(tender);
            return tender;
        }

        public Models.Tender UpdateTender(Models.Tender tender)
        {
            // Find the tender
            var t = SampleData.Current.Tenders.Find((t2) => t2.Id.Equals(tender.Id));
            if (t == null)
                throw new ResourceNotFoundException(String.Format("Tender id {0} not found", tender.Id));

            // Find the order
            var o = SampleData.Current.Orders.Find((order) => order.Id.Equals(tender.OrderId));
            if (o == null)
                throw new InvalidRequestException(String.Format("Order id {0} not found", tender.OrderId));


            // If Tender is moving from an incomplete to complete state, reduce the amount
            if (t.TenderState == TenderState.Pending && tender.TenderState == TenderState.CompleteSuccessful)
            {
                o.AmountOwing -= tender.AmountPurchase;
                // If our order isn't owing anymore, set to complete
                if (o.AmountOwing == 0)
                {
                    o.OrderState = OrderState.Complete;
                    o.TableId = string.Empty;
                }
            }

            // Update our tender
            t.AmountPurchase = tender.AmountPurchase;
            t.OriginalAmountPurchase = tender.OriginalAmountPurchase;
            t.TenderState = tender.TenderState;

            return t;
        }


    }
}
