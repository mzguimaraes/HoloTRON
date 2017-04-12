using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FRL.IO;

public class WallGun : MonoBehaviour, IGlobalTriggerPressDownHandler {

    public GameObject wallPrefab;

    public void OnGlobalTriggerPressDown(VREventData eventData)
    {

        Vector3 goal = eventData.module.transform.forward;
        goal = Vector3.ProjectOnPlane(goal, Vector3.up);

        Quaternion rot = Quaternion.FromToRotation(Vector3.forward, goal);

        Instantiate(wallPrefab, eventData.module.transform.position, eventData.module.transform.rotation);
    }
    
}
