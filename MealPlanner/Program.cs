using static MealPlanner.MealPlannerCalculator;

namespace MealPlanner
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Set the total calories for the meal plan
            int totalCalories = 0;

            // Set the gender for the meal plan
            Gender gender = Gender.Female;

            // Set the age for the meal plan
            int age = 0;

            // Set the height for the meal plan
            int height = 0;

            // Set the weight for the meal plan
            int weight = 0;

            // Set the activity level for the meal plan
            ActivityLevel activityLevel = ActivityLevel.ModeratelyActive;

            // Get user input for total calories
            Console.Write("Enter total calories: ");
            while (!int.TryParse(Console.ReadLine(), out totalCalories))
            {
                Console.Write("Invalid input. Please enter a valid integer for total calories: ");
            }

            // Get user input for gender
            Console.Write("Enter gender (Male/Female): ");
            while (!Enum.TryParse(Console.ReadLine(), out gender))
            {
                Console.Write("Invalid input. Please enter a valid gender (Male/Female): ");
            }

            // Get user input for age
            Console.Write("Enter age: ");
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.Write("Invalid input. Please enter a valid integer for age: ");
            }

            // Get user input for height
            Console.Write("Enter height (in cm): ");
            while (!int.TryParse(Console.ReadLine(), out height))
            {
                Console.Write("Invalid input. Please enter a valid integer for height (in cm): ");
            }

            // Get user input for weight
            Console.Write("Enter weight (in kg): ");
            while (!int.TryParse(Console.ReadLine(), out weight))
            {
                Console.Write("Invalid input. Please enter a valid integer for weight (in kg): ");
            }

            // Get user input for activity level
            Console.Write("Enter activity level (Sedentary/LightlyActive/ModeratelyActive/VeryActive/ExtremelyActive): ");
            while (!Enum.TryParse(Console.ReadLine(), out activityLevel))
            {
                Console.Write("Invalid input. Please enter a valid activity level (Sedentary/LightlyActive/ModeratelyActive/VeryActive/ExtremelyActive): ");
            }

            // Create an instance of the MealPlannerCalculator class
            MealPlannerCalculator mealPlanner = new MealPlannerCalculator(totalCalories, gender, age, height, weight, activityLevel);

            // Generate the meal plan
            mealPlanner.GenerateMealPlan();
        }
    }
}
