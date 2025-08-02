using UnityEngine;

public class disc_generation : MonoBehaviour
{
    [SerializeField] 

    private GameObject[] segments;
    private int nextSegmentToZero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        //spawn the segments

    }
    void Start()
    {
        //nextSegmentToZero = segments[0];
    }

    // Update is called once per frame
    void Update()
    {
        //int num = UnityEngine.Random.Range(0, segments.Length - 1);
        //int num2 = UnityEngine.Random.Range(0, 1);
        //UpdateSlice(num2 != 0, num);
    }

    public void UpdateSlice(bool show, int segment)
    {
        Debug.Log(show.ToString() + " " + segment.ToString());
        segments[segment].SetActive(show);
    }

}