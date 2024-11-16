using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assignment16 
{


    public struct Position
    {
        public float x;
        public float y;
        public float z;
        public Position(float x, float y, float z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
        public void PrintPosition() 
        {
            Debug.Log("x = " + x + ","+ "y = " + y + "," + "z = " + z );
        }
    }


    public class Character
    {
        //Parameters
        public string name;
        private int health;
        protected Position position;

        //Constructors
        public Character()
        {
            name = "No Name";
            health = 100;
            position = new Position(0, 0, 0);
        }
        public Character(string name, int health, Position position)
        {
            this.name = name;
            this.health = CheckHealth(health);
            this.position = position;
        }

        //Checkers
        private int CheckHealth(int health)
        {
            if (health < 0) return 0;
            else if (health > 100) return 100;
            else return health;
        }
        private int CheckDamage(int Damage)
        {
            if (Damage < 0)
            {
                Debug.Log("You've Entered Wrong Damage Amount , the Damage amount became 0");
                return 0;
            }
            else return Damage;
        }

        //Other Functions
        public virtual void DisplayInfo()
        {
            Debug.Log("Name :" + name + "\n" +"Health: " + health);
            Debug.Log("Position : "); position.PrintPosition();
        }
        public void Attack(int Damage, Character target)
        {
            Debug.Log( this.GetType().Name + " " + this.name + " Attacks " + target.GetType().Name + " " + target.name);
            Debug.Log("Previous "+target.GetType().Name+" Health : " + target.health);
            Damage = CheckDamage(Damage);
            Debug.Log("You've Damaged Target By : " + Damage);
            target.health -= Damage;
            target.health = CheckHealth(target.health);
            Debug.Log("Current " + target.GetType().Name + " Health : " + target.health);

        }
        public void Attack(int Damage, Character target, string attackType)
        {
            Attack(Damage, target);
            Debug.Log("Attack Type is " + attackType);
        }
    }

    public class Soldier : Character
    {
        public Soldier() : base() { }
        public Soldier(string name, int health, Position position) : base(name, health, position) { }

        public override void DisplayInfo() 
        {
            base.DisplayInfo();
            Debug.Log("Soldier");
        }
    }

    public class Officer : Character
    {
        public Officer() : base() { }
        public Officer(string name, int health, Position position) : base(name, health, position) { }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Debug.Log("Officer");
        }
    }

}

