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
            Debug.Log("�÷��̾ ����Ʈ Ʈ���� ������ �����߽��ϴ�! ����Ʈ ���� �õ�.");

            if (effectPrefab != null)
            {
                // ����Ʈ ������Ʈ�� �����ϰ� ������ �����ɴϴ�.
                GameObject spawnedEffectObject = Instantiate(effectPrefab, other.transform.position, Quaternion.identity); // �÷��̾� ��ġ���� �����ϵ��� ���� ����

                // ������ ������Ʈ���� ParticleSystem ������Ʈ�� �����ɴϴ�.
                ParticleSystem ps = spawnedEffectObject.GetComponent<ParticleSystem>();

                if (ps != null)
                {
                    ps.Play(); // ��������� ��ƼŬ �ý��� ��� ���
                    Debug.Log("����Ʈ ��ƼŬ �ý��� ��� ��� ȣ���!");
                }
                else
                {
                    Debug.LogWarning("������ ����Ʈ �����տ� ParticleSystem ������Ʈ�� �����ϴ�!");
                }

                // ����Ʈ�� �� �� �������� ���
                hasTriggered = true;

                // ����Ʈ�� ���� �� ������Ʈ ���� (���� ����, �ʿ��ϴٸ� �߰�)
                // Destroy(spawnedEffectObject, ps.main.duration); // ����Ʈ ���� �ð���ŭ ��ٸ� �� ����
            }
            else
            {
                Debug.LogWarning("����Ʈ �������� �Ҵ���� �ʾҽ��ϴ�! �ν����͸� Ȯ���ϼ���.");
            }
        }
    }

    // �ٸ� �ݶ��̴��� �� Ʈ���ſ��� ������ �� ȣ��˴ϴ�.
    private void OnTriggerExit2D(Collider2D other)
    {
        // ������ ������Ʈ�� �±װ� �÷��̾� �±׿� ��ġ�Ѵٸ�
        if (other.CompareTag(playerTag))
        {
            Debug.Log("�÷��̾ ����Ʈ Ʈ���� �������� �������ϴ�. Ʈ���� ����.");
            // hasTriggered ������ false�� �����Ͽ� ���� ���� �� ����Ʈ�� �ٽ� �������� �մϴ�.
            hasTriggered = false;
        }
    }
}

