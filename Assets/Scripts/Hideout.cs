using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hideout : MonoBehaviour
{
    public float duration;


    private void Start()
    {
        StartCoroutine(ManageLife());
    }

    IEnumerator ManageLife()
    {
        yield return new WaitForSeconds(duration);

        Destroy(this.gameObject);
    }
}
