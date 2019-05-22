using System;
using System.Collections.Generic;
using System.Text;

namespace TaxBusiness
{
    interface IVehicule
    {
        DateTime ImmatDate { get; set; }

        decimal CalculateTax();
    }
}
