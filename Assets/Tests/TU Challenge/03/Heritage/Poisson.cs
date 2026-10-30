using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU_Challenge.Heritage
{
    public class Poisson:Animal
    {
        private string _name;
        private int _pattes;
        private bool _isAlive=true;
        public bool IsAlive =>_isAlive;
        public  Poisson(string name)
        {
            
            _name = name + " le poisson";
            SetName(name + " le poisson");
            _pattes = 0;
        }

        public override string Crier()
        {
            if (fed)
            {
                return "bl";
            }
            return "blblblblblblblblblbblbllblb";
        }


        public override void Die()
        {
            base.Die();
            _isAlive = false;
        }

    }
}
