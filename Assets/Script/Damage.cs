using System.Collections;
using System.Collections.Generic;

public class Damage
{
    float damage = 1.0f;
    float multipleDamage = 1.0f;

    public Damage(float d, float md)
    {
        damage = d;
        multipleDamage = md;
    }

    public void SetDamage(float f)
    {
        damage = f;
    }
    public void MultiplyDamage(float f)
    {
        multipleDamage = f;
    }
    public float GetFinalDamage()
    {
        return damage * multipleDamage;
    }
}
