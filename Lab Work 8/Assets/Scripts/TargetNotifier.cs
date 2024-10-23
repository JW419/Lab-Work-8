using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetNotifier : MonoBehaviour
{
    private List<ScoreObserver> observers = new List<ScoreObserver>();

    public void Subscribe(ScoreObserver observer)
    {
        observers.Add(observer);
    }

    public void Unsubscribe(ScoreObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notify(int points)
    {
        foreach (var observer in observers)
        {
            observer.OnTargetHit(points);
        }
    }
}
