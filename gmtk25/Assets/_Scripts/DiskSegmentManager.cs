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

    [SerializeField] float baseSegmentWeight = 3f;
    [SerializeField] GameObject[] baseSegmentPrefabVariations;

    [SerializeField] float rampSegmentWeight = 1f;
    [SerializeField] GameObject[] rampSegmentPrefabVariations;

    [SerializeField] float holeSegmentWeight = 2f;
    [SerializeField] GameObject[] holeSegmentPrefabVariations;

    private float spawnHeightOffset;

    bool hasSpawnedCurrentSegment = false;

    private void OnEnable()
    {
        CalculateSpawnHeightOffset();
        segments = new Segment[SEGMENT_COUNT];
        SpawnAndInitializeSegments();
        currentSegment = SEGMENT_COUNT - 1;
    }

    private void Start()
    {
        if(!baseSegmentPrefabVariations.Contains(baseSegmentPrefab))
        {
            baseSegmentPrefabVariations.Append(baseSegmentPrefab);
        }
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
        int totalVariations = baseSegmentPrefabVariations.Length + rampSegmentPrefabVariations.Length + holeSegmentPrefabVariations.Length;
        if (totalVariations <= 1)
            return baseSegmentPrefab;

        float nextTypeWeight = Random.Range(0, baseSegmentWeight + rampSegmentWeight + holeSegmentWeight);

        if (nextTypeWeight > baseSegmentWeight + rampSegmentWeight)
        {
            return holeSegmentPrefabVariations[Random.Range(0, holeSegmentPrefabVariations.Length - 1)];
        }
        else if (nextTypeWeight > baseSegmentWeight)
        {
            return rampSegmentPrefabVariations[Random.Range(0, rampSegmentPrefabVariations.Length - 1)];
        }
        else
        {
            return baseSegmentPrefabVariations[Random.Range(0, baseSegmentPrefabVariations.Length - 1)];
        }
    }

    private void SpawnAndInitializeSegments()
    {
        for (int i = 0; i < SEGMENT_COUNT; ++i)
        {
            Quaternion rotation = Quaternion.Euler(90f, 360f * i / SEGMENT_COUNT, 0f);
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
