using System;
using NUnit.Framework;

namespace DesignByContract.InterfaceContracts
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

        [Test, Ignore]
        public void Add_Int32Overflow()
        {
            IAddingCalculator addingCalculator = new AddingCalculator();
            addingCalculator.Add(Int32.MaxValue, 1);
        }
    }
}