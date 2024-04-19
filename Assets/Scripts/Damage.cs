using System;

[Serializable]
public class Damage
{
    public float ammount;
    public enum DmgType {normal, frost, fire, corrosive};
    public DmgType dmgType;
}