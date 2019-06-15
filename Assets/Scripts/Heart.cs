using System;
using UnityEngine.UI;

public class Heart 
{
    public static readonly int HEART_PIECES_PER_HEART = 4;
    private const float FILL_PER_HEART_PIECE = 0.25f;
    private readonly Image m_image;

    public Heart(Image image)
    {
        m_image = image;
    }

    public void Replenish(int numberOfHeartPieces)
    {
        if (numberOfHeartPieces < 0) throw new ArgumentOutOfRangeException("numberOfHeartPieces must be positive", "numberofHeartPices");
        m_image.fillAmount += numberOfHeartPieces * FILL_PER_HEART_PIECE;
    }

    public void Deplete(int numberOfHeartPieces)
    {
        if (numberOfHeartPieces < 0) throw new ArgumentOutOfRangeException("numberOfHeartPieces must be positive", "numberofHeartPices");
        m_image.fillAmount -= numberOfHeartPieces * FILL_PER_HEART_PIECE;
    }

}