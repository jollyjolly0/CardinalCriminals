using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reviver : MonoBehaviour
{
    public float reviveRate;

    public float reviveDistance;

    public Health otherPlayer;

    private void Update()
    {
        if(otherPlayer.isAlive)
        {
            return;
        }
        float distance = Vector3.Distance(transform.position, otherPlayer.transform.position);
        if(distance<reviveDistance)
        {
            otherPlayer.GetComponent<Revivee>().ReviveAmount(reviveRate);
        }
    }
}
