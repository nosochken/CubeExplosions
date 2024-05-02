using UnityEngine;

public class CubeDestroyer : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private Breaker _breaker;
    private Explosion _explosion;

    private void Awake()
    {
        _breaker = GetComponent<Breaker>();
        _explosion = GetComponent<Explosion>();
    }

    private void Update()
    {
        Cube cube = SelectCube();

        if (cube != null)
            DestroyCube(cube);
    }

    private void DestroyCube(Cube cube)
    {
        if (_breaker.CanBreak(cube))
        {
            _breaker.BreakIntoCubes(cube);
            _explosion.Explode(cube);
        }

        Destroy(cube.gameObject);
    }

    private Cube SelectCube()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            float maxDistance = 20;

            Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.cyan);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out Cube cube))
                    return cube;
            }
        }

        return null;
    }
}