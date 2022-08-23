using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools.DragAndDrop;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Slot : Tools.DragAndDrop.Slot
{
    public SpriteRenderer slotSprite;
    public BoxCollider2D slotSize;
    [SerializeField]
    AudioSource errorSound;
    [SerializeField]
    AudioSource popSound;

    public bool isTaken;
    public float shakeDuration = 0.4f;
    protected override void OnItemDropped(Item item)
    {
        if (!isTaken && item.name == this.name)
        {
            ((Shape)item).slot = this;
            popSound.Play();
            isTaken = true;
        }
        else if (!isTaken)
        {
            transform.DOShakePosition(shakeDuration,new Vector3(0.2f, 0, 0), 70, 0);
            errorSound.Play();
        }
    }
    protected override void OnItemPicked(Item item)
    {

    }
    public void InitializeSounds(AudioSource errorSound, AudioSource popSound)
    {
        this.errorSound = errorSound;
        this.popSound = popSound;
    }
}
