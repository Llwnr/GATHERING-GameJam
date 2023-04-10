using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDestroy : MonoBehaviour
{
    [SerializeField]private GameObject weaponToDrop;
    private void OnDisable() {
        Instantiate(weaponToDrop, transform.position, Quaternion.identity);
    }
}
