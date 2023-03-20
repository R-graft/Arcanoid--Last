using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inputs : MonoBehaviour, IService
{
    [SerializeField] private EventSystem _eventSystem;

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
                _inputPositionX?.Invoke(_camera.ScreenToWorldPoint(Input.mousePosition).x);
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
