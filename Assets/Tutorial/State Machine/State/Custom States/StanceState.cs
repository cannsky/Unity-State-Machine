using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial.StateMachine.State
{
    public class StanceState : State
    {
        public float attackRecoveryTimer;

        public StanceState(Enemy enemy) => base.enemy = enemy;

        public override State HandleState()
        {
            if (!CheckPlayerAttackRange()) return enemy.stateMachine.chaseState;
            else if (attackRecoveryTimer <= 0) return enemy.stateMachine.attackState;
            else return this;
        }

        public bool CheckPlayerAttackRange() => Physics.CheckSphere(enemy.transform.position, enemy.enemySettings.attackRadius, enemy.enemySettings.playerLayer);
    }
}