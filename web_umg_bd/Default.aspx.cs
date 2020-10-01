using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web_umg_bd
{
    public partial class _Default : Page
    {
        marca producto;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack){
                producto = new marca();
                producto.drop_marca(drop_marca);
                producto.grid_productos(grid_productos);
            }
        }

        protected void btn_agregar_Click(object sender, EventArgs e)
        {
            producto = new marca();
            if (producto.agregar(txt_producto.Text,txt_descripcion.Text,txt_precioc.Text,txt_preciov.Text,txt_existencia.Text,Convert.ToInt32(drop_marca.SelectedValue)) > 0){
                lbl_mensaje.Text = "Ingreso Exitoso";
                producto.grid_productos(grid_productos);

            }
        }

        protected void grid_productos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //grid_productos.SelectedValue.ToString();
            //grid_productos.DataKeys[indice].Values["id"].ToString();
            txt_producto.Text = grid_productos.SelectedRow.Cells[2].Text;
            txt_descripcion.Text = grid_productos.SelectedRow.Cells[3].Text;
            txt_precioc.Text = grid_productos.SelectedRow.Cells[4].Text;
            txt_preciov.Text = grid_productos.SelectedRow.Cells[5].Text;
            txt_existencia.Text = grid_productos.SelectedRow.Cells[6].Text;
            int indice = grid_productos.SelectedRow.RowIndex;
            drop_marca.SelectedValue = grid_productos.DataKeys[indice].Values["id_marca"].ToString();

            btn_modificar.Visible = true;
        }

        protected void grid_productos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            

            producto = new marca();
            if (producto.eliminar(Convert.ToInt32(e.Keys["id"])) > 0)
            {
                lbl_mensaje.Text = "Eliminacion Exitoso";
                producto.grid_productos(grid_productos);
                btn_modificar.Visible = false;

            }
            

        }

        protected void btn_modificar_Click(object sender, EventArgs e)
        {

            producto = new marca();
            if (producto.modificar(Convert.ToInt32(grid_productos.SelectedValue), txt_producto.Text, txt_descripcion.Text, txt_precioc.Text, txt_preciov.Text, txt_existencia.Text, Convert.ToInt32(drop_marca.SelectedValue)) > 0)
            {
                lbl_mensaje.Text = "Modificacion Exitoso";
                producto.grid_productos(grid_productos);
                btn_modificar.Visible = false;

            }
           
            
        }

        protected void drop_marca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}