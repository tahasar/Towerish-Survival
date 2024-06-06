using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "GameEvent")]
public class GameEvent : ScriptableObject
{
    List<GameEventListener> listeners = new List<GameEventListener>();
    
    public void TriggerEvent(Transform sender, object data)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventTriggered(sender, data);
        }
    }
    
    public void AddListener(GameEventListener listener)
    {
        listeners.Add(listener);
    }
    
    public void RemoveListener(GameEventListener listener)
    {
        listeners.Remove(listener);
    }
}
