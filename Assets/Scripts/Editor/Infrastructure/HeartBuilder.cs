using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Editor.Infrastructure
{
    public class HeartBuilder : TestDataBuilder<Heart>
    {
        private Image m_image;

        public HeartBuilder(Image image)
        {
            m_image = image;
        }

        public HeartBuilder() : this(An.Image())
        {

        }

        public HeartBuilder With(Image image)
        {
            m_image = image;
            return this;
        }

        public override Heart Build => new Heart(m_image);

    }    
}
