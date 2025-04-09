using UnityEngine;

public class ChildSpawner : MonoBehaviour
{
    public GameObject prefab;
    private Vector3 localPosition = Vector3.zero;

    void Update()
    {
        if (transform.childCount == 0)
        {
            GameObject newChild = Instantiate(prefab, transform);
            newChild.transform.localPosition = localPosition;
        }
    }
}
