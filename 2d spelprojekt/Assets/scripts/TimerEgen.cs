using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerEgen : MonoBehaviour

{

        public Text timerText; //texten som visar på skärmen, kopplad till textruta
        public Text topTime;//texten som visar på skärmen, kopplad till textruta
        public Text lastTime;//texten som visar på skärmen, kopplad till textruta
        private float startTime;//när man startar
        private bool finnished = false;//berättaar om man passerat mållinjen
        private bool started = false;//berättar om man har startat
        private float endTime;
        private float bestTime;
        private float t;
        private string timer;
    // Start is called before the first frame update
    void Start()
    {
        
        finnished = false;
      

        endTime = PlayerPrefs.GetFloat("last");//hämtar från PlayerPrefs tiden som lagrats till en lokal variabel
        bestTime = PlayerPrefs.GetFloat("best");//hämtar från PlayerPrefs tiden som lagrats till en lokal variabel
        string minuteslast = ((int) endTime/60).ToString();//formaterar så tiden visas snyggt med minuter och sekunder
        string secondslast = (endTime % 60).ToString("f2");//formaterar så tiden visas snyggt med minuter och sekunder

        string minutesbest = ((int) bestTime/60).ToString();//formaterar så tiden visas snyggt med minuter och sekunder
        string secondsbest = (bestTime % 60).ToString("f2");//formaterar så tiden visas snyggt med minuter och sekunder

        lastTime.text = "Last:" + minuteslast + ":" + secondslast;//formaterar till fint format att visa i spelet, och uppdaterar där
        topTime.text ="Record:" + minutesbest + ":" + secondsbest;//formaterar till fint format att visa i spelet, och uppdaterar där
        
    }

    // Update is called once per frame
    void Update()
    {
        if(started){//om man startat

        

        if(!finnished){//om man inte har passerat mållinjen
        t = Time.time - startTime;//sättar tiden
        string minutes = ((int) t/60).ToString();//formaterar så tiden visas snyggt med minuter och sekunder
        string seconds = (t % 60).ToString("f2");//formaterar så tiden visas snyggt med minuter och sekunder

        timerText.text = minutes + ":" + seconds;//formaterar till fint format att visa i spelet, och uppdaterar där
        
        }
        }
    }

 void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Start"){//startlinjen passerad, startar tidtagning
        started = true;//gör så att timern i void Update aktiveras
        startTime = Time.time;//sätter variabeln man använder i void Update för att få tiden man kört
        }

        if(other.tag == "Finish"){//aktiveras när man passerar mållinjen
        finnished = true;
    
        //Debug.Log("test");
        //Debug.Log(endTime);
        //Debug.Log(timer);
        PlayerPrefs.SetFloat("last", t);


        endTime = PlayerPrefs.GetFloat("last");
        bestTime = PlayerPrefs.GetFloat("best");


        if(endTime < bestTime)//kollar om senaste tiden är snabbare än rekordet
        {
        PlayerPrefs.SetFloat("best", endTime);//updaterar rekordet i playerprefs som kan kommas åt mellan filer och olika scener.
        Debug.Log("NYTT REKORD");
        }
        
        else if(bestTime == 0){//för när man inte har ett rekord innan (spelar första gången)
        PlayerPrefs.SetFloat("best", t);//updaterar rekordet i playerprefs som kan kommas åt mellan filer och olika scener.
        Debug.Log("FIRST TIME");
        }

        else
        {
            //PlayerPrefs.SetFloat("best", bestTime)
            Debug.Log("BAD TIME");
        }
        }
        
        

        

        if(finnished)//laddar om scenen så man kan köra ett nytt varv
        SceneManager.LoadScene("SampleScene");<
      

        
    }
}
