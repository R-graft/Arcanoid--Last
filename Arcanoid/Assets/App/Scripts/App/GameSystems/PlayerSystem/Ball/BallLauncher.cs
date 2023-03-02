using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallLauncher : MonoBehaviour , IPointerUpHandler, IPointerDownHandler
{
    public Rigidbody2D _ballRb;

    public Transform _platformTransform;

    private const float BallDisposition = 0.9f;

    private const float BallOffset = 0.4f;

    private const float StartForceIndex = 0.04f;

    public void Init(Rigidbody2D ballRb, Transform platformTransform)
    {
        _ballRb = ballRb;

        _platformTransform = platformTransform;
    }

    private void Launch()
    {
        var startDirection = _ballRb.position.normalized;

        _ballRb.AddForce(new Vector2(startDirection.x, - startDirection.y) * StartForceIndex);

        gameObject.SetActive(false);
    }
    private IEnumerator FollowPlatform()
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();

            _ballRb.position = new Vector2((_platformTransform.position.x) / BallDisposition,
           _platformTransform.position.y + BallOffset);
        }
    }
    public void OnPointerUp(PointerEventData eventData) => Launch();

    public void OnPointerDown(PointerEventData eventData) => StartCoroutine(FollowPlatform());
}
