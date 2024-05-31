using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using AYellowpaper.SerializedCollections;

public class StatsManager : MonoBehaviour
{
    
    [SerializedDictionary("Player Stat", "Değer")][SerializeField]
    private SerializedDictionary<PlayerStats, float> playerStats = new SerializedDictionary<PlayerStats, float>();
    
    public Array UpgradeArray => Enum.GetValues(typeof(PlayerStats));
    
    private void Awake()
    {
        playerStats[PlayerStats.Damage] = 10;
        playerStats[PlayerStats.MaxHealth] = 100;
        playerStats[PlayerStats.AttackSpeed] = 1;
        playerStats[PlayerStats.MoveSpeed] = 5;
        
        SaveStats();
    }
    
    private void SaveStats()
    {
        var dict = playerStats.ToDictionary(
            x => x.Key.ToString(),
            x => x.Value);
        
        // Sadece PlayerStats ve float değerleri olacak şekilde json dosyası oluştur.
        ES3.Save("PlayerStats", dict, ES3Settings.defaultSettings.path + "PlayerStats.json");
    }
    
    private void LoadStats()
    {
        var dict = ES3.Load<Dictionary<string, float>>("PlayerStats",
            ES3Settings.defaultSettings.path + "PlayerStats.json");
        playerStats = new SerializedDictionary<PlayerStats, float>(dict.ToDictionary( 
            x => (PlayerStats)Enum.Parse(typeof(PlayerStats), x.Key), 
            x => x.Value));
    }
}