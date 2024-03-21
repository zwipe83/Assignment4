/// <summary>
/// Filename: Program.cs
/// Created on: 2024-03-16 00:00:00
/// Author: Samuel Jeffman
/// </summary>
/// 

using Assignment4.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4.Forms
{
    internal class RecipeManager
    {
        private Recipe[] recipeList;

        /// <summary>
        /// Constructor
        /// </summary>
        public RecipeManager(int maxNumOfElements)
        {
            recipeList = new Recipe[maxNumOfElements];
        }

        /// <summary>
        /// Add recipe
        /// </summary>
        public bool Add(Recipe recipe)
        {
            int index = FindVacantPosition();
            recipeList[index] = recipe;

            return true;
        }

        /// <summary>
        /// Add recipe
        /// </summary>
        public bool Add(string name, FoodCategory category, string[] ingredients)
        {
            Add(new Recipe(name, category, ingredients));
            return true;
        }

        /// <summary>
        /// Change element
        /// </summary>
        public void ChangeElement(int index, Recipe recipe)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Check index
        /// </summary>
        private bool CheckIndex(int index)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Delete element
        /// </summary>
        public void DeleteElement(int index)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Find vacant position
        /// </summary>
        public int FindVacantPosition()
        {
            int index = -1;

            for (int i = 0; i < recipeList.Length; i++)
            {
                if (recipeList[i] == null)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        /// <summary>
        /// Get current number of recipes
        /// </summary>
        public int GetCurrentNumberOfRecipes()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Get recipe at
        /// </summary>
        public Recipe GetRecipeAt(int index)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Move elements one step to left
        /// </summary>
        private void MoveElementsOneStepToLeft(string index)
        {
            throw new System.NotImplementedException();
        }

        private int NumOfElements()
        {
            int count = 0;

            for (int i = 0; i < recipeList.Length; i++)
            {
                if (recipeList[i] != null)
                    count++;
            }
            return count;
        }

        /// <summary>
        /// Recipe list to string
        /// </summary>
        public string RecipeListToString()
        {
            int numOfElements = NumOfElements();
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
    }
}
