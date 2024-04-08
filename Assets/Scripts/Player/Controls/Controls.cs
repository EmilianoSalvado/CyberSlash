using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controls : MonoBehaviour
{
    [SerializeField] float _timer;
    [SerializeField] float _swipeTimeBegin;
    [SerializeField] float _minVectorMagnitude;
    [SerializeField] protected PlayerActions _playerActions;

    Vector3 _aPos;
    Vector3 _bPos;
    Vector3 _swipeVector;

    private void Update()
    {
        if (Input.touchCount < 1) return;

        if (Input.touches[0].phase == TouchPhase.Began)
        {
            _aPos = Input.touches[0].position;
            _timer = 0;
        }

        if (Input.touches[0].phase == TouchPhase.Ended)
        {
            if (_timer < _swipeTimeBegin)
            {
                TouchAction();
                return;
            }

            _bPos = Input.touches[0].position;
            _swipeVector = _bPos - _aPos;

            if (_swipeVector.magnitude > _minVectorMagnitude)
                SwipeAction(_swipeVector);

            _timer = 0;
        }

        _timer += Time.deltaTime;
    }

    protected abstract void TouchAction();
    protected abstract void SwipeAction(Vector3 swipeDir);
}
