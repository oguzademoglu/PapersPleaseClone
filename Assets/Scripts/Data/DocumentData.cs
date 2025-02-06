using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DocumentData", menuName = "ScriptableObjects/DocumentData", order = 1)]
public class DocumentData : ScriptableObject
{
    public List<string> names = new() { "Dave", "Esin", "Oguz", "Ethan" };
    public List<string> countries = new() { "Turkiye", "Italy", "Serbia", "Korea" };
    public int minAge = 18;
    public int maxAge = 50;
}
