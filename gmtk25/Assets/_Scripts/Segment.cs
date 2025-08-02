using UnityEngine;

public class Segment : MonoBehaviour
{
    public bool CheckZeroCol()
    {
        return (transform.rotation.eulerAngles.y > 356f || transform.rotation.eulerAngles.y < 5f);
    }
}
