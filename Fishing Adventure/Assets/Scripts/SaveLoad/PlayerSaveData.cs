using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//namespace SaveLoad
//{
    public class PlayerSaveData : MonoBehaviour
    {
        public PlayerInventory inventory; //= ScriptableObject.CreateInstance<PlayerInventory>();
       // public PlayerData MyData = new PlayerData();


        private PlayerData MyData = new PlayerData();
        //public PlayerData MyData; // FIXXXXX: Causes Null Reference Exception

        private bool canSave;


        void Start()
        {
            //UpdateData();
            canSave = true;
        }



        void Update() 
        {
            /*
            if (canSave == false)
            {
                StartCoroutine(AutoSave()); // call autosave function
            }
            */

            // Stores all data into MyData struct

            if (canSave)
            {
                UpdateData();
                Debug.Log("TEST");
                canSave = false;
                StartCoroutine(AutoSave());
            }
            


            if (Input.GetKeyDown(KeyCode.L)) // TEST
            {
                LoadLastSave();
            }
        }
                   

            /*
    
            if (canSave == true) 
            { // Save data
                canSave = false;
               // var trans = transform;
                MyData.PlayerLocation = trans.position; // Change to every 30 sec!! ///ADD boat location too??!!
                MyData.PlayerMoney = inventory.playerMoney; // Saves player money into struct
                MyData.HookStrength = inventory.HookStrength;
                MyData.HookDepth = inventory.hookDepth;
                MyData.MaxFish = inventory.maxFish;
                MyData.InventoryFull = inventory.inventoryFull;
                MyData.Count = inventory.count;

                MyData.FishLengthHolder = inventory.fishLengthHolder; // Store fishLengthHolder into struct
                MyData.FishFound = inventory.fishFound;
                MyData.DisplayFish = inventory.displayFish;
                MyData.Fish = inventory.fish;

                MyData.InventoryUpgradeCost = inventory.inventoryUpgradeCost;
                MyData.DepthUpgradeCost = inventory.depthUpgradeCost;
                MyData.HookUpgradeCost = inventory.hookUpgradeCost;
                MyData.DockUpgradeCost = inventory.dockUpgradeCost;
                MyData.DockUpgraded = inventory.dockUpgraded;
                MyData.StrengthLevel = inventory.strengthLevel;
                MyData.InventoryLevel = inventory.inventoryLevel;
                MyData.DepthLevel = inventory.depthLevel;
                MyData.Highered = inventory.highered;
                MyData.WorkerLevel = inventory.workerLevel;
                MyData.WorkerUpgradeCost = inventory.workerUpgradeCost;

                // Quests
                MyData.CountFish = inventory.CountFish; //Count caught fish
                MyData.QuestActive = inventory.QuestActive;
                MyData.QuestComplete = inventory.QuestComplete;
                MyData.SpikedHook = inventory.SpikedHook; // Quest reward that stops fish from taking bait

                MyData.PirateQuest = inventory.PirateQuest;
                MyData.CaughtSpirit = inventory.CaughtSpirit;
                MyData.BoatUpgrade = inventory.BoatUpgrade; // Quest reward that makes boat 50% faster 1.5 --> 2.25

                // Keep Player Stats Info
                MyData.TotalCatches = inventory.totalCatches;
                MyData.TotalExcapes = inventory.totalExcapes;
                MyData.TotalMoney = inventory.totalMoney;
            }
            */
    

    /*        
            if (Input.GetKeyDown(KeyCode.S)) // Change to when player clicks save button
            {
                SaveGameManager.CurrentSaveData.PlayerData = MyData; // Calling PlayerData from SaveData into PlayerData struct
                SaveGameManager.CurrentSaveData.TestInventory = inventory; // Save current inventory
                SaveGameManager.SaveGame();
            }
    */
    

        IEnumerator AutoSave()
        {
            yield return new WaitForSeconds(30f); // 30 second autosave
            canSave = true;
            Debug.Log("--- AUTOSAVE ---");
        }


        public void SaveCurrentGame() // Function that will push MyData into Json file
        {
            Debug.Log("Game Saved!");
            SaveGameManager.CurrentSaveData.PlayerData = MyData; // Calling PlayerData from SaveData into PlayerData struct
            SaveGameManager.CurrentSaveData.TestInventory = inventory; // Save current inventory
            SaveGameManager.SaveGame();

        ////  ----- TEST ----- ////
            var trans = transform;
            MyData.SaveFile = true; // TEST //
            MyData.PlayerLocation = trans.position; // Change to every 30 sec!! ///ADD boat location too??!!
            MyData.PlayerName = inventory.playerName;
            MyData.PlayerMoney = inventory.playerMoney; // Saves player money into struct
            MyData.HookStrength = inventory.HookStrength;
            MyData.HookDepth = inventory.hookDepth;
            MyData.MaxFish = inventory.maxFish;
            MyData.InventoryFull = inventory.inventoryFull;
            MyData.Count = inventory.count;

            MyData.FishLengthHolder = inventory.fishLengthHolder; // Store fishLengthHolder into struct
            MyData.FishFound = inventory.fishFound;
            MyData.DisplayFish = inventory.displayFish;
            MyData.Fish = inventory.fish;
            MyData.FishJournalUpdate = inventory.fishJournal; 

            MyData.InventoryUpgradeCost = inventory.inventoryUpgradeCost;
            MyData.DepthUpgradeCost = inventory.depthUpgradeCost;
            MyData.HookUpgradeCost = inventory.hookUpgradeCost;
            MyData.DockUpgradeCost = inventory.dockUpgradeCost;
            MyData.DockUpgraded = inventory.dockUpgraded;
            MyData.StrengthLevel = inventory.strengthLevel;
            MyData.InventoryLevel = inventory.inventoryLevel;
            MyData.DepthLevel = inventory.depthLevel;
            MyData.Highered = inventory.highered;
            MyData.WorkerLevel = inventory.workerLevel;
            MyData.WorkerUpgradeCost = inventory.workerUpgradeCost;

            // Quests
            MyData.CountFish = inventory.CountFish; //Count caught fish
            MyData.QuestActive = inventory.QuestActive;
            MyData.QuestComplete = inventory.QuestComplete;
            MyData.SpikedHook = inventory.SpikedHook; // Quest reward that stops fish from taking bait

            MyData.PirateQuest = inventory.PirateQuest;
            MyData.CaughtSpirit = inventory.CaughtSpirit;
            MyData.BoatUpgrade = inventory.BoatUpgrade; // Quest reward that makes boat 50% faster 1.5 --> 2.25

            // Keep Player Stats Info
            MyData.TotalCatches = inventory.totalCatches;
            MyData.TotalExcapes = inventory.totalExcapes;
            MyData.TotalMoney = inventory.totalMoney;

            // Player Volume Levels
            MyData.MusicVolume = inventory.musicVolume;
            MyData.GameSound = inventory.gameSound;
        //// END OF TEST ////


        }

/*
    public void CreateNewGame() // Reset savefile  // Fix: Error makes arrays empty causing index exception errors
    {
        // Change to MyData instead of inventory? 
            Debug.Log("New Game!");

            //MyData = SaveGameManager.CurrentSaveData.PlayerData;
            //transform.position = MyData.PlayerLocation;

            // Loop through and reset array sizes!
            // for (int i = 0; i < inventory.maxFish; i++) {
                // inventory.fish[i] = null;
              //  i++;
            //}

            // for (int i = 0; i < 20; i++) {
                // inventory.fishLengthHolder[i] = null;
              //  i++;
            //}

            inventory = SaveGameManager.CurrentSaveData.TestInventory; // Get inventory saved data
            inventory.playerMoney = 0f; // Set inventory money to saved money
          //  inventory.fishLengthHolder = null; // array size 20 with values being null
           // inventory.fishFound = null; // array size 1 with value being null
            inventory.displayFish[0] = null; // array size 1 with value being null
            inventory.fish = null; // array size 5 with values being null
            inventory.hookDepth = 5f;
            inventory.HookStrength = .7f;
            inventory.maxFish = 5;
            inventory.inventoryFull = false;
            inventory.count = 0;

            inventory.inventoryUpgradeCost = 200f;
            inventory.depthUpgradeCost = 45f;
            inventory.hookUpgradeCost = 55f;
            inventory.dockUpgradeCost = 115f;
            inventory.dockUpgraded = false;
            inventory.strengthLevel = 0;
            inventory.inventoryLevel = 0;
            inventory.depthLevel = 0;
            inventory.highered = false;
            inventory.workerLevel = 0; // Maybe level 1??
            inventory.workerUpgradeCost = 250f;

            inventory.CountFish = 0;
            inventory.QuestActive = false;
            inventory.QuestComplete = false;
            inventory.SpikedHook = false;
            inventory.PirateQuest = false;
            inventory.CaughtSpirit = false;
            inventory.BoatUpgrade = false;
            inventory.totalCatches = 0f;
            inventory.totalExcapes = 0f;
            inventory.totalMoney = 0f;
            SaveGameManager.NewGame();

        }
    */


        

        public void LoadLastSave()
        {
            Debug.Log("Game Loaded!");
            SaveGameManager.LoadGame();
            MyData = SaveGameManager.CurrentSaveData.PlayerData;
            transform.position = MyData.PlayerLocation;

            inventory = SaveGameManager.CurrentSaveData.TestInventory; // Get inventory saved data
            inventory.playerName = MyData.PlayerName;
            inventory.playerMoney = MyData.PlayerMoney; // Set inventory money to saved money   // FIX: NULLREFERENCE????
            inventory.fishLengthHolder = MyData.FishLengthHolder; // Set fishLengthHolder to stored values
            inventory.fishFound = MyData.FishFound;
            inventory.displayFish = MyData.DisplayFish;
            inventory.fish = MyData.Fish;
            inventory.fishJournal = MyData.FishJournalUpdate;
            inventory.hookDepth = MyData.HookDepth;
            inventory.HookStrength = MyData.HookStrength;
            inventory.maxFish = MyData.MaxFish;
            inventory.inventoryFull = MyData.InventoryFull;
            inventory.count = MyData.Count;

            inventory.inventoryUpgradeCost = MyData.InventoryUpgradeCost;
            inventory.depthUpgradeCost = MyData.DepthUpgradeCost;
            inventory.hookUpgradeCost = MyData.HookUpgradeCost;
            inventory.dockUpgradeCost = MyData.DockUpgradeCost;
            inventory.dockUpgraded = MyData.DockUpgraded;
            inventory.strengthLevel = MyData.StrengthLevel;
            inventory.inventoryLevel = MyData.InventoryLevel;
            inventory.depthLevel = MyData.DepthLevel;
            inventory.highered = MyData.Highered;
            inventory.workerLevel = MyData.WorkerLevel;
            inventory.workerUpgradeCost = MyData.WorkerUpgradeCost;

            inventory.CountFish = MyData.CountFish;
            inventory.QuestActive = MyData.QuestActive;
            inventory.QuestComplete = MyData.QuestComplete;
            inventory.SpikedHook = MyData.SpikedHook;
            inventory.PirateQuest = MyData.PirateQuest;
            inventory.CaughtSpirit = MyData.CaughtSpirit;
            inventory.BoatUpgrade = MyData.BoatUpgrade;
            inventory.totalCatches = MyData.TotalCatches;
            inventory.totalExcapes = MyData.TotalExcapes;
            inventory.totalMoney = MyData.TotalMoney;

            inventory.musicVolume = MyData.MusicVolume;
            inventory.gameSound = MyData.GameSound;
            
        }


        public void UpdateData()
        {
            // Stores all data into MyData struct
            var trans = transform;
            MyData.PlayerLocation = trans.position; // Change to every 30 sec!! ///ADD boat location too??!!
            MyData.PlayerMoney = inventory.playerMoney; // Saves player money into struct
            MyData.HookStrength = inventory.HookStrength;
            MyData.HookDepth = inventory.hookDepth;
            MyData.MaxFish = inventory.maxFish;
            MyData.InventoryFull = inventory.inventoryFull;
            MyData.Count = inventory.count;

            MyData.FishLengthHolder = inventory.fishLengthHolder; // Store fishLengthHolder into struct
            MyData.FishFound = inventory.fishFound;
            MyData.DisplayFish = inventory.displayFish;
            MyData.Fish = inventory.fish;
            MyData.FishJournalUpdate = inventory.fishJournal;

            MyData.InventoryUpgradeCost = inventory.inventoryUpgradeCost;
            MyData.DepthUpgradeCost = inventory.depthUpgradeCost;
            MyData.HookUpgradeCost = inventory.hookUpgradeCost;
            MyData.DockUpgradeCost = inventory.dockUpgradeCost;
            MyData.DockUpgraded = inventory.dockUpgraded;
            MyData.StrengthLevel = inventory.strengthLevel;
            MyData.InventoryLevel = inventory.inventoryLevel;
            MyData.DepthLevel = inventory.depthLevel;
            MyData.Highered = inventory.highered;
            MyData.WorkerLevel = inventory.workerLevel;
            MyData.WorkerUpgradeCost = inventory.workerUpgradeCost;

            // Quests
            MyData.CountFish = inventory.CountFish; //Count caught fish
            MyData.QuestActive = inventory.QuestActive;
            MyData.QuestComplete = inventory.QuestComplete;
            MyData.SpikedHook = inventory.SpikedHook; // Quest reward that stops fish from taking bait

            MyData.PirateQuest = inventory.PirateQuest;
            MyData.CaughtSpirit = inventory.CaughtSpirit;
            MyData.BoatUpgrade = inventory.BoatUpgrade; // Quest reward that makes boat 50% faster 1.5 --> 2.25

            // Keep Player Stats Info
            MyData.TotalCatches = inventory.totalCatches;
            MyData.TotalExcapes = inventory.totalExcapes;
            MyData.TotalMoney = inventory.totalMoney;


            // Keep track of volume levels
            MyData.MusicVolume = inventory.musicVolume;
            MyData.GameSound = inventory.gameSound;

        }
    }

    [System.Serializable]
    public struct PlayerData // Stores all player data
    {
        public string PlayerName;
        public bool SaveFile;
        public float PlayerMoney; 
        public float HookStrength;
        public float HookDepth;
        public int MaxFish; // inventory size
        public int Count; // counter
        public bool InventoryFull;
        public Vector3 PlayerLocation; // WORKS!

        public string[] FishLengthHolder; 
        public Object[] FishFound;
        public FishData[] DisplayFish; 
        public FishData[] Fish;
        public bool[] FishJournalUpdate;
        //public FishData[] AllFish; // don't think this needs saved


        // Upgrades
        public float InventoryUpgradeCost;
        public float DepthUpgradeCost;
        public float HookUpgradeCost;
        public float DockUpgradeCost;
        public bool DockUpgraded;
        public int StrengthLevel;
        public int InventoryLevel;
        public int DepthLevel;
        public bool Highered;
        public int WorkerLevel;
        public float WorkerUpgradeCost;

        // Quests //
        public int CountFish; //Count caught fish
        public bool QuestActive;
        public bool QuestComplete;
        public bool SpikedHook; // Quest reward that stops fish from taking bait

        // Pirate Quest //
        public bool PirateQuest;
        public bool CaughtSpirit;
        public bool BoatUpgrade; // Quest reward that makes boat 50% faster 1.5 --> 2.25

        // Keep Player Stats Info //
        public float TotalCatches;
        public float TotalExcapes;
        public float TotalMoney;

        // Store Music and Sound Levels //
        public float MusicVolume;
        public bool GameSound;
    }
//}
