using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    private Animator playerAnimator;
    private SpriteRenderer playerSpriteRenderer;

    //Player Stats
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float jumpHeight = 50f;
   
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
        playerSpriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        playerRigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * maxSpeed, playerRigidBody.velocity.y);
        
        //play walk animation
        bool isWalking = playerRigidBody.velocity.x != 0;
        playerAnimator.SetBool("Walk", isWalking);

        //flip player direction
        if (isWalking){
            bool isGoingLeft = playerRigidBody.velocity.x < 0;
            playerSpriteRenderer.flipX = isGoingLeft;
        }
        
        if (Input.GetButtonDown("Jump")){
            //playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, playerRigidBody.velocity.y * jumpHeight);
            playerRigidBody.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
    }
    
}
