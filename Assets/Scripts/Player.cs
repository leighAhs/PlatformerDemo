using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator anim;
    [SerializeField] int force;
    [SerializeField] float speed;

    [SerializeField] bool onGround;
    [SerializeField] bool OnAir;

    [SerializeField] Vector2 startingPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onGround || OnAir)
            {
                OnAir = false;
                onGround = false;   
                rb2d.AddForce(Vector2.up * force);
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            //anim.SetBool("isBool", true);
            //anim.Play("MoveLeftAnimation", 0);
            //anim.SetTrigger("trigger");
            anim.Play("MoveLeftAnimation");
        } else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            anim.Play("MoveRightAnimation");
            //anim.Play("MoveRightAnimation", 0);
        }
        else
        {
            anim.Play("Idle");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
            OnAir = false;
        }
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            onGround = true;
            OnAir = false;
            transform.SetParent(collision.gameObject.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            OnAir = true;
        }
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            OnAir = true;
            transform.SetParent(null);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            transform.position = startingPosition;
        }
    }
}
