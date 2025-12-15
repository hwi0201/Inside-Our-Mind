using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public GameObject brokenBridge;
    public GameObject fixedBridge;  

    // 소켓이 몇 개 찼는지
    private int socketCount = 0;

    public void OnSocketFilled()
    {
        socketCount = socketCount + 1;

        // 만약 카운트가 3개가 되면
        if (socketCount >= 3)
        {
            // 다리를 복구
            brokenBridge.SetActive(false); // 무너진 다리 숨기기
            fixedBridge.SetActive(true);   // 복구된 다리 보여주기
        }
    }
}