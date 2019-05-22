using System;
using System.Collections.Generic;
using System.Text;
using NFluent;
using NUnit.Framework;
using TaxBusiness;

namespace taxKataScTest
{
    public class VanTaxCalculateTest
    {

        private const int VAN_EXPECTED_TAX_WHEN_WEIGHT_UNDER_3500 = 165;
        private const int VAN_EXPECTED_TAX_WHEN_WEIGHT_OVER_3500 = 190;

        [Test]
        public void Should_tax_be_165_when_weight_is_under_3500()
        {
            Van myVan = new Van()
            {
                Weight = 10,
            };
            Decimal tax = myVan.CalculateTax();
            Check.That<Decimal>(tax).IsEqualTo(VAN_EXPECTED_TAX_WHEN_WEIGHT_UNDER_3500);
        }

        [Test]
        public void Should_tax_be_190_when_weight_is_over_3500()
        {
            Van myVan = new Van()
            {
                Weight = 10000,
            };
            Decimal tax = myVan.CalculateTax();
            Check.That<Decimal>(tax).IsEqualTo(VAN_EXPECTED_TAX_WHEN_WEIGHT_OVER_3500);
        }

        [Test]
        public void Should_tax_be_190_when_weight_is_equal_3500()
        {
            Van myVan = new Van()
            {
                Weight = 3500,
            };
            Decimal tax = myVan.CalculateTax();
            Check.That<Decimal>(tax).IsEqualTo(VAN_EXPECTED_TAX_WHEN_WEIGHT_OVER_3500);
        }

    }
}
