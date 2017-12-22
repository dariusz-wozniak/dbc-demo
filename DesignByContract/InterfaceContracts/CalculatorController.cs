using System;
using System.Diagnostics.Contracts;

namespace DesignByContract.InterfaceContracts
{
    public class CalculatorController
    {
        public void Add(IAddingCalculator calc)
        {
            Contract.Requires<ArgumentNullException>(calc != null);

            calc.Add(0, 0);
        }
    }
}