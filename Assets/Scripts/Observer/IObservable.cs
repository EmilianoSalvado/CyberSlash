using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObservable
{
    void Subscribe(IObserver observer);
    void NotifySubscribers(string action);
    void Unsubscribe();
}
