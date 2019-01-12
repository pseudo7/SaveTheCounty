using System.Collections;
using UnityEngine;

public class PseudoBlast : MonoBehaviour
{
    public Sprite[] blastSprites;
    public float playSpeed = 3;
    public bool loop;

    SpriteRenderer overlay;

    void Start()
    {
        overlay = GetComponent<SpriteRenderer>();
        StartCoroutine(PlaySpriteAnim());
    }

    IEnumerator PlaySpriteAnim()
    {
        var spritesLength = blastSprites.Length;
        int index = 0;

        while (index < spritesLength)
        {
            overlay.sprite = blastSprites[index++];
            yield return new WaitForSeconds(Time.deltaTime * playSpeed);
            if (loop) index %= spritesLength;
        }
        Destroy(gameObject);
    }
}
