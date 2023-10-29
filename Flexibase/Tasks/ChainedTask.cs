using System.Diagnostics;

namespace Flexibase.Tasks
{
    public abstract class ChainedTask
    {
        public string GetResult(int number, string lastState)
        {
            var result = Process(number);

            if (IsNumber(lastState) || IsEmpty(lastState))
            {
                return result;
            }

            if (!IsNumber(result))
            {
                return $"{lastState}-{result}";
            }

            return lastState;
        }

        private static bool IsNumber(string value) => int.TryParse(value, out var _);
        private static bool IsEmpty(string value) => value.Trim().Length == 0;

        protected abstract string Process(int number);
    }
}
