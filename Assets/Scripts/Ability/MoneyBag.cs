using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyBag : MonoBehaviour
{
    public float duration;
    public AudioClip bagDropSFX;

    private AudioSource audioSource;

    private void Start()
    {
        StartCoroutine(ManageLife());
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(bagDropSFX);
    }

    IEnumerator ManageLife()
    {
        yield return new WaitForSeconds(duration);

        Destroy(this.gameObject);
    }
}
