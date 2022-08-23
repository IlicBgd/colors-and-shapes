using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapesGenerator : MonoBehaviour
{
    [SerializeField]
    Sprite[] sprites;
    [SerializeField]
    Shape shapePrefab;
    [SerializeField]
    AudioSource pickedSound;
    [SerializeField]
    int width = 3;
    [SerializeField]
    int height = 6;

    public SlotsGenerator slotsGenerator;

    Vector2 offset;
    Vector2 startPosition;
    private void Start()
    {
        GenerateShapes();
    }
    void GenerateShapes()
    {
        startPosition = transform.position;

        int counter = sprites.Length - 1;

        offset.x = shapePrefab.shapeSize.size.x * shapePrefab.transform.localScale.x * 2;
        offset.y = shapePrefab.shapeSize.size.y * shapePrefab.transform.localScale.y * 1.5f;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (counter == -1)
                {
                    return;
                }
                Shape shape;
                Vector2 newPosition = startPosition + new Vector2(offset.x * i, -offset.y * j);
                shape = Instantiate(shapePrefab, newPosition, Quaternion.identity, transform);
                shape.shapeSprite.sprite = sprites[counter];
                shape.name = sprites[counter].name;
                shape.slotsGenerator = slotsGenerator;
                shape.shapeSprite.sortingOrder = 1;
                shape.SoundInitialization(pickedSound);
                counter--;
            }
        }
    }
}
