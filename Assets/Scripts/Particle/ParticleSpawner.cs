using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    private GameObject splashParticle;
    private GameObject splashObject;
    private ParticleSystem specialParticle;

    private void Awake()
    {
        splashParticle = Resources.Load<GameObject>("Prefabs/SplashParticle");
        splashObject = Resources.Load<GameObject>("Prefabs/SplashObject");

        specialParticle = GameObject.FindGameObjectWithTag("SpecialParticle").GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        GameManager.Instance.OnSpecialChanged += OnSpecialChanged;
        GameManager.Instance.OnGameFailed += OnGameFailed;
    }

    private void OnGameFailed()
    {
        Destroy(this);
    }

    private void OnSpecialChanged(bool isActive)
    {
        if (isActive)
        {
            specialParticle.Play();
        }
        else
        {
            specialParticle.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        SpawnSplashObject(collision);
    }

    private void SpawnSplashObject(Collision collision)
    {
        if (!transform) return;

        SpawnSplashParticle();

        Instantiate(splashObject, transform.position + new Vector3(0, 0.05f), Quaternion.Euler(0, Random.Range(0, 360), 0), collision.transform.parent);
    }

    private void SpawnSplashParticle()
    {
        Instantiate(splashParticle, transform.position, Quaternion.Euler(new Vector3(-90, 0)));
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnSpecialChanged -= OnSpecialChanged;
    }
}
