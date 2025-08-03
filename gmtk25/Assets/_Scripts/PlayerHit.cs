using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerProjectile"))
        {
            transform.parent.parent.parent.GetComponent<PlayerRotation>().PushBack(40f);
            Destroy(other.gameObject);
        }
    }
}
