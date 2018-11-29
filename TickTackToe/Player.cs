using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TickTackToe
{
    public class Player
    {
        public Player(string name, string move)
        {
            this.Name = name;
            this.Move = move;
        }

        public string Move { get; private set; }
        public string Name { get; private set; }
    }
}
