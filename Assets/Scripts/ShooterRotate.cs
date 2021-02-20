using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterRotate : MonoBehaviour
{
    // Start is called before the first frame update
   private enum RotateState
    {
        Idle,Vertical,Horizontal,Ready
    }

    private RotateState state = RotateState.Idle;
    public float verticalRotateSpeed = 360f;
    public float horizontalRotateSpeed = 360f;

    public BallShooter ballShooter;


    void Update()
    {
         if(state == RotateState.Idle)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                state = RotateState.Horizontal;
            }
        }

         else if(state == RotateState.Horizontal)
        {
            if (Input.GetButton("Fire1"))  //Fire1 에 해당하는 버튼을 누르고 잇는 동안에는
            {
                transform.Rotate(new Vector3(0, horizontalRotateSpeed * Time.deltaTime, 0)); // 회전을 넣어줌, y축으로 회전하면 수평방향으로 회전함
            }
            else if (Input.GetButtonUp("Fire1")) // 버튼을 뗀순간에 수직으로 회전해야하니까
            {
                state = RotateState.Vertical;
            }
        }

        else if(state == RotateState.Vertical)
        {
            if (Input.GetButton("Fire1"))
            {
                transform.Rotate(new Vector3(-verticalRotateSpeed * Time.deltaTime, 0, 0)); // 이번엔 x 방향으로 회전 - 붙인 이유는 생각해봐 
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                state = RotateState.Ready; // 회전 코드 완성
                ballShooter.enabled = true;
            }
        }
    }

    private void OnEnable()
    {
        transform.rotation = Quaternion.identity;
        state = RotateState.Idle;
        ballShooter.enabled = false;        // identity 는 0도 0도 0 도 회전한 걸 말함
    }


}



//========= ======== ========== ========= ======== ============ ============ ========= ===========

// 업데이트 문안에 있어여함 이것.


//else if문 말고 switch문으로 하면 더 간결하게 사용가능함. enum이 switch랑 잘 어울림

//switch (state)
//{
//    case RotateState.Idle:
//        {
//            if (Input.GetButtonDown("Fire1"))
//                state = RotateState.Horizontal;
//        }
//        break;

//    case RotateState.Horizontal:
//        {
//            if (Input.GetButton("Fire1"))  //Fire1 에 해당하는 버튼을 누르고 잇는 동안에는
//            {
//                transform.Rotate(new Vector3(0, horizontalRotateSpeed * Time.deltaTime, 0)); // 회전을 넣어줌, y축으로 회전하면 수평방향으로 회전함
//            }
//            else if (Input.GetButtonUp("Fire1")) // 버튼을 뗀순간에 수직으로 회전해야하니까
//            {
//                state = RotateState.Vertical;
//            }
//        }
//        break;

//    case RotateState.Vertical:
//        {
//            if (Input.GetButton("Fire1"))
//            {
//                transform.Rotate(new Vector3(-verticalRotateSpeed * Time.deltaTime, 0, 0)); // 이번엔 x 방향으로 회전 - 붙인 이유는 생각해봐 
//            }
//            else if (Input.GetButtonUp("Fire1"))
//            {
//                state = RotateState.Ready; // 회전 코드 완성
//            }
//        }
//        break;

//    case RotateState.Ready:
//        break;
//}