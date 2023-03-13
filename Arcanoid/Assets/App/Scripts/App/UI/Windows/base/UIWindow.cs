using UnityEngine;

public abstract class UIWindow :MonoBehaviour
{   
    protected UIPopUpController _popUpHandler;

    public void Construct(UIPopUpController popUpHandler)
    {
        _popUpHandler = popUpHandler;

        InitWindow();
    }

    public abstract void InitWindow();
}
