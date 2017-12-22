using System;
using DesignByContract.InterfaceContracts;
using NUnit.Framework;

namespace DesignByContract.Tests.Unit
{
    [TestFixture]
    public class AddingCalculatorTests
    {
        [Test]
        public void Add_FirstAdderIsLessThanZero_ExceptionIsThrown()
        {
            IAddingCalculator addingCalculator = new AddingCalculator();
            TestDelegate testDelegate = () => addingCalculator.Add(-1, 1);
            Assert.That(testDelegate, Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [Explicit]
        public void Add_Int32Overflow()
        {
            IAddingCalculator addingCalculator = new AddingCalculator();
            addingCalculator.Add(Int32.MaxValue, 1);
        }
    }
}