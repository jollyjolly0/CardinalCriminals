using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hideout : MonoBehaviour
{
    public float duration;
    public AudioClip hideoutSFX;

    private AudioSource audioSource;

    private void Start()
    {
        StartCoroutine(ManageLife());
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(hideoutSFX, .5f);
    }

    IEnumerator ManageLife()
    {
        yield return new WaitForSeconds(duration);

        Destroy(this.gameObject);
    }
}
