using System;
using UnityEngine;

public class Slime : Character
{
    private Animator myAnimator;
    private SpriteRenderer mySpriteRender;
    protected override void Awake()
    {
        base.Awake();
        myAnimator = GetComponent<Animator>();
        mySpriteRender = GetComponent<SpriteRenderer>();

    }

    private void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");  // A / D
        movement.y = Input.GetAxisRaw("Vertical");    // W / S

        myAnimator.SetFloat("moveX" ,movement.x);
        myAnimator.SetFloat("moveY" ,movement.y);
        movement.Normalize(); 
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void AdjustPlayerFacingDirection()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if (mousePos.x < playerScreenPoint.x)
        {
            mySpriteRender.flipX = true;
        }
        else
        {
            mySpriteRender.flipX = false;
        }
    }





}
