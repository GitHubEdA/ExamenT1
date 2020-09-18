using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPersonaje : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;
    public GameObject bullet;
    private Transform _transform;
    private bool valor = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        _transform = GetComponent<Transform>();
        valor = false;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        animator.SetInteger("Cambio", 0); 

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(10, rb.velocity.y); 
            animator.SetInteger("Cambio", 1);
            sr.flipX = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-10, rb.velocity.y); 
            animator.SetInteger("Cambio", 1);
            sr.flipX = true;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            rb.AddForce(new Vector2(0, 30), ForceMode2D.Impulse); 

        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetInteger("Cambio", 2);
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            Instantiate(bullet, _transform.position, Quaternion.identity);
        }
        if (Input.GetKey(KeyCode.X))
        {
            animator.SetInteger("Cambio", 3);
        }
        if (valor == true)
        {
            animator.SetInteger("Cambio", 4);
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Zombie")
        {
            valor = true;
            Debug.Log("Chocaste con un Zombie");

        }
    }
}
