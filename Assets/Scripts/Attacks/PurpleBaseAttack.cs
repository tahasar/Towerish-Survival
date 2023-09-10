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
        public GameObject player;
        private AttackManager _attackManager;
        private Transform _enemy;
        private SpriteRenderer _spellSprite;
        private float _xEkseni;

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            _attackManager = player.GetComponent<AttackManager>();
            var characterSprite = player.GetComponent<PlayerMovement>().characterSprite;
            _xEkseni = characterSprite.localScale.x;

            _spellSprite = GetComponent<SpriteRenderer>();
        }

        private void FixedUpdate()
        {
            FindClosestEnemy();

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
            //Enemy enemy = other.GetComponent<Enemy>();
            //enemy.TakeDamage(damage);

            if (other.TryGetComponent(out Enemy.Enemy enemy))
            {
                enemy.TakeDamage(damage);
                speed = 0;
                _spellSprite.enabled = false;
                Destroy(gameObject, 1f);
            }
        }

        public void FindClosestEnemy()
        {
            var enemies = GameObject.FindGameObjectsWithTag("Enemy");
            var shortestDistance = Mathf.Infinity;
            GameObject nearestEnemy = null;

            foreach (var enemy in enemies)
            {
                var distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }


            if (nearestEnemy != null && shortestDistance <= range)
                targetEnemy = nearestEnemy.transform;
            else
                targetEnemy = null;
        }
    }
}