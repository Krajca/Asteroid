using UnityEngine;


namespace AsteroidGame.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public PlayerData playerData;

        [SerializeField]
        GameObject ThrustFX;
        [SerializeField]
        GameObject TurnLeftFX;
        [SerializeField]
        GameObject TurnRightFX;

        Rigidbody2D rb;

        float angle;

        bool accelerating;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public void Turn(bool right)
        {
            angle += (right ? -1 : 1) * playerData.TurnSpeed;
            rb.MoveRotation(angle);
        }

        public void Accelerate()
        {
            accelerating = true;

            Vector2 dir = (Vector2)(Quaternion.Euler(0, 0, angle) * Vector2.up);
            rb.AddForce(dir * playerData.Acceleration, ForceMode2D.Force);
        }

        public void Update()
        {
            if (accelerating) ThrustFX.SetActive(true); else ThrustFX.SetActive(false);
            accelerating = false;
        }
    }
}
