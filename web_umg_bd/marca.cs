using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;

namespace web_umg_bd
{
    public class marca
    {
        ConexionBD conectar;
        private DataTable drop_marca(){
            DataTable tabla = new DataTable();
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string strConsulta = string.Format("select id_marca as id,marca from marcas;");
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerarConexion();
            return tabla;
        }
        public void drop_marca(DropDownList drop){
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elige marca >>");
            drop.Items[0].Value = "0";
            drop.DataSource = drop_marca();
            drop.DataTextField = "marca";
            drop.DataValueField = "id";
            drop.DataBind();

        }
        private DataTable grid_productos() {
            DataTable tabla = new DataTable();
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            String consulta = string.Format("select e.id_marca as id,e.producto,e.descripcion,e.precioc,e.preciov,e.existencia,p.marca,p.id_marca from productos as e inner join marcas as p on e.id_marca = p.id_marca;");
            MySqlDataAdapter query = new MySqlDataAdapter(consulta, conectar.conectar);
            query.Fill(tabla);
            conectar.CerarConexion();
            return tabla;
        }
        public void grid_productos(GridView grid){
            grid.DataSource = grid_productos();
            grid.DataBind();

        }
        public int agregar(string producto,string descripcion,string precioc,string preciov,string existencia,int id_marca){
            int no_ingreso = 0;
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string strConsulta = string.Format("insert into productos(producto,descripcion,precioc,preciov,existencia,id_marca) values('{0}','{1}','{2}','{3}','{4}','{5}');",producto,descripcion,precioc,preciov,existencia,id_marca);
            MySqlCommand insertar = new MySqlCommand(strConsulta, conectar.conectar);
            
            insertar.Connection = conectar.conectar;
            no_ingreso = insertar.ExecuteNonQuery();
            conectar.CerarConexion();
            return no_ingreso;

        }
        public int modificar(int id,string producto, string descripcion, string precioc, string preciov, string existencia, int id_marca)
        {
            int no_ingreso = 0;
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string strConsulta = string.Format("update productos set producto = '{0}',descripcion='{1}',precioc='{2}',preciov='{3}',existencia='{4}',id_marca ={5} where id_marca ={6};", producto, descripcion, precioc, preciov,existencia, id_marca,id);
            MySqlCommand insertar = new MySqlCommand(strConsulta, conectar.conectar);

            insertar.Connection = conectar.conectar;
            no_ingreso = insertar.ExecuteNonQuery();
            conectar.CerarConexion();
            return no_ingreso;

        }
        public int eliminar (int id)
        {
            int no_ingreso = 0;
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string strConsulta = string.Format("delete  from productos  where id_producto ={0};",  id);
            MySqlCommand insertar = new MySqlCommand(strConsulta, conectar.conectar);

            insertar.Connection = conectar.conectar;
            no_ingreso = insertar.ExecuteNonQuery();
            conectar.CerarConexion();
            return no_ingreso;

        }
    }
}