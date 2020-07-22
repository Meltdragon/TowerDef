using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : BaseState
{
    BasicEnemy basicEnemy;

    public MoveState(BasicEnemy basicEnemy)
    {
        this.basicEnemy = basicEnemy;
    }

    public override void OnEnter()
    {

    }

    public override void OnExecute()
    {
        Vector3 direction = (basicEnemy.WayPoints[0].transform.position - basicEnemy.transform.position).normalized;
        basicEnemy.transform.position += direction * basicEnemy.MovementSpeed * Time.deltaTime;
    }

    public override void OnExit()
    {

    }
}