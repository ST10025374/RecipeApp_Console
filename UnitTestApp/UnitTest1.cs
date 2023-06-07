using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipeConsoleApp;
using System;
using System.Collections.Generic;

namespace UnitTestApp
{
    

    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Array to store each recipe 
        /// </summary>
        public List<RecipeClass> RecipeArray = new List<RecipeClass>();

        //--------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Test SumCalories Method to check if it is correctly summing
        /// Arrays are used pass values
        /// Holds Calories Values for ingredients
        /// Holds Sum Matching each calorieData array sum of values
        /// Compares if values match to check if Sum works correctly
        /// </summary>
        [TestMethod]
        public void TotalCaloriesCalculationTest()
        {
            int[] CaloriesData1 = new int[10] { 100, 150, 100, 1, 0, 5, 30, 22, 10, 2};
            int[] CaloriesData2 = new int[10] { 3, 0, 1000, 1, 3, 1000, 102, 44, 55, 0};
            int[] CaloriesData3 = new int[10] { 8, 1, 7, 20, 44, 99, 24, 55, 32, 111};
            int[] CaloriesData4 = new int[10] { 100, 3000, 1, 100, 500, 600, 700, 0, 0, 1};
            int[] CaloriesData5 = new int[10] { 0, 0, 1, 10, 25, 30, 21, 55, 100, 200};
            int[] CaloriesData6 = new int[10] { 100, 150, 100, 1, 0, 5, 3, 66, 88, 10};
            int[] CaloriesData7 = new int[10] { 3, 0, 1000, 200, 44, 100, 96, 33, 22, 45};
            int[] CaloriesData8 = new int[10] { 8, 1, 7, 3, 5, 6, 300, 100, 3, 0};
            int[] CaloriesData9 = new int[10] { 100, 3000, 1 , 23, 45, 65, 32, 234, 34, 56};
            int[] CaloriesData10 = new int[10] { 0, 0, 1 , 34, 12, 45, 76, 43, 45, 67};

            int[] TotalSumsArray = new int[10] { 420, 2208, 401, 
                                                 5002, 442, 523, 
                                                 1543, 433, 3590, 323};

            Assert.AreEqual(ReturnSumOfArray(CaloriesData1, 0), TotalSumsArray[0]);
            Assert.AreEqual(ReturnSumOfArray(CaloriesData2, 1), TotalSumsArray[1]);
            Assert.AreEqual(ReturnSumOfArray(CaloriesData3, 2), TotalSumsArray[2]);
            Assert.AreEqual(ReturnSumOfArray(CaloriesData4, 3), TotalSumsArray[3]);
            Assert.AreEqual(ReturnSumOfArray(CaloriesData5, 4), TotalSumsArray[4]);
            Assert.AreEqual(ReturnSumOfArray(CaloriesData6, 5), TotalSumsArray[5]);
            Assert.AreEqual(ReturnSumOfArray(CaloriesData7, 6), TotalSumsArray[6]);
            Assert.AreEqual(ReturnSumOfArray(CaloriesData8, 7), TotalSumsArray[7]);
            Assert.AreEqual(ReturnSumOfArray(CaloriesData9, 8), TotalSumsArray[8]);
            Assert.AreEqual(ReturnSumOfArray(CaloriesData10, 9), TotalSumsArray[9]);
        }

        //--------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method receives Calories values and passes it to Object Recipe
        /// Obj Recipe is stored at global recipeArray List 
        /// List is passed to sumCalories Method for values to be summed
        /// Method returns total Sum
        /// Instance of RecipeClass Created
        /// </summary>
        /// <param name="DataArray"></param>
        public int ReturnSumOfArray(int[] CaloriesData, int Num)
        {
            var Recipe = new RecipeClass();

            var Ingredient1 = new IngredientsClass { IngredientCalories = CaloriesData[0] };
            var Ingredient2 = new IngredientsClass { IngredientCalories = CaloriesData[1] };
            var Ingredient3 = new IngredientsClass { IngredientCalories = CaloriesData[2] };
            var Ingredient4 = new IngredientsClass { IngredientCalories = CaloriesData[3] };
            var Ingredient5 = new IngredientsClass { IngredientCalories = CaloriesData[4] };
            var Ingredient6 = new IngredientsClass { IngredientCalories = CaloriesData[5] };
            var Ingredient7 = new IngredientsClass { IngredientCalories = CaloriesData[6] };
            var Ingredient8 = new IngredientsClass { IngredientCalories = CaloriesData[7] };
            var Ingredient9 = new IngredientsClass { IngredientCalories = CaloriesData[8] };
            var Ingredient10 = new IngredientsClass { IngredientCalories = CaloriesData[9] };

            Recipe.IngredientsArray = new List<IngredientsClass> { Ingredient1, Ingredient2,
                                                                   Ingredient3, Ingredient4,
                                                                   Ingredient5, Ingredient6,
                                                                   Ingredient7, Ingredient8,
                                                                   Ingredient9, Ingredient10};

            this.RecipeArray.Add(Recipe);

            var Sum = Recipe.SumCalories(Num, this.RecipeArray);

            return Sum;
        }
    }
}
//---------------------------------------------------------< END >-----------------------------------------------------//
   
