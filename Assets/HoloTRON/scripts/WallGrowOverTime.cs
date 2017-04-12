using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class WallGrowOverTime : MonoBehaviour {
	
    public float growthRate = 5f;
    
    private bool hasHitBoundingBox = false;

    private Vector3 startPos;
    private float startScale;

    void Start ()
    {
        startPos = transform.position;
        startScale = transform.localScale.z;

        //lower until it hits floor 
        RaycastHit rch;
        Physics.Raycast(transform.position, -transform.up, out rch);
        transform.position -= new Vector3(0f, rch.distance - transform.localScale.y / 2, 0f);

        //right rotation so it goes forward along floor
        //step 1: get desired forward vector by projecting current forward onto XZ-plane
        Vector3 goal = transform.forward;
        goal = Vector3.ProjectOnPlane(goal, Vector3.up);

        //2: get rotation to goal and set rotation
        Quaternion rot = Quaternion.FromToRotation(Vector3.forward, goal);
        transform.rotation = rot;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<BoundingBoxWall>() != null)
        {
            hasHitBoundingBox = true;
        }
          
    }

	void Update () {
        if (!hasHitBoundingBox)
        {
            float scaleIncreaseAmt = Time.deltaTime * growthRate;
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, Mathf.MoveTowards(transform.localScale.z, Mathf.Infinity, scaleIncreaseAmt));
            transform.position = startPos + transform.forward * ((transform.localScale.z / 2) + (startScale / 2));
        }
        
	}
}
