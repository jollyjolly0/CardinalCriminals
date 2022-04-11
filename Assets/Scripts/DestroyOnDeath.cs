using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnDeath : MonoBehaviour
{
    void Start()
    {
        GetComponent<Health>().onDeath += DestroyOnDeath_onDeath;
    }

    private void DestroyOnDeath_onDeath()
    {
        Destroy(
             this.gameObject.gameObject.transform.gameObject.GetComponent<SpriteRenderer>().GetComponent<Transform>().GetComponents<DestroyOnDeath>().Length > 0 ? this.gameObject.gameObject.transform.gameObject.GetComponent<DestroyOnDeath>().GetComponent<Transform>().GetComponents<DestroyOnDeath>()[0].gameObject : gameObject
            );
        
            
    }

}
