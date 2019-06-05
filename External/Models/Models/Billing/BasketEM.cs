using System;
using DotNetDistance;

namespace TransportSystems.Frontend.External.Models.Models.Billing
{
    public class BasketEM
    {
        /// <summary>
        /// Протяженость маршрута (км)
        /// </summary>
        public Distance Distance { get; set; }

        /// <summary>
        /// Требуется погрузка
        /// </summary>
        public int LoadingValue { get; set; }

        /// <summary>
        /// Руль заблокирован
        /// </summary>
        public int LockedSteeringValue { get; set; }

        /// <summary>
        /// Количество заблокированных колес
        /// </summary>
        public int LockedWheelsValue { get; set; }

        /// <summary>
        /// ТС перевернуто
        /// </summary>
        public int OverturnedValue { get; set; }

        /// <summary>
        /// ТС в кювете
        /// </summary>
        public int DitchValue { get; set; }
    }
}
