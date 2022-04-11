using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(IHeadingProvider))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    IHeadingProvider heading;
    private Health health;
    private Rigidbody2D rb;

    public float speed;

    private float stunTime = 0.2f;
    private bool isKnocked = false;

    private void Awake()
    {
        heading = GetComponent<IHeadingProvider>();
        health = GetComponent<Health>();
        rb = this.GetComponent<Rigidbody2D>();

        health.onHurt += OnHurt;
        health.onDeath +=OnDeath;
    }

    private void OnHurt(Attack attack)
    {
        StartCoroutine(GetKnocked(attack.direction,attack.speed,stunTime));   
    }
    IEnumerator GetKnocked(Vector2 direction, float speed, float time)
    {
        Debug.Log($"knocking {gameObject.name}");
        isKnocked = true;

        rb.velocity = direction.normalized * speed;

        yield return new WaitForSeconds(time);


        isKnocked = false;
    }


    // Update is called once per frame
    void Update()
    {

        if (health.isAlive & !isKnocked)
        {
            rb.velocity = heading.GetHeading().normalized * speed;
        }

    }

    void OnDeath()
    {
        rb.velocity = Vector2.zero;
    }
}
