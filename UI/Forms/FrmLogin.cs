using Domain.core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIforms
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

 
        private void btnAceptarLogin_Click(object sender, EventArgs e)
        {
            
            if ( ConsultarUsuario.LoginUsuario(txtUser.Text, txtPass.Text) )
            {
                FrmFactura frmFac = new FrmFactura();
                frmFac.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario O Clave no coinciden");
                gboxLogin.Controls.OfType<TextBox>().ToList().ForEach(t => t.Text = string.Empty);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
