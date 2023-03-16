using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : MonoBehaviour
{
    [SerializeField] private GameObject[] _webs;

    private Queue<GameObject> _webQueue = new Queue<GameObject>();

    public void CreateEffect(Vector2 position)
    {
        foreach (var web in _webs)
        {
            var newWeb = Instantiate(web, position, Quaternion.identity, transform);

            newWeb.SetActive(false);

            _webQueue.Enqueue(newWeb);
        }
    }
    public void ClearEffect()
    {
        for (int i = 0; i < _webQueue.Count; i++)
        {
            var web = _webQueue.Dequeue();

            web.SetActive(false);

            _webQueue.Enqueue(web);
        }
    }

    public void ApplyEffect()
    {
        var currentWeb = _webQueue.Dequeue();

        currentWeb.SetActive(true);

        _webQueue.Enqueue(currentWeb);
    }
}
