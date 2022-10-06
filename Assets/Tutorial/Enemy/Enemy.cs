using UnityEngine;

namespace Tutorial
{
    public class Enemy : MonoBehaviour
    {
        [System.Serializable] public class EnemySettings { public LayerMask playerLayer; public float chaseRadius = 3f, attackRadius = 1f, movementSpeed = 1f, attackRecoveryTime = 2f; }

        public EnemySettings enemySettings;
        public StateMachine.StateMachine stateMachine;

        private void Start() => stateMachine = new StateMachine.StateMachine(this);

        private void Update() => stateMachine.Tick();
    }
}