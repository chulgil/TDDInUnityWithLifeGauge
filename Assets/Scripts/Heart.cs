using System;
using UnityEngine.UI;

public class Heart 
{
    private const float FillPerHeartPercentage = 0.25f;
    private readonly Image m_image;

    public Heart(Image image)
    {
        m_image = image;
    }

    public void Replenish(int numberOfHeartPieces)
    {
        if (numberOfHeartPieces < 0) throw new ArgumentOutOfRangeException("numberOfHeartPieces must be positive", "numberofHeartPices");
        m_image.fillAmount += numberOfHeartPieces * FillPerHeartPercentage;
    }

    public void Deplete(int numberOfHeartPieces)
    {
        if (numberOfHeartPieces < 0) throw new ArgumentOutOfRangeException("numberOfHeartPieces must be positive", "numberofHeartPices");
        m_image.fillAmount -= numberOfHeartPieces * FillPerHeartPercentage;
    }

}