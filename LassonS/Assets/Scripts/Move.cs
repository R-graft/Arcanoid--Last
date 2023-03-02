using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 5;

    public float jumpForce;

    public Rigidbody2D rb;

    public SpriteRenderer sr;

    public GroundDetection gr;

    public Animator animator;

    public AudioSource jumpAudio;

    void Update()
    {
        animator.SetBool("isRun", false);

        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isRun", true);

            rb.AddForce(Vector2.left * speed );

            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isRun", true);

            rb.AddForce(Vector2.right * speed );

            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("isAttack");
        }

        if (Input.GetKeyDown(KeyCode.Space) && gr.isGrounded == true)
        {
            rb.AddForce(Vector2.up * jumpForce);
        }

        animator.SetBool("isGrounded", gr.isGrounded);

        animator.SetFloat("SpeedY", rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
