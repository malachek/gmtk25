using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    //examples for header
    //[field: Header("Torch SFX")]
    //[field: SerializeField] public EventReference torchGrab { get; private set; }


    //Example for future one shot referrences
    //AudioManager.instance.PlayOneShot(FMODEvents.instance.sonarPing, this.transform.position);
    public static FMODEvents instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one FMOD Events scripts in the scene");
        }
        instance = this;
    }
}
