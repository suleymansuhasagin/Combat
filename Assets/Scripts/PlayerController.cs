using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator myAnim;
    private SpriteRenderer mySpriteRenderer;
    private void Awake() 
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        mySpriteRenderer = GetComponent <SpriteRenderer>();
    }

    private void OnEnable() 
    {
        playerControls.Enable();    
    }

    private void Update() 
    {
        PlayerInput();
    }

    private void FixedUpdate() 
    {
        AdjustPlayerFacingDirection();
        Move();
    }
    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
        myAnim.SetFloat("moveX" , movement.x);
        myAnim.SetFloat("moveY" , movement.x);
    }
    private void Move()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    private void AdjustPlayerFacingDirection()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 PlayerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if(mousePos.x < PlayerScreenPoint.x)
        {
            mySpriteRenderer.flipX = true;
        }
        else
        {
            mySpriteRenderer.flipX = false;
        }
    }
}
