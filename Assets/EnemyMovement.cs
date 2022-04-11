using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private PlayerStatus[] players;
    public float speed;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        GameObject[] myPlayers = GameObject.FindGameObjectsWithTag("Player");
        players = new PlayerStatus[myPlayers.Length];
        for(int i = 0; i <myPlayers.Length; i++)
        {
            players[i] = myPlayers[i].GetComponent<PlayerStatus>();
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, closestPlayer().position, speed);
    }

    public Transform closestPlayer()
    {
        if(!players[0].isAlive)
        {
            return players[1].transform;
        }
        if (!players[1].isAlive)
        {
            return players[0].transform;
        }
        float distance1 = Vector3.Distance(this.transform.position, players[0].transform.position); 
        float distance2 = Vector3.Distance(this.transform.position, players[1].transform.position); 
        
        if(distance1<distance2)
        {
            return players[0].transform;
        }
        else
        {
            return players[1].transform;
        }
    }
}
