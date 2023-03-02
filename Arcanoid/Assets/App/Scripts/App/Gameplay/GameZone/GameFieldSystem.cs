using UnityEngine;

public class GameFieldSystem : MonoBehaviour
{
    [SerializeField]
    private Transform _leftEdge;

    [SerializeField]
    private Transform _rightEdge;

    [SerializeField]
    private Transform _upEdge;

    [SerializeField]
    private Transform _downEdge;

    private Vector2 _screenValue;

    private const float UpOffset = 0.75f;

    private const float ColliderWidth = 4;

    public void Init()
    {
        _screenValue = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        SetLeft();
        SetRight();
        SetDown();
        SetUp();
    }

    private void SetLeft()
    {
        _leftEdge.transform.position = new Vector2(-_screenValue.x, 0);

        _leftEdge.transform.localScale = new Vector2(ColliderWidth, _screenValue.y);
    }
    private void SetRight()
    {
        _rightEdge.transform.position = new Vector2(_screenValue.x, 0);

        _rightEdge.transform.localScale = new Vector2(ColliderWidth, _screenValue.y);
    }

    private void SetDown()
    {
        _downEdge.transform.position = new Vector2(0, -_screenValue.y);

        _downEdge.transform.localScale = new Vector2(_screenValue.x, ColliderWidth);
    }

    private void SetUp()
    {
        _upEdge.transform.position = new Vector2(0, _screenValue.y * UpOffset);

        _upEdge.transform.localScale = new Vector2(_screenValue.x, ColliderWidth);
    }
}
