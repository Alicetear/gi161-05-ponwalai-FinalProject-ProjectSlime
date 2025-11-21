using System;
using UnityEngine;

public class Slime : Character
{
    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        // ?????? Input
        movement.x = Input.GetAxisRaw("Horizontal");  // A / D
        movement.y = Input.GetAxisRaw("Vertical");    // W / S
        movement.Normalize(); 
    }

    private void FixedUpdate()
    {
        Move();
    }
}
