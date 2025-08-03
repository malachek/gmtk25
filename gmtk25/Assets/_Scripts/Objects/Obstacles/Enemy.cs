using UnityEngine;

public class Enemy : ObstacleBase
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PlayerProjectile"))
        {
            transform.localScale = startScale * Calculator.PowerToScale(--powerLevel);
            Destroy(other);
            if (powerLevel <= 0)
                Destroy(gameObject);
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
