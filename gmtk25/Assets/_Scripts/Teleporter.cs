using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public bool TpUp;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        other.transform.parent?.parent?.parent?.GetComponent<PlayerJump>()?.TeleportUpDown(TpUp);
    }
}
