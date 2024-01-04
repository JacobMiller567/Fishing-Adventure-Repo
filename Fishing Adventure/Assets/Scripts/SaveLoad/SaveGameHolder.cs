using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class SaveGameHolder : MonoBehaviour
    {
        public PlayerSaveData data;
        public void SaveGame()
        {
            SaveGameManager.SaveGame(); 
            data.SaveCurrentGame();
        }
        public void LoadGame()
        {
            data.LoadLastSave(); 
            SaveGameManager.LoadGame();
        }

        public void NewGame()
        {

        }
    }
