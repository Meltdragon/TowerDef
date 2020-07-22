using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveWayPointState : BaseState
{
    BasicEnemy basicEnemy;

    public RemoveWayPointState(BasicEnemy basicEnemy)
    {
        this.basicEnemy = basicEnemy;
    }

    public override void OnEnter()
    {
        basicEnemy.RemoveFromList();
    }

    public override void OnExecute()
    {

    }

    public override void OnExit()
    {

    }
}