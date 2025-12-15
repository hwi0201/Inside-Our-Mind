using UnityEngine;

public class OrbColorManager : MonoBehaviour
{
    // 감정 수집 여부를 기억하는 체크박스들
    public bool hasJoy = false;
    public bool hasSadness = false;
    public bool hasDisgust = false;

    private bool isRainbowMode = false;
    private Renderer orbRenderer;

    void Start()
    {
        orbRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (isRainbowMode)
        {
            float hue = Mathf.PingPong(Time.time * 0.5f, 1f); 
            Color rainbow = Color.HSVToRGB(hue, 1f, 1f);
            UpdateColor(rainbow);
        }
    }

    // 색상 변경 내부 함수
    void UpdateColor(Color newColor)
    {
        if(orbRenderer == null) orbRenderer = GetComponent<Renderer>();
        orbRenderer.material.color = newColor;
        orbRenderer.material.SetColor("_EmissionColor", newColor);
    }

    // 외부에서 호출할 함수: 감정 추가하기
    public void AddEmotion(string emotionType)
    {
        // 1. 감정 기록 및 색상 변경
        if (emotionType == "Joy") 
        {
            hasJoy = true;
            isRainbowMode = false; // 무지개 끄고
            UpdateColor(Color.yellow); // 노랑으로
        }
        else if (emotionType == "Sadness") 
        {
            hasSadness = true;
            isRainbowMode = false;
            UpdateColor(Color.blue);
        }
        else if (emotionType == "Disgust") 
        {
            hasDisgust = true;
            // 까칠만 깼을 땐 일단 초록으로
            isRainbowMode = false;
            UpdateColor(Color.green);
        }

        // 3개 다 모았는지 체크
        CheckAllCollected();
    }

    void CheckAllCollected()
    {
        // 3개가 전부 True라면? 무지개 모드 발동
        if (hasJoy && hasSadness && hasDisgust)
        {
            Debug.Log("무지개 모드");
            isRainbowMode = true;
        }
    }
}