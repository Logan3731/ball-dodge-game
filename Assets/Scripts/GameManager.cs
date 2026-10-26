using UnityEngine;
using UnityEngine.UI;

// 생존시간 측정/표시와 Game Over 상태를 관리한다.
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private Text timeText;
    [SerializeField] private GameObject gameOverText; // Game Over 때 화면 가운데에 보여줄 문구

    public bool IsGameOver { get; private set; }
    private float survivalTime;

    void Awake()
    {
        Instance = this;
        if (gameOverText != null) gameOverText.SetActive(false);
    }

    void Update()
    {
        if (IsGameOver) return;

        survivalTime += Time.deltaTime;
        if (timeText != null)
        {
            timeText.text = "Time: " + survivalTime.ToString("F1") + "s";
        }
    }

    public void GameOver()
    {
        if (IsGameOver) return; // 여러 공에 동시에 닿아도 한 번만 처리
        IsGameOver = true;
        Debug.Log("Game Over");
        if (gameOverText != null) gameOverText.SetActive(true);
    }
}
