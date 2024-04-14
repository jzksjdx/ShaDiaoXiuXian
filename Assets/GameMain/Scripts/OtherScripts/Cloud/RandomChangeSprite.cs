using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomChangeSprite : MonoBehaviour
{
    public List<Sprite> randomSprites;
    
    SpriteRenderer m_SpriteRenderer;
    // Start is called before the first frame update

    private void Awake()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        m_SpriteRenderer.sprite = randomSprites[Random.Range(0,randomSprites.Count)];
    }
}
