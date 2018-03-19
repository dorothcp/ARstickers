using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Video : MonoBehaviour {

    bool isEnabled;
    public Color isOn;
    public Color ifOff;
    public Renderer MaterialRend;
    void Start()
    {
        isEnabled = false;
        DetermineColor();

    }

    public void ToggleVideo()
    {
        isEnabled = !isEnabled;
        DetermineColor();
    }

    void DetermineColor()
    {

        if (isEnabled)
        {
            MaterialRend.material.color = isOn;
        }
        else
        {
            MaterialRend.material.color = ifOff;

        }
    }
}
