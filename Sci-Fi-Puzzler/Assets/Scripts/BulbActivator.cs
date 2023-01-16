using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbActivator : PuzzleSolution
{
    [SerializeField] private Sprite _offSprite;
    [SerializeField] private Sprite _onSprite;

    private SpriteRenderer _spriteRenderer;
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _offSprite;

    }

    public new void Complete() {
        Debug.Log("Bulb Activated");
        _spriteRenderer.sprite = _onSprite;
    }
}
