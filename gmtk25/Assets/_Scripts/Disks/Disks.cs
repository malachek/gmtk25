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

    private DiskSegmentManager midMgr;
    private DiskSegmentManager highMgr;

    private void Awake()
    {
        lowDisk = Instantiate(DiskPrefab).GetComponent<RotationManager>();
        midDisk = Instantiate(DiskPrefab).GetComponent<RotationManager>();
        highDisk = Instantiate(DiskPrefab).GetComponent<RotationManager>();

        midMgr = midDisk.transform.GetChild(0).GetComponentInChildren<DiskSegmentManager>();
        highMgr = highDisk.transform.GetChild(0).GetComponentInChildren<DiskSegmentManager>();


        lowDisk.Initialize(0f, MaxVelocity, Acceleration);
        midDisk.Initialize(GapHeight, MaxVelocity, Acceleration);
        highDisk.Initialize(GapHeight * 2f, MaxVelocity, Acceleration);

        player.SetPushBack(MaxVelocity);
    }

    public (bool,float) IsFloorReal(float dg)
    {
        Debug.Log("degree" + dg);
        float Degree = (dg - midMgr.transform.rotation.eulerAngles.y + 22.5f + 360f) % 360f;
        if(midMgr.IsDiskAtDgFake(Degree)) return (false, 4f);
        if (highMgr.IsDiskAtDgFake(Degree)) return (false, 8f);
        return (true, 0f);
    }
}
