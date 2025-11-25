using System;
using UnityEngine;

public class Slime : Character
{
    public static event Action OnPlayerDeath;
    public Inventory Inventory { get; private set; }
    private Animator myAnimator;
    private SpriteRenderer mySpriteRender;
    protected override void Start()
    {
        base.Start();
        Inventory = new Inventory();
    }


    protected override void Awake()
    {
        base.Awake();
        myAnimator = GetComponent<Animator>();
        mySpriteRender = GetComponent<SpriteRenderer>();
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


    private void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");  // A / D
        movement.y = Input.GetAxisRaw("Vertical");    // W / S

        myAnimator.SetFloat("moveX" ,movement.x);
        myAnimator.SetFloat("moveY" ,movement.y);
        movement.Normalize();


        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(10);
        }
        
        AdjustPlayerFacingDirection();

    }


    private void FixedUpdate()
    {
        Move();
    }

    protected override void Die()
    {
        Debug.Log("Player died");
        Destroy(gameObject);
        OnPlayerDeath?.Invoke();
        Time.timeScale = 0f;
    }

}
