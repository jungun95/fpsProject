//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class GameManager : MonoBehaviour
//{
//    public static GameManager instance;

//    public GameObject readyPannel;

//    public Text scoreText;
//    public Text bestScoreText;
//    public Text massageText;

//    public bool isRoundActive = false; // 대기상태일때는 false

//    private int score = 0;

//    public ShooterRotate shooterRotator;

//    // public CamFollow cam;



//    void Awake()
//    {
//        instance = this; // 자기자신을 싱글톤 자리에 넣어줘
//        UpdateUI();
//    }

//    public void AddScore(int newScore)
//    {
//        score += newScore;
//        UpdateBestScore();
//        UpdateUI();
//    }

//    void UpdateBestScore()  // 최고 스코어 저장 플레이어 프리퍼런스 key value만 있으면댐
//    {
//        if(GetBestScore() < score)
//        {
//            PlayerPrefs.SetInt("BestScore", score);
//        }
//    }

//    int GetBestScore()
//    { 
//        int bestScore = PlayerPrefs.GetInt("BestScore"); // 여기선 키값만 가져와주면 되기 때문에 BestScore만 넣음
//        return bestScore;
//    }

//    void UpdateUI()
//    {
//        scoreText.text = "Score: " + score;
//        bestScoreText.text = "Best Score: " + GetBestScore(); 
//    }

//    public void OnBallDestroy()
//    {
//        UpdateUI(); //ui를 갱신해주고
//        isRoundActive = false;  // 플레이 상태를 탈출할때 사용
//    }

//    public void Reset()
//    {
//        score = 0;
//        UpdateUI();

//        // 라운드를 다시 처음부터 시작하는 코드 == 코루틴을 통해서
//    }

//    IEnumerator RoundRoutine()
//    {
//        //READY
//        readyPannel.SetActive(true); // 레디패널 켜고 끄는거 켬.
        


//        yield return new WaitForSeconds(3f);

//        //PLAY



//        //END

//        yield return new WaitForSeconds(3f);
//        Reset();

//    }

//}
