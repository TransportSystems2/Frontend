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

        public List<BillItemEM> Items { get; }

        public decimal TotalCost { get; set; }
    }
}