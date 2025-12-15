using UnityEngine;

public class ItemReset : MonoBehaviour
{
    private Vector3 startPos;       // 태어난 위치
    private Quaternion startRot;    // 태어난 회전값(각도)
    private Rigidbody rb;

    void Start()
    {
        // 시작하자마자 "아, 나 여기 있었지" 하고 기억해둠
        startPos = transform.position;
        startRot = transform.rotation;
        rb = GetComponent<Rigidbody>();
    }

    // 쓰레기통이 "돌아가!" 하면 실행되는 함수
    public void ResetPosition()
    {
        // 1. 날아가던 물리 힘(속도)을 0으로 만듦 (안 그러면 튕겨 나감)
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        // 2. 원래 위치로 순간이동
        transform.position = startPos;
        transform.rotation = startRot;
    }
}