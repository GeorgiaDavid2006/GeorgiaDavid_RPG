using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeorgiaDavid_RPG
{
    internal class HealthSystem
    {
        public int _maxHealth;
        public int _currentHealth;

        public HealthSystem(int maxHealth, int currentHealth)
        {
            _maxHealth = maxHealth;
            _currentHealth = currentHealth;
        }

        public void UpdateHealth(int amount)
        {
            _currentHealth = _currentHealth + amount;

            if (_currentHealth > _maxHealth)
            {
                _currentHealth = _maxHealth;
            }
        }
    }
}
