using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    private float _delay = 0.5f;
    private int _count = 0;
    private IEnumerator _countup;
    private bool isRun = true;
    public event Action<int> CountChanched;

    private void Start()
    {
        _countup = Countup(_delay);
        StartCoroutine(_countup);
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
                StartCoroutine(_countup);
                isRun = true;
            }
        }
    }

    private IEnumerator Countup(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (enabled)
        {
            CountChanched?.Invoke(_count);
            _count++;
            yield return wait;
        }
    }
}
