using System;
using System.Reflection.Metadata;
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
            Vehicule myVan = new Vehicule()
            {
                Type = VehiculeTypes.Van,     
                Weight = 10,
            };
            Decimal tax = taxCalculator.Calculate(myVan);
            Check.That<Decimal>(tax).IsEqualTo(165);
        }

        [Test]
        public void Should_tax_be_190_when_weight_is_over_3500()
        {
            TaxCalculator taxCalculator = new TaxCalculator();
            Vehicule myVan = new Vehicule()
            {
                Type = VehiculeTypes.Van,
                Weight = 10000,
            };
            Decimal tax = taxCalculator.Calculate(myVan);
            Check.That<Decimal>(tax).IsEqualTo(190);
        }

        [Test]
        public void Should_tax_be_190_when_weight_is_equal_3500()
        {
            TaxCalculator taxCalculator = new TaxCalculator();
            Vehicule myVan = new Vehicule()
            {
                Type = VehiculeTypes.Van,
                Weight = 3500,
            };
            Decimal tax = taxCalculator.Calculate(myVan);
            Check.That<Decimal>(tax).IsEqualTo(190);
        }

        [Test]
        public void Should_return_110_when_car_older_than_1_march2001_and_engine_less_equal_1550cc()
        {
            TaxCalculator taxCalculator = new TaxCalculator();
            Vehicule myCar = new Vehicule()
            {
                Type = VehiculeTypes.Car,
                ImmatDate = new DateTime(2000, 1, 1),
                EngineCc = 1500
            };
            Decimal tax = taxCalculator.Calculate(myCar);
            Check.That<Decimal>(tax).IsEqualTo(110);
        }

        [Test]
        public void Should_return_165_when_car_older_than_1_march2001_and_engine_more_than_1550cc()
        {
            TaxCalculator taxCalculator = new TaxCalculator();
            Vehicule myCar = new Vehicule()
            {
                Type = VehiculeTypes.Car,
                ImmatDate = new DateTime(2001, 1, 1),
                EngineCc = 1600
            };
            Decimal tax = taxCalculator.Calculate(myCar);
            Check.That<Decimal>(tax).IsEqualTo(165);
        }

    }

    public class Vehicule
    {
        public VehiculeTypes Type { get; internal set; }
        public DateTime ImmatDate { get; internal set; }
        public int EngineCc { get; internal set; }
        public int Weight { get; internal set; }
    }

    public enum VehiculeTypes
    {
        Car = 0,
        Van,
    }

    public class TaxCalculator
    {
        public decimal Calculate(Vehicule vehicule)
        {
            switch (vehicule.Type)
            {
                case VehiculeTypes.Car:
                {
                    if (vehicule.EngineCc > 1550 )
                    {
                        return 165;
                    }
                    return 110;
                }
                case VehiculeTypes.Van:
                {
                    if (vehicule.Weight < 3500)
                    {
                        return 165;
                    }

                    return 190;
                }
            }
            return 110.0m;
        }
    }
}
