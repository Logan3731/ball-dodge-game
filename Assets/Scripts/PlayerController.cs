using UnityEngine;
using UnityEngine.InputSystem;

// WASD로 플레이어를 이동시키고, 공(Obstacle)에 닿으면 Game Over를 알린다.
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody rb;
    private Vector3 input;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // 공에 맞아도 캡슐이 넘어지지 않게
    }

    void Update()
    {
        input = Vector3.zero;
        if (GameManager.Instance != null && GameManager.Instance.IsGameOver) return;

        Keyboard kb = Keyboard.current;
        if (kb == null) return;

        if (kb.wKey.isPressed) input.z += 1f;
        if (kb.sKey.isPressed) input.z -= 1f;
        if (kb.dKey.isPressed) input.x += 1f;
        if (kb.aKey.isPressed) input.x -= 1f;
        input = input.normalized;
    }

    void FixedUpdate()
    {
        if (rb.isKinematic) return;
        rb.MovePosition(rb.position + input * moveSpeed * Time.fixedDeltaTime);
    }

    // 떨어지는 공, 스치는 공은 Enter에서, 이미 붙어 있는 공은 Stay에서 잡는다.
    void OnCollisionEnter(Collision collision) => CheckHit(collision);
    void OnCollisionStay(Collision collision) => CheckHit(collision);

    void CheckHit(Collision collision)
    {
        if (collision.gameObject.GetComponent<Obstacle>() == null) return;
        if (GameManager.Instance == null || GameManager.Instance.IsGameOver) return;

        GameManager.Instance.GameOver();
        // 공에 밀려 움직이지 않도록 물리 영향도 끊는다.
        rb.linearVelocity = Vector3.zero;
        rb.isKinematic = true;
    }
}
