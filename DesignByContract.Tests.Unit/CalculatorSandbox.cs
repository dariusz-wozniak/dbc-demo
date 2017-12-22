using System;
using NUnit.Framework;

namespace DesignByContract.Tests.Unit
{
    public class CalculatorSandbox
    {
        [Test]
        [Explicit]
        public void Playground()
        {
            var calculator = new AddingCalculatorCodeContracts();
            // CASE 1: Broke preconditions
            calculator.Add(-1, 0);

            // CASE 2: Broke object invariants
             calculator.Add(Int32.MaxValue, 1);

            // CASE 3: Remember to include Contract.EndContractBlock();
            var oldCalculator = new AddingCalculator();
            oldCalculator.Add(-1, 0);
        }
    }
}