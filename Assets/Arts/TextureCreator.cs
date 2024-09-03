using UnityEngine;

public class TextureCreator : MonoBehaviour
{
    public int width = 256; // Width of the texture
    public int height = 256; // Height of the texture
    public Color fillColor = Color.red; // Color to fill the texture

    void Start()
    {
        // Create a new Texture2D
        Texture2D texture = new Texture2D(width, height);

        // Fill the texture with a single color
        Color[] pixels = new Color[width * height];
        for (int i = 0; i < pixels.Length; i++)
        {
            pixels[i] = fillColor;
        }
        texture.SetPixels(pixels);
        texture.Apply();

        // Assign the texture to a GameObject's material
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.mainTexture = texture;
        }
    }
}
