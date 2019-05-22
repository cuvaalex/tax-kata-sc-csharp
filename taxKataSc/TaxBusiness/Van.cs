using System;
using System.Collections.Generic;
using System.Text;

namespace TaxBusiness
{
    public class Van : IVehicule
    {
        public int Weight { get; set; }
        public DateTime ImmatDate { get ; set ; }
        public decimal CalculateTax()
        {
            if (this.Weight < 3500)
            {
                return 165;
            }

            return 190;
        }
    }
}
