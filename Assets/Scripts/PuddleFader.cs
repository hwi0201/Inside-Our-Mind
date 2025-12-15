using UnityEngine;
using System.Collections;

public class PuddleFader : MonoBehaviour
{
    public float fadeDuration = 7.0f; // 7초 동안 나타남
    public float targetAlpha = 0.8f;  // 최종 투명도
    
    private Renderer rend;
    private Collider col; // 콜라이더 (처음엔 꺼둘 것임)

    void Awake()
    {
        rend = GetComponent<Renderer>();
        col = GetComponent<Collider>();
        
        // 시작하자마자 투명하게 만듦 (Alpha = 0)
        if (rend != null)
        {
            Color c = rend.material.color;
            c.a = 0f;
            rend.material.color = c;
        }

        // 물이 차기 전엔 염색 기능 꺼두기
        if (col != null) col.enabled = false;
    }

    // 오브젝트가 켜질 때 자동으로 실행됨
    void OnEnable()
    {
        StartCoroutine(FadeInRoutine());
    }

    IEnumerator FadeInRoutine()
    {
        float timer = 0f;
        Color startColor = rend.material.color;
        
        // 7초 동안 서서히 루프
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            
            // 0 -> 목표값까지 서서히 증가
            float newAlpha = Mathf.Lerp(0f, targetAlpha, timer / fadeDuration);
            
            // 색상 적용
            Color newColor = startColor;
            newColor.a = newAlpha;
            rend.material.color = newColor;

            yield return null; // 한 프레임 대기
        }

        // 끝! 물이 다 찼으니 이제 구슬 닿으면 염색되게 켜줌
        if (col != null) col.enabled = true;
    }
}