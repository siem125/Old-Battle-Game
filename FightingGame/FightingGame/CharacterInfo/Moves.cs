using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightingGame
{
    public class Moves
    {
        public List<MoveList> moves { get; set; }
        //public Moves(List<MoveList> moves)
        //{
        //    this.moves = moves;
        //}

        public string getTCPFormat()
        {
            string tcp = "<charmoves>";

            //loop
            foreach (MoveList move in moves)
            {
                tcp += move.getTCPFormat();
            }

            tcp += "</charmoves>";
            return tcp;
        }
    }
}
