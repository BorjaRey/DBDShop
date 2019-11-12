using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DBDShopLib
{
    public class Client
    {
        MySqlConnection m_connection = null;

        public Client(string databasename, string username, string password, string server= "remotemysql.com")
        {
            m_connection = new MySqlConnection();
            m_connection.ConnectionString =
            "Server=" + server + ";" +
            "database=" + databasename + ";" +
            "UID=" + username + ";" +
            "password=" + password + ";";
            m_connection.Open();
        }

        public void InsertTestData()
        {
            string query = "CREATE TABLE IF NOT EXISTS PRODUCTO (stock int, idProducto int, descripcion TEXT, idPedido int, nArt int)";
            MySqlCommand cmd = new MySqlCommand(query, m_connection);
            cmd.ExecuteNonQuery();
            query = "INSERT INTO PRODUCTO VALUES(1, 1,'Nocilla', 24, 1);";
            cmd = new MySqlCommand(query, m_connection);
            cmd.ExecuteNonQuery();
            query = "INSERT INTO PRODUCTO VALUES(2,2,'Patata',22,1);";
            cmd = new MySqlCommand(query, m_connection);
            cmd.ExecuteNonQuery();
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            string query = "SELECT * FROM PRODUCTO";
            MySqlCommand cmd = new MySqlCommand(query, m_connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                
                int stock = int.Parse(reader.GetValue(0).ToString());
                int idProducto = int.Parse(reader.GetValue(1).ToString());
                string descripcion = reader.GetValue(2).ToString();
                int idPedido = int.Parse(reader.GetValue(3).ToString());
                int nArt = int.Parse(reader.GetValue(4).ToString());
                Product product = new Product();
                product.stock = stock;
                product.idProducto = idProducto;
                product.descripcion = descripcion;
                product.idPedido = idPedido;
                product.nArt = nArt;
                products.Add(product);
            }
            reader.Close();
            return products;
        }

        public void DeleteProducts(List<Product> products)
        {
            foreach(Product product in products)
            {
                string query = "DELETE FROM PRODUCTO WHERE IDPRODUCTO =" + product.idProducto + ";";
                MySqlCommand cmd = new MySqlCommand(query, m_connection);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
