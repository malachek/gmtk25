using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using Unity.VisualScripting;
public class Frog_Grass_Fst : MonoBehaviour
{
    private string EventPath = "event:/Character/Footsteps/FrogWetGrassFootsteps";


    //FOR testing
    //private void Update()
    //{

    //    if (Input.GetKeyDown(KeyCode.J))
    //    {
    //        AudioManager.instance.PlayOneShot(FMODEvents.instance.FrogGrassFst, this.transform.position);
    //        Debug.Log("Playing Frog Grass Footstep");
    //    }
    //}
    void PlayGrassFootstepEvent()
    {


        EventInstance FrogGrassFst = RuntimeManager.CreateInstance(EventPath);
        RuntimeManager.AttachInstanceToGameObject(FrogGrassFst, transform, GetComponent<Rigidbody>());




        FrogGrassFst.start();
        FrogGrassFst.release();
    }

}

