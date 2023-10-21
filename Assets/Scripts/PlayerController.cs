using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject Player;
    [SerializeField] float Speed=83f;
    [SerializeField] float JumpSpeed =290f;
    [SerializeField] float ClimbSpeed = 8f;
    [SerializeField] Vector2 die = new Vector2(20f, 20f);
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform Gun;

    Vector2 moveInput;
    Rigidbody2D MyRigidBody;
    Animator animator;
    BoxCollider2D myFeetCollider;
    float GravityAtStart;
    bool isAlive = true;
    void Start()
    {

        MyRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        GravityAtStart = MyRigidBody.gravityScale;
    }


    void Update()
    {
        if (!isAlive) { return; }
        Run();
        FlipSprite();
        ClimbLadder();
        Die();
    }

    void OnFire(InputValue value)
    {
        if (!isAlive) { return; }
        Instantiate(Bullet, Gun.position,transform.rotation);
    }
    void OnMove(InputValue value)
    {
        if (!isAlive) { return; }
        moveInput = value.Get<Vector2>();
    }
    void Run()
    {
        if (!isAlive) { return; }
        Vector2 PlayerVelocity = new Vector2(moveInput.x * Speed * Time.deltaTime, MyRigidBody.velocity.y);
        MyRigidBody.velocity = PlayerVelocity;

        bool PlayerHasHorizontal = Mathf.Abs(MyRigidBody.velocity.x) > Mathf.Epsilon;
        animator.SetBool("isRunning", PlayerHasHorizontal);

    }
    void OnJump(InputValue value)
    {
        if (!isAlive) { return; }
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }
        if (value.isPressed)
        {
            MyRigidBody.velocity += new Vector2(0f, JumpSpeed * Time.deltaTime);
        }
    }
    void FlipSprite()
    {
        bool PlayerHasHorizontal = Mathf.Abs(MyRigidBody.velocity.x) > Mathf.Epsilon;
        if (PlayerHasHorizontal)
        {
            {
                transform.localScale = new Vector2(Mathf.Sign(MyRigidBody.velocity.x), 1f);

            }

        }
    }
    void ClimbLadder()
    {
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            MyRigidBody.gravityScale = GravityAtStart;
            animator.SetBool("isClimbing", false);
            return;
        }

        Vector2 ClimbVelocity = new Vector2(MyRigidBody.velocity.x, moveInput.y * ClimbSpeed);
        MyRigidBody.velocity = ClimbVelocity;

        bool PlayerHasVertical = Mathf.Abs(MyRigidBody.velocity.y) > Mathf.Epsilon;
        animator.SetBool("isClimbing", PlayerHasVertical);
        MyRigidBody.gravityScale = 0f;

    }
    void Die()
    {
        if (MyRigidBody.IsTouchingLayers(LayerMask.GetMask("Enemies", "Hazards")))
        {
            isAlive = false;
            animator.SetTrigger("Dying");
            MyRigidBody.velocity = die;
            //GameObject.Destroy(tag.Player, 2f);
        }
    }

}
