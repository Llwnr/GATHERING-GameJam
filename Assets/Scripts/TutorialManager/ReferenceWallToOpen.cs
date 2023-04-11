using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceWallToOpen : MonoBehaviour
{
    [SerializeField]private OpenWall wallToOpenRef;
    
    private void OnDisable() {
        wallToOpenRef.OpenTheWall();
    }
}
