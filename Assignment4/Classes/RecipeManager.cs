﻿/// <summary>
/// Filename: Program.cs
/// Created on: 2024-03-16 00:00:00
/// Author: Samuel Jeffman
/// </summary>
/// 
using static Assignment4.FormMain;

namespace Assignment4.Forms
{
    internal class RecipeManager
    {
        #region Fields
        private Recipe[] recipeList;
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="RecipeManager"/> class to the specified max number of elements
        /// </summary>
        /// <param name="maxNumOfElements"></param>
        public RecipeManager(int maxNumOfElements)
        {
            recipeList = new Recipe[maxNumOfElements];
        }
        #endregion
        #region Methods
        /// <summary>
        /// Add recipe to array
        /// </summary>
        private bool Add(Recipe recipe)
        {
            int index = FindVacantPosition();
            if (index < 0)
                throw new IndexOutOfRangeException($"No vacant position for recipe found, array is full! Max count is: {MaxNumOfElements}");
            recipeList[index] = recipe;

            return true;
        }

        /// <summary>
        /// Add recipe to array
        /// </summary>
        public bool Add(string name, FoodCategory category, string[] ingredients, string description)
        {
            Add(new Recipe(name, category, ingredients, description));
            return true;
        }

        /// <summary>
        /// Change element
        /// </summary>
        public void ChangeElementAtIndex(int index, Recipe recipe)
        {
            if (CheckIndex(index))
            {
                this.recipeList[index] = recipe;
            }
            else
            {
                throw new IndexOutOfRangeException($"Invalid index({index}) when trying to change an element. Maybe you haven't selected a recipe?");
            }
        }

        /// <summary>
        /// Check index
        /// </summary>
        private bool CheckIndex(int index)
        {
            return (index >= 0 && index < this.recipeList.Length);
        }

        /// <summary>
        /// Delete element
        /// </summary>
        public void DeleteElement(int index)
        {
            if (CheckIndex(index))
            {
                this.recipeList[index] = null;
                MoveElementsOneStepToLeft(index);
            }
            else
            {
                throw new IndexOutOfRangeException($"Invalid index({index}) when trying to delete an element. Maybe you haven't selected a recipe?");
            }
        }

        /// <summary>
        /// Find vacant position
        /// </summary>
        private int FindVacantPosition()
        {
            return Array.IndexOf(this.recipeList, null);
        }

        /// <summary>
        /// Get current number of recipes
        /// </summary>
        public int GetCurrentNumberOfRecipes()
        {
            int count = 0;

            for (int i = 0; i < this.recipeList.Length; i++)
            {
                if (recipeList[i] != null)
                    count++;
            }
            return count;
        }

        /// <summary>
        /// Get recipe at
        /// </summary>
        public Recipe? GetRecipeAt(int index)
        {
            if (CheckIndex(index))
            {
                return recipeList[index];
            }
            else
            {
                throw new IndexOutOfRangeException($"Invalid index({index}) when trying to retreive an element. Maybe you haven't selected a recipe?");
            }
        }

        /// <summary>
        /// Move elements one step to left
        /// </summary>
        private void MoveElementsOneStepToLeft(int index)
        {
            for (int i = index; i < this.recipeList.Length - 1; i++)
            {
                this.recipeList[i] = this.recipeList[i + 1];
            }
        }

        /// <summary>
        /// Get number of ingredients in the provided recipe
        /// </summary>
        /// <param _name="recipe"></param>
        /// <returns></returns>
        private int GetNumOfIngredients(Recipe recipe)
        {
            int ingredients = 0;

            foreach (var ingredient in recipe.Ingredients)
            {
                if (ingredient != null)
                {
                    ingredients++;
                }
            }

            return ingredients;
        }

        /// <summary>
        /// Recipe list to string
        /// </summary>
        public string RecipeListToString() //Using RecipeListToListBox instead
        {
            string infoString = String.Empty;

            for (int i = 0, j = 0; i < recipeList.Length; i++)
            {
                if (recipeList[i] != null)
                {
                    infoString += recipeList[i].ToString() + "\n";
                    j++;
                }
            }
            return infoString;
        }

        /// <summary>
        /// Recipe list to string
        /// </summary>
        public void RecipeListToListBox(ListBox listbox)
        {
            foreach (var recipe in recipeList)
            {
                if (recipe != null)
                {
                    listbox.Items.Add(string.Format("{0,-44} {1,-40} {2,5}", recipe.Name, recipe.Category, GetNumOfIngredients(recipe)));
                }
            }
        }
        #endregion
    }
}
