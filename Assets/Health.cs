using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public List<DamageSource.Source> vulnerabilities;
    private PlayerStatus ps;

    private void Awake()
    {
        ps = GetComponent<PlayerStatus>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DamageSource dSource = collision.gameObject.GetComponent<DamageSource>();
        if (null != dSource)
        {
            if(vulnerabilities.Contains(dSource.source))
            {
                if(null != ps)
                {
                    ps.Die();
                }
                
                Debug.Log("FU*K");
            }
        }
    }
}
