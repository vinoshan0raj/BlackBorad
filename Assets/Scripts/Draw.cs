using UnityEngine;
using UnityEngine.UI;

public class Draw : MonoBehaviour
{
    public SpriteRenderer paintingSurface; 
    public Texture2D paintingTexture; 
    public Color brushColor = Color.white;

    public void SetWhiteColor() 
    { 
        SetBrushColor(Color.white); 
    }
    public void SetRedColor() 
    { 
        SetBrushColor(Color.red); 
    }
    public void SetBlueColor() 
    { 
        SetBrushColor(Color.blue); 
    }

    private void Start()
    {
        paintingTexture = new Texture2D(paintingTexture.width, paintingTexture.height);
        paintingSurface.sprite = Sprite.Create(paintingTexture, new Rect(0, 0, paintingTexture.width, paintingTexture.height), new Vector2(0.5f, 0.5f));
        ClearTexture();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Paint();
        }
    }

    private void Paint()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null && hit.collider.gameObject == paintingSurface.gameObject)
        {
            Vector2 localPosition = hit.point;
            Vector2 texturePosition = (localPosition - (Vector2)paintingSurface.transform.position) / paintingSurface.bounds.size;
            Vector2 uvPosition = new Vector2((texturePosition.x + 0.5f) * paintingTexture.width, (texturePosition.y + 0.5f) * paintingTexture.height);

            int x = Mathf.FloorToInt(uvPosition.x);
            int y = Mathf.FloorToInt(uvPosition.y);

            if (x >= 0 && x < paintingTexture.width && y >= 0 && y < paintingTexture.height)
            {
                paintingTexture.SetPixel(x, y, brushColor);
                paintingTexture.Apply();
            }
        }
    }

    public void SetBrushColor(Color color)
    {
        brushColor = color;
    }

    public void ClearTexture()
    {
        Color[] clearPixels = new Color[paintingTexture.width * paintingTexture.height];
        for (int i = 0; i < clearPixels.Length; i++)
        {
            clearPixels[i] = Color.black; 
        }
        paintingTexture.SetPixels(clearPixels);
        paintingTexture.Apply();
    }

    public void ClearPainting()
    {
        ClearTexture();
    }

}
