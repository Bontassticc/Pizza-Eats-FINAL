

using System;
using UnityEngine;

namespace Assets.Scripts.RollAndWriteManagement
{
    [Serializable]
    public class RolledNumber
    {
        [SerializeField]
        private int number;

        [SerializeField]
        private bool isSelected;

        public int Number { get => number; }
        public bool IsSelected { get => isSelected; }

        public RolledNumber(int number)
        {
            this.number = number;
        }

        public void OnUsed()
        {
            isSelected = true;
        }

        public void Reset()
        {
            number = 0;
            isSelected = false;
        }
    }
}
