using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reviver : MonoBehaviour
{
    public float reviveRate;

    public float reviveDistance;

    //public Health otherPlayer;


    List<Revivee> revivees;
    private void Start()
    {

        revivees = new List<Revivee>();
        var tmp = FindObjectsOfType<Revivee>();


        foreach (var player in tmp)
        {
            if(player.gameObject != gameObject)
            {
                revivees.Add(player);
            }
        }

    }

    private void Update()
    {
        foreach (var otherPlayer in revivees)
        {
            if (otherPlayer.GetComponent<Health>().isAlive)
            {
                return;
            }
            float distance = Vector3.Distance(transform.position, otherPlayer.transform.position);
            if (distance < reviveDistance)
            {
                otherPlayer.ReviveAmount(reviveRate);
            }
        }


    }
}
