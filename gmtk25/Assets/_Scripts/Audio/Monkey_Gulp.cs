using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using Unity.VisualScripting;
public class Monkey_Gulp : MonoBehaviour
{
    private string EventPath = "event:/Enemies/MonkeyGulp";



    //private void Update()
    //{











    //}
    void PlayMonkeyGulpEvent()
    {


        EventInstance MonkeyGulp = RuntimeManager.CreateInstance(EventPath);
        RuntimeManager.AttachInstanceToGameObject(MonkeyGulp, transform, GetComponent<Rigidbody>());




        MonkeyGulp.start();
        MonkeyGulp.release();
    }

}

