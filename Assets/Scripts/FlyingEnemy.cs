using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private int damage = 100;
    private Vector3 _startPosition;
    private Vector2 _direction = Vector2.up;

    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_direction * speed * Time.deltaTime);
        var distance = Vector2.Distance(_startPosition, transform.position);
        if (distance >= 2){
            _direction *= -1;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject == Player.Instance.gameObject) {
            Player.Instance.health -= damage;
            Debug.Log($"Player Health: {Player.Instance.health}");
        }
    }
}
