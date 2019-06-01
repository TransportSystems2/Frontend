using System.Collections.Generic;

namespace TransportSystems.Frontend.External.Models.Models.Billing
{
    public class BillEM
    {
        public BillEM()
        {
            Items = new List<BillItemEM>();
        }

        public BillInfoEM Info { get; set; }

        public BasketEM Basket { get; set; }

        public List<BillItemEM> Items { get; set; }

        public decimal TotalCost { get; set; }
    }
}