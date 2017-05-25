using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GunGames.controles;
using GunGames.modelos;

namespace GunGames
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            List<Control> components = new List<Control> {
                txtUser,
                lblUser,
                txtPassword,
                lblPassword,
                btnLogin
            };

            Centralizar(components);
        }

        public void Centralizar(List<Control> components)
        {            
            foreach(Control comp in components)
            {
                comp.Left = (comp.Parent.Width - comp.Width) / 2;
                //comp.Top = (comp.Parent.Height - comp.Height) / 2;

            }
        }

        private void login()
        {
            if (txtUser.Text != "" && txtPassword.Text != "")
            {
                User user = UserController.isValidUser(txtUser.Text, txtPassword.Text);

                if (user != null)
                {
                    this.Visible = false;

                    Painel painelForm = new Painel();
                    painelForm.Show();
                    painelForm.Focus();
                }
                else
                {
                    MessageBox.Show("Usuário e/ou Senha incorreto(s)");
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                login();
            }
        }

    }
}
