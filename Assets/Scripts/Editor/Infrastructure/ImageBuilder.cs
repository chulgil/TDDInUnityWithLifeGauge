using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Editor.Infrastructure
{
    public class ImageBuilder : TestDataBuilder<Image>
    {
        private float m_fillAmount;

        public ImageBuilder(float fillAmount)
        {
            m_fillAmount = fillAmount;
        }

        public ImageBuilder() : this(0)
        {

        }

        public ImageBuilder WithFillAmount(float fillAmount)
        {
            m_fillAmount = fillAmount;
            return this;
        }

        public override Image Build
        {
            get
            {
                var image = new GameObject().AddComponent<Image>();
                image.fillAmount = m_fillAmount;
                return image;
            }
        }
    }    
}

