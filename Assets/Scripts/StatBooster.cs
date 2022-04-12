using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatBooster : MonoBehaviour
{
    public Health health;
    public Movement movement;
    public Attack attack;
    public Reviver reviver;

    public int hpRestore;

    private bool axisReset = true;

    enum Stat
    {
        none,
        hp,
        mov,
        atk,
        rev
    }

    public Image levelUpImage;

    public float levelUpTimer = 60f;
    private float lastLevelUpTime;

    private int skillPointsAvailable = 0;

    string horizontalAxisName;
    string verticalAxisName;
    private void Awake()
    {
        int playerNumber = GetComponent<Player>().playerNumber;


        horizontalAxisName = "DPadX" + playerNumber.ToString();
        verticalAxisName = "DPadY" + playerNumber.ToString();
    }
    private void Start()
    {
        lastLevelUpTime = Time.time;
    }

    private void Update()
    {
        if (Time.time > levelUpTimer + lastLevelUpTime)
        {
            LevelUp();
            lastLevelUpTime = Time.time;
        }
        if (skillPointsAvailable > 0)
        {
            if (axisReset)
            {
                ChooseBoost();
            }
            else if(Mathf.Abs(Input.GetAxisRaw(horizontalAxisName))<.1f && Mathf.Abs(Input.GetAxisRaw(verticalAxisName)) < .1f)
            {
                axisReset = true;
            }
        }
        else
        {
            if (null != levelUpImage)
            {
                levelUpImage.enabled = false;
            }
        }
    }

    void ChooseBoost()
    {
        Stat toLevel = Stat.none;
        axisReset = false;
        if (Input.GetAxisRaw(horizontalAxisName) >.5f)
        {
            toLevel = Stat.atk;
        }
        else if(Input.GetAxisRaw(horizontalAxisName) < -.5f)
        {
            toLevel = Stat.mov;
        }
        else if(Input.GetAxisRaw(verticalAxisName) > .5f)
        {
            toLevel = Stat.hp;
        }
        else if(Input.GetAxisRaw(verticalAxisName) < -.5f)
        {
            toLevel = Stat.rev;
        }
        else
        {
            axisReset = true;
        }
        switch (toLevel)
        {
            case Stat.atk:
                IncreaseAttack();
                break;
            case Stat.hp:
                IncreaseHealth();
                break;
            case Stat.mov:
                IncreaseMovement();
                break;
            case Stat.rev:
                IncreaseReviver();
                break;
        }
    }

    void LevelUp()
    {
        Debug.Log("LEVEL"); 
        if (null != levelUpImage)
        {
            levelUpImage.enabled = true;
        }
        skillPointsAvailable++;
        health.currentHP += hpRestore;
    }
    private void IncreaseHealth(int amount = 1)
    {
        health.maxHP += amount;
        health.currentHP += amount;
        skillPointsAvailable--;
    }

    private void IncreaseMovement(float amount = .25f)
    {
        movement.speed += amount;
        skillPointsAvailable--;
    }

    private void IncreaseAttack(int amount = 1)
    {
        attack.damage += amount;
        skillPointsAvailable--;
    }

    private void IncreaseReviver(float amount = 0.0002f)
    {
        reviver.reviveRate += amount;
        skillPointsAvailable--;
    }
}
