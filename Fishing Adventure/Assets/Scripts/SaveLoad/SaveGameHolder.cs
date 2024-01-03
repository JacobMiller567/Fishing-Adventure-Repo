using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//namespace SaveLoad // I added this to TEST
//{
    public class SaveGameHolder : MonoBehaviour
    {
        //SaveGameManager test = new SaveGameManager();
        public PlayerSaveData data;
      //  public GameObject test;
       // PlayerSaveData.SaveCurrentGame();
        public void SaveGame()
        {
            //data.SaveCurrentGame();
            SaveGameManager.SaveGame(); 
            data.SaveCurrentGame();
           // SaveGameManager.SaveGame(); 
        }
        public void LoadGame()
        {
        // Load Game
          //  test.SetActive(true);
            data.LoadLastSave(); //FIX: NULL REFERENCE
            SaveGameManager.LoadGame();
            //data.LoadLastSave();
        }

        public void NewGame()
        {
            //data.CreateNewGame();
           // SaveGameManager.NewGame();
        }
    }
//}
