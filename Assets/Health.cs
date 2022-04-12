using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private int _currentHP;

    public int maxHP;
    public int currentHP {
        get {
            return _currentHP;
        }
        set {
            _currentHP = value;
            if (null != healthbarFill) {
                float fillAmount = (float)_currentHP / maxHP;
                healthbarFill.fillAmount = fillAmount;
                healthbar.gameObject.SetActive(fillAmount < 1);
                healthbarDeath.gameObject.SetActive(fillAmount <= 0);
            }
        }
    }

    public bool isAlive = true;

    public List<DamageSource.Source> vulnerabilities;

    public Image healthbar;
    public Image healthbarFill;
    public Image healthbarDeath;

    public delegate void OnDeath();
    public event OnDeath onDeath;

    public delegate void OnRevive();
    public event OnRevive onRevive;

    public OnHitEvent onHurt;

    private Dictionary<GameObject, float> recentHitters;
    private float recentHitWindow = 0.2f;


    private void Awake()
    {
        currentHP = maxHP;
        recentHitters = new Dictionary<GameObject, float>();

        var hurtboxes = GetComponentsInChildren<HurtBox>();

        foreach (var box in hurtboxes)
        {
            box.onHurtBoxStruck += Box_onHit;
        }

        if(hurtboxes.Length == 0)
        {
            Debug.LogWarning("Did you forget to add a hurtbox to me?");
        }
    }



    private void Box_onHit(Attack attack)
    {
        DamageSource dSource = attack.attackSource.GetComponent<DamageSource>();
        if (null != dSource && vulnerabilities.Contains(dSource.source))
        {
            if (!WasHitRecently(attack.attackSource))
            {
                AddRecentHit(attack.attackSource);

                GetHit(attack);

            }
        }
    }


    private void GetHit(Attack attack)
    {
        onHurt?.Invoke(attack);

        currentHP = currentHP - attack.damage;

        if(currentHP <= 0)
        {
            currentHP = 0;
            Die();
        }
    }
    private void Die()
    {
        isAlive = false;
        onDeath?.Invoke();
    }



    private bool WasHitRecently(GameObject hitter)
    {
        if (!recentHitters.ContainsKey(hitter))
        {
            return false;
        }


        float lastHit = recentHitters[hitter];

        if (Time.time > recentHitWindow + lastHit)
        {
            return false;
        }


        return true;

    }
    private void AddRecentHit(GameObject hitter)
    {
        recentHitters[hitter] = Time.time;
    }


    public void Revive()
    {
        Debug.Log("Revived");
        isAlive = true;
        onRevive?.Invoke();

        currentHP = maxHP / 2;
    }


}
