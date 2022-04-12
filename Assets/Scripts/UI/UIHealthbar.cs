using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthbar : MonoBehaviour {
    [SerializeField]
    private Image healthbarFill;
    [SerializeField]
    private Image healthbarDeath;

    private float _fill;

    public float fill {
        get { return _fill; }
        set {
            _fill = value;
            healthbarFill.fillAmount = _fill;
            healthbarDeath.gameObject.SetActive(_fill <= 0);
            gameObject.SetActive(_fill < 1);
        }
    }
}
