using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient
{
    public static readonly Ingredient MUD = new Ingredient("Mud", 35, "mud_icon", new Color(1, 0.54f, 0));
    public static readonly Ingredient STICKS = new Ingredient("Sticks", 20, "stick_icon", new Color(0, 0.76f, 0.84f));

    public static IEnumerable<Ingredient> Values
    {
        get
        {
            yield return MUD;
            yield return STICKS;
        }
    }

    public string name { get; private set; }
    public int value { get; private set; }
    public string iconName { get; private set; }
    public Color color { get; private set; }

    private Ingredient(string name, int value, string iconName, Color color) => (this.name, this.value, this.iconName, this.color) = (name, value, iconName, color);

}
