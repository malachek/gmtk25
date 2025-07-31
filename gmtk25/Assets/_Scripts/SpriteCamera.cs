using UnityEngine;

public class SpriteCamera : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;

    private void LateUpdate()
    {
        transform.LookAt()
    }
}
