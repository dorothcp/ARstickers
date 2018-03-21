using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Video : MonoBehaviour {

    bool isEnabled;
    public Animator anim;
    void Start()
    {
        isEnabled = false;

    }

    public void ToggleVideo()
    {
            isEnabled = !isEnabled;
    }

    private void OnEnable()
    {
        anim.SetBool("isEnabled", true);

    }
    private void OnDisable()
    { 
        anim.SetBool("isEnabled", false);

    }
}
