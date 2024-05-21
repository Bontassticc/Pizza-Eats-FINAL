using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.RollAndWriteManagement
{
    public class BowlManager : MonoBehaviour
    {
        [SerializeField]
        private List<BowlController> bowls;
        
        public void DeactivateInvalidBowls(List<RolledNumber> numbers)
        {
            // Collect the integers from the classes
            List<int> rawNumbers = new List<int>();
            foreach (var number in numbers)
            {
                rawNumbers.Add(number.Number);
            }

            // Activate or deactivate bowls
            for (int i = 0; i < bowls.Count; i++)
            {
                var bowl = bowls[i];
                var bowlNumber = bowl.AssociatedNumber;
                if (!rawNumbers.Contains(bowlNumber))
                {
                    bowl.Deactivate();
                }
            }
        }

        // Called on end of player turn / beginning of next player turn
        public void ActivateAllBowls()
        {
            foreach (var bowl in bowls)
            {
                bowl.Activate();
            }

        }
    }
}