using System.Collections;
using UnityEngine;

public class Panel : MonoBehaviour
{
    Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void SetEmissionColor(Color color)
    {
        if (_renderer != null && _renderer.material != null)
        {
            _renderer.material.EnableKeyword("_EMISSION");
            _renderer.material.color = color;
            _renderer.material.SetColor("_EmissionColor", color * 2f);

            StartCoroutine(ChangeBackToBlack());
        }
    }

    IEnumerator ChangeBackToBlack()
    {
        yield return new WaitForSeconds(0.01f);

        float duration = 0.5f;
        float elapsedTime = 0f;
        Color startColor = _renderer.material.GetColor("_EmissionColor");

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            Color newColor = Color.Lerp(startColor, Color.black, elapsedTime / duration);
            _renderer.material.SetColor("_EmissionColor", newColor);
            _renderer.material.color = newColor;
            yield return null;
        }

        _renderer.material.SetColor("_EmissionColor", Color.black);
        _renderer.material.color = Color.black;
    }
}
