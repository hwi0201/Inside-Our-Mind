using UnityEngine;

public class BodySocketFollower : MonoBehaviour
{
    [Header("필수 연결")]
    public Transform hmdCamera; 

    [Header("위치 조정")]
    [Tooltip("배꼽 높이 (클수록 아래로 내려감)")]
    public float heightOffset = 0.5f; 
    
    [Tooltip("배 앞쪽 거리 (클수록 앞으로 나감)")]
    public float bodyDistance = 0.25f; 

    [Tooltip("좌우 위치 조정 (+는 오른쪽, -는 왼쪽)")]
    public float sideOffset = 0.15f; // [추가된 기능] 기본값 0.15 (오른쪽)

    [Header("부드러움")]
    public float smoothSpeed = 10f; 

    void LateUpdate()
    {
        if (hmdCamera == null) return;

        // 1. [회전] Y축 회전만 가져옴
        float currentYRotation = hmdCamera.eulerAngles.y;
        Quaternion targetRotation = Quaternion.Euler(0, currentYRotation, 0);

        // 2. [위치] 
        Vector3 bodyCenter = hmdCamera.position;
        bodyCenter.y -= heightOffset; // 높이 조절

        // 3. [오프셋 적용] 앞쪽 + 오른쪽(Side) 이동 추가!
        Vector3 finalOffset = (Vector3.forward * bodyDistance) + (Vector3.right * sideOffset);
        
        // 회전 방향에 맞춰서 오프셋 적용
        Vector3 finalPosition = bodyCenter + (targetRotation * finalOffset);

        // 4. [적용]
        transform.position = Vector3.Lerp(transform.position, finalPosition, Time.deltaTime * smoothSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * smoothSpeed);
    }
}