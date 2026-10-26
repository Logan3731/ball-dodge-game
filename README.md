# 공 피하기 게임 (Ball Dodge)

하늘에서 떨어지는 공을 피해 최대한 오래 살아남는 간단한 Unity 3D 게임입니다.
Claude Code와 Unity MCP를 이용해 AI와 협업하며 만들었습니다. 결과는 Unity에서 직접 Play하면서 확인하고 고쳤습니다.

## 조작법

| 키 | 동작 |
|---|---|
| W / A / S / D | 앞 / 왼쪽 / 뒤 / 오른쪽 이동 |

## 게임 규칙

- 3초마다 공중의 랜덤한 위치에서 공이 떨어집니다.
- 공에 닿으면 **Game Over**가 됩니다. 떨어지는 공, 스치는 공, 바닥에 멈춰 있는 공 모두 해당합니다.
- 화면 왼쪽 위에 생존시간이 초 단위로 표시됩니다.
- Game Over가 되면 화면 가운데에 `GAME OVER`가 뜨고 이동과 생존시간이 멈춥니다.

## 실행 방법

1. Unity **6000.3.26f1 (Unity 6.3 LTS)** 버전으로 이 폴더를 엽니다.
2. `Assets/Scenes/SampleScene.unity`를 엽니다.
3. Play 버튼을 누릅니다.

## 스크립트 구성

| 파일 | 역할 |
|---|---|
| `Rotator.cs` | 큐브를 Y축 기준 초당 90도로 회전시킵니다(Inspector에서 속도 변경 가능) |
| `PlayerController.cs` | WASD 이동(새 Input System)을 처리하고, 공에 닿으면 Game Over를 알립니다 |
| `BallSpawner.cs` | 3초마다 랜덤 위치에 Rigidbody 공을 만들어 떨어뜨립니다 |
| `GameManager.cs` | 생존시간 UI와 Game Over 상태·문구를 관리합니다 |
| `Obstacle.cs` | 플레이어가 공을 구분하기 위한 표시용 컴포넌트입니다 |

## 사용 도구

- Unity 6.3 LTS (URP)
- Claude Code + [MCP for Unity](https://github.com/CoplayDev/unity-mcp)
