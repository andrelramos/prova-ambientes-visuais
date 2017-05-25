using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

using GunGames.modelos;
using GunGames.utils;

namespace GunGames.controles
{
    class GameController
    {
        public static bool salveGame(Game game)
        {
            NpgsqlConnection conexao = null;
            try
            {

                conexao = ConectaDB.getConexao();

                string sql = "INSERT INTO Games (name, console, type, value, cost) VALUES (@name, @console, @type, @value, @cost)";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);

                cmd.Parameters.Add(new NpgsqlParameter("@name", game.Name));
                cmd.Parameters.Add(new NpgsqlParameter("@console", game.Console));
                cmd.Parameters.Add(new NpgsqlParameter("@type", game.Type));
                cmd.Parameters.Add(new NpgsqlParameter("@value", game.Value));
                cmd.Parameters.Add(new NpgsqlParameter("@cost", game.Cost));

                cmd.ExecuteNonQuery();

                return true;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (conexao != null)
                {
                    conexao.Close();
                }
            }

            return false;
        }

        public static List<Game> all()
        {
            List<Game> games = new List<Game>();
            NpgsqlConnection conexao = null;
            try
            {

                conexao = ConectaDB.getConexao();

                string sql = "SELECT * FROM GaMeS";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Game game = new Game(
                        Convert.ToInt16(dr["id"]),
                        dr["name"].ToString(),
                        dr["console"].ToString(),
                        dr["type"].ToString(),
                        Convert.ToDouble(dr["value"]),
                        Convert.ToDouble(dr["cost"])
                    );

                    games.Add(game);

                }   
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (conexao != null)
                {
                    conexao.Close();
                }
            }
            return games;
        }
    }
}
