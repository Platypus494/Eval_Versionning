using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU_Challenge.Heritage
{
    public class Chat: Animal 
    {
        private string _name;
        private int _pattes=4;
        public string Name => _name;
        public int Pattes => _pattes;
        private bool fishEaten = false;

        public Chat(string name)
        {
            _name = name;
        }

        public override string Crier()
        {
            if (fishEaten)
            {
                return "Miaou (Le poisson etait bon)";
            }
            if (fed)
            {
                return "Miaou (c'est bon laisse moi tranquille humain)";
            }
            return "Miaou (j'ai faim)";
        }


        protected void SetPattes(int pattes)
        {
            _pattes = pattes;
        }


        public override void Welcome(Animalerie animalerie)
        {
            base.Welcome(animalerie);
            foreach (var el in animalerie.List)
            {
                if(el is Poisson)
                {
                    el.Die();
                    fishEaten = true;
                }
            }
            animalerie.OnAddAnimal += TryEatAnimal;
        }

        private void TryEatAnimal(Animal animal)
        {
            if (animal is Poisson)
            {
                animal.Die();
                fishEaten = true;
            }
        }

    }
}
