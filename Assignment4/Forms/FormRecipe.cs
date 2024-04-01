namespace Assignment4.Forms
{
    public partial class FormRecipe : Form
    {
        #region Fields
        private Recipe _recipe;
        #endregion
        #region Properties
        public Recipe Recipe
        {
            get => _recipe;
            set => _recipe = value;
        }
        #endregion
        #region Constructors
        public FormRecipe(Recipe recipe)
        {
            InitializeComponent();

            Recipe = recipe;

            InitGUI();
        }
        #endregion
        #region Initializers
        /// <summary>
        /// initializes GUI
        /// </summary>
        private void InitGUI()
        {
            this.Text = Recipe.Name;
            lblIngredients.Text = $"INGREDIENTS\n{GetIngredients(Recipe)}";
            lblInstructions.Text = $"INSTRUCTIONS";
            txtInstructions.Text = $"{GetInstructions(Recipe)}";
        }
        #endregion
        #region Methods
        /// <summary>
        /// Get _ingredients for current recipe
        /// </summary>
        /// <param _name="recipe"></param>
        /// <returns></returns>
        private string GetIngredients(Recipe recipe)
        {
            string? ingredients = String.Empty;
            foreach (var ingredient in recipe.Ingredients)
            {
                if (ingredient != null)
                {
                    if (ingredients.Length > 0)
                    {
                        ingredients += ", ";
                    }
                    ingredients += $"{ingredient}";
                }
            }

            return ingredients;
        }

        /// <summary>
        /// Get _description for current recipe
        /// </summary>
        /// <param _name="recipe"></param>
        /// <returns></returns>
        private string GetInstructions(Recipe recipe)
        {
            string? instructions = String.Empty;
            foreach (var instruction in recipe.Description)
            {
                instructions += $"{instruction}";
            }

            return instructions;
        }
        #endregion
    }
}
