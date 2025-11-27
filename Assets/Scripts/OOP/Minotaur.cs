using UnityEngine;

public class Minotaur : Enemy
{
    protected override void Start()
    {
        base.Start();
        Intialize(100);
        chaseRange = 15f;
        attackRange = 3f;

    }

    protected override void Attack()
    {
        base.Attack();
        Debug.Log("Minotaur Attack Player");
    }
}
