using UnityEngine;

public class SimpleCharacterController : MonoBehaviour
{
    public float speed = 5f; // 이동 속도
    private Rigidbody rb;
    public Animator animator;

    private float moveSpeed = 0f; // 애니메이터에 전달할 MoveSpeed 변수

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // A, D 또는 좌우 화살표
        float moveVertical = Input.GetAxis("Vertical");   // W, S 또는 상하 화살표

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized * speed;

        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z); // Y축 속도는 그대로 유지

        // 움직임이 있으면 MoveSpeed 증가
        if (moveHorizontal != 0 || moveVertical != 0)
        {
            moveSpeed += 0.5f;
        }
        else
        {
            moveSpeed = 0f; // 멈추면 0으로 초기화
        }

        // MoveSpeed 값을 애니메이터에 적용
        animator.SetFloat("MoveSpeed", moveSpeed);
    }
}
