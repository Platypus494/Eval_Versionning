using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU_Challenge.Heritage
{
    public class Animalerie
    {
        private List<Animal> list = new List<Animal>();
        public List<Animal> List => list;
        public event Action<Animal> OnAddAnimal;

        public bool Contains(Animal a)
        {
            return list.Contains(a);
        }

        public void AddAnimal(Animal a)
        {
            a.Welcome(this);
            OnAddAnimal?.Invoke(a);
            list.Add(a);

        }

        public Animal GetAnimal(int index)
        {
            return list[index];
        }

        public void FeedAll()
        {
            foreach (Animal a in list) {
                a.Feed();
            }
            
        }
    }
}
