using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private static Player[] players;

    public float speed;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();

        players = FindObjectsOfType<Player>();

    }




    // Update is called once per frame
    void Update()
    {

        Transform closestPlayer = ClosestPlayer();

        if(closestPlayer != null)
        {
            rb.velocity = (closestPlayer.position - this.transform.position).normalized * speed;
        }

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
}
