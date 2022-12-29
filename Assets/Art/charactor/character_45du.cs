using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_45du : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;
    private Animator anim;
    private float horizontalMove;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        GroundMovement();

        SwitchAnim();
    }
    void GroundMovement()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");//Ö»·µ»Ø-1£¬0£¬1
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);

        if (horizontalMove != 0)
        {
            transform.localScale = new Vector3(horizontalMove * Mathf.Abs(transform.localScale.x), Mathf.Abs(transform.localScale.y), Mathf.Abs(transform.localScale.z));
        }

    }
    void SwitchAnim()//¶¯»­ÇÐ»»
    {
        anim.SetFloat("running", Mathf.Abs(rb.velocity.x));

    }
}
