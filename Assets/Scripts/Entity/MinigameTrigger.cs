using UnityEngine;
using UnityEngine.SceneManagement; // �� ������ ���� �� ���ӽ����̽��� �߰��ؾ� �մϴ�!

public class MinigameTrigger : MonoBehaviour
{
    // �ε��� �̴ϰ��� ���� �̸��� ����Ƽ �ν����Ϳ��� �����մϴ�.
    public string miniGameSceneName;

    // �� Ʈ���ſ� ���� '�÷��̾�'�� �±׸� �����մϴ�.
    public string playerTag = "Player";

    // �� Ʈ���Ű� �� ���� �۵��ϵ��� ���� ���� (���� ����)
    public bool triggerOnce = true;
    private bool hasTriggered = false; // �� �� �۵��ߴ��� �����ϴ� ����

    // �ٸ� �ݶ��̴��� �� Ʈ���� �ȿ� �������� �� ȣ��˴ϴ�.
    private void OnTriggerEnter2D(Collider2D other) // 2D ������ ���
    // private void OnTriggerEnter(Collider other) // 3D ������ ���
    {
        // ������ ������Ʈ�� �±װ� �÷��̾� �±׿� ��ġ�ϴ��� Ȯ��
        // �׸��� triggerOnce�� true�� ���, ���� Ʈ���ŵ��� �ʾҴٸ�
        if (other.CompareTag(playerTag) && (!triggerOnce || !hasTriggered))
        {
            Debug.Log($"�÷��̾ �̴ϰ��� Ʈ���� ������ �����߽��ϴ�! {miniGameSceneName} �� �ε� �õ�.");

            // �ε��� �� �̸��� ������� ������ Ȯ��
            if (!string.IsNullOrEmpty(miniGameSceneName))
            {
                // �̴ϰ��� �� �ε�
                SceneManager.LoadScene(miniGameSceneName);

                // �� ���� Ʈ���ŵǵ��� �����ߴٸ�, hasTriggered�� true�� ����
                if (triggerOnce)
                {
                    hasTriggered = true;
                }
            }
            else
            {
                Debug.LogWarning("�ε��� �̴ϰ��� �� �̸��� MinigameTrigger ��ũ��Ʈ�� �Ҵ���� �ʾҽ��ϴ�!");
            }
        }
    }

    // �÷��̾ Ʈ���� �������� ������ �� ȣ��˴ϴ�.
    private void OnTriggerExit2D(Collider2D other)
    {
        // ���� Ʈ���Ű� �� ���� �۵��ϵ��� �����Ǿ� ���� �ʴٸ�,
        // �÷��̾ ������ Ʈ���Ÿ� �����Ͽ� �ٽ� ���� �� �۵��ϰ� �մϴ�.
        if (other.CompareTag(playerTag) && !triggerOnce)
        {
            hasTriggered = false; // Ʈ���� ����
            Debug.Log("�÷��̾ �̴ϰ��� Ʈ���� �������� �������ϴ�. Ʈ���� ����.");
        }
    }

    // ���� �ε�� ������ hasTriggered�� �ʱ�ȭ�Ϸ��� �� �޼��带 ����� �� �ֽ��ϴ�.
    // (��: �÷��̾ ���� ������ ���ƿ� �� Ʈ���Ÿ� �ٽ� Ȱ��ȭ�ϰ� ���� ��)
    void OnEnable()
    {
        // �� �ε� �Ϸ� �� ȣ��� �̺�Ʈ�� �޼��� ���
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // ������Ʈ ��Ȱ��ȭ �� �̺�Ʈ ��� ���� (�޸� ���� ����)
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // ���� ���� ���� ���̶�� (�Ǵ� Ʈ���Ű� �ִ� ���̶��)
        // hasTriggered�� �ʱ�ȭ�Ͽ� �ٽ� �۵��� �� �ְ� �մϴ�.
        // �� �κ��� ������ �帧�� ���� �����ؾ� �մϴ�.
        // ��: if (scene.name == "MainGameScene") { hasTriggered = false; }
    }
}