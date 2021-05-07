using UnityEngine;
public class playerMovement : MonoBehaviour
{
    public float MovementSpeed;
    private Rigidbody2D rigibody;
    private Vector2 moveVelocity;
    public Rigidbody2D rb;
    private Animator anim;
    //public float hp;
    Vector3 mv;
    void Start()
    {
        rigibody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * MovementSpeed;

    }
    void FixedUpdate()
    {
        rigibody.MovePosition(rigibody.position + moveVelocity * Time.fixedDeltaTime);
        rb.velocity = new Vector2(mv.x, mv.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /* hp -= 5;
          if (hp<=0)
          {
              Destroy(GameObject.FindGameObjectWithTag("Player"));
          }*/
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Exit");
    }
}