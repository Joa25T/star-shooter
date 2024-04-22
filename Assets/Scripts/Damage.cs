using System;

[Serializable]
public class Damage
{
    public float ammount;
    public enum DmgType {normal, frost, fire, corrosive};
    public DmgType dmgType;
    public Damage(float ammountC, DmgType dmgTypeC)
    {
        ammount = ammountC;
        dmgType = dmgTypeC;
    }
}