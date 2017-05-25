using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GunGames.modelos;
using GunGames.controles;

namespace GunGames
{
    public partial class Painel : Form
    {
        public Painel()
        {
            InitializeComponent();
        }

        private void Painel_Load(object sender, EventArgs e)
        {
            populateDgv();
        }

        private void populateDgv()
        {

            dgvJogos.Rows.Clear();

            List<Game> games = GameController.all();

            foreach(Game game in games)
            {
                dgvJogos.Rows.Add(game.ToDGV());
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Game game = new Game();

            game.Name = txtName.Text;
            game.Console = cbConsole.Text;
            game.Type = cbType.Text;
            game.Value = Convert.ToDouble(txtSale.Text);
            game.Cost = Convert.ToDouble(txtCost.Text);

            bool result = GameController.salveGame(game);

            if(result)
            {
                MessageBox.Show("Cadastrado com sucesso!");
                populateDgv();
            } else
            {
                MessageBox.Show("Falha ao cadastrar");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
