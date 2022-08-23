using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools.DragAndDrop;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Shape : Item
{
    [SerializeField]
    AnimationCurve curve;
    public Slot slot;
    public SpriteRenderer shapeSprite;
    public BoxCollider2D shapeSize;
    public SlotsGenerator slotsGenerator;

    float animationDuration = 0.3f;

    AudioSource pickedSound;
    //Vector2 currentScale;
    public override void OnItemDropped()
    {
        if (slot != null)
        {
            if (this.name == slot.name)
            {
                transform.position = slot.transform.position;
                transform.localScale = new Vector2(0.01f, 0.01f);
                //currentScale = transform.localScale;
                transform.localRotation = slot.transform.localRotation;
                this.enabled = false;
                //StartCoroutine(SlotAnimation());
                slotsGenerator.endgameCounter++;
                transform.DOScale(slot.transform.localScale * 1.05f, animationDuration).SetEase(Ease.InOutSine).OnComplete(() =>
                {
                    if (slotsGenerator.endgameCounter == slotsGenerator.slotsCounter)
                    {
                        slotsGenerator.OpenWindow();
                    }
                });
                shapeSprite.sortingOrder = 1;
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public override void OnItemPicked()
    {
        shapeSprite.sortingOrder = 3;
        CreateClone();
        transform.localScale = new Vector2(0.5f, 0.5f);
        pickedSound.Play();
    }
    void CreateClone()
    {
        Shape clone;
        clone = Instantiate(this, transform.position, Quaternion.identity);
        clone.shapeSprite.sprite = this.shapeSprite.sprite;
        clone.shapeSprite.sortingOrder = 1;
        clone.name = this.name;
        clone.SoundInitialization(pickedSound);
    }
    public void SoundInitialization(AudioSource pickedSound)
    {
        this.pickedSound = pickedSound;
    }
    //public IEnumerator SlotAnimation()
    //{
    //    float ratio = 0;
    //    float startTime = Time.time;
    //    do
    //    {
    //        yield return new WaitForEndOfFrame();
    //        ratio = (Time.time - startTime) / animationDuration;
    //        transform.localScale = Vector2.Lerp(currentScale, slot.transform.localScale, ratio);

    //    } while (ratio < 1);
    //}
}
