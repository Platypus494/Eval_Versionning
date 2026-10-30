using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

namespace TU_Challenge.Heritage
{
    public abstract class Animal
    {
        private string _name;
        Animalerie _animalerie;
        public string Name => _name;
        private int _pattes;
        public int Pattes => _pattes;
        protected bool fed = false;
        public event Action OnDie;

        public abstract string Crier();

        public void Feed()
        {
            fed = true;
        }

        protected void SetName(string name)
        {
            _name = name;
        }

        public virtual void Welcome(Animalerie animalerie)
        {
            _animalerie = animalerie;
        }

        public virtual void Die()
        {
            OnDie?.Invoke();
        }
    }
}
