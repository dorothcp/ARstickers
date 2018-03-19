using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AREngineUtils : MonoBehaviour
{

    public static AREngineUtils instance;

    void Awake()
    {
        
        instance = this;
    }
    public enum TouchMode { Started, Moved, Ended, Stationary };
   
    public bool HasMouseMoved()
    {
        float threshhold = 0.0001f;
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        return ((x > threshhold || x < -threshhold) || (y > threshhold || y < -threshhold));
    }
    public Ray GetTouchRay()
    {
        return ViewportPointToRay(GetTouchViewportPosition());
    }
    public Ray ViewportPointToRay(Vector3 viewportPoint)
    {
        return Camera.main.ViewportPointToRay(viewportPoint);
    }
    public Vector3 GetTouchViewportPosition()
    {
        Vector3 ret = Vector3.zero;

#if UNITY_EDITOR && (UNITY_IOS || UNITY_ANDROID)
		ret = Input.mousePosition;
#else
        ret = Input.GetTouch(0).position;
#endif

        return Camera.main.ScreenToViewportPoint(ret);
    }
  
    public float GetPinchDelta()
    {
        float ret = 0.0f;
#if !UNITY_EDITOR
        if (GetTouchCount() == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPosition = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPosition = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPosition - touchOnePrevPosition).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            ret = (prevTouchDeltaMag - touchDeltaMag)*0.01f;
        }
#else



        ret = Input.mouseScrollDelta.y;


#endif

        return ret;
    }
    public float GetFingerDeltaX(int ID)
    {
        float ret = 0.0f;
#if !UNITY_EDITOR
        if (GetTouchCount() > ID)
        {
            Touch touchZero = Input.GetTouch(0);

            Vector2 touchZeroPrevPosition = touchZero.position - touchZero.deltaPosition;

            float touchDeltaMag = (touchZero.position.x - touchZeroPrevPosition.x);

            ret = (touchDeltaMag);
        }
#else

        ret = Input.mouseScrollDelta.y;


#endif

        return ret;
    }
    public bool isTouchingScreen()
    {
        bool ret = false;
#if UNITY_EDITOR && (UNITY_IOS || UNITY_ANDROID)
		if (Input.GetMouseButton (0) || Input.GetMouseButton (1))
		{
			ret = true;
		}
#else
        if (Input.touchCount > 0)
        {
            ret = true;
        }
#endif
        return ret;
    }
    public int GetTouchCount()
    {
        int ret = 0;
#if UNITY_EDITOR && (UNITY_IOS || UNITY_ANDROID)
		if (Input.GetMouseButton (0) || Input.GetMouseButton (1)) 
        {
            ret = 1;

        }
#else
        ret =Input.touchCount;
        
#endif
        return ret;
    }
    public TouchMode GetTouchMode()
    {
        TouchMode mode = TouchMode.Stationary;

#if UNITY_EDITOR && (UNITY_IOS || UNITY_ANDROID)
		if (Input.GetMouseButtonDown (0) || Input.GetMouseButtonDown(1)) 
		{
			mode = TouchMode.Started;
		} else if (Input.GetMouseButtonUp (0) || Input.GetMouseButtonUp(1)) {
			mode = TouchMode.Ended;
		} else if (HasMouseMoved ()) {
			mode = TouchMode.Moved;
		} else 
		{
			mode = TouchMode.Stationary;
		}

#elif UNITY_IOS || UNITY_ANDROID
		if(Input.touches.Length > 0)
		{
			Touch t = Input.GetTouch (0);
			switch(t.phase)
			{
			case TouchPhase.Began:
				mode = TouchMode.Started;
				break;
			case TouchPhase.Moved:
				mode = TouchMode.Moved;
				break;
			case TouchPhase.Ended:
				mode = TouchMode.Ended;
				break;
			case TouchPhase.Stationary:
				mode = TouchMode.Stationary;
				break;
            
			}

		}

#endif

        return mode;
    }
}
