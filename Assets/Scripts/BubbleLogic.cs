using UnityEngine;

public class BubbleLogic : MonoBehaviour
{
    [Header("움직임 설정")]
    public float moveSpeed = 0.5f;
    public float moveRange = 1.5f;
    public float minHeight = 0.5f;
    public float maxHeight = 9.0f;

    private Vector3 startPos;
    private Vector3 targetPos;

    void Start()
    {
        startPos = transform.position;
        SetNewTarget();
    }

    void Update()
    {
        // 둥둥 떠다니는 로직
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            SetNewTarget();
        }
    }

    void SetNewTarget()
    {
        // 랜덤 이동 로직
        float x = Random.Range(-moveRange, moveRange);
        float y = Random.Range(-moveRange, moveRange);
        float z = Random.Range(-moveRange, moveRange);
        Vector3 potentialTarget = startPos + new Vector3(x, y, z);

        if (potentialTarget.y < minHeight) potentialTarget.y = minHeight + 0.5f;
        if (potentialTarget.y > maxHeight) potentialTarget.y = maxHeight - 0.5f;

        targetPos = potentialTarget;
    }

    // 잡았을 때 호출할 함수
    public void PopByGrab()
    {
        // 점수 추가
        JoyRoomManager manager = FindObjectOfType<JoyRoomManager>();
        if (manager != null)
        {
            manager.AddScore();
        }

        // 펑
        Destroy(gameObject);
    }
}