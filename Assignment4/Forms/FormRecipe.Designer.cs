namespace Assignment4.Forms
{
    partial class FormRecipe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblIngredients = new Label();
            lblInstructions = new Label();
            SuspendLayout();
            // 
            // lblIngredients
            // 
            lblIngredients.AutoSize = true;
            lblIngredients.Location = new Point(12, 9);
            lblIngredients.Name = "lblIngredients";
            lblIngredients.Size = new Size(78, 15);
            lblIngredients.TabIndex = 0;
            lblIngredients.Text = "INGREDIENTS";
            // 
            // lblInstructions
            // 
            lblInstructions.AutoSize = true;
            lblInstructions.Location = new Point(12, 71);
            lblInstructions.Name = "lblInstructions";
            lblInstructions.Size = new Size(87, 15);
            lblInstructions.TabIndex = 0;
            lblInstructions.Text = "INSTRUCTIONS";
            // 
            // FormRecipe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblInstructions);
            Controls.Add(lblIngredients);
            Name = "FormRecipe";
            Text = "FormRecipe";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblIngredients;
        private Label lblInstructions;
    }
}