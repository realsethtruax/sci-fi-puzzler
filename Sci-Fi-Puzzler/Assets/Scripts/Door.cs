using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour, IActivatable, ILockable
{
  //  private Ease moveEase = Ease.Linear;
    //private float moveDuration = 1f;
    [SerializeField] private Transform destination;
    [SerializeField] private Transform cameraTransform;

    private Animator animator;
    private Collider2D doorCollision;

    private bool _isOpen = false;

    void Awake() {
        animator = GetComponent<Animator>();
        doorCollision = GetComponent<Collider2D>();
    }

    //public void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        if (!_isOpen)
    //        {
    //            animator.SetBool("isOpen", true);
    //            //Open Door
    //        }
    //        other.transform.position = destination.position;
    //        Vector3 destinationPosition = destination.position;
    //        destinationPosition.y = cameraTransform.position.y;
    //        cameraTransform.DOMoveX(destinationPosition.x, moveDuration).SetEase(moveEase);
    //    }
    //}

    //public void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.CompareTag("ActivationArea"))
    //    {
    //        if (_isOpen)
    //        {
    //            animator.SetBool("isOpen", false);
    //        }
    //    }
    //}

    public void Activate() {
        _isOpen = true;
        animator.SetBool("isOpen", _isOpen);
        StartCoroutine(DisableDoorCollision());
        AudioManager.instance.PlayOneShot(FMODEvents.instance.doorOpen, this.transform.position);
    }

    public void Deactivate() {
        _isOpen = false;
        animator.SetBool("isOpen", _isOpen);
        StartCoroutine(EnableDoorCollision());
        AudioManager.instance.PlayOneShot(FMODEvents.instance.doorClose, this.transform.position);
    }

    IEnumerator DisableDoorCollision() {
        yield return new WaitForSeconds(.6f);
        doorCollision.enabled = false;
    }
    IEnumerator EnableDoorCollision() {
        yield return new WaitForSeconds(.4f);
        doorCollision.enabled = true;
    }

    public void Lock()
    {
        throw new System.NotImplementedException();
    }

    public void Unlock()
    {
        throw new System.NotImplementedException();
    }
}