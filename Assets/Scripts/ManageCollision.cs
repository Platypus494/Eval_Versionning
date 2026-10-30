using System;
using UnityEngine;
using UnityEngine.Events;

public class ManageCollision : MonoBehaviour
{
    int _health;
    [SerializeField] UnityEvent _onDie;
    public int Health => _health;
    public event Action OnTouchGround;

    void Awake()
    {
        _health = 5;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        _health--;
        OnTouchGround?.Invoke();
        if (_health<=0)
        {
            Die();
        }

    }

    void Die()
    {
        _onDie?.Invoke();
        Destroy(gameObject,3f);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
