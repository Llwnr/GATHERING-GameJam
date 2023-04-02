using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RangeManager : MonoBehaviour
{
    private CinemachineVirtualCamera vCam;
    private CinemachineTransposer vCamBody;
    private Vector3 origTransposer;

    //Manage offset/range of camera when player is near
    [SerializeField]private float zMaxRange, zMinRange, yMaxRange, yMinRange;
    private float slowDownFactor;
    // Start is called before the first frame update
    void Awake()
    {
        vCam = GetComponent<CinemachineVirtualCamera>();
        vCamBody = vCam.GetCinemachineComponent<CinemachineTransposer>();
        origTransposer = new Vector3(vCamBody.m_XDamping, vCamBody.m_YawDamping, vCamBody.m_ZDamping);
        //So that the camera resets in a perfect way where it is set to original y & z offset at the same time
        slowDownFactor = 1/((zMaxRange - zMinRange) / (yMaxRange - yMinRange));
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKey(KeyCode.S)){
            //Basically make camera go further and show more when player comes closer
            vCamBody.m_FollowOffset.z -= Time.deltaTime;
            if(vCamBody.m_FollowOffset.z < -zMaxRange) vCamBody.m_FollowOffset.z = -zMaxRange;
            vCamBody.m_FollowOffset.y += Time.deltaTime * slowDownFactor;
            if(vCamBody.m_FollowOffset.y > yMaxRange) vCamBody.m_FollowOffset.y = yMaxRange;
        }else{
            //Slowly go back near player
            vCamBody.m_FollowOffset.z += Time.deltaTime;
            if(vCamBody.m_FollowOffset.z > -zMinRange) vCamBody.m_FollowOffset.z = -zMinRange;
            vCamBody.m_FollowOffset.y -= Time.deltaTime * slowDownFactor;
            if(vCamBody.m_FollowOffset.y < yMinRange) vCamBody.m_FollowOffset.y = yMinRange;
        }
    }
}
