using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU_Challenge.Heritage
{
    public class ChatQuiBoite : Chat
    {
        private string _name;
        private int _pattes=3;
        public int _Pattes => _pattes;

        public ChatQuiBoite(string name) : base(name)
        {
            SetPattes(3);
        }

        public override void Welcome(Animalerie animalerie)
        {

        }
    }
}
