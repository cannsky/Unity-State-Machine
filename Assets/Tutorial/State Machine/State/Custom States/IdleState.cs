using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial.StateMachine.State
{
    public class IdleState : State
    {
        public IdleState(Enemy enemy) => base.enemy = enemy;

        public override State HandleState()
        {
            if (CheckPlayerRange()) return enemy.stateMachine.chaseState;
            else return this;
        }

        public bool CheckPlayerRange() => Physics.CheckSphere(enemy.transform.position, enemy.enemySettings.chaseRadius, enemy.enemySettings.playerLayer);
    }
}