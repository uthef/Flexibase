﻿using Flexibase.Tasks;

namespace Flexibase
{
    public class NumberConverter
    {
        public IEnumerable<int> Sequence { get; }

        public NumberConverter(IEnumerable<int> sequence)
        {
            Sequence = sequence;
        }

        public string ExecuteTaskChain(params ChainedTask[] tasks)
        {
            string output = "";
            using var enumerator = Sequence.GetEnumerator();

            while (enumerator.MoveNext())
            {
                string lastState = "";

                foreach (var task in tasks)
                {
                    var number = enumerator.Current;
                    lastState = task.GetResult(number, lastState);
                }

                if (output.Length > 0) 
                    output += ", ";

                output += lastState;
            }

            return output;
        }
    }
}