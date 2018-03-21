using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
public class StreamVideo : MonoBehaviour
{

    RawImage Img;
    VideoPlayer Player;

    void Start()
    {
        Player = GetComponent<VideoPlayer>();
        Img = GetComponent<RawImage>();
  
    }
    void OnComplete(VideoPlayer v)
    {
        Player.Pause();
    }
    void Update()
    {
        if (Img != null && Player != null)
        {
            Img.texture = Player.texture;

        }
    }
   
    void OnEnable()
    {
        Player.prepareCompleted += PrepareComplete;
        Player.loopPointReached += OnComplete;

        if (Img != null)
        {
            Img.enabled = false;
        }


        Player.Play();


    }
  
    void OnDisable()
    {
        Player.prepareCompleted -= PrepareComplete;
        Player.loopPointReached -= OnComplete;

    }

    void PrepareComplete(VideoPlayer v)
    {

        if (Img != null)
        {
            Img.enabled = true;
        }
    }
}