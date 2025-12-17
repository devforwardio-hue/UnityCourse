using Mono.Cecil.Cil;
using Unity.VisualScripting;
using UnityEngine;



//Assignment Pseudocode prompt:
//Come up with your interpretation of what you would need to do in order to create a Key collection system, and door unlocking/opening system. 

//Create 3D object like a key or other small object that a player would typically add to their pocket or a bag. Small as to not break the illusion of the world you have created.

//Create a interaction/object collision with the player object so that the object disappears when it touches the player. This can and will need to be evolved into a button prompt to pick up the object and an arm animation of the player picking up the object. But for now the act of the player simply touching the object and obtaining it will work.

//Create a inventory system of items/objects that the player has picked up

//Create a wall with a separate door object

//Create a script that has the door rotate open and close

//Create a collision trigger that opens the door when touched

//Require that player object has a curtain object(key) attached to them before the door opens (door open script runs)

//Consider creating a button prompt to open the door and an animation of the player inserting and turning the key. 

public class Keyanddoorsystem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
