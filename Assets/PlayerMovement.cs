using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour , IHeadingProvider
{
    private string horizontalAxisName;
    private string verticalAxisName;

    // Start is called before the first frame update
    void Awake()
    {
        int playerNumber = GetComponent<Player>().playerNumber;


        horizontalAxisName = "Horizontal" + playerNumber.ToString();
        verticalAxisName = "Vertical" + playerNumber.ToString();


    }

    public Vector2 GetHeading()
    {
        return new Vector2(Input.GetAxisRaw(horizontalAxisName), Input.GetAxisRaw(verticalAxisName));
    }
}
