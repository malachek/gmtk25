using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;

    public void Attack(float Dg, bool isCW)
    {
        Projectile projectile = Instantiate(projectilePrefab).transform.GetChild(0).GetComponentInChildren<Projectile>();
        projectile.Initialize(Dg, transform.position.y, isCW);
        //AudioManager.instance.PlayOneShot(FMODEvents.instance.BubbleShoot, this.transform.position);
    }
}
