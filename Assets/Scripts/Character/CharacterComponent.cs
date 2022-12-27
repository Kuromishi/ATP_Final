using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterComponent : MonoBehaviour
{
    [Header("Character Movement")]
    Rigidbody2D rigidBody;
    public float detectiveSpeed = 5f;
    private float horizontalInput;
    private float verticalInput;
    Vector2 movementInput;
    Vector2 movementVelocity;
    private float Angle;

    private Vector3 mousePosition;

    [Header("Color")]
    public string CharacterColor;

    public bool isTalking;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        //CharacterColor.rgb = 0;
        CharacterColor = "transp";
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        movementInput = new Vector2(horizontalInput, verticalInput);
        movementVelocity = movementInput.normalized * detectiveSpeed;
        if(Input .GetMouseButtonDown(2))
        {
            CharacterColor = "transp";
        }

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Angle = Mathf.Atan2(mousePosition.y - transform.position.y, mousePosition.x - transform.position.x) * Mathf.Rad2Deg-83.5f;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Angle));
        
    }
    private void FixedUpdate()
    {
        if(rigidBody && !isTalking)
        {
            rigidBody.MovePosition(rigidBody.position + movementVelocity * Time.deltaTime);
        }
        
    }
}
