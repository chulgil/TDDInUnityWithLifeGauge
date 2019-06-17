using System;
using UnityEngine.UI;

public class Heart
{
    public static readonly int HeartPiecesPerHeart = 4;
    private const float FILL_PER_HEART_PIECE = 0.25f;
    private readonly Image m_image;

    public Heart(Image image)
    {
        m_image = image;
    }

    public int FilledHeartPieces 
    {
        get { return CalculateFilledHeartPieces(); }
    }

    public int EmptyHeartPieces
    {
        get { return HeartPiecesPerHeart - CalculateFilledHeartPieces(); }
    }

    private int CalculateFilledHeartPieces()
    {
        return (int) (m_image.fillAmount * HeartPiecesPerHeart);
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