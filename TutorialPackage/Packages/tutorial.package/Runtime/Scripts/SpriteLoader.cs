using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class SpriteLoader : MonoBehaviour
{
    public string spriteAddress = "Tutorial Package/Assets/Arrow";

    void Start()
    {
        Addressables.LoadAssetAsync<Sprite>(spriteAddress).Completed += OnSpriteLoaded;
        gameObject.SetActive(false);
    }


    void OnSpriteLoaded(AsyncOperationHandle<Sprite> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            // The sprite has been loaded successfully, now use it
            Image spriteRenderer = GetComponent<Image>();
            spriteRenderer.sprite = handle.Result;
            gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("Failed to load sprite.");
        }
    }
}
