using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
    [SerializeField]private Transform myObject;
    private Image hpBar;

    private float maxHp;

    private void Start() {
        hpBar = GetComponent<Image>();
        maxHp = myObject.GetComponent<HealthManager>().GetMaxHp();
    }

    private void Update() {
        float currHp = myObject.GetComponent<HealthManager>().GetCurrentHp();

        hpBar.fillAmount = currHp/maxHp;
    }
}
