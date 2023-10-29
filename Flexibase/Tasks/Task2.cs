namespace Flexibase.Tasks
{
    public class Task2 : ChainedTask
    {
        protected override string Process(int number)
        {
            string output = number.ToString();

            var muzz = number % 4 == 0;
            var guzz = number % 7 == 0;

            if (muzz && guzz)
                output = "muzz-guzz";
            else if (muzz)
                output = "muzz";
            else if (guzz)
                output = "guzz";

            return output;
        }
    }
}
