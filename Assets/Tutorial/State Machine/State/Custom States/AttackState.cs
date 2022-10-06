using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial.StateMachine.State
{
    public class AttackState : State
    {
        public AttackState(Enemy enemy) => base.enemy = enemy;

        public override State HandleState() => DoStuff();

        public State DoStuff()
        {
            Player.Instance.HandleDamage(2f);
            enemy.stateMachine.stanceState.attackRecoveryTimer = enemy.enemySettings.attackRecoveryTime;
            return enemy.stateMachine.stanceState;
        }
    }

}