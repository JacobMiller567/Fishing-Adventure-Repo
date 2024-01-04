using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class PlayerSaveData : MonoBehaviour
    {
        public PlayerInventory inventory; 
        private PlayerData MyData = new PlayerData();
        private bool canSave;

        void Start()
        {
            canSave = true;
        }

        void Update() 
        {
            if (canSave)
            {
                UpdateData();
                Debug.Log("TEST");
                canSave = false;
                StartCoroutine(AutoSave());
            }
            if (Input.GetKeyDown(KeyCode.L)) 
            {
                LoadLastSave();
            }
        }
                   
        IEnumerator AutoSave()
        {
            yield return new WaitForSeconds(30f); 
            canSave = true;
            Debug.Log("--- AUTOSAVE ---");
        }


        public void SaveCurrentGame() // Function that will push MyData into Json file
        {
            Debug.Log("Game Saved!");
            SaveGameManager.CurrentSaveData.PlayerData = MyData; // Calling PlayerData from SaveData into PlayerData struct
            SaveGameManager.CurrentSaveData.TestInventory = inventory; // Save current inventory
            SaveGameManager.SaveGame();

            var trans = transform;
            MyData.SaveFile = true; 
            MyData.PlayerLocation = trans.position; 
            MyData.PlayerName = inventory.playerName;
            MyData.PlayerMoney = inventory.playerMoney;
            MyData.HookStrength = inventory.HookStrength;
            MyData.HookDepth = inventory.hookDepth;
            MyData.MaxFish = inventory.maxFish;
            MyData.InventoryFull = inventory.inventoryFull;
            MyData.Count = inventory.count;

            MyData.FishLengthHolder = inventory.fishLengthHolder; 
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
            MyData.CountFish = inventory.CountFish; 
            MyData.QuestActive = inventory.QuestActive;
            MyData.QuestComplete = inventory.QuestComplete;
            MyData.SpikedHook = inventory.SpikedHook;

            MyData.PirateQuest = inventory.PirateQuest;
            MyData.CaughtSpirit = inventory.CaughtSpirit;
            MyData.BoatUpgrade = inventory.BoatUpgrade; 

            // Keep Player Stats Info
            MyData.TotalCatches = inventory.totalCatches;
            MyData.TotalExcapes = inventory.totalExcapes;
            MyData.TotalMoney = inventory.totalMoney;

            // Player Volume Levels
            MyData.MusicVolume = inventory.musicVolume;
            MyData.GameSound = inventory.gameSound;
        }

        public void LoadLastSave()
        {
            Debug.Log("Game Loaded!");
            SaveGameManager.LoadGame();
            MyData = SaveGameManager.CurrentSaveData.PlayerData;
            transform.position = MyData.PlayerLocation;

            inventory = SaveGameManager.CurrentSaveData.TestInventory;
            inventory.playerName = MyData.PlayerName;
            inventory.playerMoney = MyData.PlayerMoney; 
            inventory.fishLengthHolder = MyData.FishLengthHolder; 
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
            var trans = transform;
            MyData.PlayerLocation = trans.position;
            MyData.PlayerMoney = inventory.playerMoney; 
            MyData.HookStrength = inventory.HookStrength;
            MyData.HookDepth = inventory.hookDepth;
            MyData.MaxFish = inventory.maxFish;
            MyData.InventoryFull = inventory.inventoryFull;
            MyData.Count = inventory.count;

            MyData.FishLengthHolder = inventory.fishLengthHolder; 
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
            MyData.CountFish = inventory.CountFish;
            MyData.QuestActive = inventory.QuestActive;
            MyData.QuestComplete = inventory.QuestComplete;
            MyData.SpikedHook = inventory.SpikedHook; 

            MyData.PirateQuest = inventory.PirateQuest;
            MyData.CaughtSpirit = inventory.CaughtSpirit;
            MyData.BoatUpgrade = inventory.BoatUpgrade; 

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
        public int MaxFish; 
        public int Count; 
        public bool InventoryFull;
        public Vector3 PlayerLocation; 

        public string[] FishLengthHolder; 
        public Object[] FishFound;
        public FishData[] DisplayFish; 
        public FishData[] Fish;
        public bool[] FishJournalUpdate;

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
        public int CountFish; 
        public bool QuestActive;
        public bool QuestComplete;
        public bool SpikedHook; 

        // Pirate Quest //
        public bool PirateQuest;
        public bool CaughtSpirit;
        public bool BoatUpgrade; 

        // Keep Player Stats Info //
        public float TotalCatches;
        public float TotalExcapes;
        public float TotalMoney;

        // Store Music and Sound Levels //
        public float MusicVolume;
        public bool GameSound;
    }

