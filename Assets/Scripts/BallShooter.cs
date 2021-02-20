 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BallShooter : MonoBehaviour
{
    public Rigidbody ball;

    public Transform firePos;

    public Slider powerSlider;
     
    public AudioSource shootingAudio;
    public AudioClip fireClip;
    public AudioClip chargingClip;

    public float minForce = 15f;

    public float maxForce = 30f;
    public float chargingTime = 0.75f;

    private float currentForce;
    private float chargeSpeed;
    private bool fired;


    private void OnEnable() // 컴포넌트가 꺼져있다가 켜질때 발동됨 (매번)
    {
        currentForce = minForce; // 시작힘은 최소
        powerSlider.value = minForce;
        fired = false;

    }

    private void Start()
    {
        chargeSpeed = (maxForce - minForce) / chargingTime; // 거 = 속 * 시, `     속 = 거리/시간
    }

    private void Update()
    {
        if(fired == true)
        {
            return;
        }

        powerSlider.value = minForce;


         if(currentForce >= maxForce && !fired)
        {
            currentForce = maxForce;
            Fire();
            //발사처리
        }
        else if(Input.GetButtonDown("Fire1")) // 누른순간
        {
             fired = false; // 연사가능
            currentForce = minForce;            // 막눌렀으니 최소힘이고
            shootingAudio.clip = chargingClip; // 차징 오디오
            shootingAudio.Play();               // 재생해야지
        }
         else if (Input.GetButton("Fire1") && !fired)
        {
            currentForce = currentForce + chargeSpeed * Time.deltaTime;

            powerSlider.value = currentForce;
        }
            
         else if(Input.GetButtonUp("Fire1") && !fired)
        {
            Fire();
        }
    }


    private void Fire()
    {
        fired = true;
        Rigidbody ballInstance = Instantiate(ball, firePos.position, firePos.rotation);

        ballInstance.velocity = currentForce * firePos.forward; // (힘 * 방향)

        shootingAudio.clip = fireClip;
        shootingAudio.Play();

        currentForce = minForce;

    }
}
