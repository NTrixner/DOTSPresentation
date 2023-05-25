using UnityEngine;

[RequireComponent(typeof(Texture2D))]
public class Mover : MonoBehaviour
{
    private float speed;
    private SpriteRenderer _sprite;
    private Camera cam;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        speed = Random.Range(-1f, 1f);
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 transformPosition = transform.position;
        transformPosition.y += speed * Time.deltaTime * 10f;
        transform.position = transformPosition;
        Bounds spriteBounds = _sprite.sprite.bounds;
        if (cam.WorldToScreenPoint(transform.position - spriteBounds.size / 2f).y <= 0 ||
            cam.WorldToScreenPoint(transform.position + spriteBounds.size / 2f).y >= Screen.height)
        {
            speed *= -1;
        }
    }
}