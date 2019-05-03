using System;
using NFluent;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace taxKataScTest
{
    public class Class1
    {
        [Test]
        public void Should_tax_be_165_when_weight_is_under_3500()
        {
            TaxCalculator taxCalculator = new TaxCalculator();
            Decimal tax = taxCalculator.Calculate(10);
            Check.That<Decimal>(tax).IsEqualTo(165);
        }

        [Test]
        public void Should_tax_be_190_when_weight_is_over_3500()
        {
            TaxCalculator taxCalculator = new TaxCalculator();
            Decimal tax = taxCalculator.Calculate(10000);
            Check.That<Decimal>(tax).IsEqualTo(190);
        }

        [Test]
        public void Should_tax_be_190_when_weight_is_equal_3500()
        {
            TaxCalculator taxCalculator = new TaxCalculator();
            Decimal tax = taxCalculator.Calculate(3500);
            Check.That<Decimal>(tax).IsEqualTo(190);
        }


    }

    public class Vehicule
    {

    }

    public class TaxCalculator
    {
        public decimal Calculate(float weight)
        {
            if (weight < 3500)
            {
                return 165;
            }

            return 190;
        }
    }
}
