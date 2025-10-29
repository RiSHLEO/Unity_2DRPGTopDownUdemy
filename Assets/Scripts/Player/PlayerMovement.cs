using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float _speed;

    private Player _player;
    private PlayerAnimations _playerAnimations;
    private PlayerActions _actions;
    private Rigidbody2D _rb2D;
    private Vector2 _moveDirection;

    private void Awake()
    {
        _actions = new PlayerActions();
        _rb2D = GetComponent<Rigidbody2D>();
        _playerAnimations = GetComponent<PlayerAnimations>();
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _actions.Enable();
    }

    private void OnDisable()
    {
        _actions.Disable();
    }

    private void Update()
    {
        ReadMovement();
    }

    private void FixedUpdate()
    {
        Move();
    }
    private void ReadMovement()
    {
        _moveDirection = _actions.Movement.Move.ReadValue<Vector2>().normalized;

        if( _moveDirection == Vector2.zero)
        {
            _playerAnimations.SetMoveBoolTransition(false);
            return;
        }

        _playerAnimations.SetMoveBoolTransition(true);
        _playerAnimations.SetMoveAnimation(_moveDirection);
    }

    private void Move()
    {
        if(_player.Stats.Health <= 0f)
            return;

        _rb2D.MovePosition(_rb2D.position + _moveDirection * (_speed * Time.fixedDeltaTime));  //rigidbody is physics so need to use fixed update
    }

}
