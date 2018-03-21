using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class video : MonoBehaviour {

    bool isEnabled;
    public Animator anim;
    public VideoPlayer player;
    public List<DoozyUI.NavigationPointer> OpenOnClick;
    public bool isPaused;
    public List<DoozyUI.NavigationPointer> PauseMenu;

    void Start()
    {
        isEnabled = false;
        isPaused = false;
    }

    public void OpenVideo()
    {
        DoozyUI.UINavigation.Show(OpenOnClick);
        //anim.SetBool("isEnabled", true);
        if (isPaused)
        {
            player.Pause();
            DoozyUI.UINavigation.Show(PauseMenu);
        }
        else
        {
            player.Play();
            DoozyUI.UINavigation.Hide(PauseMenu);

        }

    }
    public void ToggleVideo()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            player.Pause();
            DoozyUI.UINavigation.Show(PauseMenu);
        }
        else
        {
            player.Play();
            DoozyUI.UINavigation.Hide(PauseMenu);

        }

    }
    public void CloseVideo()
    {
      //  DoozyUI.UINavigation.Hide(PauseMenu);

    }
}
