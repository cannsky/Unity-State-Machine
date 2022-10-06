using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial.StateMachine.State
{
    public class ChaseState : State
    {
        public ChaseState(Enemy enemy) => base.enemy = enemy;

        public override State HandleState()
        {
            if (!CheckPlayerRange()) return enemy.stateMachine.idleState;
            else if (CheckPlayerAttackRange()) return enemy.stateMachine.stanceState;
            else return DoStuff();
        }

        public State DoStuff()
        {
            enemy.transform.position = new Vector3(
                enemy.transform.position.x + CalculateSpeedMultiplier() * Time.deltaTime * enemy.enemySettings.movementSpeed,
                enemy.transform.position.y,
                enemy.transform.position.z
            );
            return this;
        }

        public float CalculateSpeedMultiplier() => enemy.transform.position.x < Player.Instance.transform.position.x ? 1 : -1;

        public bool CheckPlayerAttackRange() => Physics.CheckSphere(enemy.transform.position, enemy.enemySettings.attackRadius, enemy.enemySettings.playerLayer);

        public bool CheckPlayerRange() => Physics.CheckSphere(enemy.transform.position, enemy.enemySettings.chaseRadius, enemy.enemySettings.playerLayer);
    }
}