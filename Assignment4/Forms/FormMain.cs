
/// <summary>
/// Filename: Program.cs
/// Created on: 2024-03-16 00:00:00
/// Author: Samuel Jeffman
/// </summary>
/// 

using Assignment4.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment4
{
    public partial class FormMain : Form
    {
        private const int maxNumOfElements = 100;
        private const int maxNumOfIngredients = 20;
        private RecipeManager recipeManager = new RecipeManager(maxNumOfElements);
        private Recipe currRecipe;

        public static int MaxNumOfIngredients
        {
            get
            {
                return maxNumOfIngredients;
            }
        }

        public FormMain()
        {
            InitializeComponent();
            InitializeGUI();
            currRecipe = new Recipe(maxNumOfIngredients);
        }

        /// <summary>
        /// Init GUI
        /// </summary>
        public void InitializeGUI()
        {
            cmbFoodCategory.Items.Clear();
            cmbFoodCategory.DataSource = Enum.GetValues(typeof(FoodCategory));
        }

        /// <summary>
        /// Update GUI
        /// </summary>
        private void UpdateGUI()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Clear selection
        /// </summary>
        private void ClearSelection()
        {
            throw new System.NotImplementedException();
        }

        private void btnAddIngredient_Click(object sender, EventArgs e)
        {
            FormIngredients fi = new FormIngredients(currRecipe);
            fi.Show();
        }

        private void btnAddRecipe_Click(object sender, EventArgs e)
        {
            recipeManager.Add(txtNameRecipe.Text, (FoodCategory)cmbFoodCategory.SelectedItem, currRecipe.Ingredients, currRecipe.Description);

            lstRecipe.Items.Clear();
            recipeManager.RecipeListToListBox(lstRecipe);

            txtDescription.Text = String.Empty;
            txtNameRecipe.Text = String.Empty;
            cmbFoodCategory.SelectedIndex = 0;

            currRecipe = new Recipe(maxNumOfIngredients);
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            currRecipe.Description = txtDescription.Text;
        }
    }
}
