using System;
using System.Diagnostics.Contracts;

namespace DesignByContract.InterfaceContracts
{
    [ContractClassFor(typeof(IAddingCalculator))]
    public abstract class AddingCalculatorContract : IAddingCalculator
    {
        public int Add(int a, int b)
        {
            Contract.Requires<ArgumentOutOfRangeException>(a >= 0);
            Contract.Requires<ArgumentOutOfRangeException>(b >= 0);
            Contract.Ensures(Contract.Result<int>() >= 0);
            return default(int);
        }

        public int GetLastResult()
        {
            Contract.Ensures(Contract.Result<int>() >= 0);
            return default(int);
        }
    }
}