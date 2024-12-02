using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    private float lifetime;

    /// <summary>
    /// Sets the lifetime of the object.
    /// </summary>
    /// <param name="lifetime">Time in seconds before destruction</param>
    public void SetLifetime(float lifetime)
    {
        this.lifetime = lifetime;
        //start the timer to destroy the object
        Invoke(nameof(DestroyObject), lifetime);
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
