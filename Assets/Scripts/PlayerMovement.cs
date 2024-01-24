using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator ani;
    private SpriteRenderer sprite;
    [SerializeField]private LayerMask jumpableGround;
    private float dirX = 0f;
    [SerializeField]private float moveSpeed = 7f;
    [SerializeField]private float jumpForce = 14f;

    private enum MovementState { idle, Running, jump, fall}

    [SerializeField] private AudioSource jumpSoundEffect;
    PhotonView view;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (view.IsMine)
        {
            dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); 
        }

        UpdateAnimationState();
        } 
    }    
    private void UpdateAnimationState()
    {

        MovementState state;

        if (dirX < 0f)
        {
            state = MovementState.Running;
            sprite.flipX = true;
        }
        else if (dirX > 0f)
        {
            state = MovementState.Running;
            sprite.flipX = false;
        } 
        else
        {
            state = MovementState.idle;
        } 

        if( rb.velocity.y > .1f)
        {
            state = MovementState.jump;
        }
        else if( rb.velocity.y < -.1f)
        {
            state = MovementState.fall;
        }

        ani.SetInteger("state", (int)state);

    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
        
    
}
