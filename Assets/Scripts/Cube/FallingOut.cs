using UnityEngine;

public class FallingOut : MonoBehaviour
{
    [SerializeField] private float _boundaryOfExtinction;

    private void Update()
    {
        if (transform.position.y < _boundaryOfExtinction)
        {
            Destroy(gameObject);
        }
    }
}
