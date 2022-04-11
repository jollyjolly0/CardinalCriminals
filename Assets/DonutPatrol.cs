using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutPatrol : MonoBehaviour
{
    Movement movement;

    public float runDuration;
    public float restDuration;

    private float runSpeed;

    private void Awake()
    {
        movement = GetComponent<Movement>();
    }

    private void Start()
    {
        runSpeed = movement.speed;
        StartCoroutine(RunRoutine());
    }

    IEnumerator RunRoutine()
    {
        while (true)
        {
            movement.speed = runSpeed;
            yield return new WaitForSeconds(runDuration);

            movement.speed = 0f;
            yield return new WaitForSeconds(restDuration);
        }
    }

}
