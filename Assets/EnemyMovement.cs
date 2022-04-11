using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour , IHeadingProvider
{
    private static Player[] players;

    private void Awake()
    {
        players = FindObjectsOfType<Player>();

    }



    public Transform ClosestPlayer()
    {
        float minDist = Mathf.Infinity;
        Transform closestPlayer = null;
        foreach (var player in players)
        {

            if (player.GetComponent<Health>().isAlive)
            {
                float distance = Vector3.Distance(this.transform.position, player.transform.position);
                if(distance < minDist)
                {
                    minDist = distance;
                    closestPlayer = player.transform;
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
