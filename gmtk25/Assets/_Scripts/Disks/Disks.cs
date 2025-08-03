using UnityEngine;

public class Disks : MonoBehaviour
{
    [SerializeField] PlayerRotation player;
    [SerializeField] GameObject DiskPrefab;

    [SerializeField] float GapHeight;
    [SerializeField] float MaxVelocity;
    [SerializeField] float Acceleration;

    private RotationManager lowDisk;
    private RotationManager midDisk;
    private RotationManager highDisk;

    private void Awake()
    {
        lowDisk = Instantiate(DiskPrefab).GetComponent<RotationManager>();
        midDisk = Instantiate(DiskPrefab).GetComponent<RotationManager>();
        highDisk = Instantiate(DiskPrefab).GetComponent<RotationManager>();

        lowDisk.Initialize(0f, MaxVelocity, Acceleration);
        midDisk.Initialize(GapHeight, MaxVelocity, Acceleration);
        highDisk.Initialize(GapHeight * 2f, MaxVelocity, Acceleration);

        player.SetPushBack(MaxVelocity);
    }
}
