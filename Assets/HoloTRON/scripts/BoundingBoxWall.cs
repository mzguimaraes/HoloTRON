using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent (typeof(BoxCollider))]
public class BoundingBoxWall : MonoBehaviour {

    private BoxCollider col;

    void Awake ()
    {
        col = GetComponent<BoxCollider>();
    }

	void OnDrawGizmos()
    {
        
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(col.bounds.center, col.bounds.size);
    }
}
