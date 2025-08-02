using UnityEngine;

public class RingCollision : MonoBehaviour
{
    public static RingCollision instance;



    private void Awake()
    {
        if(instance == null && instance != this)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }
}
