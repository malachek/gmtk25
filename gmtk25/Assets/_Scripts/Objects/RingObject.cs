using UnityEngine;

public class RingObject : MonoBehaviour
{
    //public float GetQuadrant();

    public float YPos;
    public float initXWidth;
    public float initYHeight;

    SpriteRenderer spriteRenderer;
    Renderer realRenderer;

    public float rDistance;
    public float degreeXWidth;

    protected virtual void Awake()
    {
        
    }


    public void Initialize(float spawnDegree, float spawnHeight)
    {
        if (gameObject.transform.parent != null)
            rDistance = gameObject.transform.parent.localPosition.x;
        else
            rDistance = gameObject.transform.GetChild(0).localPosition.x;

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        realRenderer = GetComponentInChildren<Renderer>();

        if (spriteRenderer != null)
        {
            initXWidth = spriteRenderer.bounds.size.x;
            initYHeight = spriteRenderer.bounds.size.y;
        }
        if (realRenderer != null)
        {
            initXWidth = realRenderer.bounds.size.x;
            initYHeight = realRenderer.bounds.size.y;
        }

        degreeXWidth = initXWidth * 180f / (Mathf.PI * rDistance);
        //Debug.Log($"{degreeXWidth} wide in degrees");

        YPos = transform.position.y;
    }

    protected virtual void OnEnable()
    {
        //Debug.Log("Pooling " + this);
        ObjectPooler.Instance?.RegisterObject(this);
    }
    protected virtual void OnDisable()
    {
        //Debug.Log("UnPooling " + this);
        ObjectPooler.Instance?.DeregisterObject(this);
    }

    public float GetDegrees()
    {
        float deg = (transform.rotation.eulerAngles.y + 90) % 360f;
        return (deg + 360f) % 360f;
    }
    public virtual float GetYHeight() => initYHeight;
    public virtual float GetXWidth() => degreeXWidth;

}
