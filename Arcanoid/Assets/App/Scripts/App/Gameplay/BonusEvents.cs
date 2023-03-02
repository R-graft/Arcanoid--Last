using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BonusEvents 
{
    public static UnityEvent<bool> OnFuryBallBonus = new UnityEvent<bool>();

    public static UnityEvent<bool, int> OnBallSpeedBonus = new UnityEvent<bool, int>();

    public static UnityEvent<float> OnResizePlatform = new UnityEvent<float>();

    public static UnityEvent<bool, float> OnSetPlatformSpeed = new UnityEvent<bool, float>();

    public static UnityEvent<Vector2> OnDuplicateBall = new UnityEvent<Vector2>();

    public static UnityEvent<List<(int, int)>, int> OnBombBonus = new UnityEvent<List<(int, int)>, int>();

    public static UnityEvent<int, bool> OnSetLives = new UnityEvent<int, bool>();
}
