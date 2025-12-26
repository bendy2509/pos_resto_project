using System;
using MySql.Data.MySqlClient;

namespace POS_RESTO.Configuration
{
    public static class DatabaseConfig
    {
        public static MySqlConnection GetConnection()
        {
            // Paramètres mis à jour
            string host = "localhost";
            string port = "3310"; // Votre port spécifique
            string database = "posresto";
            string user = "pos_resto_admin";
            string password = "groupabb";
            
            // On ajoute "Port={port};" dans la chaîne
            string connString = $"Server={host};Port={port};Database={database};Uid={user};Pwd={password};";
            
            return new MySqlConnection(connString);
        }
    }
}