using NaughtyAttributes;
using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Foldout("Health")]
    [MinValue(1)]
    [SerializeField] int _MaxHealth=100;

    [Foldout("Health")]
    [ReadOnly]
    [ProgressBar("Current Health", 100, EColor.Red)]
    [SerializeField] int _CurrentLife = 100;

    [Foldout("Event")]
    [SerializeField] UnityEvent onDamage;
    [Foldout("Event")]
    [SerializeField] UnityEvent _OnHeal;
    [Foldout("Event")]
    [SerializeField] UnityEvent _OnDeath;
    [Foldout("Event")]
    [SerializeField] UnityEvent _OnResist;

    private event Action die ;
    [SerializeField] Slider slider;


    public int MaxHealth
    {
        get { return _MaxHealth; }

    }

    public int CurrentLife
    {
        get { return _CurrentLife; }

    }

    private void Reset()
    {
        _MaxHealth = 100;
        _CurrentLife = 100;
    }

    private void OnValidate()
    {
        /*if (_MaxHealth < 1)
        {
            Debug.LogWarning("Max health cannot be negative");
            _MaxHealth = 100;
        }

        if (_CurrentLife < 0)
        {
            Debug.LogWarning("Current health cannot be negative");
            _CurrentLife = 100;
        }*/
        if (_MaxHealth < _CurrentLife)
        {
            Debug.LogWarning("Current health cannot be higher than MaxHealth");
            _CurrentLife = _MaxHealth;
        }

    }

    [Button]
    public void Damage(int damage=10)
    {
        _CurrentLife-= damage;
        if (slider != null)
        {
            slider.value = _CurrentLife;
        }
        if (_CurrentLife <= 0)
        {
            _CurrentLife = 0;
            _OnDeath?.Invoke();
            die?.Invoke();
            if (slider != null)
            {
                slider.value = 0;
            }
            return;
        }
        if (damage == 0)
        {
            _OnResist?.Invoke();
        }
        else
        {
            onDamage?.Invoke();
        }
    }


    public void Heal(int heal)
    {
        _CurrentLife += heal;
        _OnHeal?.Invoke();
        if (_CurrentLife > MaxHealth)
        {
            _CurrentLife= MaxHealth;
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        die += Die;
        _CurrentLife = _MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
