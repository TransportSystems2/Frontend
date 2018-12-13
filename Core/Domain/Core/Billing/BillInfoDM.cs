namespace TransportSystems.Frontend.Core.Domain.Core.Billing
{
    public class BillInfoDM
    {
        public int PriceId { get; set; }

        /// <summary>
        /// Комиссия системы
        /// </summary>
        public byte CommissionPercentage { get; set; }

        /// <summary>
        /// Процент сложности
        /// </summary>
        public float DegreeOfDifficulty { get; set; }
    }
}
