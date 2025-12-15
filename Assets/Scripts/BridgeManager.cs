using UnityEngine;

public class BridgeManager : MonoBehaviour
{
    [Header("다리 오브젝트")]
    public GameObject brokenBridge; // 끊어진 다리 (처음에 켜져있음)
    public GameObject fixedBridge;  // 완성된 다리 (처음에 꺼져있음)

    [Header("쿠쿠궁 연출")]
    public AudioSource bridgeSoundSource; // 효과음 틀어줄 스피커
    public AudioClip bridgeRumbleSound;   // "쿠쿠궁!" 하는 소리 파일
    public GameObject dustEffects;        // 다리 생길 때 먼지/빛 파티클 (선택)

    // 외부(소켓이나 버튼)에서 이 함수를 실행하면 다리가 생김
    public void RestoreBridge()
    {
        Debug.Log("다리 복구 시작! 쿠쿠궁!");

        // 1. 다리 교체 (끊어진 거 끄고, 새거 켜고)
        if (brokenBridge != null) brokenBridge.SetActive(false);
        if (fixedBridge != null) fixedBridge.SetActive(true);

        // 2. 파티클 효과 (있으면 켜기)
        if (dustEffects != null) dustEffects.SetActive(true);

        // 3. ★ 핵심: 효과음 재생
        if (bridgeSoundSource != null && bridgeRumbleSound != null)
        {
            bridgeSoundSource.PlayOneShot(bridgeRumbleSound);
        }
    }
}