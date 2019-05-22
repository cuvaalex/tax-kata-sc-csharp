using System;
using System.Reflection.Metadata;
using NFluent;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TaxBusiness;

namespace taxKataScTest
{
    public class CarTaxCalculateTest
    {
        private const int CAR_EXPECTED_TAX_WHEN_ENGINE_UNDER_1550_AND_OLDER_THAN_1MARCH2001 = 110;
        private const int CAR_EXPECTED_TAX_WHEN_ENGINE_OVER_1550_AND_OLDER_THAN_1MARCH2001 = 165;

        [Test]
        public void Should_return_110_when_car_older_than_1_march2001_and_engine_less_equal_1550cc()
        {
            Car myCar = new Car()
            {
                ImmatDate = new DateTime(2000, 1, 1),
                EngineCc = 1500
            };
            Decimal tax = myCar.CalculateTax();
            Check.That<Decimal>(tax).IsEqualTo(CAR_EXPECTED_TAX_WHEN_ENGINE_UNDER_1550_AND_OLDER_THAN_1MARCH2001);
        }

        [Test]
        public void Should_return_165_when_car_older_than_1_march2001_and_engine_more_than_1550cc()
        {
            Car myCar = new Car()
            {
                ImmatDate = new DateTime(2001, 1, 1),
                EngineCc = 1600
            };
            Decimal tax = myCar.CalculateTax();
            Check.That<Decimal>(tax).IsEqualTo(CAR_EXPECTED_TAX_WHEN_ENGINE_OVER_1550_AND_OLDER_THAN_1MARCH2001);
        }

    }
}
