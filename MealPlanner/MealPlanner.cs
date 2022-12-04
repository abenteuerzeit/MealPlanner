
namespace MealPlanner
{

    /// <summary>
    /// Calculates the average number of calories per day, the number of calories burned per day,
    /// and the number of calories to consume per day. You can use this information to create your own
    /// meal plan with specific foods and recipes.
    /// </summary>
    public class MealPlannerCalculator
    {


        // Constants for average calories per day by gender and age
        private const int MALE_CALORIES_PER_DAY = 2500;
        private const int FEMALE_CALORIES_PER_DAY = 2000;
        private const int CHILD_CALORIES_PER_DAY = 1800;
        private const int TEENAGER_CALORIES_PER_DAY = 2000;
        private const int ADULT_CALORIES_PER_DAY = 2200;
        private const int SENIOR_CALORIES_PER_DAY = 2000;
        private const int ELDERLY_CALORIES_PER_DAY = 1800;


        // Constants for average calories burned per day by activity level
        private const int SEDENTARY_CALORIES_BURNED = 500;
        private const int LIGHTLY_ACTIVE_CALORIES_BURNED = 750;
        private const int MODERATELY_ACTIVE_CALORIES_BURNED = 1000;
        private const int VERY_ACTIVE_CALORIES_BURNED = 1250;
        private const int EXTREMELY_ACTIVE_CALORIES_BURNED = 1500;

        // Member variables
        private int _totalCalories;
        private Gender _gender;
        private int _age; // Renamed field
        private int _height;
        private int _weight;
        private ActivityLevel _activityLevel;

        public int TotalCalories { get => _totalCalories; set => _totalCalories = value; }
        public Gender Gender1 { get => _gender; set => _gender = value; }
        public int Age { get => _age; set => _age = value; } // Renamed property
        public int Height { get => _height; set => _height = value; }
        public int Weight { get => _weight; set => _weight = value; }
        public ActivityLevel ActivityLevel1 { get => _activityLevel; set => _activityLevel = value; }

        // Enum for age group
        public enum AgeGroup
        {
            Child,
            Teenager,
            Adult,
            Senior,
            Elderly
        }


        // Enum for gender
        public enum Gender
        {
            Male,
            Female
        }


        // Enum for activity level
        public enum ActivityLevel
        {
            Sedentary,
            LightlyActive,
            ModeratelyActive,
            VeryActive,
            ExtremelyActive
        }

        // Constructor
        public MealPlannerCalculator(int totalCalories, Gender gender, int age, int height, int weight, ActivityLevel activityLevel)
        {
            TotalCalories = totalCalories;
            Gender1 = gender;
            Age = age;
            Height = height;
            Weight = weight;
            ActivityLevel1 = activityLevel;
        }


        // Get the age group for this person
        public AgeGroup GetAgeGroup()
        {
            return Age < 18 ? AgeGroup.Child :
            Age >= 18 && Age < 50 ? AgeGroup.Adult :
            Age >= 50 && Age < 65 ? AgeGroup.Senior :
            AgeGroup.Elderly;
        }


        // Generates a simple meal plan based on the given data
        public void GenerateMealPlan()
        {
            // Calculate the average number of calories per day based on gender and age
            int averageCaloriesPerDay = AVERAGE_CALORIES_PER_DAY[Gender1][GetAgeGroup()];

            // Calculate the number of calories burned per day based on activity level
            int caloriesBurnedPerDay = GetCaloriesBurnedPerDay();

            // Calculate the number of calories to consume per day based on total calories and activity level
            int caloriesToConsumePerDay = TotalCalories - (averageCaloriesPerDay - caloriesBurnedPerDay);

            // Print the results
            Console.WriteLine($"Meal Plan for a {Gender1} aged {Age} who is {Height} cm tall and weighs {Weight} kg");
            Console.WriteLine($"Activity Level: {ActivityLevel1}");
            Console.WriteLine($"Average Calories per Day: {averageCaloriesPerDay}");
            Console.WriteLine($"Calories Burned per Day: {caloriesBurnedPerDay}");
            Console.WriteLine($"Calories to Consume per Day: {caloriesToConsumePerDay}");
        }


        // Constants for average calories per day by gender and age
        private static readonly Dictionary<Gender, Dictionary<AgeGroup, int>> AVERAGE_CALORIES_PER_DAY = new Dictionary<Gender, Dictionary<AgeGroup, int>>
            {
                {
                    Gender.Male, new Dictionary<AgeGroup, int>
                    {
                        { AgeGroup.Child, MALE_CALORIES_PER_DAY },
                        { AgeGroup.Teenager, TEENAGER_CALORIES_PER_DAY },
                        { AgeGroup.Adult, ADULT_CALORIES_PER_DAY },
                        { AgeGroup.Senior, SENIOR_CALORIES_PER_DAY },
                        { AgeGroup.Elderly, ELDERLY_CALORIES_PER_DAY }
                    }
                },
                {
                    Gender.Female, new Dictionary<AgeGroup, int>
                    {
                        { AgeGroup.Child, CHILD_CALORIES_PER_DAY },
                        { AgeGroup.Teenager, TEENAGER_CALORIES_PER_DAY },
                        { AgeGroup.Adult, FEMALE_CALORIES_PER_DAY },
                        { AgeGroup.Senior, SENIOR_CALORIES_PER_DAY },
                        { AgeGroup.Elderly, ELDERLY_CALORIES_PER_DAY }
                    }
                }
            };



        // Calculates the average number of calories per day based on gender and age
        public int GetAverageCaloriesPerDay()
        {
            // Get the age group for this person
            AgeGroup ageGroup = GetAgeGroup();

            // Return the average calories per day for this person's gender and age group
            return AVERAGE_CALORIES_PER_DAY[Gender1][ageGroup];
        }

        // Calculates the number of calories burned per day based on activity level
        private int GetCaloriesBurnedPerDay()
        {
            // Return the number of calories burned per day based on the activity level
            switch (ActivityLevel1)
            {
                case ActivityLevel.Sedentary:
                    return SEDENTARY_CALORIES_BURNED;
                case ActivityLevel.LightlyActive:
                    return LIGHTLY_ACTIVE_CALORIES_BURNED;
                case ActivityLevel.ModeratelyActive:
                    return MODERATELY_ACTIVE_CALORIES_BURNED;
                case ActivityLevel.VeryActive:
                    return VERY_ACTIVE_CALORIES_BURNED;
                case ActivityLevel.ExtremelyActive:
                    return EXTREMELY_ACTIVE_CALORIES_BURNED;
                default:
                    return 0;
            }
        }
    }
}


