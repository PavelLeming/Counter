using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;


    private void OnEnable()
    {
        _counter.CountChanched += ShowCount;
    }

    private void OnDisable()
    {
        _counter.CountChanched -= ShowCount;
    }

    public void ShowCount(int count)
    {
        Debug.Log(count);
    }
}
