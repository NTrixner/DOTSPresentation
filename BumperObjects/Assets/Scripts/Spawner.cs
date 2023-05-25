using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int amount;
    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
        Resolution currentResolution = Screen.currentResolution;
        for (int i = 0; i < amount; i++)
        {
            GameObject newInstance = Instantiate(prefab);
            float xPos = Random.Range(0.05f, 0.95f);
            float yPos = Random.Range(0.05f, 0.95f);
            newInstance.transform.position = cam.ViewportToWorldPoint(new Vector3(xPos, yPos, 10));
        }
    }
}