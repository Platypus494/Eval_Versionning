using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TU_Challenge.Heritage
{
    public class Chien :Animal
    {
        private string _name;
        private int _pattes;
        public Chien(string name)
        {
            _name = name;
            _pattes = 4;
        }

        public override string Crier()
        {
            if (fed)
            {
                return "Ouaf (viens on joue ?)";
            }
            return "Ouaf (j'ai faim)";
        }
    }
}
