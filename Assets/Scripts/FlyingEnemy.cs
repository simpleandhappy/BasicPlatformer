using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _maxDistance = 2f;
    [SerializeField] Vector2 _direction = Vector2.up;
    private Vector2 _startPosition;

    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_direction.normalized * _speed * Time.deltaTime);
        var distance = Vector2.Distance(_startPosition, transform.position);

        if (distance >= _maxDistance){//bug where if too far will continously change direction
            transform.position = _startPosition + (_direction.normalized * _maxDistance);
            _direction *= -1;
        }
    }
}
