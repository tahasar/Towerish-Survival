using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Attacks
{
    public class LaserCaster : MonoBehaviour
    {
        public Texture2D icon;

        public float range = 5;
        public float damage = 50;
        public float damageTime = 0.5f;
        private AttackManager _attackManager;
        private bool _canDamage = true;
        private Transform _enemy;
        private LineRenderer _lineRenderer;
        private GameObject _player;
        private Rigidbody2D _rb;

        private Transform _targetEnemy;


        private void Start()
        {
            _lineRenderer = GetComponent<LineRenderer>();
            _player = GameObject.FindGameObjectWithTag("Player");
            _attackManager = _player.GetComponent<AttackManager>();
        }

        // Update is called once per frame
        private void Update()
        {
            //_targetEnemy = _attackManager.FindClosestEnemy(range);

            if (_targetEnemy != null)
            {
                TurnOfLaser();
                return;
            }
            
            //_enemy = _targetEnemy.GetComponent<Transform>();
            
        }

        private void TurnOfLaser()
        {
            _lineRenderer.DOColor(new Color2(Color.white, Color.white), new Color2(Color.green, Color.black), 1);

            var position = transform.position;
            _lineRenderer.SetPosition(0, position);
            _lineRenderer.SetPosition(1, position);
        }

        private IEnumerator Cooldown()
        {
            yield return new WaitForSeconds(damageTime);
            _canDamage = true;
        }
    }
}