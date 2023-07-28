using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float characterSpeed;

        public Rigidbody2D rb;
        public Animator animator;
        public Transform characterSprite;
        private Vector2 movement;

        // Update is called once per frame
        private void Update()
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);

            //Karakter durduğu zaman, bakacağı yönü belirler.
            if (animator.GetFloat("Horizontal") > 0)
            {
                //pr.rotation.y = 180f;
            }

            if (animator.GetFloat("Horizontal") < 0)
            {
            }
        }

        private void FixedUpdate()
        {
            rb.MovePosition(rb.position + movement * (characterSpeed * Time.fixedDeltaTime));
        }
    }
}