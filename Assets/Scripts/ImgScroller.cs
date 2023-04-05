using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImgScroller : MonoBehaviour
{
    [SerializeField]private RawImage imgBox;
    [SerializeField]private float xSpeed, ySpeed;
    // Update is called once per frame
    void Update()
    {
        imgBox.uvRect = new Rect(imgBox.uvRect.position + new Vector2(xSpeed, ySpeed)*Time.deltaTime, imgBox.uvRect.size);
    }
}
