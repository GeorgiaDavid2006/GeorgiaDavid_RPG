using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeorgiaDavid_RPG
{
    internal class HealthSystem
    {
        int _maxHealth;
        int _currentHealth;

        public HealthSystem(int maxHealth, int currentHealth)
        {
            _maxHealth = maxHealth;
            _currentHealth = currentHealth;
        }

        void UpdateHealth(int amount)
        {
            _currentHealth = _currentHealth + amount;
        }
    }
}
