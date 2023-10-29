namespace Flexibase
{
    public class RawInput
    {
        private string Value { get; }

        public RawInput(string value) 
        { 
            Value = value;
        }

        public IEnumerable<int> ToSequence()
        {
            if (Value.Trim().Length == 0) yield break;

            var rawNumbers = Value.Split(',');

            for (int i = 0; i < rawNumbers.Length; i++)
            {
                var intValue = int.Parse(rawNumbers[i].Trim());
                yield return intValue;
            }
        }
    }
}
