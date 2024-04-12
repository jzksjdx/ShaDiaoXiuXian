﻿//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace GameMain
{

    public class ShowHpBarItemInfo : ShowEntityUiItemInfo
    {
        public float targetHpRatio;

        public ShowHpBarItemInfo(int serialId, Entity entity, int typeId, float targetHpRatio) : base(serialId, entity, typeId)
        {
            this.targetHpRatio = targetHpRatio;
        }
    }
    public class HPBarItem : EntityUiItem
    {
        private const float AnimationSeconds = 0.3f;
        private const float KeepSeconds = 0.4f;
        private const float FadeOutSeconds = 0.3f;

        [SerializeField]
        private Slider m_HPBar = null;


        public override void Init(object userData)
        {
            base.Init(userData);
            ShowHpBarItemInfo data = userData as ShowHpBarItemInfo;
            var targetValue = (float)data.targetHpRatio;
            m_HPBar.value = targetValue;
            //StartCoroutine(HPBarCo(targetValue, AnimationSeconds, KeepSeconds, FadeOutSeconds));
        }


        private IEnumerator HPBarCo(float value, float animationDuration, float keepDuration, float fadeOutDuration)
        {
            yield return m_HPBar.SmoothValue(value, animationDuration);
            yield return new WaitForSeconds(keepDuration);
            yield return canvasGroup.FadeToAlpha(0f, fadeOutDuration);
        }
    }
}
