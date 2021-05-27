 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    
    
    

    private float ElapsedTime;
    public Text ScoreText;
    public Text TimerText;
    public int MatchTime = 120;
    public float StartTime = 0;
    private int Score = 0;
    private bool MatchActive = false;
    void Start()
    {
        SetTimeDisplay(MatchTime);
        StartTime = Time.time;
        MatchActive = true;
    }

    public void IncrementScore()
    {
        if(MatchActive)
        { Score++;
            
            ScoreText.text = "Score: " + Score.ToString();
            
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time- StartTime < MatchTime)
        {
            ElapsedTime = Time.time - StartTime;
            SetTimeDisplay(MatchTime - ElapsedTime);
           
        }
       
        else
        {


            SceneManager.LoadScene(2);
                

            MatchActive = false;
            SetTimeDisplay(0);
            TimerText.color = Color.red;
            
        }
        

    }

    private void SetTimeDisplay( float TimeDisplay)
    {
        TimerText.text = " " + GetTimeDisplay( TimeDisplay );  
    }
    private string GetTimeDisplay( float TimeToShow)
    {
        int SecondsToShow = Mathf.CeilToInt(TimeToShow);
        int Seconds = SecondsToShow % 60;
        string SecondsDisplay = (Seconds < 10) ? "0" + Seconds.ToString() : Seconds.ToString();
        int Minutes = (SecondsToShow - Seconds) / 60;
        return Minutes.ToString() + ":" + SecondsDisplay;
    }


}
