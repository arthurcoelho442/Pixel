using UnityEngine;
using UnityEngine.Events;

public class RockHeadDetection : MonoBehaviour
{
    [SerializeField]
    EventStompAtk stompAtk;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Player") stompAtk.Invoke(true);
        
    }
}
[System.Serializable]
public class EventStompAtk : UnityEvent<bool> { }