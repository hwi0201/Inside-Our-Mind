using UnityEngine;

public class SpongeLogic : MonoBehaviour
{
    public float cleanSpeed = 0.8f; // 닦이는 속도

    // 물체와 겹쳐있는 동안 계속 실행되는 함수
    private void OnTriggerStay(Collider other)
    {
        // 1. 태그가 "DirtySurface"인 얼룩만 닦음
        if (other.CompareTag("DirtySurface"))
        {
            Renderer dirtRenderer = other.GetComponent<Renderer>();
            
            // 안전장치: 렌더러가 없으면 무시
            if(dirtRenderer == null) return;

            Color color = dirtRenderer.material.color;

            // 2. 아직 투명하지 않다면? -> 점점 투명하게 만듦
            if (color.a > 0)
            {
                // 알파값 감소
                color.a -= cleanSpeed * Time.deltaTime;
                dirtRenderer.material.color = color;
            }
            // 3. 완전히 투명해졌다면? -> 삭제하고 점수 추가!
            else
            {
                // 더러운 판 삭제
                Destroy(other.gameObject);

                // 매니저를 찾아서 "1개 닦았습니다!" 보고하기
                SadnessRoomManager manager = FindObjectOfType<SadnessRoomManager>();
                if (manager != null)
                {
                    // [핵심] 바로 클리어하지 않고, 점수만 1점 올림
                    manager.AddCleanScore(); 
                }
            }
        }
    }
}