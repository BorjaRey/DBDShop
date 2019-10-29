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
            "Server=" + remotemysql.com + ";" +
            "database=" + eSQ5HjQqMG  + ";" +
            "UID=" + eSQ5HjQqMG  + ";" +
            "password=" + RRcl8SrkxR + ";";
            m_connection.Open();
        }

        public void InsertTestData()
        {
            string query = "CREATE TABLE IF NOT EXISTS Products (Id int,Name TEXT)";
            MySqlCommand cmd = new MySqlCommand(query, m_connection);
            cmd.ExecuteNonQuery();
            query = "INSERT INTO Products VALUES(1,'Nocilla');";
            cmd = new MySqlCommand(query, m_connection);
            cmd.ExecuteNonQuery();
            query = "INSERT INTO Products VALUES(2,'Patata');";
            cmd = new MySqlCommand(query, m_connection);
            cmd.ExecuteNonQuery();
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            string query = "SELECT IDPRODUCTO,DESCRIPCION FROM PRODUCTO";
            MySqlCommand cmd = new MySqlCommand(query, m_connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                
                int id= int.Parse(reader.GetValue(0).ToString());
                string nombre = reader.GetValue(1).ToString();
                Product product = new PRODUCTO();
                product.IDPRODUCTO = id;
                product.IDPRODUCTO = nombre;
                products.Add(product);
            }
            reader.Close();
            return products;
        }

        public void DeleteProducts(List<Product> products)
        {
            foreach(Product product in products)
            {
                string query = "DELETE FROM Products WHERE Id =" + product.Id + ";";
                MySqlCommand cmd = new MySqlCommand(query, m_connection);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
