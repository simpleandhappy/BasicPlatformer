using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    private Animator playerAnimator;
    private Vector2 playerDirection;
    private Vector2 forward = new Vector2(1, 1);
    private Vector2 backward = new Vector2(-1, 1);

    //Player Stats
    [SerializeField] private float maxSpeed = 10f;
   
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
        playerAnimator = GetComponent<Animator>();
        playerDirection = forward;

    }

    // Update is called once per frame
    void Update()
    {
        playerRigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * maxSpeed, playerRigidBody.velocity.y);
        
        bool isWalking = playerRigidBody.velocity.x != 0;
        playerAnimator.SetBool("Walk", isWalking);

        if (playerRigidBody.velocity.x < -0.01) {
            playerDirection = backward;
        } 
        else if (playerRigidBody.velocity.x > 0.01){
            playerDirection = forward;
        }
        transform.localScale = playerDirection;
        
    }
}
