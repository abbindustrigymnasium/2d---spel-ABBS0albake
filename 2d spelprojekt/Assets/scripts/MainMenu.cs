//deklarerar funktoner i unity att ta med
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour

{


public Text topTime; //variabel kopplad till det som visas i spelet
public Text lastTime; //variabel kopplad till det som visas i spelet
private float endTime; //float för senaste tiden man fick
private float bestTime; //float för ens bästa tid


void Update()
    {
        endTime = PlayerPrefs.GetFloat("last");//hämtar från PlayerPrefs tiden som lagrats till en lokal variabel
        bestTime = PlayerPrefs.GetFloat("best");//hämtar från PlayerPrefs tiden som lagrats till en lokal variabel
        string minuteslast = ((int) endTime/60).ToString();//formaterar så tiden visas snyggt med minuter och sekunder
        string secondslast = (endTime % 60).ToString("f2");//formaterar så tiden visas snyggt med minuter och sekunder

        string minutesbest = ((int) bestTime/60).ToString();//formaterar så tiden visas snyggt med minuter och sekunder
        string secondsbest = (bestTime % 60).ToString("f2");//formaterar så tiden visas snyggt med minuter och sekunder

        lastTime.text = "Last:" + minuteslast + ":" + secondslast;//formaterar till fint format att visa i spelet, och uppdaterar där
        topTime.text ="Record:" + minutesbest + ":" + secondsbest;//formaterar till fint format att visa i spelet, och uppdaterar där
        
    }





  public void PlayGame ()
  {
      SceneManager.LoadScene("SampleScene");//laddar scenen där man kör själva spelet, kopplad till knappen play
  }

  

   public void QuitGame ()
  {
      Debug.Log ("QUIT!");//för att veta att funktinen funkar även när man kör utvecklingsläge
      Application.Quit();//avslutar hela spelet om man trycket på knappen "quit" som callar på den funktionen
  }
   public void OptionsMenu ()
  {
      Debug.Log("options");//kolla att knapen fungerar
      PlayerPrefs.SetFloat("best", 0);//återställer tiden 
      PlayerPrefs.SetFloat("last", 0);//återställer tiden 
  }

}
