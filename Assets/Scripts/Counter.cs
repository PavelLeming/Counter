using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    private float _delay = 0.5f;
    public int Count { get; private set; }
    private Coroutine _countup;
    CounterView counterView = new CounterView();
    private bool isRun = true;
    public event UnityAction CountChanched;

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
            CountChanched?.Invoke();
            Count++;
            yield return wait;
        }
    }
}
