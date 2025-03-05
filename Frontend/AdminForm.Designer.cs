namespace GestionTournoiEtape3.Frontend
{
    partial class AdminForm
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
            labelTrace = new Label();
            richTextTrace = new RichTextBox();
            listEquipesEnCours = new ListBox();
            labelEquipesEnCours = new Label();
            textNomTournoi = new TextBox();
            labelNomTournoi = new Label();
            buttonDemarrerCompetition = new Button();
            listJoueurs = new ListBox();
            labelJoueurs = new Label();
            listEquipesInscrites = new ListBox();
            labelEquipes = new Label();
            SuspendLayout();
            // 
            // labelTrace
            // 
            labelTrace.AutoSize = true;
            labelTrace.Location = new Point(523, 51);
            labelTrace.Name = "labelTrace";
            labelTrace.Size = new Size(101, 15);
            labelTrace.TabIndex = 21;
            labelTrace.Text = "Trace des activités";
            // 
            // richTextTrace
            // 
            richTextTrace.Enabled = false;
            richTextTrace.Location = new Point(523, 69);
            richTextTrace.Name = "richTextTrace";
            richTextTrace.Size = new Size(500, 333);
            richTextTrace.TabIndex = 20;
            richTextTrace.Text = "";
            // 
            // listEquipesEnCours
            // 
            listEquipesEnCours.FormattingEnabled = true;
            listEquipesEnCours.HorizontalScrollbar = true;
            listEquipesEnCours.ItemHeight = 15;
            listEquipesEnCours.Location = new Point(11, 248);
            listEquipesEnCours.Name = "listEquipesEnCours";
            listEquipesEnCours.Size = new Size(250, 154);
            listEquipesEnCours.TabIndex = 19;
            // 
            // labelEquipesEnCours
            // 
            labelEquipesEnCours.AutoSize = true;
            labelEquipesEnCours.Location = new Point(11, 230);
            labelEquipesEnCours.Name = "labelEquipesEnCours";
            labelEquipesEnCours.Size = new Size(185, 15);
            labelEquipesEnCours.TabIndex = 18;
            labelEquipesEnCours.Text = "Les équipes en cours d'inscription";
            // 
            // textNomTournoi
            // 
            textNomTournoi.Location = new Point(126, 12);
            textNomTournoi.Name = "textNomTournoi";
            textNomTournoi.Size = new Size(391, 23);
            textNomTournoi.TabIndex = 17;
            // 
            // labelNomTournoi
            // 
            labelNomTournoi.AutoSize = true;
            labelNomTournoi.Location = new Point(11, 16);
            labelNomTournoi.Name = "labelNomTournoi";
            labelNomTournoi.Size = new Size(93, 15);
            labelNomTournoi.TabIndex = 16;
            labelNomTournoi.Text = "Nom du tournoi";
            // 
            // buttonDemarrerCompetition
            // 
            buttonDemarrerCompetition.BackColor = Color.IndianRed;
            buttonDemarrerCompetition.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonDemarrerCompetition.ForeColor = Color.White;
            buttonDemarrerCompetition.Location = new Point(523, 1);
            buttonDemarrerCompetition.Name = "buttonDemarrerCompetition";
            buttonDemarrerCompetition.Size = new Size(249, 38);
            buttonDemarrerCompetition.TabIndex = 15;
            buttonDemarrerCompetition.Text = "Démarrer la compétition";
            buttonDemarrerCompetition.UseVisualStyleBackColor = false;
            buttonDemarrerCompetition.Click += buttonDemarrerCompetition_Click;
            // 
            // listJoueurs
            // 
            listJoueurs.FormattingEnabled = true;
            listJoueurs.HorizontalScrollbar = true;
            listJoueurs.ItemHeight = 15;
            listJoueurs.Location = new Point(267, 69);
            listJoueurs.Name = "listJoueurs";
            listJoueurs.Size = new Size(250, 334);
            listJoueurs.TabIndex = 14;
            // 
            // labelJoueurs
            // 
            labelJoueurs.AutoSize = true;
            labelJoueurs.Location = new Point(267, 51);
            labelJoueurs.Name = "labelJoueurs";
            labelJoueurs.Size = new Size(106, 15);
            labelJoueurs.TabIndex = 13;
            labelJoueurs.Text = "Les joueurs inscrits";
            // 
            // listEquipesInscrites
            // 
            listEquipesInscrites.FormattingEnabled = true;
            listEquipesInscrites.HorizontalScrollbar = true;
            listEquipesInscrites.ItemHeight = 15;
            listEquipesInscrites.Location = new Point(11, 69);
            listEquipesInscrites.Name = "listEquipesInscrites";
            listEquipesInscrites.Size = new Size(250, 154);
            listEquipesInscrites.TabIndex = 12;
            // 
            // labelEquipes
            // 
            labelEquipes.AutoSize = true;
            labelEquipes.Location = new Point(11, 51);
            labelEquipes.Name = "labelEquipes";
            labelEquipes.Size = new Size(114, 15);
            labelEquipes.TabIndex = 11;
            labelEquipes.Text = "Les équipes inscrites";
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1032, 409);
            Controls.Add(labelTrace);
            Controls.Add(richTextTrace);
            Controls.Add(listEquipesEnCours);
            Controls.Add(labelEquipesEnCours);
            Controls.Add(textNomTournoi);
            Controls.Add(labelNomTournoi);
            Controls.Add(buttonDemarrerCompetition);
            Controls.Add(listJoueurs);
            Controls.Add(labelJoueurs);
            Controls.Add(listEquipesInscrites);
            Controls.Add(labelEquipes);
            Name = "AdminForm";
            Text = "AdminForm";
            Load += AdminForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTrace;
        private RichTextBox richTextTrace;
        private ListBox listEquipesEnCours;
        private Label labelEquipesEnCours;
        private TextBox textNomTournoi;
        private Label labelNomTournoi;
        private Button buttonDemarrerCompetition;
        private ListBox listJoueurs;
        private Label labelJoueurs;
        private ListBox listEquipesInscrites;
        private Label labelEquipes;
    }
}