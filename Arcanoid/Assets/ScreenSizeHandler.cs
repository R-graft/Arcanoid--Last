using UnityEngine;

public class ScreenSizeHandler : Singleton<ScreenSizeHandler>
{
    private Camera _m_Camera;

    public readonly float screenHeight = 10;

    [HideInInspector] public float screenWidth;
    [HideInInspector] public float leftScreenEdge;
    [HideInInspector] public float rightScreenEdge;
    [HideInInspector] public float upScreenEdge;
    [HideInInspector] public float downScreenEdge;

    public void Init()
    {
        SingleInit();

        GetScreenValues();
    }

    public void SetCamera()
    {
        _m_Camera = Camera.main;
    }

    private void GetScreenValues()
    {
        if (!_m_Camera)
        {
            SetCamera();
        }

        float aspect = _m_Camera.aspect;

        screenWidth = aspect * screenHeight;

        leftScreenEdge = -screenWidth;
        rightScreenEdge = screenWidth;
        upScreenEdge = screenHeight;
        downScreenEdge = -screenHeight;
    }
}