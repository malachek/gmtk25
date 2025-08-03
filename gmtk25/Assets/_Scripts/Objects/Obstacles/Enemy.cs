using UnityEngine;

public class Enemy : ObstacleBase
{

    
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PlayerProjectile"))
        {
            transform.localScale = startScale * Calculator.PowerToScale(--powerLevel);
            Destroy(other.gameObject);

            if (powerLevel <= 0)
                Destroy(gameObject);
            AudioManager.instance.PlayOneShot(FMODEvents.instance.BubblePop, this.transform.position);

        }

        if(other.CompareTag("Player"))
        {
            other.transform.parent.parent.parent.GetComponent<PlayerRotation>().PushBack(30f);
        }
        
    }

    protected override void PassedZero()
    {
        transform.localScale = startScale * Calculator.PowerToScale(powerLevel+=2);
    }
}
