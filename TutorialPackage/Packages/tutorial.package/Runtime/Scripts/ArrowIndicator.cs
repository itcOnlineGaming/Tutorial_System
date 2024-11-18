using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Codice.CM.Common;
public class ArrowIndicator : MonoBehaviour
{
    [Header("Arrow Configuration")]
    public float angle;
    public float radius;
    public Sprite inputSprite;

    [Header("Object To Indicate")]
    public GameObject toIndicate;

    [Header("Movement Threshold")]
    public float movementThreshhold = 20f;
    public float speed = 5f;

    private float minRadius;
    private GameObject arrowObject;
    private GameObject objectToIndicate;

    private void Awake()
    {
        arrowObject = transform.Find("Arrow").gameObject;
        if (!toIndicate)
        {
            objectToIndicate = transform.Find("ObjectToIndicate").gameObject;
        }
        else
        {
            objectToIndicate = toIndicate;
        }
    }
    /// <summary>
    /// Debug in editor
    /// </summary>
    private void OnValidate()
    {
        minRadius = radius;
        arrowObject = transform.Find("Arrow").gameObject;
        if (!toIndicate)
        {
            objectToIndicate = transform.Find("ObjectToIndicate").gameObject;
        }
        else
        {
            objectToIndicate = toIndicate;
        }
        setDistance();
        pointArrowAtObject();
    }
    void Start()
    {
        minRadius = radius;
        if (inputSprite)
        {
            arrowObject.GetComponent<Image>().sprite = inputSprite;
        }
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

        float x = objectToIndicate.transform.position.x + minRadius * Mathf.Cos(angleRad);
        float y = objectToIndicate.transform.position.y + minRadius * Mathf.Sin(angleRad);

        arrowObject.GetComponent<RectTransform>().position = new Vector3(x, y, arrowObject.transform.position.z);
    }

    /// <summary>
    /// Points arrow to look ar object you want to indicate
    /// </summary>
    void pointArrowAtObject()
    {
        Vector3 direction = objectToIndicate.transform.position - arrowObject.transform.position;

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
}
