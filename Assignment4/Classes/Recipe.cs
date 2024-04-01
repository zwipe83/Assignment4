/// <summary>
/// Filename: Program.cs
/// Created on: 2024-03-16 00:00:00
/// Author: Samuel Jeffman
/// </summary>
/// 
namespace Assignment4.Forms
{
    public class Recipe
    {
        #region Fields
        private FoodCategory _category;
        private string? _description;
        private string[]? _ingredients;
        private string? _name;
        #endregion
        #region Constructors
        public Recipe(int maxNumOfIngredients)
        {
            DefaultValues(maxNumOfIngredients);
        }
        public Recipe(string name, FoodCategory category, string[] ingredients, string description)
        {
            Name = name;
            Category = category;
            Ingredients = ingredients;
            Description = description;
        }
        #endregion
        #region Properties
        public FoodCategory Category
        {
            get => _category;
            set
            {
                _category = value;
            }
        }

        public string? Description
        {
            get => _description;
            set
            {
                _description = value ?? string.Empty; //You won't be able to save the recipe with an empty _description, as "Add recipe" will throw an exception, so we might as well allow an empty string.
            }
        }

        public string[]? Ingredients
        {
            get => _ingredients;
            set
            {
                if (value != null && value.Length > 0)
                {
                    _ingredients = value;
                }
            }
        }

        public string? Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _name = string.Empty;
                    throw new ArgumentException("Name can not be null or empty.");
                }
                _name = value;
            }
        }
        #endregion
        #region Methods

        /// <summary>
        /// Add an ingredient to current recipe
        /// </summary>
        /// <param _name="input"></param>
        /// <returns></returns>
        public bool AddIngredient(string input) //FIXED: Is lastIndex needed?
        {
            bool ok = true;
            int index = FindVacantPosition();

            if (CheckIndex(index) && CheckInput(input))
            {
                Ingredients[index] = input; //FIXED: Maybe null check?
            }
            else
            {
                ok = false;
            }

            return ok;
        }

        /// <summary>
        /// Check for correct input
        /// </summary>
        /// <param _name="input"></param>
        /// <returns></returns>
        private bool CheckInput(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        /// <summary>
        /// Change an ingredient in a specific recipe
        /// </summary>
        /// <param _name="index"></param>
        /// <param _name="value"></param>
        /// <returns></returns>
        public bool ChangeIngredientAt(int index, string value) //Not used, as all Ingredients will be overwritten if you click OK in FormIngredients
        {
            bool ok = true;
            if (CheckIndex(index) && CheckInput(value))
            {
                Ingredients[index] = value;
            }
            else
            {
                ok = false;
            }

            return ok;
        }

        /// <summary>
        /// Check index is in range
        /// </summary>
        /// <param _name="index"></param>
        /// <returns></returns>
        private bool CheckIndex(int index)
        {
            return (index >= 0 && index < Ingredients.Length);
        }

        /// <summary>
        /// Check Ingredients is not null
        /// </summary>
        /// <param _name="ingredients"></param>
        /// <returns></returns>
        private bool CheckIngredients(string[] ingredients)
        {
            return (ingredients is not null);
        }

        /// <summary>
        /// Get current number of _ingredients
        /// </summary>
        /// <returns></returns>
        public int CurrentNumberOfIngredients()
        {
            return Ingredients.Count(ingredient => ingredient != null);
        }

        /// <summary>
        /// Sets default values for recipe
        /// </summary>
        public void DefaultValues(int maxNumOfIngredients)
        {
            Name = "<Enter recipe name>";
            Category = FoodCategory.Meats;
            Description = "<Enter recipe descriptions>";
            Ingredients = new string[maxNumOfIngredients];
        }

        /// <summary>
        /// Delete an ingredient from a recipe
        /// </summary>
        /// <param _name="index"></param>
        public void DeleteIngredientAt(int index) //Not used, as all Ingredients will be overwritten if you click OK in FormIngredients
        {
            if (CheckIndex(index) && CheckIngredients(Ingredients))
            {
                Ingredients[index] = null;
            }
        }

        /// <summary>
        /// Find first vacant(null) position in array
        /// </summary>
        /// <returns></returns>
        private int FindVacantPosition()
        {
            int index = -1;

            if (CheckIngredients(Ingredients))
            {
                for (int i = 0; i < Ingredients.Length; i++)
                {
                    if (Ingredients[i] == null)
                    {
                        index = i;
                        break;
                    }
                }
            }

            return index;
        }

        /// <summary>
        /// Override for ToString()
        /// </summary>
        /// <returns>Name of recipe</returns>
        public override string ToString()
        {
            return Name;
        }
        #endregion
    }
}
