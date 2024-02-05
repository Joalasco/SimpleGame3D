using UnityEngine;

public class SeguirEsfera : MonoBehaviour
{
    public Transform objetivo;
    public Vector3 offset = new Vector3(0f, 1.5f, -3f);

    void Update()
    {
        if (objetivo != null)
        {
            transform.position = objetivo.position + offset;
        }
    }
}
