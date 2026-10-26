using UnityEngine;

// 일정 간격마다 공중의 랜덤 위치에 Sphere를 만들어 중력으로 떨어뜨린다.
public class BallSpawner : MonoBehaviour
{
    [SerializeField] private float spawnInterval = 3f;
    [SerializeField] private float spawnHeight = 10f;
    [SerializeField] private float spawnRange = 4.5f; // Ground(10x10) 안쪽 범위
    [SerializeField] private float ballSize = 1f;
    [SerializeField] private Material ballMaterial;

    private float timer;

    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.IsGameOver) return;

        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer -= spawnInterval;
            SpawnBall();
        }
    }

    void SpawnBall()
    {
        Vector3 pos = new Vector3(
            Random.Range(-spawnRange, spawnRange),
            spawnHeight,
            Random.Range(-spawnRange, spawnRange));

        GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        ball.name = "Ball";
        ball.transform.position = pos;
        ball.transform.localScale = Vector3.one * ballSize;
        if (ballMaterial != null)
        {
            ball.GetComponent<Renderer>().sharedMaterial = ballMaterial;
        }

        Rigidbody rb = ball.AddComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic; // 빠르게 떨어져도 통과하지 않게
        ball.AddComponent<Obstacle>();
    }
}
