using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollision : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip[] _clips;

    private void Start()
    {
        _audioSource = GameObject.FindWithTag("ItemSounds").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        AudioClip clip = _clips[Random.Range(0, _clips.Length - 1)];
        _audioSource.PlayOneShot(clip);

        if (TryGetComponent<Coin>(out var coin))
        {
            PlayerDataManager.instance.AddCoin();
            SetStrings.instance.SetCurrentCoins();
            CoinFactory.Instance.ReturnCoin(coin);
            return;
        }
       
        PlayerDataManager.instance.AddMostro();
        _audioSource.PlayOneShot(_clips[0]);
        Destroy(gameObject);
    }
}
