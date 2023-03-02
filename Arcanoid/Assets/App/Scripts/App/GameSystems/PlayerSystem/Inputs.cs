using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inputs : Singleton<Inputs>
{
    [SerializeField] private EventSystem _eventSystem;

    private const float _inputConstrainterY = 0;

    public static Action<float> _inputPositionX;

    public static Action OnMouseUp, OnMouseDown;

    private Camera _camera;

    private bool _enabled;

    public void Init()
    {
        SingleInit();

        _enabled = false;
    }

    public void SetCamera()
    {
        _camera = Camera.main;
    }
    public void TurnOff(bool allSystem)
    {
        if (allSystem)
        {
            _eventSystem.enabled = false;
        }
        else
        {
            _enabled = false;
        }
    }

    public void TurnOn(bool allSystem)
    {
        if (allSystem)
        {
            _eventSystem.enabled = true;
        }
        else
        {
            _enabled = true;
        }
    }
    
    public void Update()
    {
        if (!_camera)
        {
            SetCamera();
        }

        if (_enabled)
        {
            if (Input.GetMouseButton(0))
            {
                if (_camera.ScreenToWorldPoint(Input.mousePosition).y < _inputConstrainterY)
                {
                    _inputPositionX?.Invoke(_camera.ScreenToWorldPoint(Input.mousePosition).x);
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                OnMouseDown?.Invoke();
            }

            if (Input.GetMouseButtonUp(0))
            {
                OnMouseUp?.Invoke();
            }
        }
    }
}
