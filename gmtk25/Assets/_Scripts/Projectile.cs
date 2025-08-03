using UnityEngine;

public class Projectile : ObstacleBase
{
    [SerializeField] float VelocityDg;
    [SerializeField] Transform rootTransform;


    [SerializeField] BoxCollider col;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        col.enabled = false;
        Invoke("EnableCol", 1f);
    }

    private void EnableCol()
    {
        col.enabled = true;
    }
    public void Initialize(float _dg, float _yPos, bool _isCW)
    {
        base.Initialize();
        rootTransform.position = new Vector3(0f, _yPos, 0f);
        Debug.Log((_dg + 270f) % 360f);
        rootTransform.rotation = Quaternion.Euler(0, (_dg + 270f) % 360f, 0);
        if (_isCW) VelocityDg *= -1f;
    }

    private void Update()
    {
        rootTransform.Rotate(Vector3.up * VelocityDg * Time.deltaTime, Space.Self);
    }
}
