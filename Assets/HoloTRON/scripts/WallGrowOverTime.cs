using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class WallGrowOverTime : MonoBehaviour {
	
    public float growthRate = 5f;
    
    private bool hasHitBoundingBox = false;

    void Start ()
    {
        //lower until it hits floor 
        RaycastHit rch;
        Physics.Raycast(transform.position, -transform.up, out rch);
        transform.position -= new Vector3(0f, rch.distance - transform.localScale.y / 2, 0f);
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("OnTriggerEnter");
        if (col.gameObject.GetComponent<BoundingBoxWall>() != null)
        {
            hasHitBoundingBox = true;
        }
          
    }

	void Update () {
        if (!hasHitBoundingBox)
        {
            float scaleIncreaseAmt = Time.deltaTime * growthRate;
            transform.localScale += new Vector3(scaleIncreaseAmt, 0f, 0f);
            transform.localPosition += new Vector3(scaleIncreaseAmt / 2, 0f, 0f);
        }
        
	}
}
