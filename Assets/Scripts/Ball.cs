using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public LayerMask whatIsProp; // 태그는 일반적, 레이어는 물리판별 , 레이어 여러개를 동시에 식별, 프롭만 체크

    public ParticleSystem explosionParticle;

    public AudioSource explosionAudio;

    public float maxDamage = 100f;
    public float explosionForce = 1000f; // 폭발반경

    public float lifeTime = 10f; // 폭탄 터지는 시간
    public float explosionRadius = 20f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter(Collider other) // 실제로 튕겨나가지는 않고 체크만
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, whatIsProp); // 나 자신의 위치, 반지름, 프롭제외한 모든것들
                                                    
        //중심과 반지름을 지정해주면 반경안에 있는 모든 콜라이더들을 배열로 가져와줌 


       for(int i= 0; i<colliders.Length; i++)
        {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

            targetRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);

            Prop targetProp = colliders[i].GetComponent<Prop>();

            float damage = CalculateDamage(colliders[i].transform.position);

            targetProp.TakeDamage(damage);
        }



        explosionParticle.transform.parent = null; // ball이 어디에 부딪힌 순간에 없어지면 자식인 explosionParticle 이 없어지니까 없어지기전에 부모밖으로 빼기
                                                   // 그래서 이 transform에 부모로 접근하는 parent를 null
        explosionParticle.Play();   
        explosionAudio.Play();      // 파괴된 순간에 둘 다 재생

        Destroy(explosionParticle.gameObject, explosionParticle.duration); 
        Destroy(gameObject); // 닿자마자 파괴
    }

    private float CalculateDamage(Vector3 targetPosition)
    {       // 이게 x 고               x를 구하려면 프롭위치 - 내 폭발위치 하면 
        Vector3 explosionToTarget = targetPosition - transform.position;    //나의 위치(폭발위치)에서 상대방의 위치까지 가는 방향과 거리가 나옴

        float distance = explosionToTarget.magnitude; //  벡터는 자기자신의 길이를 리턴해줌 magnitude는 거리

        float edgeToCenterDistance = explosionRadius - distance;

        float percentage = edgeToCenterDistance / explosionRadius;

        float damage = maxDamage * percentage;

        damage = Mathf.Max(0,damage);   // 두 수를 넣었을때 큰 값을 반환해줌. 0보다 크면 damage 그 자체가 들어감 0보다 작으면 0이 더크니 0이 리턴댐

        return damage;
    }


}
