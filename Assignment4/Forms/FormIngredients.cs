/// <summary>
/// Filename: Program.cs
/// Created on: 2024-03-16 00:00:00
/// Author: Samuel Jeffman
/// </summary>
/// 
using Assignment4.Wpf;
using static Assignment4.FormMain;

namespace Assignment4.Forms
{
    public partial class FormIngredients : Form
    {
        #region Fields
        private Recipe _currRecipe;
        private int _ingredientIndex;
        #endregion
        #region Properties
        private Recipe CurrRecipe
        {
            get { return _currRecipe; }
            set { _currRecipe = value; }
        }
        public int IngredientIndex
        {
            get { return _ingredientIndex; }
            set { _ingredientIndex = value; }
        }
        #endregion
        #region Constructors
        public FormIngredients(Recipe recipe)
        {
            InitializeComponent();

            CurrRecipe = recipe;

            InitializeGUI();
        }
        #endregion
        #region Initializers
        /// <summary>
        /// Init GUI
        /// </summary>
        public void InitializeGUI()
        {
            btnAdd.Enabled = false; //FIXED: Release should be false
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnOK.Enabled = false;
            AddIngredients(CurrRecipe);
            UpdateGUI();
        }
        #endregion
        #region Methods
        /// <summary>
        /// Adds _ingredients from current recipe to listbox
        /// </summary>
        /// <param _name="recipe"></param>
        private void AddIngredients(Recipe recipe)
        {
            lstIngredients.Items.AddRange(recipe.Ingredients.Where(ingredient => !string.IsNullOrWhiteSpace(ingredient)).ToArray());
        }
        /// <summary>
        /// Count _ingredients in the list
        /// </summary>
        /// <returns></returns>
        private int CountIngredients()
        {
            int count = 0;
            foreach (var ingredient in lstIngredients.Items)
            {
                if (!string.IsNullOrWhiteSpace((string)ingredient))
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Update GUI
        /// </summary>
        private void UpdateGUI()
        {
            lblCurrNumber.Text = $"{CountIngredients()}/{MaxNumOfIngredients}";
        }

        /// <summary>
        /// Adds an ingredient to the list
        /// </summary>
        /// <param _name="sender"></param>
        /// <param _name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstIngredients.Enabled) // Add new
                {
                    if (CountIngredients() >= MaxNumOfIngredients)
                    {
                        throw new InvalidOperationException($"Too many ingredients! The limit is {MaxNumOfIngredients}");
                    }

                    var ingredientText = txtNameIngredient.Text?.Trim() ?? throw new ArgumentNullException(nameof(txtNameIngredient.Name), "Input string cannot be null or empty.");
                    lstIngredients.SelectedIndex = lstIngredients.Items.Add(ingredientText);
                }
                else // Edit existing
                {
                    if (IngredientIndex < 0 || IngredientIndex >= MaxNumOfIngredients)
                    {
                        throw new IndexOutOfRangeException("Index is out of range");
                    }

                    var ingredientText = txtNameIngredient.Text?.Trim() ?? throw new ArgumentNullException(nameof(txtNameIngredient.Name), "Input string cannot be null or empty.");
                    lstIngredients.Items[IngredientIndex] = ingredientText;
                    lstIngredients.Enabled = true;
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                    btnAdd.Text = "Add";
                }

                txtNameIngredient.Text = string.Empty;
                UpdateGUI();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        /// <summary>
        /// Handle exceptions
        /// </summary>
        /// <param _name="ex"></param>
        private void HandleException(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        /// <summary>
        /// Goes through the list of _ingredients and adds them to currRecipe
        /// </summary>
        /// <param _name="sender"></param>
        /// <param _name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Recipe recipe = new Recipe(MaxNumOfIngredients);

                foreach (var ingredient in lstIngredients.Items)
                {
                    if (!string.IsNullOrWhiteSpace((string)ingredient))
                    {
                        recipe.AddIngredient((string)ingredient);
                    }
                    else
                    {
                        throw new ArgumentNullException(nameof(sender), "Input string cannot be null or empty.");
                    }
                }

                CurrRecipe.Ingredients = recipe.Ingredients;
                GC.Collect();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Closes the window without saving anything
        /// </summary>
        /// <param _name="sender"></param>
        /// <param _name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Deletes an ingredient from the list
        /// </summary>
        /// <param _name="sender"></param>
        /// <param _name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                lstIngredients.Items.RemoveAt((lstIngredients.SelectedIndex >= 0 && lstIngredients.SelectedIndex < MaxNumOfIngredients) ? lstIngredients.SelectedIndex : throw new IndexOutOfRangeException("Selected index is out of range.")); //FIXED: Check?
                txtNameIngredient.Text = String.Empty;
                UpdateGUI();
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Initiates editing of an ingredient
        /// </summary>
        /// <param _name="sender"></param>
        /// <param _name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditIngredient();
        }

        /// <summary>
        /// Edit an ingredient
        /// </summary>
        private void EditIngredient()
        {
            try
            {
                lstIngredients.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnAdd.Text = "Save";
                IngredientIndex = (lstIngredients.SelectedIndex >= 0 && lstIngredients.SelectedIndex < MaxNumOfIngredients) ? lstIngredients.SelectedIndex : throw new IndexOutOfRangeException("Selected index is out of range."); //FIXED: Maybe null check?
                txtNameIngredient.Text = lstIngredients?.SelectedItem?.ToString();
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Handle _name change of ingredient
        /// </summary>
        /// <param _name="sender"></param>
        /// <param _name="e"></param>
        private void txtNameIngredient_TextChanged(object sender, EventArgs e)
        {
            if (txtNameIngredient.Text.Length > 0)
            {
                btnAdd.Enabled = true;
            }
            else
            {
                btnAdd.Enabled = false;
            }
        }

        /// <summary>
        /// Handle index change on ingredient list
        /// </summary>
        /// <param _name="sender"></param>
        /// <param _name="e"></param>
        private void lstIngredients_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool hasIngredients = CountIngredients() > 0;
            btnOK.Enabled = hasIngredients;
            btnEdit.Enabled = hasIngredients;
            btnDelete.Enabled = hasIngredients;
        }

        /// <summary>
        /// Initiate an edit of ingredient
        /// </summary>
        /// <param _name="sender"></param>
        /// <param _name="e"></param>
        private void lstIngredients_DoubleClick(object sender, EventArgs e)
        {
            EditIngredient();
        }
        #endregion
    }
}
