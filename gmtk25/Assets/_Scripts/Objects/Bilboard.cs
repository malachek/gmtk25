using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Bilboard : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    bool isRight = true;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void LateUpdate()
    {
        transform.forward = Camera.main.transform.forward;
        // new(0, 0, -1);
    }

    public void FaceRight(bool _isRight)
    {
        if (isRight == _isRight) return;
        isRight = _isRight;
        spriteRenderer.flipX = !_isRight;
    }
}
