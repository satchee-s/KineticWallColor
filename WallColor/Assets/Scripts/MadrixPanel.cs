using System.Collections;
using UnityEngine;

public class MadrixPanel : MonoBehaviour
{
    SpriteRenderer _renderer;
    Coroutine currCoroutine;
    Color secondColor;
    Color lastColor;
    Color[] possibleColors = { Color.red, Color.green, Color.cyan, Color.magenta };

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void SetEmissionColor()
    {
        if (currCoroutine != null)
        {
            StopCoroutine(currCoroutine);
        }

        secondColor = GetRandomColor(lastColor);

        currCoroutine = StartCoroutine(ChangeColorEffect(Color.yellow, secondColor, Color.blue));
    }

    IEnumerator ChangeColorEffect(Color first, Color second, Color third)
    {
        yield return LerpColor(first, second, 0.8f, 1f);
        yield return LerpColor(second, third, 0.8f, 1f); 
        yield return LerpColor(third, third, 0.8f, 0f);
    }

    IEnumerator LerpColor(Color startColor, Color targetColor, float duration, float targetAlpha)
    {
        float elapsedTime = 0f;
        Color startColorWithAlpha = new Color(startColor.r, startColor.g, startColor.b, _renderer.color.a);
        Color targetColorWithAlpha = new Color(targetColor.r, targetColor.g, targetColor.b, targetAlpha);

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float lerpFactor = elapsedTime / duration;
            Color newColor = Color.Lerp(startColorWithAlpha, targetColorWithAlpha, lerpFactor);
            SetObjectColor(newColor);
            yield return null;
        }

        SetObjectColor(targetColorWithAlpha);
    }

    void SetObjectColor(Color color)
    {
        if (_renderer != null)
        {
            _renderer.color = color;
        }
    }

    Color GetRandomColor(Color excludeColor)
    {
        Color newColor;
        do
        {
            newColor = possibleColors[Random.Range(0, possibleColors.Length)];
        } while (newColor == excludeColor);

        return newColor;
    }
}
