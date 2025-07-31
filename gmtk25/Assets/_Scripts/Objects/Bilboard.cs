using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Bilboard : MonoBehaviour
{
    private void LateUpdate()
    {
        transform.forward = Camera.main.transform.forward;
        // new(0, 0, -1);
    }
}
