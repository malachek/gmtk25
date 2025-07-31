using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    [Header("Kinematics")]
    [SerializeField] float jumpForce;
    [SerializeField] float gravity;
    [SerializeField] float fallMultiplier;

    [Space(10), Header("Jump Details")]
    [SerializeField] float maxJumpTime;
    [SerializeField] float groundY = 0f;

    private float jumpTimeCounter = 0f;
    private bool isJumpHeld = false;
    private float yVelocity = 0f;
    private bool IsGrounded;

    void Update()
    {
        Gravity();    
        MoveY();
        GroundClamp();
    }

    private void Gravity()
    {
        if (!IsGrounded)
        {
            bool isFalling = !isJumpHeld || yVelocity < 0f;
            yVelocity += gravity * Time.deltaTime * (isFalling ? fallMultiplier : 1f);
        }
    }

    private void MoveY()
    {
        transform.position += Vector3.up * yVelocity * Time.deltaTime;
    }

    private void GroundClamp()
    {
        if (transform.position.y <= groundY)
        {
            IsGrounded = true;
            isJumpHeld = false;

            yVelocity = 0f;

            Vector3 pos = transform.position;
            pos.y = groundY;
            transform.position = pos;
        }
        else
        {
            IsGrounded = false;
        }
    }

    public void StartJump()
    {
        if (IsGrounded || !IsGrounded && yVelocity < 0f && transform.position.y < .1f)
        {
            isJumpHeld = true;
            jumpTimeCounter = maxJumpTime;
            yVelocity = jumpForce;
            IsGrounded = false;
            Debug.Log("Start Jump");
            return;
        }
    }
    public void HoldJump()
    {
        if (isJumpHeld)
        {
            if (jumpTimeCounter > 0f)
            {
                if (jumpTimeCounter < maxJumpTime * .8f)
                {
                    yVelocity = jumpForce;
                }
                jumpTimeCounter -= Time.deltaTime;
                Debug.Log("Continue Jump");
            }
            else
            {
                isJumpHeld = false;
            }
        }
    }
    public void EndJump()
    {
        isJumpHeld = false;
        Debug.Log("End Jump");
        return;
    }

}
