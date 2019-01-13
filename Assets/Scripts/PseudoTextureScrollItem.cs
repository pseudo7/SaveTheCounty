using UnityEngine;

public class PseudoTextureScrollItem : MonoBehaviour
{
    PseudoTextureScroll textureScroll;
    Vector3 firstItemPositiom, lastItemPosition;

    private void Start()
    {
        if (!textureScroll)
            textureScroll = transform.GetComponentInParent<PseudoTextureScroll>();
    }

    void LateUpdate()
    {
        if (transform.position.x > 25.6f)
            textureScroll.SetPosition(transform);
    }
}