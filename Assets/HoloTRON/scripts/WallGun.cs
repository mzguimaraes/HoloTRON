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

    void FireWall(Transform currTransform)
    {
        //TODO: add haptic + visual feedback
        Instantiate(wallPrefab, currTransform.position, currTransform.rotation);
        
    }

    public void OnGlobalTriggerPressDown(VREventData eventData)
    {
        if (cdTimer <= 0f)
        {
            cdTimer = cooldown;
            FireWall(eventData.module.transform);
        }
    }
    
}
