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

    public bool isTaken;
    public float shakeDuration = 0.4f;
    protected override void OnItemDropped(Item item)
    {
        if (!isTaken && item.name == this.name)
        {
            ((Shape)item).slot = this;
            isTaken = true;
        }
        else
        {
            transform.DOShakePosition(shakeDuration,new Vector3(0.2f, 0, 0), 70, 0);
        }
    }
    protected override void OnItemPicked(Item item)
    {

    }
}
