using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{

    public int score = 5;
    public ParticleSystem explosionParticle;

    public float hp = 10f; // hp가 작아지면 프롭이 파괴되게 10으로 설정

    public void TakeDamage(float damage)
    {
        hp -= damage;

        if (hp <= 0)
        {                                     // 오브젝트, 내 포지션, 나  자신의 로테이션
            ParticleSystem instance = Instantiate(explosionParticle, transform.position, transform.rotation);                         
            // 이 함수는 매개변수에 오브젝트를 넣어주면 그 게임오브젝트를 새로하나 찍혀나옴

            AudioSource explosionAudio = instance.GetComponent<AudioSource>();  // 새로만든 이 프롭의 오디오 소스를 explosionAudio 변수에 넣어주고 재생
            explosionAudio.Play();

            Destroy(instance.gameObject, instance.duration); //파티클 시스템 하고나서 지워줘야 하는데 gameObject를 지우고 나서, 그 지연시간은 시간동안
            gameObject.SetActive(false);    // 프롭을 재사용하는 방식으로함. 재사용말고 프롭이 없어지는게 아니라 안보이게만 잠시 꺼두고 새로운라운드면 다시 켜지게
        }



    }
}
