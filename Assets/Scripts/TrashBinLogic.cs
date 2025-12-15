using UnityEngine;

public class TrashBinLogic : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // 1. 나쁜 물건(Bad) -> 쌓이게 둠!
        if (other.CompareTag("Bad"))
        {
            // B. 점수 추가
            FindObjectOfType<DisgustRoomManager>().AddScore();
            
            other.tag = "Untagged"; 
        }
        
        // 2. 좋은 물건(Good) -> 실패! (제자리 복구) - 이건 그대로 유지
        else if (other.CompareTag("Good"))
        {
            ItemReset resetScript = other.GetComponent<ItemReset>();
            
            if (resetScript != null)
            {
                resetScript.ResetPosition();
            }
        }
    }
}