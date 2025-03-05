using GestionTournoi.Backend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionTournoi.Frontend
{
    public partial class JoueurForm : Form
    {
        public Tournoi tournoi = Tournoi.GetInstance();
        private Equipe? equipe = null;
        private bool IsEquipeComplete = false;
        public JoueurForm()
        {
            tournoi.SetNbJoueursMin(3);
            tournoi.SetNomTournoi("Tournoi intergallactique");
            InitializeComponent();
        }

        private void textNomEquipe_TextChanged(object sender, EventArgs e)
        {

            bool isUnique = tournoi.IsUniqueNomEquipe(textNomEquipe.Text);

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
        }

        private void textPseudo_TextChanged(object sender, EventArgs e)
        {
            bool isUnique = tournoi.IsUniquePseudo(textPseudo.Text);

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
            //////// Your code
            //////// Ecrire le code pour rajouter l'équipe en backend et récupérer l'équipe avec son Id
            equipe = tournoi.AddEquipe(textNomEquipe.Text);
            //////////

            if (equipe == null)
            {
                labelErreurNomEquipe.ForeColor = Color.Red;
                labelErreurNomEquipe.Text = "Création de l'équipe impossible!!";
            }
            else
            {
                {
                    labelErreurNomEquipe.ForeColor = Color.Green;
                    labelErreurNomEquipe.Text = "Equipe numéro " + equipe.id + " créée!!";
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
            bool isUnique = tournoi.IsUniquePseudo(textPseudo.Text);

            if (!isUnique)
            {
                labelErreurPseudo.ForeColor = Color.Red;
                labelErreurPseudo.Text = "Ce pseudo est déjà pris";
            }
            if (equipe != null && textPseudo.Text != "" && isUnique)
            {
                Joueur? joueur = tournoi.AddJoueur(textPseudo.Text, equipe.id);
                

                if (joueur == null)
                {
                    labelErreurPseudo.ForeColor = Color.Red;
                    labelErreurPseudo.Text = "Impossible de rajouter " + textPseudo.Text + " à l'équipe";
                }
                else
                {
                    labelErreurPseudo.ForeColor = Color.Green;
                    labelErreurPseudo.Text = textPseudo.Text + " rajouté à l'équipe";
                    textPseudo.Text = "";
                    listMembresEquipe.Items.Clear();
                    Joueur[]? joueurs = equipe.GetJoueurs().ToArray();

                    if (joueurs != null) listMembresEquipe.Items.AddRange(joueurs);
                    listMembresEquipe.DisplayMember = "DisplayJoueur";

                    if (IsEquipeComplete = tournoi.IsEquipeComplete(equipe.id))
                    {
                        labelErreur.ForeColor = Color.Green;
                        labelErreur.Text = "Equipe complète, attendez la fin de la phase d'inscription";
                    }
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
                // Equipe prête
                this.Hide();

            }
        }

        private void JoueurForm_Load(object sender, EventArgs e)
        {
            labelErreur.ForeColor = Color.Black;
            labelErreur.Text = "Saisissez le nom de l'équipe";
        }
        private void JoueurForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        } 

    }
}
