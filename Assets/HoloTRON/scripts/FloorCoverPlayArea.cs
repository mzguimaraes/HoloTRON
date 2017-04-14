using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCoverPlayArea : MonoBehaviour {

    public SteamVR_PlayArea playArea;
    public float floorThickness = .25f;

    Valve.VR.HmdQuad_t rect;

	// Use this for initialization
	void Start () {
        rect = new Valve.VR.HmdQuad_t();
        SteamVR_PlayArea.GetBounds(SteamVR_PlayArea.Size.Calibrated, ref rect);

        transform.localScale = new Vector3(Mathf.Abs(rect.vCorners0.v0 - rect.vCorners2.v0), floorThickness, Mathf.Abs(rect.vCorners0.v2 - rect.vCorners2.v2));
        transform.position = new Vector3(0f, -floorThickness / 2f, 0f);
	}
}
