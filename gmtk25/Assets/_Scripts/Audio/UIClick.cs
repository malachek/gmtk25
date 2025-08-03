using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using Unity.VisualScripting;
public class UIClick : MonoBehaviour
{
    private string EventPath = "event:/Environment/UI Click";



    //private void Update()
    //{











    //}
    void PlayUIClickEvent()
    {


        EventInstance UIClick = RuntimeManager.CreateInstance(EventPath);
        RuntimeManager.AttachInstanceToGameObject(UIClick, transform, GetComponent<Rigidbody>());




        UIClick.start();
        UIClick.release();
    }

}

