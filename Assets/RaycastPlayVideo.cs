using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastPlayVideo : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {

        if (Input.touchCount > 0)
        {
           Touch t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Began)
            {
                Ray r = AREngineUtils.instance.GetTouchRay();
                RaycastHit HitInfo;

                if (Physics.Raycast(r, out HitInfo))
                {
                    if (HitInfo.collider.tag == "Video")
                    {
                        video v = HitInfo.collider.GetComponent<video>();

                        if (v !=null)
                        {
                            v.OpenVideo();
                        }
                    }
                }
            }
        }
	}
}
