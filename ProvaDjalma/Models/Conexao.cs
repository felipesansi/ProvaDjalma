using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProvaDjalma.Models
{
    public class Conexao: IDisposable
    {
        public MySqlConnection conn;
        private readonly string _server = "127.0.0.1";
        private readonly string _port = "3306";
        private readonly string _database = "bd_provaDjalma";
        private readonly string _uid = "root";
        private readonly string _pwd = "felipe";

        public Conexao() 
        {
            conectar();
        }

        private void conectar()
        {
            string conexao = "Server=" + _server;
              conexao += "Port=" + _port;
             conexao += "Database=" + _database;
            conexao += "Uid=" + _uid;
            conexao += "Pwd=" + _pwd;

            conn = new MySqlConnection(conexao);

            try
            {
                conn.Open();

            }
            catch (Exception ex)
            {

                throw ex;
            }

            
        }
        public void Dispose()
        {
            conn.Close();
            conn.Dispose();
        }
    }
}