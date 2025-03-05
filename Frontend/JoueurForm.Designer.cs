namespace GestionTournoi.Frontend
{
    partial class JoueurForm
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
            labelErreurNomEquipe = new Label();
            labelErreurPseudo = new Label();
            buttonAjouter = new Button();
            textPseudo = new TextBox();
            labelPseudo = new Label();
            labelErreur = new Label();
            boutonJouer = new Button();
            listMembresEquipe = new ListBox();
            LabelMembres = new Label();
            textNomEquipe = new TextBox();
            labelNomEquipe = new Label();
            SuspendLayout();
            // 
            // labelErreurNomEquipe
            // 
            labelErreurNomEquipe.AutoSize = true;
            labelErreurNomEquipe.Location = new Point(122, 75);
            labelErreurNomEquipe.Name = "labelErreurNomEquipe";
            labelErreurNomEquipe.Size = new Size(176, 15);
            labelErreurNomEquipe.TabIndex = 34;
            labelErreurNomEquipe.Text = "Saisissez le nom de votre équipe";
            // 
            // labelErreurPseudo
            // 
            labelErreurPseudo.AutoSize = true;
            labelErreurPseudo.Location = new Point(236, 190);
            labelErreurPseudo.Name = "labelErreurPseudo";
            labelErreurPseudo.Size = new Size(148, 15);
            labelErreurPseudo.TabIndex = 33;
            labelErreurPseudo.Text = "Le pseudo doit être unique";
            labelErreurPseudo.Visible = false;
            // 
            // buttonAjouter
            // 
            buttonAjouter.BackColor = SystemColors.GradientActiveCaption;
            buttonAjouter.Location = new Point(236, 155);
            buttonAjouter.Name = "buttonAjouter";
            buttonAjouter.Size = new Size(236, 23);
            buttonAjouter.TabIndex = 32;
            buttonAjouter.Text = "<< Ajoutez un membre";
            buttonAjouter.UseVisualStyleBackColor = false;
            buttonAjouter.Visible = false;
            buttonAjouter.Click += buttonAjouterJoueur_Click;
            // 
            // textPseudo
            // 
            textPseudo.Location = new Point(236, 126);
            textPseudo.Name = "textPseudo";
            textPseudo.Size = new Size(236, 23);
            textPseudo.TabIndex = 31;
            textPseudo.Visible = false;
            textPseudo.TextChanged += textPseudo_TextChanged;
            // 
            // labelPseudo
            // 
            labelPseudo.AutoSize = true;
            labelPseudo.Location = new Point(236, 108);
            labelPseudo.Name = "labelPseudo";
            labelPseudo.Size = new Size(202, 15);
            labelPseudo.TabIndex = 30;
            labelPseudo.Text = "Saisir le pseudo du nouveau membre";
            labelPseudo.Visible = false;
            // 
            // labelErreur
            // 
            labelErreur.AutoSize = true;
            labelErreur.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelErreur.ForeColor = Color.Black;
            labelErreur.Location = new Point(12, 9);
            labelErreur.Name = "labelErreur";
            labelErreur.Size = new Size(306, 20);
            labelErreur.TabIndex = 29;
            labelErreur.Text = "Saisir le nom de l'équipe et les participants";
            // 
            // boutonJouer
            // 
            boutonJouer.BackColor = Color.Turquoise;
            boutonJouer.Enabled = false;
            boutonJouer.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            boutonJouer.Location = new Point(11, 310);
            boutonJouer.Name = "boutonJouer";
            boutonJouer.Size = new Size(460, 35);
            boutonJouer.TabIndex = 28;
            boutonJouer.Text = "Créer équipe";
            boutonJouer.UseVisualStyleBackColor = false;
            boutonJouer.Click += boutonJouer_Click;
            // 
            // listMembresEquipe
            // 
            listMembresEquipe.FormattingEnabled = true;
            listMembresEquipe.ItemHeight = 15;
            listMembresEquipe.Location = new Point(12, 126);
            listMembresEquipe.Name = "listMembresEquipe";
            listMembresEquipe.Size = new Size(218, 169);
            listMembresEquipe.TabIndex = 27;
            listMembresEquipe.Visible = false;
            // 
            // LabelMembres
            // 
            LabelMembres.AutoSize = true;
            LabelMembres.Location = new Point(12, 108);
            LabelMembres.Name = "LabelMembres";
            LabelMembres.Size = new Size(138, 15);
            LabelMembres.TabIndex = 26;
            LabelMembres.Text = "Les membres de l'équipe";
            LabelMembres.Visible = false;
            // 
            // textNomEquipe
            // 
            textNomEquipe.Location = new Point(122, 49);
            textNomEquipe.Name = "textNomEquipe";
            textNomEquipe.Size = new Size(350, 23);
            textNomEquipe.TabIndex = 25;
            textNomEquipe.TextChanged += textNomEquipe_TextChanged;
            // 
            // labelNomEquipe
            // 
            labelNomEquipe.AutoSize = true;
            labelNomEquipe.Location = new Point(11, 53);
            labelNomEquipe.Name = "labelNomEquipe";
            labelNomEquipe.Size = new Size(95, 15);
            labelNomEquipe.TabIndex = 24;
            labelNomEquipe.Text = "Nom de l'équipe";
            // 
            // JoueurForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(486, 354);
            Controls.Add(labelErreurNomEquipe);
            Controls.Add(labelErreurPseudo);
            Controls.Add(buttonAjouter);
            Controls.Add(textPseudo);
            Controls.Add(labelPseudo);
            Controls.Add(labelErreur);
            Controls.Add(boutonJouer);
            Controls.Add(listMembresEquipe);
            Controls.Add(LabelMembres);
            Controls.Add(textNomEquipe);
            Controls.Add(labelNomEquipe);
            Name = "JoueurForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "JoueurForm";
            FormClosed += JoueurForm_FormClosed;
            Load += JoueurForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelErreurNomEquipe;
        private Label labelErreurPseudo;
        private Button buttonAjouter;
        private TextBox textPseudo;
        private Label labelPseudo;
        private Label labelErreur;
        private Button boutonJouer;
        private ListBox listMembresEquipe;
        private Label LabelMembres;
        private TextBox textNomEquipe;
        private Label labelNomEquipe;
    }
}