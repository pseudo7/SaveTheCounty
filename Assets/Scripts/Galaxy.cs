using System.Collections;
using UnityEngine;

public class Galaxy : MonoBehaviour
{
    public float minAlpha = .6f;
    public float delay = 1f;

    SpriteRenderer[] stars;

    private void Awake()
    {
        stars = GetComponentsInChildren<SpriteRenderer>();
    }

    void Start()
    {
        StartCoroutine(Twinkle());
    }

    IEnumerator Twinkle()
    {
        while (gameObject.activeInHierarchy)
        {
            yield return new WaitForSeconds(delay);
            foreach (var star in stars)
                StartCoroutine(CrossFade(star, new Color(1, 1, 1, Random.Range(0, 10) % 2 == 0 ? minAlpha : 1)));
        }
    }

    IEnumerator CrossFade(SpriteRenderer sprite, Color color)
    {
        float a = sprite.color.r;
        if (a < color.a)
            while (a <= color.a)
            {
                sprite.color = new Color(1, 1, 1, a += Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
        else
            while (a >= color.a)
            {
                sprite.color = new Color(1, 1, 1, a -= Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
    }
}
