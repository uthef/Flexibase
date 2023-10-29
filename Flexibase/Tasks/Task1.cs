namespace Flexibase.Tasks
{
    public class Task1 : ChainedTask
    {
        public bool AnimalMode;

        public Task1(bool animalMode)
        {
            AnimalMode = animalMode;
        }

        protected override string Process(int number)
        {
            string output = number.ToString();

            var fizz = number % 3 == 0;
            var buzz = number % 5 == 0;

            if (fizz && buzz)
                output = AnimalMode ? "good-boy" : "fizz-buzz";
            else if (fizz)
                output = AnimalMode ? "dog" : "fizz";
            else if (buzz)
                output = AnimalMode ? "cat" : "buzz";

            return output;
        }
    }
}
