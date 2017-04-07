using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FRL.IO;

public class WallGun : MonoBehaviour, IGlobalTriggerPressDownHandler {

    public GameObject wallPrefab;

    public void OnGlobalTriggerPressDown(VREventData eventData)
    {
        Instantiate(wallPrefab, eventData.module.transform.position, Quaternion.Euler(eventData.module.transform.forward));
    }
    
}
