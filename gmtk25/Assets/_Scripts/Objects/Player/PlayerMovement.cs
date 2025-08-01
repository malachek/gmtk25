using UnityEngine;
using UnityEngine.InputSystem;

//[RequireComponent(typeof(PlayerRotation))]
[RequireComponent(typeof(PlayerJump))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] PlayerRotation playerRotation;
    [SerializeField] PlayerJump playerJump;

    public void RotationInputOverride(bool isCW)
    {
        playerRotation.RotationInputOverride(isCW);
    }
    public void SetSprint(bool isSprint)
    {
        playerRotation.SetSprint(isSprint);
    }

    public void StartJump()
    {
        playerJump.StartJump();
    }
    public void HoldJump()
    {
        playerJump.HoldJump();
    }
    public void EndJump()
    {
        playerJump.EndJump();
    }
}
