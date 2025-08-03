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

    [field: Header("FrogRockFootsteps")]
    [field: SerializeField] public EventReference FrogRockFootsteps { get; private set; }

    [field: Header("FrogJump")]
    [field: SerializeField] public EventReference FrogJump { get; private set; }

    [field: Header("BubbleShoot")]
    [field: SerializeField] public EventReference BubbleShoot { get; private set; }

    [field: Header("BubblePop")]
    [field: SerializeField] public EventReference BubblePop { get; private set; }

    [field: Header("CrabAttack")]
    [field: SerializeField] public EventReference CrabAttack { get; private set; }

    [field: Header("MonkeyGulp")]
    [field: SerializeField] public EventReference MonkeyGulp { get; private set; }

    [field: Header("Teleport")]
    [field: SerializeField] public EventReference Teleport { get; private set; }

    [field: Header("ObstacleBreak")]
    [field: SerializeField] public EventReference ObstacleBreak { get; private set; }


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
