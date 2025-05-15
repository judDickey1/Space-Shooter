using UnityEngine;
//bring in the input system namespace
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int _movementSpeed;
    
    InputAction moveAction;

    private float _leftbound = -9.5f;
    private float _rightbound = 9.5f;
    private float _topbound = 1.2f;
    private float _bottombound = -4;

    InputAction firingAction;
 
    [SerializeField]
    private float _attackDelay;
    private float _attackTimer;

    [SerializeField]
    private GameObject _laser;
    
    [SerializeField]
    private int _health;

    private SpawnManager _spawnManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {        
        transform.position = new Vector3(0, 0, 0);
        _movementSpeed = 5;
        
        moveAction = InputSystem.actions.FindAction("Move");
        
        firingAction = InputSystem.actions.FindAction("Attack");


        _attackDelay = .33f;
        _attackTimer = -1f;

        _health = 3;

        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Firing();
        
    }

    void Movement()
    {
        Vector3 playerposition = transform.position;        
        Vector2 moveValue = moveAction.ReadValue<Vector2>();        
        transform.Translate(moveValue * Time.deltaTime * _movementSpeed);
        
        if (playerposition.x > _rightbound)
        {
            transform.position = new Vector3(_rightbound, playerposition.y, 0);
        }
        ;
        if (playerposition.x < _leftbound)
        {
            transform.position = new Vector3(_leftbound, playerposition.y, 0);
        }
        ;
        if (playerposition.y > _topbound)
        {
            transform.position = new Vector3(playerposition.x, _topbound, 0);
        }
        ;
        if (playerposition.y < _bottombound)
        {
            transform.position = new Vector3(playerposition.x, _bottombound, 0);
        }
        ;
    }

    public void Firing()
    {
              
        if (firingAction.IsPressed() && Time.time > _attackTimer)
        {           
                _attackTimer = Time.time + _attackDelay;                
                Instantiate(_laser, transform.position, Quaternion.identity);
        }

    }

    public void Damage()
    {
        _health -= 1;

        if (_health < 1)
        {
            Debug.Log("Player Died");
            Destroy(this.gameObject);
            _spawnManager.OnPlayerDeath();
            
        }
    }
}