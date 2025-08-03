using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

public class RingCollision : MonoBehaviour
{
    [SerializeField] PlayerRotation player;
    [SerializeField] PlayerJump jump;

    [SerializeField] float xToleranceDg = 5f;
    [SerializeField] float jumpTolerance = .2f;
    [SerializeField] float yTolerance = 2f;


    private float playerToObjectXDistance;
    private float playerToObjectYDistance;

    private bool PlayerXOverlap;
    private bool PlayerYOverlap;

    private float tempGroundY = 0f;
    private float realGroundY = 0f;


    void Update()
    {
        List<RingObject> objects = ObjectPooler.Instance.GetActiveObjects();

        foreach (RingObject obj in objects)
        {
            //Debug.Log(obj);
            if (obj == player) continue;
            if (!IsSameFloor(player, obj)) continue;

            PlayerYOverlap = IsPlayerYInObject(player, obj);

            //Debug.Log("Player Y In Object");
            PlayerXOverlap = IsXOverlap(player, obj);
            //if(!PlayerXOverlap) continue;


            //Debug.Log($"Y Overlap: {playerToObjectYDistance} | X Overlap: {playerToObjectXDistance}");
            //Debug.Log($"Collided with: {obj.name}, pushing back with extra {currOverlap} dg force");

            //Debug.Log(currOverlap);
            if (PlayerYOverlap && PlayerXOverlap) // left-right collisino
            {
                if (playerToObjectXDistance < 0f) // left collision
                {
                    Debug.Log("Player to left of object, pushing");
                    player.PushBack(Mathf.Max(playerToObjectXDistance, 0f));
                    //player.PushTo()
                }
                else
                {
                    Debug.Log($"Player to right of object, up by {playerToObjectYDistance}");
                }
            }
            if (!PlayerYOverlap) // above
            {
                if (PlayerXOverlap)
                {
                    Debug.Log("Player is above object");
                    jump.SetGroundY(tempGroundY);
                }
                else
                {
                    Debug.Log("Player is off object");
                    jump.SetGroundY(realGroundY);
                }
            }
        }
    }

    private bool IsSameFloor(RingObject obj1, RingObject obj2)
    {
        return Mathf.Abs(obj1.YPos - obj2.YPos) < yTolerance;
    }

    private bool IsPlayerYInObject(RingObject obj1, RingObject obj2)
    {
        //Debug.Log($"Player Bottom Y: {obj1.transform.position.y} | Obstacle Top Y: {obj2.transform.position.y + obj2.GetYHeight() * .5f} | Collided? : {obj1.transform.position.y <= obj2.transform.position.y + obj2.GetYHeight() * .5f}");

        float playerBottom = obj1.transform.position.y;
        float objectTop = obj2.transform.position.y + obj2.GetYHeight() * .5f;

        playerToObjectYDistance = objectTop - playerBottom; // + above, - notabove

        if (playerToObjectYDistance <= 0f)
        {
            tempGroundY = objectTop;
            Debug.Log($"Player is {playerToObjectYDistance} above objecttop");
        }

        return playerToObjectYDistance > 0f;
    }

    private bool IsXOverlap(RingObject obj1, RingObject obj2)
    {
        float dg1 = NormalizeDegree(obj1.GetDegrees());
        float dg2 = NormalizeDegree(obj2.GetDegrees());

        bool ObjectCenterBehindPlayerCenter = dg1 < dg2;

        if (ObjectCenterBehindPlayerCenter)
        {
            float playerLeftEdge = dg1 + obj1.GetXWidth() * .5f;
            float objectRightEdge = dg2 - obj2.GetXWidth() * .5f;

            playerToObjectXDistance = playerLeftEdge - objectRightEdge;
            return (objectRightEdge - xToleranceDg <= playerLeftEdge);
        }

        else // Object 
        {
            float playerRightEdge = dg1 - obj1.GetXWidth() * .5f;
            float objectLeftEdge = dg2 + obj2.GetXWidth() * .5f;

            //if(playerRightEdge - degreeTolerance <= objectLeftEdge) Debug.Log($"player right: {playerRightEdge} | object left: {objectLeftEdge}");

            playerToObjectXDistance = objectLeftEdge - playerRightEdge;
            return (playerRightEdge - xToleranceDg <= objectLeftEdge);
        }
    }


    float NormalizeDegree(float deg) => (deg + 360f) % 360f;

}
