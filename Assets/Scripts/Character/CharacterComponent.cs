using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterComponent : MonoBehaviour
{
    //character
    Rigidbody2D rigidBody;
    public float detectiveSpeed = 5f;
    private float horizontalInput;
    private float verticalInput;
    Vector2 movementInput;
    Vector2 movementVelocity;

    public string CharacterColor;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        //CharacterColor.rgb = 0;
        CharacterColor = "white";
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        movementInput = new Vector2(horizontalInput, verticalInput);
        movementVelocity = movementInput.normalized * detectiveSpeed;

    }
    private void FixedUpdate()
    {
        if(rigidBody)
        {
            rigidBody.MovePosition(rigidBody.position + movementVelocity * Time.deltaTime);
        }
        
    }
}
