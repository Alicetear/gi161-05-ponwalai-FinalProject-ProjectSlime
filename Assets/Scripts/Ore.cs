using UnityEngine;

public class Ore : Enemy
{
    protected override void Start()
    {
        base.Start();
        Intialize(80);
        chaseRange = 10f;
        attackRange = 2f;

    }

    protected override void Attack()
    {
        base.Attack();
        Debug.Log("Ore Attack Player");
    }
}
