using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour
{
    private Ease moveEase = Ease.Linear;
    private float moveDuration = 1f;
    [SerializeField] private Transform destination;
    [SerializeField] private Transform cameraTransform;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("enter");

            other.transform.position = destination.position;
            Vector3 destinationPosition = destination.position;
            destinationPosition.y = cameraTransform.position.y;
            cameraTransform.DOMoveX(destinationPosition.x, moveDuration).SetEase(moveEase);
        }
    }
}