using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DoOne : MonoBehaviour
{
    public GameObject testTransform;

    public Image testSprite;

    private void Start()
    {
        //testTransform.DOLocalMove(new Vector2(3, 0), 5);// (���� �� ����� �����)

        //testTransform.DOMoveX(3,5);// (���� ���)

        //testTransform.DOLocalJump(new Vector2(3, 0),5,4,5);// (������)

        //testTransform.DOScale(new Vector2(2, 2), 2).SetLoops(4);// (���� �� ����� �����)

        testSprite.DOColor(Color.black, 2);// (���� �� ����� �����)
    }
}
