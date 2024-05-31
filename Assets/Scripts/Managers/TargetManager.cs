using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class TargetManager : MonoBehaviour
{
    public Transform GetTarget(GameObject seeker, List<string> targetTags)
    {
        Transform closestTarget = null;
        float shortestDistance = Mathf.Infinity;

        foreach (var targetTag in targetTags)
        {
            var potentialTargets = GameObject.FindGameObjectsWithTag(targetTag);

            foreach (var potentialTarget in potentialTargets)
            {
                var distanceToPotentialTarget = Vector2.Distance(seeker.transform.position, potentialTarget.transform.position);
                if (distanceToPotentialTarget < shortestDistance)
                {
                    shortestDistance = distanceToPotentialTarget;
                    closestTarget = potentialTarget.transform;
                }
            }
        }

        return closestTarget;
    }
}