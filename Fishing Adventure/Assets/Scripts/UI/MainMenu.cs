using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR // TEST
using UnityEditor;
#endif
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
 // public PlayerSaveData DataSaved; //Test


  public void PlayGame()
  {
    //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Go to next scene from scene manager
    SceneManager.LoadScene("FishingGame");
    Debug.Log("Starting the Game!!!");
    
  }

  public void QuitGame()
  {
    Application.Quit();
    //UnityEditor.EditorApplication.isPlaying = false; //Only can be used in Editor not Build mode!
  }
  
  public void LoadGame()
  {
    //DataSaved.LoadLastSave(); //TEST
    //PlayGame();
    //SceneManager.LoadScene("MainMenu");
  }
}