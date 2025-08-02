using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DiskSegmentManager : MonoBehaviour
{
    private readonly int SEGMENT_COUNT = 8;
    private Segment[] segments;
    private int currentSegment;


    [SerializeField] GameObject baseSegmentPrefab;


    private void OnEnable()
    {
        segments = new Segment[SEGMENT_COUNT];
        SpawnAndInitializeSegments();
        currentSegment = SEGMENT_COUNT - 1;
    }

    private void Update()
    {
        bool ShouldResetCurrentSegment = segments[currentSegment].CheckZeroCol();
        
        if (ShouldResetCurrentSegment)
        {
            Debug.Log($"CHANGE UR MESH @ SEGMENT #{currentSegment}: {segments[currentSegment]}");
            currentSegment = (currentSegment - 1 + SEGMENT_COUNT) % SEGMENT_COUNT;
            //segments[currentSegment].ChangeMeshTo(); 
        }
    }

    private void SpawnAndInitializeSegments()
    {
        // temp spawn object to get y displacement
        // ensure that top of base plane is y = 0
        GameObject temp = Instantiate(baseSegmentPrefab);
        float height = temp.GetComponent<Renderer>()?.bounds.max.y ?? 1f;
        Destroy(temp);


        for (int i = 0; i < SEGMENT_COUNT; ++i)
        {
            Quaternion rotation = Quaternion.Euler(90f, 360f * i / SEGMENT_COUNT, 0f);
            Vector3 position = transform.position - new Vector3(0f, height, 0f);

            segments[i] = Instantiate(baseSegmentPrefab, position, rotation, transform).GetComponent<Segment>();
        }
    }
}
