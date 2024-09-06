using UnityEngine;

[RequireComponent(typeof(Checking—lickOnCube))]

public class StartingCrushingCube : MonoBehaviour
{
    private Checking—lickOnCube _checking—lickOnCube;

    private void Awake()
    {
        _checking—lickOnCube = GetComponent<Checking—lickOnCube>();
    }

    private void OnEnable()
    {
        _checking—lickOnCube.CubeClick += StartCrushCube;
    }

    private void OnDisable()
    {
        _checking—lickOnCube.CubeClick -= StartCrushCube;
    }

    private void StartCrushCube(GameObject cube)
    {
        cube.GetComponent<CrushingCube>().Crush();
    }
}
