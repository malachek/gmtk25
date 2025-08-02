using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationManager : MonoBehaviour
{
    [SerializeField] Transform DiskTransform;

    public float velocity { get; private set; }
    [SerializeField] float acceleration;
    [SerializeField] float maxVelocity;

    bool isConstSpeed = false;

    [SerializeField] RotationEnum rotationEnum;

    public enum RotationEnum
    {
        None = 0,
        CW = 1,
        CCW = 2
    }

    private void Awake()
    {
        switch(rotationEnum)
        {
            case RotationEnum.None:
                acceleration = 0; break;
            case RotationEnum.CW:
                /*acceleration = acceleration;*/ break;
            case RotationEnum.CCW:
                acceleration = -acceleration; break;
        }
    }
    void Start()
    {
        if(rotationEnum != RotationEnum.None) 
            StartCoroutine(WindUp( maxVelocity, () => FullSpeed()));
    }

    void Update()
    {
        RotateDisk();
        RevolveObjects();
    }

    private void RotateDisk()
    {
        DiskTransform.Rotate(Vector3.up * velocity * Time.deltaTime, Space.Self);
    }

    private void RevolveObjects()
    {

    }




    private IEnumerator WindUp(float endVelocity, Action callback)
    {
        while(Mathf.Abs(velocity += acceleration * Time.deltaTime) < endVelocity)
        {
            yield return null;
        }

        velocity = endVelocity;

        callback();
    }

    private void FullSpeed()
    {
        isConstSpeed = true;
    }
    public void RotationInputOverride(bool isCW)
    {
        bool otherWay = isCW ^ (velocity < 0f);
        float deltaVelocity = (otherWay ? 4f : 1f) * (isCW ? -1 : 1) * acceleration * Time.deltaTime;

        velocity = Mathf.Clamp(velocity + deltaVelocity, -maxVelocity, maxVelocity);

        Debug.Log(deltaVelocity);
    }
}
