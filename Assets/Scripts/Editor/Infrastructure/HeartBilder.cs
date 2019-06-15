using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Editor.Infrastructure
{
    public class HeartBuilder : MonoBehaviour
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

        public Heart Build()
        {
            return new Heart(m_image);
        }

        public static implicit operator Heart(HeartBuilder heartBuilder)
        {
            return heartBuilder.Build();
        }
    
    }    
}

