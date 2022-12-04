using MealPlanner;
using NUnit.Framework;
using System;
using System.Runtime.ConstrainedExecution;
using static MealPlanner.MealPlannerCalculator;


namespace MealPlannerTests
{
    public class MealPlannerTests
    {
        // Create an instance of the MealPlanner class to use in the tests
        protected MealPlanner.MealPlannerCalculator mealPlanner = new MealPlanner.MealPlannerCalculator(2000, Genders.Female, 30, 160, 60, ActivityLevel.ModeratelyActive);

        [Test]
        public void TestGetAgeGroup_WithAgeLessThan18_ShouldReturnChild()
        {
            // Set the age to a value less than 18
            mealPlanner.Age = 10;

            // Assert that the GetAgeGroup method returns the expected age group
            Assert.That(mealPlanner.GetAgeGroup(), Is.EqualTo(AgeGroup.Child));
        }

        [Test]
        public void TestGetAgeGroup_WithAgeGreaterThanEqualTo18AndLessThan50_ShouldReturnAdult()
        {
            // Set the age to a value greater than or equal to 18 and less than 50
            mealPlanner.Age = 18;

            // Assert that the GetAgeGroup method returns the expected age group
            Assert.That(mealPlanner.GetAgeGroup(), Is.EqualTo(AgeGroup.Adult));

            // Set the age to a value greater than or equal to 18 and less than 50
            mealPlanner.Age = 49;

            // Assert that the GetAgeGroup method returns the expected age group
            Assert.That(mealPlanner.GetAgeGroup(), Is.EqualTo(AgeGroup.Adult));
        }

        [Test]
        public void TestGetAgeGroup_WithAgeGreaterThanEqualTo50AndLessThan65_ShouldReturnSenior()
        {
            // Set the age to a value greater than or equal to 50 and less than 65
            mealPlanner.Age = 50;

            // Assert that the GetAgeGroup method returns the expected age group
            Assert.That(mealPlanner.GetAgeGroup(), Is.EqualTo(AgeGroup.Senior));

            // Set the age to a value greater than or equal to 50 and less than 65
            mealPlanner.Age = 64;

            // Assert that the GetAgeGroup method returns the expected age group
            Assert.That(mealPlanner.GetAgeGroup(), Is.EqualTo(AgeGroup.Senior));
        }

        [Test]
        public void TestGetAgeGroup_WithAgeGreaterThanEqualTo65_ShouldReturnElderly()
        {
            // Set the age to a value greater than or equal to 65
            mealPlanner.Age = 65;

            // Assert that the GetAgeGroup method returns the expected age group
            Assert.That(mealPlanner.GetAgeGroup(), Is.EqualTo(AgeGroup.Elderly));
        }

        [Test]
        public void TestGetAgeGroup()
        {
            var calculator = new MealPlannerCalculator(2500, Genders.Male, 25, 180, 80, ActivityLevel.ModeratelyActive);
            var ageGroup = calculator.GetAgeGroup();

            // Check that the correct age group is returned for this person
            Assert.That(ageGroup, Is.EqualTo(AgeGroup.Adult));
        }

        [Test]
        public void TestGetCaloriesBurnedPerDay()
        {
            var calculator = new MealPlannerCalculator(2500, Genders.Male, 25, 180, 80, ActivityLevel.ModeratelyActive);
            var caloriesBurnedPerDay = calculator.GetCaloriesBurnedPerDay();

            // Check that the correct number of calories burned per day is returned for this person
            Assert.That(caloriesBurnedPerDay, Is.EqualTo(1000));
        }

        [Test]
        public void TestGenerateMealPlan()
        {
            var calculator = new MealPlannerCalculator(2500, Genders.Male, 25, 180, 80, ActivityLevel.ModeratelyActive);
            var mealPlan = calculator.GenerateMealPlan();

            // Check that the meal plan is generated correctly
            Assert.That(mealPlan, Is.EqualTo($"Meal Plan for a Male age 25, 180cm tall and weighs 80kg:\n" +
                                             $"Average Calories Per Day: 2500\n" +
                                             $"Calories Burned Per Day: 1000\n" +
                                             $"Calories to Consume Per Day: 1500\n\n" +
                                             $"Breakfast: 375 calories\n" +
                                             $"Lunch: 375 calories\n" +
                                             $"Dinner: 375 calories\n" +
                                             $"Snacks: 375 calories\n"));
        }







    }
}
