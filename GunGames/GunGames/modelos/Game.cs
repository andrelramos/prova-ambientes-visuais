using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunGames.modelos
{
    class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Console { get; set; }
        public string Type { get; set; }
        public double Value { get; set; }
        public double Cost { get; set; }

        public Game()
        {

        }

        public Game(int id, string name, string console, string type, double value, double cost)
        {
            this.Id = id;
            this.Name = name;
            this.Console = console;
            this.Type = type;
            this.Value = value;
            this.Cost = cost;
        }

        public string[] ToDGV()
        {
            string[] fields = {
                this.Id.ToString(),
                this.Name,
                this.Console,
                this.Type,
                this.Value.ToString(),
                this.Cost.ToString()
            };

            return fields;
        }
    }
}
