using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip teleportSFX;

    public static AudioManager Instance;

    private void Awake() {
        if(null != Instance) {
            Destroy(gameObject);
        } else {
            Instance = this;
        }
    }
}
