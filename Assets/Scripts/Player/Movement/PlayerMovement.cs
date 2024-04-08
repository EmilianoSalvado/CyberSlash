using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;

    [SerializeField] bool _run;
    [SerializeField] float _speed;
    [SerializeField] float _jumpForce;
    [SerializeField] float _translationSpeed;

    [SerializeField] Vector3 _finalPosition;
    [SerializeField] Vector3 _add;

    [SerializeField] PlayerActions _playerActions;

    bool _stop;

    private void Awake()
    {
        _stop = true;
        _rb = GetComponent<Rigidbody>();
        _add = transform.forward * (_speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if (_stop) return;

        if (!_run && transform.position.y > _finalPosition.y)
        {
            if (_add.magnitude > (Vector3.Distance(new Vector3(_finalPosition.x, 0, _finalPosition.z), new Vector3(transform.position.x, 0, transform.position.z))))
                _add = new Vector3(_finalPosition.x, 0, _finalPosition.z) - new Vector3(transform.position.x, 0, transform.position.z);

            if (Vector3.Distance(new Vector3(_finalPosition.x, 0, _finalPosition.z), new Vector3(transform.position.x, 0, transform.position.z)) < .2f) _playerActions.Stop();

            _rb.MovePosition(transform.position += _add);
            return;
        }

        if (_run)
            _rb.MovePosition(transform.position += _add);
    }

    public void Run()
    {
        _add = transform.forward * (_speed * Time.fixedDeltaTime);
        _run = true;
        _stop = false;
    }

    public void Jump()
    {
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

    public void SetInPlace(Vector3 position)
    {
        _stop = false;

        _run = false;

        _finalPosition = new Vector3(position.x, transform.position.y, position.z);

        _add = (new Vector3(_finalPosition.x, 0, _finalPosition.z) - new Vector3(transform.position.x, 0, transform.position.z)).normalized * (_translationSpeed * Time.fixedDeltaTime);
    }

    public void SetInPlaceInstantly(Vector3 position)
    {
        transform.position += (new Vector3(position.x, 0, position.z) - new Vector3(transform.position.x, 0, transform.position.z));
        _playerActions.Stop();
    }

    public void Stop()
    {
        _add = Vector3.zero;
        _stop = true;
    }
}