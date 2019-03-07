using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

//using Services;
using Domain.core;
using Entities;

namespace UIforms
{
    public partial class FrmFactura : Form
    {
        List<FacturaDetalle> oDetalle = new List<FacturaDetalle>();
        

        public FrmFactura()
        {
            InitializeComponent();

        }

        private void FrmFactura_Load(object sender, EventArgs e)
        {

            cboCliente.DataSource = RegistrarClientes.ConsultarClientes();
            cboCliente.DisplayMember = "CodigoCliente";
            cboCliente.ValueMember = "IdCliente";
            cboCliente.SelectedIndex = -1;

            cboNombreProducto.DataSource = RegistrarProductos.ConsultarProductos();
            cboNombreProducto.DisplayMember = "NombreProducto";
            cboNombreProducto.ValueMember = "IdProducto";
            cboNombreProducto.SelectedIndex = -1;

            IniciarFactura();

        }

        private void IniciarFactura()
        {
            Random rnd = new Random();
            int nroFac = rnd.Next(10, 3000);
            txtNroFactura.Text = nroFac.ToString();

            DateTime date = DateTime.Now;
            txtFechaFactura.Text = date.ToString("yyyy-MM-dd");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            cboCliente.ValueMember = "IdCliente";
            var _IdCliente = int.Parse(cboCliente.SelectedValue.ToString());
            var _NumeroFactura = txtNroFactura.Text;
            cboCliente.ValueMember = "CodigoCliente";
            var _CodigoEmpresa = cboCliente.SelectedValue.ToString();
            var _CodigoCliente = cboCliente.SelectedValue.ToString();
            var _Impuesto = decimal.Parse(txtImpuesto.Text);
            var _FechaFactura = DateTime.Parse(txtFechaFactura.Text);


            FacturaEncabezado oFactura = new FacturaEncabezado
            {
                IdCliente = _IdCliente,
                NumeroFactura = _NumeroFactura,
                CodigoEmpresa = _CodigoEmpresa,
                CodigoCliente = _CodigoCliente,
                Impuesto = _Impuesto,
                Total = Convert.ToDecimal(txtTotal.Text),
                Sub_Total = Convert.ToDecimal(txtSubTotal.Text),
                FechaFactura = _FechaFactura
            };


            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                FacturaDetalle FacturaLinea = new FacturaDetalle
                {
                    IdProducto = Convert.ToInt16(row.Cells["IdProducto"].Value),
                    CodigoProducto = Convert.ToString(row.Cells["CodigoProducto"].Value),
                    NombreProducto = Convert.ToString(row.Cells["NombreProducto"].Value),
                    Descuento = Convert.ToDecimal(row.Cells["Descuento"].Value),
                    Cantidad = Convert.ToInt16(row.Cells["Cantidad"].Value),
                    Precio = Convert.ToDecimal(row.Cells["Precio"].Value)
                };

                oFactura.Lineas.Add(FacturaLinea);
            }

            Venta.RegistrarFacturaVenta(oFactura);
            
            LimpiarControles(false);

        }

        private void LimpiarControles(bool EsDetalle)
        {
            if (!EsDetalle)
            {
                grbLineaFact.Controls.OfType<TextBox>().ToList().ForEach(t => t.Text = string.Empty);
                grbFacEnc.Controls.OfType<TextBox>().ToList().ForEach(t => t.Text = string.Empty);
                cboNombreProducto.SelectedIndex = -1;
                cboCliente.SelectedIndex = -1;

                oDetalle.Clear();
                dgvDetalle.DataSource = null;

                IniciarFactura();
            }
            else if (EsDetalle)
            {
                grbLineaFact.Controls.OfType<TextBox>().ToList().ForEach(t => t.Text = string.Empty);
                cboNombreProducto.SelectedIndex = -1;
            }
        }

        private void cboNombreProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNombreProducto.SelectedIndex > 0)
            {
                 
                cboNombreProducto.ValueMember = "CodigoProducto";
                txtCodProducto.Text = cboNombreProducto.SelectedValue.ToString();

                cboNombreProducto.ValueMember = "PrecioUnitario";
                txtPrecio.Text = cboNombreProducto.SelectedValue.ToString();
            }
        }

        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCliente.SelectedIndex > 0)
            {
               cboCliente.ValueMember = "NombreCliente";
               txtNombreCliente.Text = cboCliente.SelectedValue.ToString();
               cboCliente.ValueMember = "DireccionCliente";
               txtDireccion.Text = cboCliente.SelectedValue.ToString();

            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            cboNombreProducto.ValueMember = "IdProducto";
            
            if (string.IsNullOrEmpty(txtCodProducto.Text) 
                && string.IsNullOrEmpty(txtDecuento.Text) 
                && string.IsNullOrEmpty(txtCantidad.Text) 
                && string.IsNullOrEmpty(txtPrecio.Text)
                && string.IsNullOrEmpty(txtImpuesto.Text))
            {
                MessageBox.Show("Debe Ingresar Datos de producto descuento cantidad y precio, No deben estar vacios");


            }
            else
            {
                FacturaDetalle oDet = new FacturaDetalle()
                {
                    IdProducto = int.Parse(cboNombreProducto.SelectedValue.ToString()),
                    CodigoProducto = txtCodProducto.Text,
                    NombreProducto = cboNombreProducto.Text,
                    Descuento = Convert.ToInt16(txtDecuento.Text),
                    Cantidad = int.Parse(txtCantidad.Text),
                    Precio = decimal.Parse(txtPrecio.Text)
                };
                oDetalle.Add(oDet);
                dgvDetalle.DataSource = oDetalle.ToArray();

                var totalFac = (from data in oDetalle
                                select data.Subtotal).Sum();

                txtSubTotal.Text = totalFac.ToString();
                txtTotal.Text = (totalFac * (1 + Convert.ToDecimal(txtImpuesto.Text)/100)).ToString();
            }

            this.dgvDetalle.Columns["IdFacturaDetalle"].Visible = false;
            this.dgvDetalle.Columns["IdFacturaEncabezado"].Visible = false;
            this.dgvDetalle.Columns["IdProducto"].Visible = false;

            LimpiarControles(true);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
