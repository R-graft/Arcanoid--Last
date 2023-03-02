using System.Collections;
using UnityEngine;

public class OnColl : MonoBehaviour
{
    public Test1 testPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(Corout(0, 1));
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Corout(0, 20));
        }
    }
    private IEnumerator Corout(int startcount, int iterator )
    {
        var numb = startcount;
        while (true)
        {
            
            yield return new WaitForFixedUpdate();

            numb += iterator;
            print(numb);
        }
    }
}
