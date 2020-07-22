using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy
{
    BaseStateMachine stateMachine;

    protected override void Start()
    {
        base.Start();
        stateMachine = new BasicEnemyStateMachine(this);
    }

    private void Update()
    {
        stateMachine.ExecuteState();
    }
}