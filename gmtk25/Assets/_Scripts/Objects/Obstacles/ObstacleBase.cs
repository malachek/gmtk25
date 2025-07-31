using UnityEngine;

public class ObstacleBase : MonoBehaviour
{
    private Vector3 startScale;
    private bool hasPassedZero = false;

    private int powerLevel = 1;

    private void Awake()
    {
        startScale = transform.localScale;
    }

    void Update()
    {
        CheckZeroCol();
    }

    private void CheckZeroCol()
    {
        if (!hasPassedZero && transform.position.x >= 0f && transform.position.z > 0f)
        {
            hasPassedZero = true;
            Debug.Log("zero");
            PassedZero();
        }

        if (hasPassedZero && transform.position.x < 0f)
        {
            hasPassedZero = false;
        }
    }
    private void PassedZero()
    {
        transform.localScale = startScale * Calculator.PowerToScale(++powerLevel);
    }
}
