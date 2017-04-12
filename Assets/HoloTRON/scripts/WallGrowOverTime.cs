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
        startScale = transform.localScale.x;

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
            transform.localScale = new Vector3(Mathf.MoveTowards(transform.localScale.x, Mathf.Infinity, scaleIncreaseAmt), transform.localScale.y, transform.localScale.z);
            transform.position = startPos + transform.right * ((transform.localScale.x / 2) + (startScale / 2));
        }
        
	}
}
