using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipeConsoleApp;
using System;

namespace UnitTesting
{
    [TestClass]
    public class RecipeClassTests
    {
        RecipeClass Recipe = new RecipeClass();

        /// <summary>
        /// Populating int Array that will hold calories values to be Summed in Loop
        /// Populating IngredientList with Loop
        /// </summary>
        [TestMethod]
        public void TotalCaloriesTest()
        {
            RecipeClass RecipeObj = new RecipeClass();

            int[] CaloriesData = new int[10] {100, 200, 150, 40, 110, 120, 22, 8, 1, 7};

            for (int i = 0; i < 10; i++)
            {
                var NewIngredient = new IngredientsClass();

                NewIngredient.IngredientCalories.Equals(CaloriesData[i]);

                Recipe.IngredientsArray.Add(NewIngredient);
            }

            Recipe.RecipeArray.Add(RecipeObj);

            int Total = Recipe.SumCalories(0);

            if (Total == 758)
            {
                Assert.IsTrue(true);   
            }
            else
            {
                Assert.IsFalse(false);
            }
        }
    }
}
