using System;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Collider))]

public class CrushingCube : MonoBehaviour
{
    [SerializeField, Min(0),] private int _minAmountCrushing;
    [SerializeField] private int _maxAmountCrushing;
    [SerializeField, Min(1)] private int _denominatorOfCrushing;
    [SerializeField, Min(1)] private int _denominatorProbabilityOfCrushing;

    private Transform _cubeTransform;
    private Collider _collider;
    private MeshRenderer _meshRenderer;

    public event Action<Vector3> Crushing; 

    public int ProbabilityOfCrushing { get; private set; }

    private void OnValidate()
    {
        if (_minAmountCrushing >= _maxAmountCrushing)
        {
            _maxAmountCrushing = _minAmountCrushing + 1;
        }
    }

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _collider = GetComponent<Collider>();
        _cubeTransform = GetComponent<Transform>();
        ProbabilityOfCrushing = 100;
    }

    public void Crush()
    {
        if (ProbabilityOfCrushing >= UnityEngine.Random.Range(1, 101))
        {
            _meshRenderer.enabled = false;

            for (int i = 0; i < UnityEngine.Random.Range(_minAmountCrushing, _maxAmountCrushing); i++)
            {
                GameObject cube = Instantiate(gameObject);
                cube.transform.localScale = _cubeTransform.localScale / _denominatorOfCrushing;
                cube.GetComponent<MeshRenderer>().enabled = true;
                cube.GetComponent<CrushingCube>().ProbabilityOfCrushing = ProbabilityOfCrushing / _denominatorProbabilityOfCrushing;
                cube.transform.position = _cubeTransform.position;
            }
        }
        else
        {
            Crushing?.Invoke(transform.position);
        }

        Destroy(gameObject);
    }
}
