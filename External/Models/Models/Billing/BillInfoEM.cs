namespace TransportSystems.Frontend.External.Models.Models.Billing
{
    public class BillInfoEM
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
