using UnityEngine;

public class Minotaur : Enemy
{
    protected override void Start()
    {
        base.Start();
        Intialize(100);
        chaseRange = 8f;
        attackRange = 1.2f;

    }

    protected override void Attack()
    {
        base.Attack();
        Debug.Log("Minotaur Attack Player");
    }
}
