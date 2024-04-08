using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string _gameID;
    [SerializeField] string _adID;

    private void Start()
    {
        Advertisement.Initialize(_gameID, true, this);
    }

    public void ShowAd()
    {
        if (!Advertisement.isInitialized) return;
        Advertisement.Load(_adID, this);
    }


    #region Initialization
    public void OnInitializationComplete()
    {
        //Debug.Log("Initialization completed");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        return;
    }
    #endregion

    #region Load
    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Ad loaded");
        Advertisement.Show(_adID, this);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        return;
    }
    #endregion

    #region Show
    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        return;
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        return;
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        return;
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (placementId == _adID)
        {
            if (showCompletionState == UnityAdsShowCompletionState.SKIPPED || showCompletionState == UnityAdsShowCompletionState.COMPLETED)
                Shop.instance.IncreaseEnergy();
        }

        Debug.Log("Ad watched");
    }
    #endregion
}