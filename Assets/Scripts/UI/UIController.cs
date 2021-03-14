﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Planetarity.PlayerFunctionality;

namespace Planetarity.UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField]
        private Slider slider;
        [SerializeField]
        private Text HPtext;

        private Image sliderImage;
        private Player player; 
        public Color camBackgroundColor1;
        public Color camBackgroundColor2;
        [SerializeField]
        private Canvas canvas;
        //private UIBuilder builder;

        private void Start()
        {
            player = GameManagement.GameManager.Instance.Player;
            player.HPchanged += OnPlayerHPChanged;
            player.CooldownChanged += OnPlayerCooldownChanged;

            sliderImage = slider.transform.GetChild(0).GetComponent<Image>();
        }

        void OnPlayerHPChanged(float newHP)
        {
            HPtext.text = "    Current HP - " + newHP;
        }

        void OnPlayerCooldownChanged(float newCD)
        {
            slider.maxValue = newCD;
            slider.value = newCD;
            sliderImage.color = new Color(1f, 0.5f, 0f);
        }

        private void Update()
        {
            if (slider.value > 0)
            {

                slider.value -= Time.deltaTime;
                if (slider.value <= 0)
                    sliderImage.color = Color.green;
            }

            CameraBackgroundColorLerp();
        }

        public Canvas getCanvas()
        {
            return canvas;
        }

        void CameraBackgroundColorLerp()
        {
            canvas.GetComponent<Image>().color = Color.Lerp(camBackgroundColor1, camBackgroundColor2, Mathf.PingPong(Time.unscaledTime * 0.1f, 1));
        }
    }
}


