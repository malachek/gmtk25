using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [Header("Kinematics")]
    public float Degrees { get; private set; } = 180f;
    public float Velocity { get; private set; } = 0f;
    [SerializeField] float _acceleration;

    [SerializeField] float maxWalkVelocity;
    [SerializeField] float sprintMultiplier;
    private float maxVelocity;

    [Space(10), Header("Constraints")]
    [SerializeField] float maxDegrees = 350f;
    [SerializeField] float minDegrees = 10f;


    private bool isSprinting = false;

    private void Awake()
    {
        maxVelocity = maxWalkVelocity;
    }

    private void Update()
    {
        //Debug.Log($"Velocity: {Velocity} | Acceleration: {_acceleration} | Degrees: {Degrees}");
    }
    private void UpdateRotation()
    {
        if (Degrees > maxDegrees && Velocity > 0f || Degrees + Velocity * Time.deltaTime > maxDegrees)
        {
            Degrees = maxDegrees;
            Velocity = 0f;
        }
        if (Degrees < minDegrees && Velocity < 0f || Degrees + Velocity * Time.deltaTime < minDegrees)
        {
            Degrees = minDegrees;
            Velocity = 0f;
        }
        Degrees = (Degrees + Velocity * Time.deltaTime) % 360f;
        RotatePlayerTo(Degrees);
    }

    private void RotatePlayerTo(float dg)
    {
        //transform.Rotate(Vector3.up * Velocity * Time.deltaTime, Space.Self);
        transform.rotation = Quaternion.Euler(0, (dg - 90f) % 360f, 0);
    }

    public void SetSprint(bool isSprint)
    {
        isSprinting = isSprint;
        maxVelocity = maxWalkVelocity * (isSprint ? sprintMultiplier : 1f);
    }

    public void RotationInputOverride(bool isCW)
    {
        bool otherWay = isCW ^ (Velocity < 0f);
        Velocity = otherWay ? 0f : Velocity;

        float deltaVelocity = (isCW ? -1 : 1) * _acceleration * Time.deltaTime;

        Velocity = Mathf.Clamp(Velocity + deltaVelocity, -maxVelocity, maxVelocity);
        UpdateRotation();
    }
}
