using System;
using UniRx;
using UnityEngine.Assertions;
namespace Model
{
    public class SideMenuModel
    {
        private static SideMenuModel _instance;
        public readonly ReactiveProperty<int> CurrentSelectTab = new ReactiveProperty<int>(0);
        public static SideMenuModel Instance
        {
            get => _instance ?? throw new ArgumentNullException();
            set
            {
                Assert.IsNull(_instance, "You are not allowed to assign to a generated instance");
                _instance = value;
            }
        }
        
    }
}
