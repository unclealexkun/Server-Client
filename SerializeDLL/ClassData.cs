using System.Collections.Generic;

namespace SerializeDLL
{
    public class Data
    {
        private decimal _sumResult;
        private int _mulResult;
        private decimal[] _sortedInputs;

        protected decimal Sum(Input input)
        {
            foreach (decimal dec in input.Sums)
            {
                _sumResult += dec;
            }

            _sumResult *= input.K;

            return _sumResult;
        }

        protected int Mul(Input input)
        {
            _mulResult = 1;

            foreach (int i in input.Muls)
            {
                _mulResult *= i;
            }

            return _mulResult;
        }

        protected decimal[] Sort(Input input)
        {
            List<decimal> list = new List<decimal>();

            foreach (var v in input.Sums)
            {
                list.Add(v);
            }
            foreach (var v in input.Muls)
            {
                list.Add(v);
            }

            list.Sort();

            _sortedInputs = list.ToArray();

            return _sortedInputs;
        }

        public Output Result(Input input)
        {
            Output output = new Output();

            output.SumResult = Sum(input);
            output.MulResult = Mul(input);
            output.SortedInputs = Sort(input);

            return output;
        }
    }
}
