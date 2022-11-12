using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    private Animator playerAnimator;
    private SpriteRenderer playerSpriteRenderer;
    public Vector2 startPostion;

    //Player Stats
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float jumpHeight = 50f;
    [SerializeField] private int maxJumps = 20;
    //[SerializeField] private int maxHealth = 1000;
    public int health = 1000;
    
    //helper vars
    public int jumpCounter;

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
        startPostion = transform.position;
        jumpCounter = 0;

    }

    // Update is called once per frame
    void Update()
    {
        float targetVelocity = Input.GetAxisRaw("Horizontal") * maxSpeed;
        if (Mathf.Abs(targetVelocity) >= 1){
            playerRigidBody.velocity = new Vector2(targetVelocity, playerRigidBody.velocity.y);
        }

        //play walk animation
        bool isWalking = playerRigidBody.velocity.x != 0;
        playerAnimator.SetBool("Walk", isWalking);

        //flip player direction
        if (isWalking){
            bool isGoingLeft = playerRigidBody.velocity.x < 0;
            playerSpriteRenderer.flipX = isGoingLeft;
        }
        
        if (Input.GetButtonDown("Jump") && jumpCounter < maxJumps){
            playerRigidBody.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            jumpCounter++;
        }

        if (health <= 0){
            RestartLevel();
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.layer == LayerMask.NameToLayer("ResetJump")){
            jumpCounter = 0;
        }
    }

    public void RestartLevel(){
        health = 1000;
        transform.position = startPostion;
    }
    
}
