using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inputs : MonoBehaviour, IService
{
    [SerializeField] private EventSystem _eventSystem;

    private const float _inputConstrainterY = 0;

    public Action<float> _inputPositionX;

    public Action OnMouseUp, OnMouseDown;

    private Camera _camera;

    public bool _enabled;

    public void InitService()
    {
        _enabled = false;
    }

    public void SetCamera()
    {
        if (Camera.main == null)
        {
            Debug.Log("Camera not find in scene");

            return;
        }
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

        if (_enabled && Time.timeScale != 0)
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
