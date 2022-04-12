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
    public BasicAttackTimer basicAttackTimer;
    public AbilityUser abilityUser;

    public int healthIncrement;
    public float movementIncrement;
    public int attackIncrement;
    public float reviveIncrement;

    public float levelRateIncrement;
    public float abilityCDIncrement;
    public float attackIntervalIncrement;
    public int reviveDistanceIncrement;

    public int hpRestore;

    private bool axisReset = true;

    private int level = 1;

    enum Stat
    {
        none,
        hp,
        mov,
        atk,
        rev
    }

    public Image levelUpImage;
    public Image ultimateImage;

    public float levelUpTimer = 60f;
    private float lastLevelUpTime;

    [SerializeField]
    private int skillPointsAvailable = 0;

    [SerializeField]
    private int ultimatePointsAvailable = 0;

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
        if(ultimatePointsAvailable > 0)
        {
            if(null != ultimateImage)
            {
                ultimateImage.enabled = true;
            }
            if (axisReset)
            {
                ChooseUltimate();
            }
            else if (Mathf.Abs(Input.GetAxisRaw(horizontalAxisName)) < .1f && Mathf.Abs(Input.GetAxisRaw(verticalAxisName)) < .1f)
            {
                axisReset = true;
            }
        }
        else if (skillPointsAvailable > 0)
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
            if (null != ultimateImage)
            {
                ultimateImage.enabled = false;
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
                IncreaseAttack(attackIncrement);
                break;
            case Stat.hp:
                IncreaseHealth(healthIncrement);
                break;
            case Stat.mov:
                IncreaseMovement(movementIncrement);
                break;
            case Stat.rev:
                IncreaseReviver(reviveIncrement);
                break;
        }
    }

    void ChooseUltimate()
    {
        Stat toLevel = Stat.none;
        axisReset = false;
        if (Input.GetAxisRaw(horizontalAxisName) > .5f)
        {
            toLevel = Stat.atk;
        }
        else if (Input.GetAxisRaw(horizontalAxisName) < -.5f)
        {
            toLevel = Stat.mov;
        }
        else if (Input.GetAxisRaw(verticalAxisName) > .5f)
        {
            toLevel = Stat.hp;
        }
        else if (Input.GetAxisRaw(verticalAxisName) < -.5f)
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
                DecreaseAttackTimer(attackIntervalIncrement);
                break;
            case Stat.hp:
                IncreaseLevelRate(levelRateIncrement);
                break;
            case Stat.mov:
                DecreaseAbilityCD(abilityCDIncrement);
                break;
            case Stat.rev:
                IncreaseReviveDistance(reviveDistanceIncrement);
                break;
        }
    }

    void LevelUp()
    {
        Debug.Log("LEVEL");
        level++;
        if(level%5 ==0)
        {
            health.currentHP = health.maxHP;
            ultimatePointsAvailable++;
        }
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

    private void IncreaseReviver(float amount = 0.05f)
    {
        reviver.reviveRate += amount;
        skillPointsAvailable--;
    }

    private void IncreaseLevelRate(float ratio = .9f)
    {
        levelUpTimer *= ratio;
        ultimatePointsAvailable--;
    }

    private void DecreaseAttackTimer(float ratio = .8f)
    {
        basicAttackTimer.attackInterval *= ratio;
        ultimatePointsAvailable--;
    }

    public void DecreaseAbilityCD(float ratio = .8f)
    {
        abilityUser.abilityCDModifier *= ratio;
        ultimatePointsAvailable--;
    }
    public void IncreaseReviveDistance(int amount = 1)
    {
        reviver.reviveDistance += amount;
        ultimatePointsAvailable--;
    }
}
