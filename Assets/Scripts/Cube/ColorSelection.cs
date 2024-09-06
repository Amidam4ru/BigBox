using UnityEngine;

public class ColorSelection : MonoBehaviour
{
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Start()
    {
        _renderer.material.color = new Color(Random.value, Random.value, Random.value);   
    }
}
