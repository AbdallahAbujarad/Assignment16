using UnityEngine;

namespace Assignment16
{
    public class CharacterTest : MonoBehaviour
    {
        void Start()
        {
            Character[] characters = new Character[]
            {
                new Soldier(),
                new Officer("Abdallah", 20, new Position(10, 20, 30))
            };
            foreach (Character character in characters)
            {
                character.DisplayInfo();
            }
            characters[1].Attack(20, characters[0]);// Officer Attacks Soldier
        }
    }
}

