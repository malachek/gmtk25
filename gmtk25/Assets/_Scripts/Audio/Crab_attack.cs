using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using Unity.VisualScripting;
public class Crab_Attack : MonoBehaviour
{
    private string EventPath = "event:/Enemies/CrabAttack";



    //private void Update()
    //{











    //}
    void PlayCrabAttackEvent()
    {


        EventInstance CrabAttack = RuntimeManager.CreateInstance(EventPath);
        RuntimeManager.AttachInstanceToGameObject(CrabAttack, transform, GetComponent<Rigidbody>());




        CrabAttack.start();
        CrabAttack.release();
    }

}

