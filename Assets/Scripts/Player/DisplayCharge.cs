using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCharge : MonoBehaviour
{
    private Image chargeBar;
    [SerializeField]private Transform player;
    private PlayerRotation playerRotation;

    private float maxCharge, currentCharge;

    private void Start() {
        chargeBar = GetComponent<Image>();
        playerRotation = player.GetComponent<PlayerRotation>();

        maxCharge = playerRotation.GetMaxCharge();
    }

    private void Update() {
        currentCharge = playerRotation.GetCurrentCharge();

        chargeBar.fillAmount = currentCharge/maxCharge;
    }
}
