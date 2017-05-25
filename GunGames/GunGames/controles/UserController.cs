using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

using GunGames.utils;
using GunGames.modelos;

namespace GunGames.controles
{
    class UserController
    {
        public static User loggedUser = null;

        public static User isValidUser(string login, string pwd)
        {
            NpgsqlConnection conexao = null;
            try {

                conexao = ConectaDB.getConexao();

                string sql = "SELECT * FROM Users WHERE login=@login and password=@password";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);

                cmd.Parameters.Add(new NpgsqlParameter("@login", login));
                cmd.Parameters.Add(new NpgsqlParameter("@password", pwd));

                NpgsqlDataReader dr =  cmd.ExecuteReader();

                if (dr.Read())
                {
                    User user = new User();

                    user.Id = Convert.ToInt16(dr["id"]);
                    user.Login = dr["login"].ToString();
                    user.Nivel = Convert.ToInt16(dr["nivel"]);

                    UserController.loggedUser = user;

                    return user;
                }

            } catch(Exception e)
            {
                throw new Exception(e.Message);
            } finally
            {
                if(conexao != null)
                {
                    conexao.Close();
                } 
            }

            return null;
        }
    }
}
