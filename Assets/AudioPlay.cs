using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
[RequireComponent(typeof(AudioSource))]
public class AudioPlay : MonoBehaviour, ITrackableEventHandler {

	private TrackableBehaviour mTrackableBehavior;
	public MovieTexture movie;

	void Start() {
		
		mTrackableBehavior = GetComponent < TrackableBehaviour> ();
		if (mTrackableBehavior) {
			mTrackableBehavior.RegisterTrackableEventHandler (this);
		}
	}
	public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus) {
		MovieTexture movie = GetComponent<MovieTexture> ();
		AudioSource audio = GetComponent<AudioSource>();
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
		    newStatus == TrackableBehaviour.Status.TRACKED ||
		    newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) {

			//movie.audioClip = audio.clip;

			//audio.clip = movie.audioClip;




			//movie.Play ();
			audio.Play ();
		} else {

			//movie.Stop ();
			audio.Stop ();
		}
	}
}
