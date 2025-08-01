using UnityEngine;

public class disc_generation : MonoBehaviour
{

    [SerializeField] GameObject[] segments;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
