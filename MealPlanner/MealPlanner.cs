
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
        private Genders _gender;
        private int _age; // Renamed field
        private int _height;
        private int _weight;
        private ActivityLevel _activityLevel;

        public List<string> MealPlan { get; set; }
        public int TotalCalories { get => _totalCalories; set => _totalCalories = value; }
        public Genders Gender { get => _gender; set => _gender = value; }
        public int Age { get => _age; set => _age = value; } // Renamed property
        public int Height { get => _height; set => _height = value; }
        public int Weight { get => _weight; set => _weight = value; }
        public ActivityLevel ActivityLevel1 { get => _activityLevel; set => _activityLevel = value; }

        // Constructor
        public MealPlannerCalculator(int totalCalories, Genders gender, int age, int height, int weight, ActivityLevel activityLevel)
        {
            TotalCalories = totalCalories;
            Gender = gender;
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
        public string GenerateMealPlan()
        {
            // Calculate the average number of calories per day based on gender and age
            int averageCaloriesPerDay;
            switch (GetAgeGroup())
            {
                case AgeGroup.Child:
                    averageCaloriesPerDay = CHILD_CALORIES_PER_DAY;
                    break;
                case AgeGroup.Teenager:
                    averageCaloriesPerDay = TEENAGER_CALORIES_PER_DAY;
                    break;
                case AgeGroup.Adult:
                    averageCaloriesPerDay = ADULT_CALORIES_PER_DAY;
                    break;
                case AgeGroup.Senior:
                    averageCaloriesPerDay = SENIOR_CALORIES_PER_DAY;
                    break;
                case AgeGroup.Elderly:
                    averageCaloriesPerDay = ELDERLY_CALORIES_PER_DAY;
                    break;
                default:
                    averageCaloriesPerDay = 0;
                    break;
            }

            // Calculate the number of calories burned per day based on activity level
            int caloriesBurnedPerDay;
            switch (ActivityLevel1)
            {
                case ActivityLevel.Sedentary:
                    caloriesBurnedPerDay = SEDENTARY_CALORIES_BURNED;
                    break;
                case ActivityLevel.LightlyActive:
                    caloriesBurnedPerDay = LIGHTLY_ACTIVE_CALORIES_BURNED;
                    break;
                case ActivityLevel.ModeratelyActive:
                    caloriesBurnedPerDay = MODERATELY_ACTIVE_CALORIES_BURNED;
                    break;
                case ActivityLevel.VeryActive:
                    caloriesBurnedPerDay = VERY_ACTIVE_CALORIES_BURNED;
                    break;
                case ActivityLevel.ExtremelyActive:
                    caloriesBurnedPerDay = EXTREMELY_ACTIVE_CALORIES_BURNED;
                    break;
                default:
                    caloriesBurnedPerDay = 0;
                    break;
            }

            // Calculate the number of calories to consume per day
            int caloriesToConsumePerDay = averageCaloriesPerDay - caloriesBurnedPerDay;

            // Generate a simple meal plan using string interpolation
            string mealPlan = $"Meal Plan for a {Gender} age {Age}, {Height}cm tall and weighs {Weight}kg:\n";
            mealPlan += $"Average Calories Per Day: {averageCaloriesPerDay}\n";
            mealPlan += $"Calories Burned Per Day: {caloriesBurnedPerDay}\n";
            mealPlan += $"Calories to Consume Per Day: {caloriesToConsumePerDay}\n\n";
            mealPlan += $"Breakfast: {caloriesToConsumePerDay / 4} calories\n";
            mealPlan += $"Lunch: {caloriesToConsumePerDay / 4}";
            return mealPlan;
        }










        // Constants for average calories per day by gender and age
        private static readonly Dictionary<Genders, Dictionary<AgeGroup, int>> AVERAGE_CALORIES_PER_DAY = new Dictionary<Genders, Dictionary<AgeGroup, int>>
        {
            {
                Genders.Male, new Dictionary<AgeGroup, int>
                {
                    { AgeGroup.Child, 1800 },
                    { AgeGroup.Teenager, 2000 },
                    { AgeGroup.Adult, 2200 },
                    { AgeGroup.Senior, 2000 },
                    { AgeGroup.Elderly, 1800 }
                }
            },
            {
                Genders.Female, new Dictionary<AgeGroup, int>
                {
                    { AgeGroup.Child, 1800 },
                    { AgeGroup.Teenager, 2000 },
                    { AgeGroup.Adult, 2000 },
                    { AgeGroup.Senior, 1900 },
                    { AgeGroup.Elderly, 1700 }
                }
            }
        };





        // Calculates the average number of calories per day based on gender and age
        public int GetAverageCaloriesPerDay()
        {
            // Get the age group for this person
            AgeGroup ageGroup = GetAgeGroup();

            // Return the average calories per day for this person's gender and age group
            return AVERAGE_CALORIES_PER_DAY[Gender][ageGroup];
        }

        // Calculates the number of calories burned per day based on activity level
        public int GetCaloriesBurnedPerDay()
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
    public enum Genders
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
}


