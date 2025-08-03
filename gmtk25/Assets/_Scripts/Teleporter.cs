using UnityEngine;

public class Teleporter : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
    }
}
