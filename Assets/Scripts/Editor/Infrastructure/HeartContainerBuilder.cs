using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Editor.Infrastructure
{
    public class HeartContainerBuilder : TestDataBuilder<HeartContainer>
    {
        private List<Heart> m_hearts;

        public HeartContainerBuilder(List<Heart> hearts)
        {
            m_hearts = hearts;
        }

        public HeartContainerBuilder() : this(new List<Heart>())
        {

        }

        public HeartContainerBuilder With(Heart heart, Heart target = null)
        {
            m_hearts.Add(heart);
            if(target != null) m_hearts.Add(target);
            return this;
        }

        public override HeartContainer Build => new HeartContainer(m_hearts);
    }
}