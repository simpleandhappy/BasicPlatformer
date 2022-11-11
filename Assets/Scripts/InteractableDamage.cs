using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDamage : MonoBehaviour
{
   [SerializeField] private int damage = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject == Player.Instance.gameObject) {
            Player.Instance.health -= damage;
            Debug.Log($"Player Health: {Player.Instance.health}");
        }
    }
}
