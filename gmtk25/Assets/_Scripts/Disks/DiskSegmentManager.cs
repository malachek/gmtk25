using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DiskSegmentManager : MonoBehaviour
{
    [SerializeField] ObjectSpawner objectSpawner;

    private readonly int SEGMENT_COUNT = 8;
    private Segment[] segments;
    private int currentSegment;

    [SerializeField] GameObject baseSegmentPrefab;
    [SerializeField] GameObject emptySegmentPrefab;

    [SerializeField, Range(0f, 1f)] float segmentEmptyChance = .2f; 
    private bool prevSegmentEmpty = false;

    private float spawnHeightOffset;

    bool hasSpawnedCurrentSegment = false;

    private void OnEnable()
    {
        CalculateSpawnHeightOffset();
        segments = new Segment[SEGMENT_COUNT];
        SpawnAndInitializeSegments();
        currentSegment = SEGMENT_COUNT - 1;
    }

    private void Update()
    {
        bool ShouldResetCurrentSegment = segments[currentSegment].CheckZeroCol();
        
        if (ShouldResetCurrentSegment)
        {
            //Debug.Log($"CHANGE UR MESH @ SEGMENT #{currentSegment}: {segments[currentSegment]}");
            SwapSegment(currentSegment);
            currentSegment = (currentSegment - 1 + SEGMENT_COUNT) % SEGMENT_COUNT;
            hasSpawnedCurrentSegment = false;
        }
    }

    private void SwapSegment(int outSegmentIndex)
    {
        if (hasSpawnedCurrentSegment) return;

        hasSpawnedCurrentSegment = true;
        GameObject newSegment = GetRandomNextSegment();
        ReplaceSegment(newSegment, outSegmentIndex);
    }

    private GameObject GetRandomNextSegment()
    {
        if (prevSegmentEmpty || Random.Range(0f, 1f) < segmentEmptyChance)
        {
            prevSegmentEmpty = false;
            return baseSegmentPrefab;
        }
        
        prevSegmentEmpty = true;
        return emptySegmentPrefab;
    }

    private void SpawnAndInitializeSegments()
    {
        for (int i = 0; i < SEGMENT_COUNT; ++i)
        {
            Quaternion rotation = Quaternion.Euler(0f, 360f * i / SEGMENT_COUNT, 0f);
            Vector3 position = transform.position - new Vector3(0f, spawnHeightOffset, 0f);

            segments[i] = Instantiate(baseSegmentPrefab, position, rotation, transform).GetComponent<Segment>();
        }
    }

    private void ReplaceSegment(GameObject prefab, int index)
    {
        Quaternion rotation = Quaternion.Euler(segments[index].transform.eulerAngles);
        Vector3 position = segments[index].transform.position;

        Destroy(segments[index].gameObject);
        segments[index] = Instantiate(baseSegmentPrefab, position, rotation, transform).GetComponent<Segment>();
        objectSpawner.SpawnPlatformObject(transform.parent, rotation.y, position.y);
    }

    /// <summary>
    /// temp spawn object to get y displacement
    /// ensure that top of base plane is y = 0
    /// </summary>
    private void CalculateSpawnHeightOffset()
    {
        GameObject temp = Instantiate(baseSegmentPrefab);
        spawnHeightOffset = temp.GetComponent<Renderer>()?.bounds.max.y ?? 1f;
        Destroy(temp);
    }
}
