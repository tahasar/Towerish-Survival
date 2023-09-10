using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float characterSpeed;

        public Rigidbody2D rb;
        public Animator animator;
        public Transform characterSprite;
        private Vector2 _movement;
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private static readonly int Speed = Animator.StringToHash("Speed");

        // Update is called once per frame
        private void Update()//
        {
            
            _movement.x = Input.GetAxisRaw("Horizontal");
            _movement.y = Input.GetAxisRaw("Vertical");
            _movement = _movement.normalized;
            

            animator.SetFloat(Horizontal, _movement.x);
            animator.SetFloat(Vertical, _movement.y);
            animator.SetFloat(Speed, _movement.sqrMagnitude);
        }

        private void FixedUpdate()
        {
            rb.MovePosition(rb.position + _movement * (characterSpeed * Time.fixedDeltaTime));
        }
    }
}