using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class GameManager : MonoBehaviour
{
    // �迭�� ������ �������� ������ ����
    // GameManager �ν����� â���� ���� ���� ����
    public GameObject[] falling_ItemPrefabs;

    // ��ü Ǯ���� ���� ObjectPool �ν��Ͻ�
    public ObjectPool objectPool;

    private void Awake()
    {
        // ������ 60���� ����
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        // �޼��� �ݺ� ȣ�� Ű���� ( FallingObject / 0.0f�� ������ / 1.0f�� �ݺ� )
        InvokeRepeating("FallingObject", 0.0f, 1.0f);

        // RandomItem �޼��带 ȣ�� / ���� ���� 3�� �ڿ� ���� ������ ���� / 5�ʸ��� ���� ������ ����
        // �������� ũ�� or ù ���� �ð��� �����Ͽ� ������Ʈ�� ��ġ�� �ʰ� �� �� �ֽ��ϴ�.
        InvokeRepeating("RandomItem", 3.0f, 5.0f);
    }

    private void FallingObject()
    {        
        GameObject obj = objectPool.GetPooledObject();      // Ǯ���� ��Ȱ��ȭ�� obj�� �޾ƿ���
        if (obj != null)                                    // obj�� null�� �ƴϸ�
        {
            obj.SetActive(true);                            // obj Ȱ��ȭ
        }
    }

    private void RandomItem()
    {
        // ������ �����͸� �����ϴ� randomNumber���� ����
        // Random.Range(0, N) => 0���� N-1 ���� �� �� �ϳ� ����
        // Random.Range(0, 3) => 0, 1, 2 �߿��� �ϳ� ���� ����
        int randomNumber = Random.Range(0, falling_ItemPrefabs.Length);

        // randomItemPrefab ���ӿ�����Ʈ ����
        // �ش� ������Ʈ�� �����ϰ� ������ ItemPrefab ������ ����
        GameObject randomItemPrefab = falling_ItemPrefabs[randomNumber];

        // �����ϰ� ������ ������ �������� ����
        Instantiate(randomItemPrefab);
    }
}
