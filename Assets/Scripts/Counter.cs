using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private float _delay = 0.5f;
    private int _count = 0;
    private bool isRun = true;

    private void Start()
    {
        StartCoroutine(Countup(_delay));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isRun)
            {
                StopAllCoroutines();
                isRun = false;
            }
            else
            {
                StartCoroutine(Countup(_delay));
                isRun= true;
            }
        }
    }

    private IEnumerator Countup(float delay)
    {
        while (true)
        {
            Debug.Log(_count++);
            yield return new WaitForSeconds(delay);
        }
    }
}
