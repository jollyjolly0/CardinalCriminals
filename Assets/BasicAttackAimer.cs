using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttackAimer : MonoBehaviour
{
    public enum AimAxis
    {
        horizontal,
        vertical
    }
    public AimAxis myAxis;
    public PlayerMovement movement;

    public Transform attackTransform;

    private Attack attack;

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        attack = attackTransform.GetComponentInChildren<Attack>();

    }

    const float offset = 2.5f;
    const float scaleLong = 3f;
    const float scaleShort = 2f;

    [HideInInspector]
    public bool canAim = true;
    private void Update()
    {
        if (!canAim) { return; }

        if (myAxis == AimAxis.horizontal)
        {
            if (Input.GetAxisRaw("Horizontal1") < 0)
            {
                attackTransform.localPosition = new Vector3(-offset, 0, 1);
                attackTransform.localScale = new Vector3(-scaleLong, scaleShort, 1);
                attack.direction = Vector2.left;
            }
            if (Input.GetAxisRaw("Horizontal1") > 0)
            {
                attackTransform.localPosition = new Vector3(offset, 0, 1);
                attackTransform.localScale = new Vector3(scaleLong, scaleShort, 1);
                attack.direction = Vector2.right;
            }
        }
        else
        {
            if (Input.GetAxisRaw("Vertical2") < 0)
            {
                attackTransform.localPosition = new Vector3(0, -offset, 1);
                attackTransform.localScale = new Vector3(-scaleLong, scaleShort, 1);
                attack.direction = Vector2.down;
            }
            if (Input.GetAxisRaw("Vertical2") > 0)
            {
                attackTransform.localPosition = new Vector3(0, offset, 1);
                attackTransform.localScale = new Vector3(scaleLong, scaleShort, 1);
                attack.direction = Vector2.up;
            }
        }
    }
}
