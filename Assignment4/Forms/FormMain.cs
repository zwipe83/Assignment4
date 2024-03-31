
/// <summary>
/// Filename: Program.cs
/// Created on: 2024-03-16 00:00:00
/// Author: Samuel Jeffman
/// </summary>
/// 

using Assignment4.Forms;

namespace Assignment4
{
    public partial class FormMain : Form
    {
        #region Fields
        private const int _maxNumOfElements = 100;
        private const int _maxNumOfIngredients = 20;
        private RecipeManager recipeManager = new RecipeManager(MaxNumOfElements);
        private Recipe currRecipe;
        #endregion
        #region Properties
        public static int MaxNumOfIngredients
        {
            get
            {
                return _maxNumOfIngredients;
            }
        }
        public static int MaxNumOfElements
        {
            get
            {
                return _maxNumOfElements;
            }
        }
        #endregion
        #region Constructors
        public FormMain()
        {
            InitializeComponent();
            currRecipe = new Recipe(MaxNumOfIngredients);
            InitializeGUI();
        }
        #endregion
        #region Initializers
        /// <summary>
        /// Init GUI
        /// </summary>
        public void InitializeGUI()
        {
            cmbFoodCategory.DataSource = Enum.GetValues(typeof(FoodCategory));
            txtNameRecipe.Text = currRecipe.Name;
            txtDescription.Text = currRecipe.Description;
            btnEditFinish.Enabled = false;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Update GUI
        /// </summary>
        private void UpdateGUI()
        {
            lstRecipe.Items.Clear();
            recipeManager.RecipeListToListBox(lstRecipe);
            txtNameRecipe.Text = currRecipe.Name;
            txtDescription.Text = currRecipe.Description;
        }

        /// <summary>
        /// Clear selection
        /// </summary>
        private void ClearSelection()
        {
            lstRecipe.SelectedIndex = -1;

            ResetCreateNewRecipe();

            UpdateGUI();
        }

        /// <summary>
        /// Opens a new form where you can add _ingredients to recipe
        /// </summary>
        /// <param _name="sender"></param>
        /// <param _name="e"></param>
        private void btnAddIngredient_Click(object sender, EventArgs e)
        {
            FormIngredients formIngredients = new FormIngredients(currRecipe);
            DialogResult dlgResult = formIngredients.ShowDialog();

            if (dlgResult == DialogResult.OK)
            {
                if (currRecipe.CurrentNumberOfIngredients() <= 0)
                {
                    MessageBox.Show("No ingredients, please add some.", "Error"); //Will probably never end up here, since you can't even click OK if there are no _ingredients added.
                }
            }
            //formIngredient.Show();
        }

        /// <summary>
        /// Adds current recipe to recipeManager
        /// </summary>
        /// <param _name="sender"></param>
        /// <param _name="e"></param>
        private void btnAddRecipe_Click(object sender, EventArgs e)
        {
            //FIXED: Add checks before blindly adding stuff
            try
            {
                if (string.IsNullOrWhiteSpace(currRecipe.Name))
                {
                    throw new InvalidOperationException("Enter a recipe name!");
                }

                if (currRecipe.CurrentNumberOfIngredients() <= 0)
                {
                    throw new InvalidOperationException("There are no ingredients in your recipe!");
                }

                if (currRecipe.Description.Length <= 0)
                {
                    throw new InvalidOperationException("Please add some instructions how to make your recipe!");
                }

                recipeManager.Add(currRecipe.Name, currRecipe.Category, currRecipe.Ingredients, currRecipe.Description);

                cmbFoodCategory.SelectedIndex = 0;

                currRecipe = new Recipe(MaxNumOfIngredients);

                UpdateGUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Handle decription text changed
        /// </summary>
        /// <param _name="sender"></param>
        /// <param _name="e"></param>
        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            try
            {
                currRecipe.Description = txtDescription.Text;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Warning");
            }
        }

        /// <summary>
        /// Gets _ingredients and _description for selected recipe
        /// </summary>
        /// <param _name="sender"></param>
        /// <param _name="e"></param>
        private void lstRecipe_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (lstRecipe.SelectedIndex < 0)
                {
                    return; //Maybe you clicked on an empty line in the list? Do nothing...
                }

                FormRecipe formRecipe = new FormRecipe(recipeManager.GetRecipeAt(lstRecipe.SelectedIndex));
                formRecipe.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Initiates an edit of a recipe
        /// </summary>
        /// <param _name="sender"></param>
        /// <param _name="e"></param>
        private void btnEditStart_Click(object sender, EventArgs e)
        {
            try
            {
                lstRecipe.Enabled = false;
                btnEditStart.Enabled = false;
                btnEditFinish.Enabled = true;
                btnAddRecipe.Enabled = false;
                currRecipe = recipeManager.GetRecipeAt(lstRecipe.SelectedIndex);
                txtDescription.Text = currRecipe.Description;
                txtNameRecipe.Text = currRecipe.Name;
                cmbFoodCategory.SelectedIndex = (int)currRecipe.Category;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Finish a recipe edit
        /// </summary>
        /// <param _name="sender"></param>
        /// <param _name="e"></param>
        private void btnEditFinish_Click(object sender, EventArgs e)
        {
            try
            {
                recipeManager.ChangeElementAtIndex(lstRecipe.SelectedIndex, currRecipe);
                ResetCreateNewRecipe();

                UpdateGUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Reset controls and add a new recipe
        /// </summary>
        private void ResetCreateNewRecipe()
        {
            cmbFoodCategory.SelectedIndex = 0;
            btnAddRecipe.Enabled = true;
            btnEditStart.Enabled = true;
            btnEditFinish.Enabled = false;
            lstRecipe.Enabled = true;
            currRecipe = new Recipe(MaxNumOfIngredients);
        }

        /// <summary>
        /// Handle recipe _name changed
        /// </summary>
        /// <param _name="sender"></param>
        /// <param _name="e"></param>
        private void txtNameRecipe_TextChanged(object sender, EventArgs e)
        {
            try
            {
                currRecipe.Name = txtNameRecipe.Text;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Warning");
            }
        }

        /// <summary>
        /// Handle food _category change
        /// </summary>
        /// <param _name="sender"></param>
        /// <param _name="e"></param>
        private void cmbFoodCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFoodCategory.SelectedIndex >= 0)
            {
                FoodCategory foodCategory;
                foodCategory = (FoodCategory)cmbFoodCategory.SelectedIndex;
                currRecipe.Category = foodCategory;
            }
        }

        /// <summary>
        /// Delete a recipe from recipe manager
        /// </summary>
        /// <param _name="sender"></param>
        /// <param _name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                recipeManager.DeleteElement(lstRecipe.SelectedIndex);
                UpdateGUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Clear current edit and selected recipe
        /// </summary>
        /// <param _name="sender"></param>
        /// <param _name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearSelection();
        }

        /// <summary>
        /// Mark all text
        /// </summary>
        /// <param _name="sender"></param>
        /// <param _name="e"></param>
        private void txtDescription_MouseClick(object sender, MouseEventArgs e)
        {
            txtDescription.SelectAll();
        }

        /// <summary>
        /// Mark all text
        /// </summary>
        /// <param _name="sender"></param>
        /// <param _name="e"></param>
        private void txtDescription_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtNameRecipe.SelectAll();
        }
        #endregion
    }
}
