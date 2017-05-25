using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunGames.modelos
{

    class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Nivel { get; set;  }

        public User()
        {

        }

        public User(int id, string login, string password, int nivel)
        {
            this.Id = id;
            this.Login = login;
            this.Password = password;
            this.Nivel = nivel;
        }
    }
}
