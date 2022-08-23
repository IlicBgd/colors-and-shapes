using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsGenerator : MonoBehaviour
{
    [SerializeField]
    Sprite[] sprites;
    [SerializeField]
    Slot slotPrefab;
    [SerializeField]
    Vector2 gridSize;

    public HelpWindow endgameWindow;
    public int slotsCounter = 0;
    public int endgameCounter = 0;

    Vector2 offset;
    Vector2 startPosition;
    private void Start()
    {
        GenerateSlots();
    }
    public void GenerateSlots()
    {
        startPosition = transform.position;
        int randomSprite;
        int randomNumberRotate;
        float[] rotateBool = new float[2] { 0, 90 };

        offset.x = slotPrefab.slotSize.size.x * slotPrefab.transform.localScale.x * 2.5f;
        offset.y = slotPrefab.slotSize.size.y * slotPrefab.transform.localScale.y * 1.5f;
        for (int i = 0; i < gridSize.x; i++)
        {
            for (int j = 0; j < gridSize.y; j++)
            {
                Slot slot;
                Vector2 newPosition = startPosition + new Vector2(offset.x * i, -offset.y * j);
                slot = Instantiate(slotPrefab, newPosition, Quaternion.identity, transform);
                randomSprite = Random.Range(0, sprites.Length);
                slot.slotSprite.sprite = sprites[randomSprite];
                randomNumberRotate = Random.Range(0, 2);
                slot.transform.Rotate(0, 0, rotateBool[randomNumberRotate]);
                slot.name = sprites[randomSprite].name;
                slotsCounter++;
            }
        }
    }
}
