using Flexibase.Tasks;

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

            enumerator.MoveNext();

            // the cycle repeats until no numbers left
            for (; ; )
            {
                string lastState = "";

                foreach (var task in tasks)
                {
                    var number = enumerator.Current;
                    lastState = task.GetResult(number, lastState);
                }

                output += lastState;

                if (enumerator.MoveNext())
                {
                    output += ", ";
                    continue;
                }

                break;
            }

            return output;
        }
    }
}