using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationManager : MonoBehaviour
{
    [SerializeField] Transform DiskTransform;

    public float VelocityDg { get; private set; }
    [SerializeField] float AccelerationDg;
    public float MaxVelocityDg;


    [SerializeField] RotationEnum rotationEnum = RotationEnum.CW;

    public enum RotationEnum
    {
        None = 0,
        CW = 1,
        CCW = 2
    }

    private void OnEnable()
    {
        switch(rotationEnum)
        {
            case RotationEnum.None:
                AccelerationDg = 0; break;
            case RotationEnum.CW:
                /*acceleration = acceleration;*/ break;
            case RotationEnum.CCW:
                AccelerationDg = -AccelerationDg; break;
        }
    }
    public void Initialize(float height, float _maxVelocity, float _acceleration)
    {
        transform.position += new Vector3(0f, height, 0f);
        MaxVelocityDg = _maxVelocity;
        AccelerationDg = _acceleration;   
        if (rotationEnum != RotationEnum.None)
            StartCoroutine(WindUp(MaxVelocityDg));
    }


    void Update()
    {
        RotateDisk();
    }

    private void RotateDisk()
    {
        DiskTransform.Rotate(Vector3.up * VelocityDg * Time.deltaTime, Space.Self);
    }


    private IEnumerator WindUp(float endVelocity)
    {
        while(Mathf.Abs(VelocityDg += AccelerationDg * Time.deltaTime) < endVelocity)
        {
            yield return null;
        }

        VelocityDg = endVelocity;
    }

    public void RotationInputOverride(bool isCW)
    {
        bool otherWay = isCW ^ (VelocityDg < 0f);
        float deltaVelocity = (otherWay ? 4f : 1f) * (isCW ? -1 : 1) * AccelerationDg * Time.deltaTime;

        VelocityDg = Mathf.Clamp(VelocityDg + deltaVelocity, -MaxVelocityDg, MaxVelocityDg);

        //Debug.Log(deltaVelocity);
    }
}
