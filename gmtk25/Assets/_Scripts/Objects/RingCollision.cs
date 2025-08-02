using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class RingCollision : MonoBehaviour
{
    [SerializeField] PlayerRotation player;

    [SerializeField] float degreeTolerance = 5f;
    [SerializeField] float jumpTolerance = .2f;
    [SerializeField] float yTolerance = 2f;

    [SerializeField] RotationManager rotationManager;


    private float currOverlap;


    private void Awake()
    {
        player.SetPushBack(rotationManager.velocity);
    }

    void Update()
    {
        List<RingObject> objects = ObjectPooler.Instance.GetActiveObjects();

        foreach (RingObject obj in objects)
        {
            //Debug.Log(obj);
            if (obj == player) continue;
            if (!IsSameFloor(player, obj)) continue;
            if (!IsPlayerYInObject(player, obj)) continue;
            //Debug.Log("Player Y In Object");
            if (!IsAngleOverlap(player, obj)) continue;

            //Debug.Log($"Collided with: {obj.name}, pushing back with extra {currOverlap} dg force");

            //Debug.Log(currOverlap);
            player.PushBack(Mathf.Max(currOverlap * 2f, 0f));
        }

    }

    private bool IsSameFloor(RingObject obj1, RingObject obj2)
    {
        float angle1 = NormalizeDegree(obj1.GetDegrees());
        float angle2 = NormalizeDegree(obj2.GetDegrees());

        float angularWidth1 = obj1.GetXWidth();
        float angularWidth2 = obj2.GetXWidth();

        //Debug.Log($"{obj1.YPos}, {obj2.YPos}, {Mathf.Abs(obj1.YPos - obj2.YPos) < yTolerance}");
        return Mathf.Abs(obj1.YPos - obj2.YPos) < yTolerance;
    }

    private bool IsPlayerYInObject(RingObject obj1, RingObject obj2)
    {
        //Debug.Log($"Player Bottom Y: {obj1.transform.position.y} | Obstacle Top Y: {obj2.transform.position.y + obj2.GetYHeight() * .5f} | Collided? : {obj1.transform.position.y <= obj2.transform.position.y + obj2.GetYHeight() * .5f}");
        return obj1.transform.position.y + jumpTolerance <= obj2.transform.position.y + obj2.GetYHeight() * .5f;
    }

    private bool IsAngleOverlap(RingObject obj1, RingObject obj2)
    {
        float dg1 = NormalizeDegree(obj1.GetDegrees());
        float dg2 = NormalizeDegree(obj2.GetDegrees());

        if(dg1 < dg2 ) return false; // object is behind player

        float playerRightEdge = dg1 - obj1.GetXWidth() * .5f;
        float objectLeftEdge = dg2 + obj2.GetXWidth() * .5f;

        //if(playerRightEdge - degreeTolerance <= objectLeftEdge) Debug.Log($"player right: {playerRightEdge} | object left: {objectLeftEdge}");

        currOverlap = objectLeftEdge - playerRightEdge;

        return (playerRightEdge - degreeTolerance <= objectLeftEdge);
    }

   

    float NormalizeDegree(float deg) => (deg + 360f) % 360f;

}
