using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGenerator : MonoBehaviour
{

    public GameObject[] propPrefabs; // instantiate로 찍어낼 프롭이 여러개인데 원본이 필요함

    private BoxCollider area;

    public int count = 100; //100개의 프롭

    private List<GameObject> props = new List<GameObject>();    // 프롭을 다시 생성하는게 아니라 껐다가 켜는 방식을 사용 , 렉걸림     


    void Start()
    {
        area = GetComponent<BoxCollider>();

        for(int i= 0; i<count; i++)
        {
            // 생성용 함수
            Spawn(); // 한번 spawn해주면 정해진 갯수의 프롭들을 찍어내고 시작
        }

        area.enabled = false; // 위에서 말한 인스펙터 창에서 꺼준것.
    }

    private void Spawn()
    {
        int selection = Random.Range(0, propPrefabs.Length);

        GameObject selectedPrefab = propPrefabs[selection];

        Vector3 spawnPos = GetRandomPosition();

        GameObject instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);     // Quaternion.identity 0,0,0의 회전
        props.Add(instance); // 리스트에 등록해주고
        
    }

    private Vector3 GetRandomPosition() // 설정한 boxcollider 범위내에서 randomposition으로 가져올수있
    {
        Vector3 basePosition = transform.position;
        Vector3 size = area.size;

        float posX = basePosition.x + Random.Range(-size.x / 2f, size.x / 2f);

        float posY = basePosition.y + Random.Range(-size.y / 2f, size.y / 2f);

        float posZ = basePosition.z + Random.Range(-size.z / 2f, size.z / 2f);

        Vector3 spawnPos = new Vector3(posX, posY, posZ);

        return spawnPos;
    }

    void Update()
    {
        
    }
}
