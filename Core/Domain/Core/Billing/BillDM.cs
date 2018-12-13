using System.Collections.Generic;

namespace TransportSystems.Frontend.Core.Domain.Core.Billing
{
    public class BillDM
    {
        public BillDM()
        {
            Items = new List<BillItemDM>();
        }

        public BillInfoDM Info { get; set; }

        public List<BillItemDM> Items { get; set; }

        public decimal TotalCost { get; set; }
    }
}