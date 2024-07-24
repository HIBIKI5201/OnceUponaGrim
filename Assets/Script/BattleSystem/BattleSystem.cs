using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    int _currentHealth;

    bool _buttonActive;

    private void Start()
    {
        _currentHealth = MainSystem._maxHealth;

        _buttonActive = true;
    }

    public void ButtonDown(int buttonNumber)
    {
        if (_buttonActive)
        {
            switch (buttonNumber)
            {
                case 0:
                    break;
            }
        }
    }

    public void Heal(int healAmount)
    {
        _currentHealth += healAmount;
    }

    public void HitDamage(int damage)
    {
        _currentHealth -= damage;
    }
}
