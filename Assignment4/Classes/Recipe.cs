/// <summary>
/// Filename: Program.cs
/// Created on: 2024-03-16 00:00:00
/// Author: Samuel Jeffman
/// </summary>
/// 

namespace Assignment4.Forms
{
    public class Recipe : IDisposable
    {
        #region Fields
        private FoodCategory category;
        private string? description;
        private string[]? ingredients;
        private string? name;
        #endregion
        #region Constructors
        public Recipe(int maxNumOfIngredients)
        {
            ingredients = new string[maxNumOfIngredients];
        }

        public Recipe(Recipe objToCopyFrom)
        {
            category = objToCopyFrom.category;
            description = objToCopyFrom.description;
            ingredients = objToCopyFrom.ingredients;
            name = objToCopyFrom.name;
        }
        public Recipe(string name, FoodCategory category, string[] ingredients, string description)
        {
            this.name = name;
            this.category = category;
            this.ingredients = ingredients;
            this.description = description;
        }
        #endregion
        #region Properties
        public FoodCategory Category
        {
            get => category;
            set => category = value;
        }

        public string Description
        {
            get => description;
            set => description = value;
        }

        public string[] Ingredients
        {
            get => ingredients;
            set => ingredients = value;
        }

        public int MaxNumOfIngredients
        {
            get => ingredients.Length;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }
        #endregion
        #region Methods
        public bool AddIngredient(string input, out int lastIndex)
        {
            bool ok = true;
            int index = FindVacantPosition();

            if ((index >= 0) && (input != null) && (input != String.Empty))
            {
                ingredients[index] = input;
            }
            else
                ok = false;

            lastIndex = index;

            return ok;
        }

        public bool ChangeIngredientAt(int index, string value)
        {
            throw new System.NotImplementedException();
        }

        private bool CheckIndex(int index)
        {
            throw new System.NotImplementedException();
        }

        public int CurrentNumberOfIngredients()
        {
            throw new System.NotImplementedException();
        }

        public void DefaultValues()
        {
            throw new System.NotImplementedException();
        }

        public void DeleteIngredientAt(int index)
        {
            throw new System.NotImplementedException();
        }

        private int FindVacantPosition()
        {
            int index = -1;

            for (int i = 0; i < ingredients.Length; i++)
            {
                if (ingredients[i] == null)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public override string ToString()
        {
            return Name;
        }

        public void Dispose()
        {
            //throw new System.NotImplementedException();
        }
        #endregion
    }
}
