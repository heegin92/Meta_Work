using UnityEngine;
using UnityEngine.SceneManagement; // 씬 관리를 위해 이 네임스페이스를 추가해야 합니다!

public class MinigameTrigger : MonoBehaviour
{
    // 로드할 미니게임 씬의 이름을 유니티 인스펙터에서 설정합니다.
    public string miniGameSceneName;

    // 이 트리거에 닿을 '플레이어'의 태그를 설정합니다.
    public string playerTag = "Player";

    // 이 트리거가 한 번만 작동하도록 할지 여부 (선택 사항)
    public bool triggerOnce = true;
    private bool hasTriggered = false; // 한 번 작동했는지 추적하는 변수

    // 다른 콜라이더가 이 트리거 안에 진입했을 때 호출됩니다.
    private void OnTriggerEnter2D(Collider2D other) // 2D 게임의 경우
    // private void OnTriggerEnter(Collider other) // 3D 게임의 경우
    {
        // 진입한 오브젝트의 태그가 플레이어 태그와 일치하는지 확인
        // 그리고 triggerOnce가 true일 경우, 아직 트리거되지 않았다면
        if (other.CompareTag(playerTag) && (!triggerOnce || !hasTriggered))
        {
            Debug.Log($"플레이어가 미니게임 트리거 영역에 진입했습니다! {miniGameSceneName} 씬 로드 시도.");

            // 로드할 씬 이름이 비어있지 않은지 확인
            if (!string.IsNullOrEmpty(miniGameSceneName))
            {
                // 미니게임 씬 로드
                SceneManager.LoadScene(miniGameSceneName);

                // 한 번만 트리거되도록 설정했다면, hasTriggered를 true로 설정
                if (triggerOnce)
                {
                    hasTriggered = true;
                }
            }
            else
            {
                Debug.LogWarning("로드할 미니게임 씬 이름이 MinigameTrigger 스크립트에 할당되지 않았습니다!");
            }
        }
    }

    // 플레이어가 트리거 영역에서 나갔을 때 호출됩니다.
    private void OnTriggerExit2D(Collider2D other)
    {
        // 만약 트리거가 한 번만 작동하도록 설정되어 있지 않다면,
        // 플레이어가 나가면 트리거를 리셋하여 다시 진입 시 작동하게 합니다.
        if (other.CompareTag(playerTag) && !triggerOnce)
        {
            hasTriggered = false; // 트리거 리셋
            Debug.Log("플레이어가 미니게임 트리거 영역에서 나갔습니다. 트리거 리셋.");
        }
    }

    // 씬이 로드될 때마다 hasTriggered를 초기화하려면 이 메서드를 사용할 수 있습니다.
    // (예: 플레이어가 메인 씬으로 돌아올 때 트리거를 다시 활성화하고 싶을 때)
    void OnEnable()
    {
        // 씬 로드 완료 시 호출될 이벤트에 메서드 등록
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // 오브젝트 비활성화 시 이벤트 등록 해제 (메모리 누수 방지)
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 현재 씬이 메인 씬이라면 (또는 트리거가 있는 씬이라면)
        // hasTriggered를 초기화하여 다시 작동할 수 있게 합니다.
        // 이 부분은 게임의 흐름에 따라 조절해야 합니다.
        // 예: if (scene.name == "MainGameScene") { hasTriggered = false; }
    }
}