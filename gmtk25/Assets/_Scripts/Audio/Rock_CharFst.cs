using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using Unity.VisualScripting;
public class Rock_CharFst : MonoBehaviour
{
    private string EventPath = "event:/Character/Footsteps/RockFootsteps";


     //FOR testing
    //private void Update()
    //{

    //    if (Input.GetKeyDown(KeyCode.J))
    //    {
    //        AudioManager.instance.PlayOneShot(FMODEvents.instance.RockStep, this.transform.position);
    //        Debug.Log("Playing Rock Footstep");
    //    }
    //}
    void PlayRockFootstepEvent()
    {


        EventInstance RockStep = RuntimeManager.CreateInstance(EventPath);
        RuntimeManager.AttachInstanceToGameObject(RockStep, transform, GetComponent<Rigidbody>());




        RockStep.start();
        RockStep.release();
    }

}

