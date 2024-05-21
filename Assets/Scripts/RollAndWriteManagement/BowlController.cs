using System.Collections;
using UnityEngine;

namespace Assets.Scripts.RollAndWriteManagement
{
    public class BowlController : MonoBehaviour
    {
        [SerializeField]
        private int associatedNumber;

        public int AssociatedNumber { get => associatedNumber; }

        public void Activate ()
        {
            // TODO:
            // Shouldn't be a box collider but here we are.
            // Using the box collider is what is going to cause dragging to not work.
            // We just going to have to accept it for now
            // YOU CAN ACCESS MY CODE FOR THIS, GO FIX IT 

            var colliders = GetComponentsInChildren<Collider>();
            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].enabled = true;
            }
        }

        public void Deactivate()
        {
            var colliders = GetComponentsInChildren<Collider>();
            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].enabled = false;
            }
        }
    }
}