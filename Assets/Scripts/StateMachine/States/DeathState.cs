using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : BaseState
{
    BasicEnemy basicEnemy;

    public DeathState(BasicEnemy basicEnemy)
    {
        this.basicEnemy = basicEnemy;
    }

    public override void OnEnter()
    {
        basicEnemy.Death();
    }

    public override void OnExecute()
    {

    }

    public override void OnExit()
    {

    }
}