using UnityEngine;
using UnityEngine.InputSystem;

public class EntityMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    Vector3 _direction = new Vector3(0,0,0);

    [SerializeField] float speed = 200f;


    void FixedUpdate()
    {
        if (_direction != Vector3.zero)
        {
            //_rb.linearVelocity = new Vector3(_direction.x * speed * Time.deltaTime, _rb.linearVelocity.y, _direction.z * speed * Time.deltaTime );
            _rb.AddForce(_direction * speed);

        }
    }

    //ici on fait une methode public a la place de faire un event car sa permet de s'adapter si on na plus de player brain mais autre chose genre une ia 
    public void UpdateDirection(Vector3 direction)
    {
        _direction = direction.normalized;
    }
}
