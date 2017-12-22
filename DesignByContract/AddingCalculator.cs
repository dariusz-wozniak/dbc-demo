using System;

namespace DesignByContract
{
    public class AddingCalculator : IAddingCalculator
    {
        private int _lastResult = 0;

        public int Add(int a, int b)
        {
            if (a < 0) throw new ArgumentOutOfRangeException();
            if (b < 0) throw new ArgumentOutOfRangeException();
            // HINT: You may use Contract.EndContractBlock();

            return _lastResult = a + b;
        }

        public int GetLastResult()
        {
            return _lastResult;
        }
    }
}