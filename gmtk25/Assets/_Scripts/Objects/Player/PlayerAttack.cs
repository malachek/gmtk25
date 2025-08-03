using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;

    float attackTimerMax = .5f;
    float attackTimer = 0f;

    private void Update()
    {
        attackTimer -= Time.deltaTime;
    }

    public void Attack(float Dg, bool isCW)
    {
        if (attackTimer > 0f) return;

        attackTimer = attackTimerMax;
        Projectile projectile = Instantiate(projectilePrefab).transform.GetChild(0).GetComponentInChildren<Projectile>();
        projectile.Initialize(Dg, transform.position.y, isCW);
        //AudioManager.instance.PlayOneShot(FMODEvents.instance.BubbleShoot, this.transform.position);
    }
}
