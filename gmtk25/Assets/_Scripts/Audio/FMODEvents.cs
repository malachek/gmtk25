using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    //examples for header
    [field: Header("Rock Footstep")]
    [field: SerializeField] public EventReference RockStep { get; private set; }

    [field: Header("Coconut Hit")]
    [field: SerializeField] public EventReference CoconutHit { get; private set; }

    [field: Header("FrogCroak")]
    [field: SerializeField] public EventReference FrogCroak { get; private set; }

    [field: Header("FrogGrassFst")]
    [field: SerializeField] public EventReference FrogGrassFst { get; private set; }



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
