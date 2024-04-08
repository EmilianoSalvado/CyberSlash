using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerInPlace : MonoBehaviour, IObservable
{
    [SerializeField] Transform _finalPosition;

    public Transform FinalPosition { get { return _finalPosition; } }

    [SerializeField] GameObject _observerObject;
    List<IObserver> _observers = new List<IObserver>();

    public GameObject EnemyAttached { get { return _observerObject; } }

    private void Start()
    {
        if (_observerObject != null)
            _observers.Add(_observerObject.GetComponent<IObserver>());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerMovement>(out PlayerMovement playerMovement))
        {
            if (FinalPosition != null)
            {
                playerMovement.SetInPlaceInstantly(_finalPosition.position);

                if (_observers.Count <= 0) return;
                    NotifySubscribers("Attack");

                return;
            }

            if (other.TryGetComponent<PlayerActions>(out PlayerActions playerActions))
                playerActions.Stop();
        }

        GetComponent<Collider>().enabled = false;
    }

    public void NotifySubscribers(string action)
    {
        for (int i = _observers.Count - 1; i >= 0; i--)
        {
            _observers[i].Notify(action);
        }
    }

    public void Subscribe(IObserver observer)
    {
        if (!_observers.Contains(observer))
            _observers.Add(observer);
    }

    public void Unsubscribe()
    {
        throw new System.NotImplementedException();
    }
}
