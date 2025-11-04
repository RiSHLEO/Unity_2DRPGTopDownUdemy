using UnityEngine;

public class ActionWander : FSMAction
{
    [Header("Config")]
    [SerializeField] private float _speed;
    [SerializeField] private float _wanderTime;
    [SerializeField] private Vector2 _moveRange;

    private Vector3 _movePosition;
    private float _timer;

    private void Start()
    {
        GetNewDestination();
    }

    public override void Act()
    {
        _timer -= Time.deltaTime;
        Vector3 moveDirection = (_movePosition - transform.position).normalized;
        Vector3 movement = moveDirection * (_speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, _movePosition) >= 0.5f)
            transform.Translate(movement);

        if(_timer <= 0f)
        {
            GetNewDestination();
            _timer = _wanderTime;
        }
    }

    private void GetNewDestination()
    {
        float randomX = Random.Range(-_moveRange.x, _moveRange.x);
        float randomY = Random.Range(-_moveRange.y, _moveRange.y);
        _movePosition = transform.position + new Vector3(randomX, randomY);
    }

    private void OnDrawGizmosSelected()
    {
        if(_moveRange != Vector2.zero)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireCube(transform.position, _moveRange * 2f);
            Gizmos.DrawLine(transform.position, _movePosition);
        }
    }
}
