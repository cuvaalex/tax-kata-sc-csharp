using System;
using System.Collections.Generic;
using System.Text;

namespace TaxBusiness
{
    public class Car : IVehicule
    {
        public int EngineCc { get; set; }
        public DateTime ImmatDate { get ; set ; }

        public decimal CalculateTax()
        {
            if (this.EngineCc > 1550)
            {
                return 165;
            }
            return 110;
        }
    }
}
