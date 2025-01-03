using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Develop.CommonServices.LoadingScreen
{
    public class StandartLoadingCurtain : MonoBehaviour, ILoadingCurtain
    {
        public bool IsShown { get => gameObject.activeSelf; }

        private void Awake()
        {
            Hide();
            DontDestroyOnLoad(this);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
