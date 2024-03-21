/// <summary>
/// Filename: Program.cs
/// Created on: 2024-03-16 00:00:00
/// Author: Samuel Jeffman
/// </summary>
/// 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment4.Forms
{
    public partial class FormIngredients : Form
    {
        private Recipe _recipeCopy;
        private Recipe _recipeOriginal;
        public Recipe RecipeCopy
        {
            get { return _recipeCopy; }
            set { _recipeCopy = value; }
        }
        public Recipe RecipeOriginal
        {
            get { return _recipeOriginal; }
            set { _recipeOriginal = value; }
        }
        public FormIngredients(Recipe recipeCopy, Recipe recipeOriginal)
        {
            InitializeComponent();

            RecipeCopy = recipeCopy;
            RecipeOriginal = recipeOriginal;

            InitializeGUI();
        }

        /// <summary>
        /// Init GUI
        /// </summary>
        public void InitializeGUI()
        {
            foreach (string ingredient in RecipeCopy.Ingredients)
            {
                if (ingredient != null)
                {
                    lstIngredients.Items.Add(ingredient);
                }
            }
        }

        /// <summary>
        /// Update GUI
        /// </summary>
        private void UpdateGUI()
        {
            throw new System.NotImplementedException();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int lastIndex;
            RecipeCopy.AddIngredient(txtNameIngredient.Text, out lastIndex);
            lstIngredients.Items.Add(RecipeCopy.Ingredients[lastIndex]);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            RecipeOriginal.Ingredients = RecipeCopy.Ingredients;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
