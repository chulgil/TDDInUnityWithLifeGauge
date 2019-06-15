using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Editor.Infrastructure
{
    public class ImageBuilder : MonoBehaviour
    {
        private int m_fillAmount;

        public ImageBuilder(int fillAmount)
        {
            m_fillAmount = fillAmount;
        }

        public ImageBuilder() : this(0)
        {

        }

        public ImageBuilder WithFillAmount(int fillAmount)
        {
            m_fillAmount = fillAmount;
            return this;
        }

        public Image Build()
        {
            var image = new GameObject().AddComponent<Image>();
            image.fillAmount = m_fillAmount;
            return image;
        }

        public static implicit operator Image(ImageBuilder imageBuilder)
        {
            return imageBuilder.Build();
        }
    
    }    
}

