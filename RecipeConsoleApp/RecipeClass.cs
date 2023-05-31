using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace RecipeConsoleApp
{
    public class RecipeClass
    {
        /// <summary>
        /// Store recipe name
        /// </summary>
        public string RecipeName { get; set; } = string.Empty;

        /// <summary>
        /// Instance of Ingredients class
        /// </summary>
        public IngredientsClass Ingredients = new IngredientsClass();

        /// <summary>
        /// Instance of Step class
        /// </summary>
        public StepClass Steps = new StepClass();

        /// <summary>
        /// Array to store details of each ingredient in recipe
        /// </summary>
        public List<IngredientsClass> IngredientsArray = new List<IngredientsClass>();

        /// <summary>
        /// Array to store each recipe 
        /// </summary>
        public List<RecipeClass> RecipeArray = new List<RecipeClass>();

        /// <summary>
        /// Array to store each step description
        /// </summary>
        public List<StepClass> StepArray = new List<StepClass>();

        //---------------------------------------------------------------------------------------//
        /// <summary>
        /// Default Constructor
        /// </summary>
        public RecipeClass()
        {
            
        }

        //---------------------------------------------------------------------------------------//
        /// <summary>
        /// Gets recipe name from user
        /// Keep asking till correct input requested is added
        /// In case incorrect input is added will display error message
        /// </summary>
        public void GetRecipeName()
        {
            Boolean Valid = true;

            do
            {
                try
                {
                    Valid = true;
                    Console.WriteLine("Enter the name of the recipe: ");
                    this.RecipeName = Console.ReadLine();
                }
                catch (FormatException)
                {
                    Valid = false;
                    Console.WriteLine("\nSorry, you did not enter a valid name. Please try again.");
                }
            } while (Valid.Equals(false));
        }

        //---------------------------------------------------------------------------------------//
        /// <summary>
        /// Method that calls methods 
        /// Asks user for Number of Ingredients and call method to get an ingredient detail
        /// Will loop for the number of ingredient specified
        /// Loop for amount of steps and keeps asking for description and store in StepArray
        /// Store all Data in Recipe Object including Arrays
        /// </summary>
        public void GetRecipe()
        {
            var Recipe = new RecipeClass();

            Console.WriteLine("\nEnter Recipe information bellow" +
                              "\n-------------------------------\n");

            Recipe.GetRecipeName();
            Ingredients.GetNumberOfIngredients();

            Console.WriteLine("\nType Ingredient Details" +
                              "\n-----------------------\n");

            for (int i = 0; i < Ingredients.NumberOfIngredients; i++)
            {
                var NewIngredient = new IngredientsClass();

                Console.WriteLine("\nIngredient " + (i + 1) +
                                  "\n------------\n");

                NewIngredient.GetIngredientDetails();

                Recipe.IngredientsArray.Add(NewIngredient);
            }

            Console.WriteLine("\nType number of Steps" +
                              "\n--------------------");

            Steps.GetNumberOfSteps();

            for (int i = 0; i < Steps.NumberOfSteps; i++)
            {
                var NewStep = new StepClass();

                Console.WriteLine("\nStep " + (i + 1));

                NewStep.GetStepDescription();

                Recipe.StepArray.Add(NewStep);
            }
            
            this.RecipeArray.Add(Recipe);
        }

        //---------------------------------------------------------------------------------------//
        /// <summary>
        /// Displays Recipe to User
        /// Ask user for Recipe Option
        /// If there is no recipes saved it will return
        /// If user selects recipe option that does not exist system will ask again
        /// </summary>
        public void DisplayRecipeData()
        {
            if (RecipeArray.Count.Equals(0))
            {
                Console.Clear();
                Console.WriteLine("\nSorry, there is no recipes saved at the moment");     
                return;
            }

            Console.WriteLine("\nDisplay Recipe" +
                              "\n--------------\n", Console.ForegroundColor);

            Console.ForegroundColor = ConsoleColor.Yellow;

            DisplayRecipeNameList();

            Boolean Valid = true;

            int Option = 0;

            do
            {
                try
                {
                    Valid = true;
                    Console.WriteLine("\nType option number from above recipes to diplay: ");
                    Option = int.Parse(Console.ReadLine());
                    if ((RecipeArray.Count() - 1) < Option)
                    {
                        Valid = false;
                        Console.WriteLine("\nSorry, you did not enter a valid option. Please try again.");
                    }
                }
                catch (FormatException)
                {
                    Valid = false;
                    Console.WriteLine("\nSorry, you did not enter a valid option. Please try again.");
                }
            } while (Valid.Equals(false));

            DisplayRecipeName(Option);
            DisplayIngredientData(Option);
            DisplayRecipeSteps(Option);
        }

        //---------------------------------------------------------------------------------------//
        /// <summary>
        /// Display Steps descriptions
        /// Loops thru step array and displays
        /// </summary>
        public void DisplayRecipeSteps(int Option)
        {
            int StepArrayLength = this.RecipeArray[Option].StepArray.Count;

            Console.WriteLine("\nRecipe Steps" +
                              "\n------------\n", Console.ForegroundColor);

            Console.ForegroundColor = ConsoleColor.Yellow;

            for (int i = 0; i < StepArrayLength; i++)
            {
                Console.WriteLine("Step " + (i + 1) + " :"
                    + this.RecipeArray[Option].StepArray[i].StepDescription);
            }
        }

        //---------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Display Recipe Name
        /// This method is called in DisplayRecipeNameList
        /// </summary>
        public void DisplayRecipeName(int Number)
        {
            Console.WriteLine(" (" + Number + ") Recipe name :"
                + this.RecipeArray[Number].RecipeName);
        }

        //---------------------------------------------------------------------------------------//
        /// <summary>
        /// Display Ingredients details
        /// Name and Quantity and unit of meausurament
        /// Loops thru length of Ingredients array
        /// </summary>
        public void DisplayIngredientData(int Option)
        {
                Console.WriteLine("\nDisplay Ingredients" +
                                  "\n------------------\n", Console.ForegroundColor );

            Console.ForegroundColor = ConsoleColor.Yellow;

            int IngredientsArrayLength = this.RecipeArray[Option].IngredientsArray.Count;

                for (int i = 0; i < IngredientsArrayLength; i++)
                {
                    Console.WriteLine("Ingredient " + (i + 1) + " : "
                        + this.RecipeArray[Option].IngredientsArray[i].IngredientName + " -> "
                        + this.RecipeArray[Option].IngredientsArray[i].IngredientQuantity + " "
                        + this.RecipeArray[Option].IngredientsArray[i].UnitOfMeasurement);
                }
        }

        //---------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to display recipe names list
        /// Loop thru Recipe Array
        /// This method is called in Display Recipe Data
        /// </summary>
        public void DisplayRecipeNameList()
        {           
            for (int i = 0; i < this.RecipeArray.Count; i++)
            {
                DisplayRecipeName(i);
            }
        }

        //---------------------------------------------------------------------------------------//
        /// <summary>
        /// Method To Delete Recipe
        /// If user selects recipe option that does not exist system will ask again
        /// </summary>
        public void DeleteRecipe()
        {
            if (RecipeArray.Count.Equals(0))
            {
                Console.Clear();
                Console.WriteLine("\nSorry, there is no recipes saved at the moment");
                return;
            }
            Console.WriteLine("\nDelete Recipe" +
                              "\n-------------\n", Console.ForegroundColor);

            Console.ForegroundColor = ConsoleColor.Yellow;

            DisplayRecipeNameList();

            Console.WriteLine("Type Recipe option that must be deleted: ");

            int Option = 0;
            Boolean Valid = true;

            do
            {
                try
                {
                    Valid = true;
                    Option = int.Parse(Console.ReadLine());
                    if ((RecipeArray.Count() - 1) < Option)
                    {
                        Valid = false;
                        Console.WriteLine("\nSorry, you did not enter a valid option. Please try again.");
                    }
                }
                catch (FormatException)
                {
                    Valid = false;
                    Console.WriteLine("\nSorry, you did not enter a valid Option. Please try again.");
                }
            } while (Valid.Equals(false));

            Console.WriteLine("\nAre you sure you want to delete. "
                            + "\n(1) Yes"
                            + "\n(2) No");

            Option = 0;

            do
            {
                try
                {
                    Valid = true;
                    Console.WriteLine("Choose an option:");
                    Option = int.Parse(Console.ReadLine());
                    if (Option < 1 || Option > 2)
                    {
                        Valid = false;
                    }
                }
                catch (FormatException)
                {
                    Valid = false;
                    Console.WriteLine("\nSorry, you did not enter a valid Option. Please try again.");
                }
            } while (Valid.Equals(false));

            if (Option.Equals(true))
            {
                RecipeArray.Remove(RecipeArray[Option]);
            }
        }


        //---------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Scale Up Recipe
        /// If user selects recipe option that does not exist system will ask again
        /// If user selects invalid recipe option system will ask again
        /// Method keeps looping till user terminates
        /// </summary>
        public void ScaleUp()
        {
            if (RecipeArray.Count.Equals(0))
            {
                Console.Clear();
                Console.WriteLine("\nSorry, there is no recipes saved at the moment");
                return;
            }

            Boolean Control = false; 

            do
            {                          
                Console.WriteLine("\nScale Up Recipe" +
                              "\n-------------\n");

                Boolean Valid = true;
                int ScaleOption = 0;
                int RecipeOption = 0;

                DisplayRecipeNameList();

                do
                {
                    try
                    {
                        Console.WriteLine("\nSelect Recipe option to Scale up:");
                        Valid = true;
                        RecipeOption = int.Parse(Console.ReadLine());
                        if ((RecipeArray.Count() - 1) < RecipeOption)
                        {
                            Valid = false;
                            Console.WriteLine("\nSorry, you did not enter a valid option. Please try again.");
                        }
                    }
                    catch (FormatException)
                    {
                        Valid = false;
                        Console.WriteLine("\nSorry, you did not enter a valid Option. Please try again.");
                    }

                } while (Valid.Equals(false));

                Console.WriteLine("\n (1) Half 0.5"
                            + "\n (2) Double 2"
                            + "\n (3) Triple"
                            + "\n (4) Reset"
                            + "\n (5) Go back to menu"
                            + "\n Type Option:");

                do
                {
                    try
                    {
                        Valid = true;
                        Console.WriteLine("Select Scale up Options bellow:");

                        ScaleOption = int.Parse(Console.ReadLine());

                        if (ScaleOption < 1 || ScaleOption > 5)
                        {
                            Console.WriteLine("\nSorry, you did not enter a valid Option. Please try again.");
                            Valid = false;
                        }
                    }
                    catch (FormatException)
                    {
                        Valid = false;
                        Console.WriteLine("\nSorry, you did not enter a valid Option. Please try again.");
                    }

                } while (Valid.Equals(false));

                switch (ScaleOption)
                {
                    case 1:
                        ScaleUpCalc(RecipeOption, 0.5);
                        break;
                    case 2:
                        ScaleUpCalc(RecipeOption, 2);
                        break;
                    case 3:
                        ScaleUpCalc(RecipeOption, 3);
                        break;
                    case 4:
                        DisplayIngredientData(RecipeOption);
                        break;
                    case 5:
                        Control = true;
                        break;
                }
            } while (Control.Equals(false));
        }

        //---------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to do calculations for Scale
        /// Method converts tbs to cup if value of tbs bigger than 16 and vice versa
        /// </summary>
        public void ScaleUpCalc(int Option, double Constant)
        {
            int IngredientsArrayLength = this.RecipeArray[Option].IngredientsArray.Count;

            for (int i = 0; i < IngredientsArrayLength; i++)
            {
                string IngName = this.RecipeArray[Option].IngredientsArray[i].IngredientName;
                double IngQuantity = (this.RecipeArray[Option].IngredientsArray[i].IngredientQuantity) * Constant;
                string IngUnit = this.RecipeArray[Option].IngredientsArray[i].UnitOfMeasurement;

                if ((IngQuantity < 1) && IngUnit.Equals("cups"))
                {
                    double IngQuantityCalc = IngQuantity * 16;
                    IngQuantity = IngQuantityCalc;
                    IngUnit = "tablespoons";
                }

                if ((IngQuantity >= 16) && IngUnit.Equals("tablespoons"))
                {
                    double IngQuantityCalc = IngQuantity / 16;
                    IngQuantity = IngQuantityCalc;
                    IngUnit = "cups";
                }

                Console.WriteLine("Ingredient " + (i + 1) + " : "
                    + IngName + " -> "
                    + IngQuantity + " "
                    + IngUnit);
            }
        }
    }
}
//---------------------------------------------------------< END >-----------------------------------------------------//


