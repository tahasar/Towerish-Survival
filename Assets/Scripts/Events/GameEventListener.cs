using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.Events;
using Action = System.Action;

[System.Serializable]
public class CustomGameEvent : UnityEvent<Transform, object> { }

public class GameEventListener : MonoBehaviour
{
    public GameEvent gameEvent;
    public CustomGameEvent onEventTriggered;
    
    void OnEnable()
    {
        gameEvent.AddListener(this);
    }
    
    void OnDisable()
    {
        gameEvent.RemoveListener(this);
    }
    
    public void OnEventTriggered(Transform sender, object data)
    {
        onEventTriggered.Invoke(sender, data);
    }
}