using System.Linq;
using NaughtyAttributes.Scripts.Core.DrawerAttributes;
using Player;
using UnityEngine;

namespace Attacks
{
    public class PurpleBaseAttack : MonoBehaviour
    {
        public float speed = 0.3f;
        public float rotateSpeed = 1000f;
        public float range = 50;
        public float damage = 50;
        public Rigidbody2D rb;
        public Transform targetEnemy;
        
        
        [SerializeField] public GameObject player;
        private Transform _enemy;
        
        private float _xEkseni;
        private SpriteRenderer _spellSprite;
        private TargetManager _targetManager;

        [Tag] [SerializeField]
        private string[] targetTag;
 
        private void Start()
        {
            _targetManager = TargetManager.Instance;
            player = GameObject.FindGameObjectWithTag("Player");
            _xEkseni = player.transform.localScale.x;
            _spellSprite = GetComponent<SpriteRenderer>();
            
            targetEnemy = _targetManager.GetClosestTarget(transform, targetTag.ToList());
        }
        
        private void Update()
        {
            if (targetEnemy == null)
            {
                targetEnemy = _targetManager.GetClosestTarget(transform, targetTag.ToList());
            }
        }

        private void FixedUpdate()
        {
            if (targetEnemy != null)
            {
                _enemy = targetEnemy.GetComponent<Transform>();
                var direction = (Vector2)_enemy.position - rb.position;
                direction.Normalize();
                var rotateAmount = Vector3.Cross(direction, transform.right).z;

                if (_xEkseni > 0) //karakter sağa bakıyorsa
                {
                    rb.angularVelocity = -rotateAmount * rotateSpeed;
                    rb.velocity = transform.right * speed;
                }
                else if (_xEkseni < 0) //karakter sola bakıyorsa
                {
                    _spellSprite.flipX = true;
                    rb.angularVelocity = rotateAmount * rotateSpeed;
                    rb.velocity = -transform.right * speed;
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out EnemyBehaviour enemy))
            {
                enemy.TakeDamage(damage);
                speed = 0;
                _spellSprite.enabled = false;
                Destroy(gameObject, 1f);
            }
        }
    }
}