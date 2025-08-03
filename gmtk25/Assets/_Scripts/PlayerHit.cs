using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    [SerializeField] public GameObject PlayerSoundpoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerProjectile"))
        {
            transform.parent.parent.parent.GetComponent<PlayerRotation>().PushBack(40f);
            AudioManager.instance.PlayOneShot(FMODEvents.instance.BubblePop, PlayerSoundpoint.transform.position);
            AudioManager.instance.PlayOneShot(FMODEvents.instance.FrogCroak, PlayerSoundpoint.transform.position);
            Destroy(other.gameObject);

        }
    }
}
