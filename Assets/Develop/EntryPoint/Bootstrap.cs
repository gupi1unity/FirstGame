using Assets.Develop.CommonServices.LoadingScreen;
using Assets.Develop.DI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Develop.EntryPoint
{
    public class Bootstrap : MonoBehaviour
    {
        public IEnumerator Run(DIContainer container)
        {
            ILoadingCurtain loadingCurtain = container.Resolve<ILoadingCurtain>();

            loadingCurtain.Show();

            yield return new WaitForSeconds(5);

            loadingCurtain.Hide();
        }
    }
}
