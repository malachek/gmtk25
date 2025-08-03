using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using Unity.VisualScripting;
public class Frog_Rock_Footsteps : MonoBehaviour
{
    private string EventPath = "event:/Character/Footsteps/FrogWetRockFootsteps";


    //FOR testing
    //private void Update()
    //{

    //    if (Input.GetKeyDown(KeyCode.J))
    //    {
    //        AudioManager.instance.PlayOneShot(FMODEvents.instance.FrogRockFootsteps, this.transform.position);
    //        Debug.Log("Playing Frog Rock Footstep");
    //    }
    //}
    void PlayRockFootstepEvent()
    {


        EventInstance FrogRockFootsteps = RuntimeManager.CreateInstance(EventPath);
        RuntimeManager.AttachInstanceToGameObject(FrogRockFootsteps, transform, GetComponent<Rigidbody>());




        FrogRockFootsteps.start();
        FrogRockFootsteps.release();
    }

}

