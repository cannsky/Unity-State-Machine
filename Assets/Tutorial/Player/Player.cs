using UnityEngine;
using UnityEngine.UI;

namespace Tutorial
{
    public class Player : MonoBehaviour
    {
        [System.Serializable] public class PlayerSettings { public Image healthBar; public bool isMoving; public float movementSpeed = 3f, health = 100f; };

        public PlayerSettings playerSettings;

        public static Player Instance;

        private void Start() => Instance = this;

        private void Update()
        {
            if(playerSettings.isMoving) transform.position = new Vector3(
                transform.position.x + Time.deltaTime * playerSettings.movementSpeed, 
                transform.position.y, 
                transform.position.z
            );
        }

        public void ToggleMovement() => playerSettings.isMoving = !playerSettings.isMoving;

        public void HandleDamage(float damage)
        {
            playerSettings.health -= damage;
            playerSettings.healthBar.fillAmount = playerSettings.health / 100f;
        }
    }
}
