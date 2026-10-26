using UnityEngine;

// 붙어 있는 오브젝트를 Y축 기준으로 계속 회전시킨다.
public class Rotator : MonoBehaviour
{
    // private이지만 [SerializeField] 덕분에 Inspector에서 값을 바꿀 수 있다.
    // 다른 스크립트가 함부로 값을 바꾸지 못하게 하면서 에디터 조절만 허용하기 위함.
    [SerializeField] private float rotationSpeed = 90f; // 초당 회전 각도(도)

    void Update()
    {
        // Time.deltaTime(직전 프레임 경과 시간)을 곱해 프레임레이트와 무관하게 "초당 90도"가 되도록 한다.
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}
