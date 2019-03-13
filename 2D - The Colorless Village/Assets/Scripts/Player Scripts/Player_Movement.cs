using UnityEngine;
    
public class Player_Movement : MonoBehaviour {
    //Player MoveSpeed
    [SerializeField]
    [Range(7f, 12f)]
    public static float moveSpeed = 7.0f;

    //Player rotation
    public bool facingRight = true;

    //Ground Check
    private bool isGrounded;
    public float checkRadius;
    public Transform groundcheck;
    public LayerMask whatIsGround; 

    //Player JumpForce
    public int jumpForce;

    //Animation
    public Animator animator;

    //Jump if player on ground is true
    void Update(){
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true){
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
            }
    }

    //Player movement + animations
    void FixedUpdate () {

        //Ground Check
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, checkRadius, whatIsGround);

        //Move player
        float move = Input.GetAxis("Horizontal");
        if (move < 0){
            GetComponent<Rigidbody2D>().velocity = new Vector3(move * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }else if (move > 0){
            GetComponent<Rigidbody2D>().velocity = new Vector3(move * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }else GetComponent<Rigidbody2D>().velocity = new Vector3(move * 0, GetComponent<Rigidbody2D>().velocity.y);

        //Jumping Animations
        if (Input.GetKey(KeyCode.Space) && isGrounded == false){
            animator.SetBool("IsJumping", true);
        }else if (isGrounded == false){
            animator.SetBool("IsFalling", true);
        }else if (isGrounded == true){
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", false);
        }
        //Running Animation
        animator.SetFloat("Player_Speed", Mathf.Abs(move));

        //Flip player if speed is higher or lower than 0
        if (move < 0 && facingRight) {
            Flip();
        }

        if (move > 0 && !facingRight){
            Flip();
        }
    }

    //Rotate player
    void Flip(){
        facingRight = !facingRight;
        transform.Rotate(Vector3.up * 180);
    }

}
