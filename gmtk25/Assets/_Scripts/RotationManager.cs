using UnityEngine;

public class RotationManager : MonoBehaviour
{
    [SerializeField] Transform DiskTransform;

    float velocity;
    [SerializeField] float acceleration;
    [SerializeField] float maxVelocity;

    void Start()
    {
        
    }

    void Update()
    {
        DiskTransform.Rotate(Vector3.up * velocity * Time.deltaTime, Space.Self);
        //DiskTransform.Rotate(Vector3.left * velocity * Time.deltaTime, Space.Self);
    }

    public void RotationInput(bool isRight)
    {
        bool otherWay = isRight ^ (velocity > 0f);
        float deltaVelocity = (otherWay ? 4f : 1f) * (isRight ? 1 : -1) * acceleration * Time.deltaTime;
        Debug.Log(deltaVelocity);

        velocity = Mathf.Clamp(velocity + deltaVelocity, -maxVelocity, maxVelocity);
    }
}
