using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public enum PlayerNumber
    {
        player1,
        player2
    }
    public PlayerNumber playerNumber;

    public float speed;

    public PlayerStatus ps;

    private string horizontalAxisName;
    private string verticalAxisName;

    // Start is called before the first frame update
    void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        if(playerNumber == PlayerNumber.player1)
        {
            horizontalAxisName = "Horizontal1";
            verticalAxisName = "Vertical1";
        }
        else
        {
            horizontalAxisName = "Horizontal2";
            verticalAxisName = "Vertical2";
        }
        ps = GetComponent<PlayerStatus>();
        ps.onPlayerDeath += OnPlayerDeath;
    }

    void OnPlayerDeath()
    {
        rb.velocity = Vector2.zero;
    }
    // Update is called once per frame
    void Update()
    {
        if (ps.isAlive)
        {
            Vector2 movement = new Vector2(Input.GetAxisRaw(horizontalAxisName) * speed, Input.GetAxisRaw(verticalAxisName) * speed);
            rb.velocity = movement;
            Debug.Log($"{Input.GetAxisRaw(horizontalAxisName) * speed}, {Input.GetAxisRaw(verticalAxisName) * speed}");
        }
    }
}
