using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Editor
{
    public class HeartContainerTests : MonoBehaviour
    {
        #region TestReplenishMethod
        public class TestReplenishMethod
        {
            protected Image Target;

            [SetUp]
            public void BeforeEveryTest()
            {
                Target = new GameObject().AddComponent<Image>();
            }

            [Test]
            public void _0_Sets_Image_With_0_Fill_To_0_Fill()
            {
                Target.fillAmount = 0;
                var heart = new Heart(Target);
                var HeartContainer = new HeartContainer(new List<Heart> {heart});

                HeartContainer.Replenish(0);

                Assert.AreEqual(0, Target.fillAmount);
            }

            [Test]
            public void _1_Sets_Image_With_0_Fill_To_25_Percent_Fill()
            {
                Target.fillAmount = 0;
                var heart = new Heart(Target);
                var heartContainer = new HeartContainer(new List<Heart> {heart});

                heartContainer.Replenish(1);

                Assert.AreEqual(0.25f, Target.fillAmount);
            }

            [Test]
            public void _Empty_Hearts_Are_Replenished()
            {
                Target.fillAmount = 0;
                var image = new GameObject().AddComponent<Image>();
                image.fillAmount = 1;
                var heartContainer = new HeartContainer(
                    new List<Heart> {new Heart(image), new Heart(Target)});
                heartContainer.Replenish(1);

                Assert.AreEqual(0.25f, Target.fillAmount);
            }

            [Test]
            public void _Hearts_Are_Replenished_One_At_A_Time()
            {
                Target.fillAmount = 0;
                var image = new GameObject().AddComponent<Image>();
                image.fillAmount = 0;
                var heartContainer = new HeartContainer(
                    new List<Heart> {new Heart(image), new Heart(Target)});
                heartContainer.Replenish(1);

                Assert.AreEqual(0, Target.fillAmount);
            }

            public class HeartContainer
            {
                private readonly List<Heart> m_hearts;

                public HeartContainer(List<Heart> hearts) => m_hearts = hearts;

                public void Replenish(int numberOfHeartPieces)
                {
                    foreach (var heart in m_hearts)
                        heart.Replenish(numberOfHeartPieces);
                }
            }

        }
        #endregion


    }
}
