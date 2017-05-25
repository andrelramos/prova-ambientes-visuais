using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace GunGames.utils
{
    class ConectaDB
    {
        private static string serverName = "localhost";
        private static string port = "5432";
        private static string userName = "postgres";
        private static string password = "postgres";
        private static string dataBaseName = "gungames";


        public static NpgsqlConnection getConexao()
        {
            try
            {
                string stgConexao = String.Format("Server={0}; Port={1}; User Id={2}; Password={3}; Database={4}",
                                                      serverName, port, userName, password, dataBaseName);


                NpgsqlConnection conexao = new NpgsqlConnection(stgConexao);

                conexao.Open();

                return conexao;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }

        }




    }
}
