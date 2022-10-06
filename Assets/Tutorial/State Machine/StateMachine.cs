using Tutorial.StateMachine.State;
using UnityEngine;

namespace Tutorial.StateMachine
{
    public class StateMachine
    {
        public State.State currentState;

        public AttackState attackState;
        public ChaseState chaseState;
        public IdleState idleState;
        public StanceState stanceState;

        public StateMachine(Enemy enemy)
        {
            attackState = new AttackState(enemy);
            chaseState = new ChaseState(enemy);
            idleState = new IdleState(enemy);
            stanceState = new StanceState(enemy);

            currentState = idleState;
        }

        public void Tick()
        {
            StateTimerUpgrade();
            currentState = currentState.HandleState();
        }

        public void StateTimerUpgrade()
        {
            if(stanceState.attackRecoveryTimer > 0) stanceState.attackRecoveryTimer -= Time.deltaTime;
        }
    }
}
