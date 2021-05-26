//deklarerar funktoner i unity att ta med
//Knapp för att återgå till menyn, mer detaljer på oden i MainMenu.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inGameMenu : MonoBehaviour
{
   
   public void LoadMenu()
   {
   SceneManager.LoadScene("Menu");
   }
}
