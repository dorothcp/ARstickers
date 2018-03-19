using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

[RequireComponent (typeof(AudioSource))]


public class video : MonoBehaviour {

	public MovieTexture movie;

	// Use this for initialization
	void Start ()
	{

		// this line of code will make the Movie Texture begin playing
		((MovieTexture)GetComponent<Renderer>().material.mainTexture).Play();
	



	
	}
}
