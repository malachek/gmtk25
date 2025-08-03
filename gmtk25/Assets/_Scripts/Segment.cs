using UnityEngine;

public class Segment : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    private void OnEnable()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    public bool CheckZeroCol()
    {
        return (transform.rotation.eulerAngles.y > 356f || transform.rotation.eulerAngles.y < 5f);
    }

    public void EnableMesh(bool enable)
    {
        meshRenderer.enabled = enable;
    }
}
