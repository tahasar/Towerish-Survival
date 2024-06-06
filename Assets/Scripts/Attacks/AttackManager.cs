using System;
using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes.Scripts.Core.DrawerAttributes;
using UnityEngine;

namespace Attacks
{
    public class AttackManager : MonoBehaviour
    {
        public Transform sprite;
        public Vector3 localScale;
        private Transform targetEnemy;
        
        private TargetManager _targetManager;

        private void Start()
        {
            _targetManager = TargetManager.Instance;
            
            localScale = sprite.localScale;
        }
        
        private void FixedUpdate()
        {
            targetEnemy = _targetManager.GetClosestTarget(transform);
            
            if (targetEnemy == null)
                return;
            
            LookEnemy();
        }

        private void LookEnemy()
        {
            var enemyPosition = targetEnemy.position;
            
            var direction = enemyPosition - sprite.position;

            if (direction.x > 0)
            {
                sprite.localScale = new Vector3(localScale.x, localScale.y, localScale.z);
            }
            else if (direction.x < 0)
            {
                sprite.localScale = new Vector3(-localScale.x, localScale.y, localScale.z);
            }
        }
    }
}