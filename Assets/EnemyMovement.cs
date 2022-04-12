using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour , IHeadingProvider
{
    private static EnemyTarget[] targets;


    private void ScanForTargets()
    {
        targets = FindObjectsOfType<EnemyTarget>();
    }

    private float timeBetweenScans = 0.2f;
    private float lastScan = Mathf.NegativeInfinity;
    public Transform ClosestPlayer()
    {
        if(Time.time > lastScan + timeBetweenScans)
        {
            ScanForTargets();
        }

        float minDist = Mathf.Infinity;
        Transform closestPlayer = null;
        foreach (var target in targets)
        {

            if (target.IsTargetable())
            {
                float distance = Vector3.Distance(this.transform.position, target.transform.position);
                if(distance < minDist)
                {
                    minDist = distance;
                    closestPlayer = target.transform;
                }
            }

        }

        return closestPlayer;
    }

    public Vector2 GetHeading()
    {
        Transform closestPlayer = ClosestPlayer();

        if (closestPlayer != null)
        {
            return (closestPlayer.position - this.transform.position).normalized;
        }
        return Vector2.zero;

    }
}
