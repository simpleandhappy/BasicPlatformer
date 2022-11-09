using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;

    //Player Stats
    [SerializeField] private float maxSpeed = 3f;
   
    //Singleton
    private static Player instance;
    public static Player Instance
    {
        get
        {
            if (instance == null) instance = GameObject.FindObjectOfType<Player>();
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerRigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * maxSpeed, 0);
    }
}
