using GestionTournoi.Backend;

namespace GestionTournoi.Frontend
{
    public partial class JoueurForm : Form
    {
        private Equipe? equipe = null;
        private bool IsEquipeComplete = false;
        public JoueurForm()
        {
            InitializeComponent();
        }

        private void textNomEquipe_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textNomEquipe.Text))
            {
                labelErreurNomEquipe.Text = "";
                boutonJouer.Enabled = false;
                return;
            }

            bool isUnique = Tournoi.Instance.GetEquipes()
                                            .All(e => !e.NomEquipe.Equals(textNomEquipe.Text, StringComparison.OrdinalIgnoreCase));

            if (!isUnique)
            {
                labelErreurNomEquipe.ForeColor = Color.Red;
                labelErreurNomEquipe.Text = "Ce nom d'équipe est déjà pris";
                boutonJouer.Enabled = false;
            }
            else
            {
                labelErreurNomEquipe.ForeColor = Color.Green;
                labelErreurNomEquipe.Text = "Nom d'équipe disponible";
                boutonJouer.Enabled = true;
            }
            if (!Tournoi.Instance.Chrono.isActif)
            {
                labelErreurNomEquipe.ForeColor = Color.Red;
                labelErreurNomEquipe.Text = "Les inscriptions sont terminées.";
                boutonJouer.Enabled = false;
                return;
            }

        }


        private void textPseudo_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textPseudo.Text))
            {
                labelErreurPseudo.Text = "";
                return;
            }

            bool isUnique = Tournoi.Instance.GetEquipes()
                                            .SelectMany(e => e.Joueurs)
                                            .All(j => !j.Pseudo.Equals(textPseudo.Text, StringComparison.OrdinalIgnoreCase));

            if (!isUnique)
            {
                labelErreurPseudo.ForeColor = Color.Red;
                labelErreurPseudo.Text = "Ce pseudo est déjà pris";
            }
            else
            {
                labelErreurPseudo.ForeColor = Color.Green;
                labelErreurPseudo.Text = "Pseudo disponible";
            }
        }

        private void AjouterEquipe()
        {
            if (string.IsNullOrWhiteSpace(textNomEquipe.Text))
            {
                labelErreurNomEquipe.ForeColor = Color.Red;
                labelErreurNomEquipe.Text = "Le nom de l'équipe ne peut pas être vide.";
                return;
            }

            equipe = Tournoi.Instance.AddEquipe(textNomEquipe.Text);

            if (equipe == null)
            {
                labelErreurNomEquipe.ForeColor = Color.Red;
                labelErreurNomEquipe.Text = "Création de l'équipe impossible!!";
            }
            else
            {
                {
                    labelErreurNomEquipe.ForeColor = Color.Green;
                    labelErreurNomEquipe.Text = "Equipe numéro " + equipe.Id + " créée!!";
                    labelErreur.ForeColor = Color.Red;
                    labelErreur.Text = "Rajoutez les membres de votre équipe pour jouer!";
                    textNomEquipe.Enabled = false;
                    labelErreurPseudo.Visible = true;
                    labelPseudo.Visible = true;
                    LabelMembres.Visible = true;
                    textPseudo.Visible = true;
                    buttonAjouter.Visible = true;
                    listMembresEquipe.Items.Clear();
                    listMembresEquipe.Visible = true;
                    boutonJouer.Text = "Jouer";
                }
            }
        }

        private void buttonAjouterJoueur_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textPseudo.Text))
            {
                labelErreurPseudo.ForeColor = Color.Red;
                labelErreurPseudo.Text = "Le pseudo ne peut pas être vide.";
                return;
            }

            bool isUnique = Tournoi.Instance.GetEquipes()
                                            .SelectMany(e => e.Joueurs)
                                            .All(j => !j.Pseudo.Equals(textPseudo.Text, StringComparison.OrdinalIgnoreCase));

            if (!isUnique)
            {
                labelErreurPseudo.ForeColor = Color.Red;
                labelErreurPseudo.Text = "Ce pseudo est déjà pris";
                return;
            }

            if (equipe != null)
            {
                Joueur joueur = Tournoi.Instance.AddJoueur(textPseudo.Text, equipe.Id);

                if (joueur == null)
                {
                    labelErreurPseudo.ForeColor = Color.Red;
                    labelErreurPseudo.Text = "Impossible de rajouter " + textPseudo.Text + " à l'équipe";
                }
                else
                {
                    labelErreurPseudo.ForeColor = Color.Green;
                    labelErreurPseudo.Text = textPseudo.Text + " ajouté à l'équipe";
                    textPseudo.Text = "";
                    listMembresEquipe.Items.Clear();

     
                    Joueur[] joueurs = equipe.Joueurs.ToArray();
                    listMembresEquipe.Items.AddRange(joueurs);
                    listMembresEquipe.DisplayMember = "DisplayJoueur";

                    
                    if (equipe.Joueurs.Count >= Tournoi.Instance.NbJoueursMinParEquipe)
                    {
                        IsEquipeComplete = true;
                        equipe.isReady = true;
                        labelErreur.ForeColor = Color.Green;
                        labelErreur.Text = "Équipe complète, attendez la fin de la phase d'inscription";
                    }
                }
                if (!Tournoi.Instance.Chrono.isActif)
                {
                    labelErreurPseudo.ForeColor = Color.Red;
                    labelErreurPseudo.Text = "Les inscriptions sont terminées.";
                    return;
                }

            }
        }

        private void boutonJouer_Click(object sender, EventArgs e)
        {
            if (equipe == null)
            {
                AjouterEquipe();
            }
            else if (equipe != null && !IsEquipeComplete)
            {
                labelErreur.ForeColor = Color.Red;
                labelErreur.Text = "Composition de l'équipe invalide. Impossible de lancer la partie!!";
            }
            else if (equipe != null && IsEquipeComplete)
            {
                this.Hide();

            }
        }

        private void JoueurForm_Load(object sender, EventArgs e)
        {
            labelErreur.ForeColor = Color.Black;
            labelErreur.Text = "Saisissez le nom de l'équipe";
            Tournoi.Instance.Chrono.OnTimeUp += BloquerInscriptions;
        }

        private void JoueurForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        private void BloquerInscriptions()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    labelErreurNomEquipe.ForeColor = Color.Red;
                    labelErreurNomEquipe.Text = "Les inscriptions sont terminées.";
                    boutonJouer.Enabled = false;
                    textNomEquipe.Enabled = false;
                    textPseudo.Enabled = false;
                    buttonAjouter.Enabled = false;
                }));
            }
            else
            {
                labelErreurNomEquipe.ForeColor = Color.Red;
                labelErreurNomEquipe.Text = "Les inscriptions sont terminées.";
                boutonJouer.Enabled = false;
                textNomEquipe.Enabled = false;
                textPseudo.Enabled = false;
                buttonAjouter.Enabled = false;
            }
        }

    }
}
