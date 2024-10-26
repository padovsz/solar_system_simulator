using UnityEngine;

public class ChangeLookAtTarget : MonoBehaviour {

    public GameObject target; // the target that the camera should look at

    void Start() {
        if (target == null) 
        {
            target = this.gameObject;
            Debug.Log ("ChangeLookAtTarget target not specified. Defaulting to parent GameObject");
        }
    }

    // Called when MouseDown on this gameObject
    void OnMouseDown () {
        // change the target of the LookAtTarget script to be this gameobject.
        LookAtTarget.target = target;
        Camera.main.fieldOfView = 60 * target.transform.localScale.x;

        // Deactivate all audio sources except for the target's
        DeactivateAllAudioSources();
        ActivateTargetAudioSource();
    }

    void DeactivateAllAudioSources() {
        // Find all AudioSources in the scene
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
        
        // Deactivate all AudioSources
        foreach (AudioSource audioSource in allAudioSources) {
            audioSource.enabled = false;
        }
    }

    void ActivateTargetAudioSource() {
        // Activate the AudioSource on the target if it exists
        AudioSource targetAudioSource = target.GetComponent<AudioSource>();
        if (targetAudioSource != null) {
            targetAudioSource.enabled = true;
        }
    }
}
