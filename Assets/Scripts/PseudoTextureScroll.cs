using UnityEngine;

public class PseudoTextureScroll : MonoBehaviour
{
    public float scrollSpeed = 1;

    Transform[] children;
    Transform firstChild, lastChild;
    int childCount;

    void Start()
    {
        childCount = transform.childCount;
        children = new Transform[childCount];
        for (int i = 0; i < childCount; i++)
            children[i] = transform.GetChild(i);
        firstChild = children[0];
        lastChild = children[childCount - 1];
    }

    internal void SetPosition(Transform itemTransform)
    {
        if (scrollSpeed > 0)
        {
            itemTransform.position = firstChild.position + new Vector3(-25.6f, 0);
            firstChild = itemTransform;
        }
        else
        {
            itemTransform.position = lastChild.position + new Vector3(25.6f, 0);
            lastChild = itemTransform;
        }
    }

    void Update()
    {
        transform.position += Vector3.right * scrollSpeed * Time.deltaTime;
    }

}