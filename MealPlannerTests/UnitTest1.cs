using MealPlanner;
using NUnit.Framework;
using System;
using static MealPlanner.MealPlannerCalculator;

namespace MealPlannerTests
{
    public class MealPlannerTests
    {
        // Create an instance of the MealPlanner class to use in the tests
        protected MealPlanner.MealPlannerCalculator mealPlanner = new MealPlanner.MealPlannerCalculator(2000, Gender.Female, 30, 160, 60, ActivityLevel.ModeratelyActive);

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
    }
}
