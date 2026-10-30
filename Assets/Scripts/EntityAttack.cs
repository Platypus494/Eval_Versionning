using UnityEngine;

public class EntityAttack : MonoBehaviour
{

    [SerializeField] private SphereCollider _collider;
    private bool Attacking = false;


    public void Attack(bool attack)
    {
        Attacking=attack;
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Weak" && Attacking)
        {
            other.gameObject.GetComponent<Health>().Damage(20);
            Attacking = false;
        }
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
