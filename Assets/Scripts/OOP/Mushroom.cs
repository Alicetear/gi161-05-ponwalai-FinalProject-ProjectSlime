using UnityEngine;

public class Mushroom : Enemy
{
    protected override void Start()
    {
        base.Start();
        Intialize(50);
        chaseRange = 6f;
        attackRange = 1.2f;

    }

    protected override void Attack()
    {
        base.Attack();
        Debug.Log("Mushroom Attack Player");
    }

}
