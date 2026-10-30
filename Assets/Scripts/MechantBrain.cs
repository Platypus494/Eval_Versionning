using UnityEngine;

public class MechantBrain : MonoBehaviour
{
    [SerializeField] EntityMovement _move;
    [SerializeField] GameObject _player;
    [SerializeField] float _stopDistance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 maPosition = transform.position;
        Vector3 playerPosition = _player.transform.position;

        Vector3 directionToPlayer = playerPosition - maPosition;

        if(directionToPlayer.magnitude > _stopDistance)
        {
            _move.UpdateDirection(playerPosition - maPosition);
        }else
        {
            _move.UpdateDirection(Vector3.zero);
        }

        
    }
}
