using UnityEngine;

public class EffectTrigger : MonoBehaviour
{
    public GameObject effectPrefab;
    public string playerTag = "Player";
    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag) && !hasTriggered)
        {
            Debug.Log("플레이어가 이펙트 트리거 영역에 진입했습니다! 이펙트 생성 시도.");

            if (effectPrefab != null)
            {
                // 이펙트 오브젝트를 생성하고 참조를 가져옵니다.
                GameObject spawnedEffectObject = Instantiate(effectPrefab, other.transform.position, Quaternion.identity); // 플레이어 위치에서 생성하도록 변경 권장

                // 생성된 오브젝트에서 ParticleSystem 컴포넌트를 가져옵니다.
                ParticleSystem ps = spawnedEffectObject.GetComponent<ParticleSystem>();

                if (ps != null)
                {
                    ps.Play(); // 명시적으로 파티클 시스템 재생 명령
                    Debug.Log("이펙트 파티클 시스템 재생 명령 호출됨!");
                }
                else
                {
                    Debug.LogWarning("생성된 이펙트 프리팹에 ParticleSystem 컴포넌트가 없습니다!");
                }

                // 이펙트가 한 번 터졌음을 기록
                hasTriggered = true;

                // 이펙트가 끝난 후 오브젝트 제거 (선택 사항, 필요하다면 추가)
                // Destroy(spawnedEffectObject, ps.main.duration); // 이펙트 지속 시간만큼 기다린 후 제거
            }
            else
            {
                Debug.LogWarning("이펙트 프리팹이 할당되지 않았습니다! 인스펙터를 확인하세요.");
            }
        }
    }

    // 다른 콜라이더가 이 트리거에서 나갔을 때 호출됩니다.
    private void OnTriggerExit2D(Collider2D other)
    {
        // 나가는 오브젝트의 태그가 플레이어 태그와 일치한다면
        if (other.CompareTag(playerTag))
        {
            Debug.Log("플레이어가 이펙트 트리거 영역에서 나갔습니다. 트리거 리셋.");
            // hasTriggered 변수를 false로 리셋하여 다음 진입 시 이펙트가 다시 터지도록 합니다.
            hasTriggered = false;
        }
    }
}

