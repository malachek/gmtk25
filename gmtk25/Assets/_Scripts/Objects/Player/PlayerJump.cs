using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    [Header("Kinematics")]
    [SerializeField] float jumpForce;
    [SerializeField] float gravity;
    [SerializeField] float fallMultiplier;

    [SerializeField] public GameObject PlayerSoundSource;

    [Space(10), Header("Jump Details")]
    [SerializeField] float maxJumpTime;
    public float groundY { get; private set; } = 4f;

    private float jumpTimeCounter = 0f;
    private bool isJumpHeld = false;
    private float yVelocity = 0f;
    public bool IsGrounded { get; private set; }

    [SerializeField] Animator animator;
    [SerializeField] RingCollision collision;

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

    public void SetGroundY(float _groundY)
    {
        if (_groundY == groundY)
            return;

        if (_groundY > groundY)
            IsGrounded = false;

        groundY = _groundY;
    }

    private void MoveY()
    {
        transform.position += Vector3.up * yVelocity * Time.deltaTime;
    }

    private void GroundClamp()
    {
        if (transform.position.y <= groundY)
        {
            if (IsGrounded && !isJumpHeld) return;
            IsGrounded = true;
            isJumpHeld = false;

            yVelocity = 0f;

            Vector3 pos = transform.position;
            pos.y = groundY;
            transform.position = pos;
            animator.Play("Idle");

        }
        else
        {
            if (transform.position.y >= groundY + 4f && transform.position.y <= 9f)
                SetGroundY(groundY + 4f);
            IsGrounded = false;
            animator.Play("Jump");
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
            AudioManager.instance.PlayOneShot(FMODEvents.instance.FrogJump, PlayerSoundSource.transform.position);
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
                //Debug.Log("Continue Jump");
            }
            else
            {
                isJumpHeld = false;
            }
        }
    }

    public void Fall(float floorToBeFake)
    {
        if(IsGrounded && groundY == floorToBeFake)
        {
            //SetGroundY(groundY - 4f);
            collision.realGroundY = groundY - 4f;
            IsGrounded = false;
            animator.Play("Attack");
        }
    }
    public void EndJump()
    {
        isJumpHeld = false;
        //Debug.Log("End Jump");
        return;
    }

    public void TeleportUpDown(bool isUp)
    {
        SetGroundY(groundY + 4);
        transform.position += new Vector3(0f, 4f, 0f);
    }

}