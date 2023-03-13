using UnityEngine;
using UnityEngine.Events;

public class EventListener : MonoBehaviour
{
    [SerializeField] private EventListenersList _eventsList;

    [SerializeField] private UnityEvent _reaction;

    public void RiseReaction()
    {
        _reaction.Invoke();
    }
    private void OnEnable()
    {
        _eventsList.AddListener(this);
    }

    private void OnDisable()
    {
        _eventsList.RemoveListener(this);
    }
}
