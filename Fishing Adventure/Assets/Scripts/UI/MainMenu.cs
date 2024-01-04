using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR // TEST
using UnityEditor;
#endif
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

  public void PlayGame()
  {
    SceneManager.LoadScene("FishingGame");
  }

  public void QuitGame()
  {
    Application.Quit();
  }
  
  public void LoadGame()
  {
    
  }
}