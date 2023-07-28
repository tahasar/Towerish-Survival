using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Attacks
{
    public class LaserCaster : MonoBehaviour
    {
        public Texture2D Icon;

        public float range = 5;
        public float damage = 50;
        public float damageTime = 0.5f;
        private AttackManager attackManager;
        private bool canDamage = true;
        private Transform enemy;
        private LineRenderer lineRenderer;
        private GameObject player;
        private Rigidbody2D rb;

        private Transform targetEnemy;


        private void Start()
        {
            lineRenderer = GetComponent<LineRenderer>();
            player = GameObject.FindGameObjectWithTag("Player");
            attackManager = player.GetComponent<AttackManager>();
        }

        // Update is called once per frame
        private void Update()
        {
            targetEnemy = attackManager.FindClosestEnemy(range);
        
            if (targetEnemy != null)
            {
                enemy = targetEnemy.GetComponent<Transform>();
                Laser();
            }
            else
            {
                TurnOfLaser();
            }
        }

        private void TurnOfLaser()
        {
            lineRenderer.DOColor(new Color2(Color.white, Color.white), new Color2(Color.green, Color.black), 1);
        
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position);
        }
//
        public void Laser()
        {
            GiveDamage(enemy.GetComponent<Enemy.Enemy>());
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, enemy.position);
        }

        private void GiveDamage(Enemy.Enemy other)
        {
            if (!canDamage) return;
            other.TakeDamage(damage);
            canDamage = false;
            StartCoroutine(Cooldown());
        }

        private IEnumerator Cooldown()
        {
            yield return new WaitForSeconds(damageTime);
            canDamage = true;
        }
    }
}