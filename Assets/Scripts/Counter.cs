using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private float _delay = 0.5f;
    private int _count = 0;
    private Coroutine _countup;
    CounterView counterView = new CounterView();
    private bool isRun = true;

    private void Start()
    {
        _countup = StartCoroutine(Countup(_delay));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isRun)
            {
                StopCoroutine(_countup);
                isRun = false;
            }
            else
            {
                StartCoroutine(Countup(_delay));
                isRun = true;
            }
        }
    }

    private IEnumerator Countup(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (enabled)
        {
            counterView.ShowCount(_count);
            _count++;
            yield return wait;
        }
    }
}
