using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FRL.IO;

public class WallGun : MonoBehaviour, IGlobalTriggerPressDownHandler {

    public GameObject wallPrefab;
    public float cooldown = 3f;
    private float cdTimer = 0f;

    void Update ()
    {
        if (cdTimer > 0f)
        {
            cdTimer -= Time.deltaTime;
        }
    }

    void FireWall(VREventData eventData)
    {
        //TODO: add haptic + visual feedback
        ViveControllerModule vive = (ViveControllerModule)eventData.module;
        vive.TriggerHapticPulse(.3f, 3999);

        Instantiate(wallPrefab, eventData.module.transform.position, eventData.module.transform.rotation);
        
    }

    public void OnGlobalTriggerPressDown(VREventData eventData)
    {
        
        if (cdTimer <= 0f)
        {
            cdTimer = cooldown;
            FireWall(eventData);
        }
    }
    
}
