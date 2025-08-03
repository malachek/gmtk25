using UnityEngine;

public class ObstacleBase : RingObject
{
    protected Vector3 startScale;
    private bool hasPassedZero = false;

    protected int powerLevel = 3;

    protected override void Awake()
    {
        base.Awake();
        startScale = transform.localScale;
    }

    void Update()
    {
        CheckZeroCol();
    }

    public override float GetYHeight()
    {
        return base.GetYHeight() + powerLevel * .2f; //scaling scale
    }
    public override float GetXWidth()
    {
        return base.GetXWidth() * powerLevel * .2f; 
    }

    private void CheckZeroCol()
    {
        if (!hasPassedZero && transform.position.x >= 0f && transform.position.z > 0f)
        {
            hasPassedZero = true;
            //Debug.Log("zero");
            PassedZero();
        }

        if (hasPassedZero && transform.position.x < 0f)
        {
            hasPassedZero = false;
        }
    }
    protected virtual void PassedZero()
    {
        Destroy(gameObject);
    }
}
