using LootSystem;
using Player;
using Unity.Mathematics;
using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        [Header("Hedefler")] public GameObject[] target; // Oyuncu karakteri

        public Player.Player player;

        public bool isAttacking;
        public Vector2 damageTextLocation;
        public GameObject damageText;

        public DropOnDestroy dropOnDestroy;
        public GameObject explotionEffect;
        protected float AdamMesafesi;
        protected Animator Animator;
        protected float AttackDamage;
        protected new Collider2D Collider2D;
        protected AudioSource DeathSound;
        protected string EnemyInfo;
        protected string EnemyName;
        protected SpriteRenderer EnemySprite;
        protected Transform EnemyTransform;

        protected float Health;
        protected bool InRange;
        protected bool IsDead;
        protected bool IsFlipped;
        protected float KuleMesafesi;
        protected int MainTarget;
        protected float MaxHealth;
        protected Vector2 Movement;
        protected float Range;
        protected float Speed;
        protected float SpeedMultiplier = 1;
        protected Sprite Sprite;
        protected float XpReward;
        
        private static readonly int Attack1 = Animator.StringToHash("Attack");

        private void Start()
        {
            DeathSound = GetComponent<AudioSource>();
        }

        public void Update()
        {
            ChooseTarget();

            TargetDetect(); // Hedef takibini sağlar.

            GetTargetDistance(); // Hedef ile düşman arasındaki mesafeyi ölçer.

            LookAtTarget(); // Düşmanın yönünü hedefe çevirir.

            if (!isAttacking) Move(Movement);

            if (IsDead)
            {
                player.GetComponent<Level>().AddExperience(XpReward);
                Instantiate(explotionEffect, EnemyTransform.position, quaternion.identity);
                dropOnDestroy.Drop();
                Destroy(gameObject, 0.12f);
                IsDead = false;
            }
        }

        private void GetTargetDistance() // Hedef ile düşman arasındaki mesafeyi ölçer.
        {
            InRange = Vector2.Distance(target[MainTarget].transform.position, EnemyTransform.position) <= Range;
        }

        private void TargetDetect() // Hedef takibini sağlar.
        {
            var direction = target[MainTarget].transform.position - EnemyTransform.position;
            direction.Normalize();
            Movement = direction;
        }

        public virtual void ChooseTarget()
        {
            KuleMesafesi = Vector2.Distance(target[1].transform.position, EnemyTransform.position);

            AdamMesafesi = Vector2.Distance(target[0].transform.position, EnemyTransform.position);

            if (KuleMesafesi > AdamMesafesi)
                MainTarget = 0;
            else
                MainTarget = 1;
        }

        public virtual void TakeDamage(float damageAmount)
        {
            Health -= damageAmount;

            if (Health <= 0)
            {
                Destroy(EnemySprite);
                DeathSound.Play();
                Collider2D.enabled = false;
                IsDead = true;
            }
        }

        public void Attack()
        {
            if (InRange) player.TakeDamage(AttackDamage);
        }

        public void LookAtTarget()
        {
            var flipped = transform.localScale;
            flipped.z *= -1f;

            if (EnemyTransform.position.x < target[MainTarget].transform.position.x && IsFlipped)
            {
                EnemyTransform.localScale = flipped;
                EnemyTransform.Rotate(0f, 180f, 0f);
                IsFlipped = false;
            }
            else if (EnemyTransform.position.x > target[MainTarget].transform.position.x && !IsFlipped)
            {
                EnemyTransform.localScale = flipped;
                EnemyTransform.Rotate(0f, 180f, 0f);
                IsFlipped = true;
            }
        }

        public void Move(Vector2 direction) // Hedef menzilde(inRange) değilse hareket eder.
        {
            if (InRange)
                Animator.SetTrigger(Attack1);
            else
                EnemyTransform.position = (Vector2)EnemyTransform.position + direction * (Speed * Time.deltaTime);
        }
    }
}