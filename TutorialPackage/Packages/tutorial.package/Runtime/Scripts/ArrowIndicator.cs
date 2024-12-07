using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ArrowIndicator : MonoBehaviour
{
    [Header("Arrow Configuration")]
    public float angle;
    public float radius;

    [Header("Movement Threshold")]
    public float movementThreshhold = 20f;
    public float speed = 5f;

    private Transform toIndicate;

    private float minRadius;
    private GameObject arrowObject;
    private GameObject objectToIndicate;

    private void Awake()
    {
        arrowObject = transform.Find("Arrow").gameObject;
    }

    public void SetUp(PopUpData arrowPopUpData)
    {
        angle = arrowPopUpData.angle;
        radius = arrowPopUpData.radius;
    }

    public void setObjectToIndicate(Transform position)
    {
        toIndicate = position;
    }
    void Start()
    {
        minRadius = radius;
    }
    /// <summary>
    /// Sets arrow distance based on a cricle circumference and radius with the center point being set
    /// </summary>
    void setDistance()
    {
        if (angle >= 360f || angle < 0)
        {
            angle = 0;
        }
        float angleRad = angle * Mathf.Deg2Rad;

        float x = toIndicate.position.x + minRadius * Mathf.Cos(angleRad);
        float y = toIndicate.position.y + minRadius * Mathf.Sin(angleRad);

        arrowObject.GetComponent<RectTransform>().position = new Vector3(x, y, arrowObject.transform.position.z);
    }

    /// <summary>
    /// Points arrow to look ar object you want to indicate
    /// </summary>
    void pointArrowAtObject()
    {
        Vector3 direction = toIndicate.position - arrowObject.transform.position;

        float fangle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        arrowObject.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, fangle);
    }
    /// <summary>
    /// Moves arrow back and forth
    /// </summary>
    void animateArrow()
    {
        minRadius = radius + Mathf.PingPong(Time.time * speed, movementThreshhold) - (movementThreshhold / 2);
    }

    // Update is called once per frame
    void Update()
    {
        setDistance();
        pointArrowAtObject();
        animateArrow();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
