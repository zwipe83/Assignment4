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
        private void InitGUI()
        {
            this.Text = Recipe.Name;
            lblIngredients.Text = $"INGREDIENTS\n{GetIngredients(Recipe)}";
            lblInstructions.Text = $"\n\nINSTRUCTIONS\n{GetInstructions(Recipe)}";
        }
        #endregion
        #region Methods
        private string GetIngredients(Recipe recipe)
        {
            string? ingredients = String.Empty;
            foreach (var ingredient in recipe.Ingredients)
            {
                ingredients += $"{ingredient},";
            }
            ingredients.Remove(ingredients.Length - 1); //Remove last ','

            return ingredients;
        }
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
