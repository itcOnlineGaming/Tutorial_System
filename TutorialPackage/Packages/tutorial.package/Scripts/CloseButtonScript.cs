using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButtonScript : MonoBehaviour
{
    public void ClosePopUp()
    {
        Destroy(transform.parent.gameObject);
    }
}
