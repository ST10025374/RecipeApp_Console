using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeConsoleApp
{
    public class IngredientsClass
    {
        /// <summary>
        /// Store the number of ingredients of each recipe
        /// </summary>
        private int NumberOfIngredients { get; set; } = 0;

        /// <summary>
        /// Store Ingredient Name
        /// </summary>
        private string IngredientName { get; set; } = string.Empty;

        /// <summary>
        /// Store Ingredient Quantity
        /// </summary>
        private double IngredientQuantity { get; set; } = 0.0;

        /// <summary>
        /// Store Ingredient Unit Of Measurement
        /// </summary>
        private string UnitOfMeasurement { get; set; } = string.Empty;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public IngredientsClass() 
        { 
        
        }
    }
}
