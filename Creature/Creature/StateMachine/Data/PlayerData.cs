﻿using Creature.Creature.StateMachine.CustomRuleSet;
using Creature.World;
using System.Numerics;

namespace Creature.Creature.StateMachine.Data
{
    public class PlayerData : ICreatureData
    {
        private Vector2 _position;
        private double _health;
        private int _damage;
        private int _visionRange;
        private IWorld _world;
        private RuleSet _ruleSet;

        public bool IsAlive { get => _health > 0; }

        public Vector2 Position
        {
            get => _position;
            set => _position = value;
        }

        public double Health
        {
            get => _health;
            set => _health = value;
        }

        public int Damage
        {
            get => _damage;
            set => _damage = value;
        }

        public int VisionRange
        {
            get => _visionRange;
            set => _visionRange = value;
        }

        public IWorld World
        {
            get => _world;
            set => _world = value;
        }

        public RuleSet RuleSet
        {
            get => _ruleSet;
            set => _ruleSet = value;
        }

        public PlayerData(Vector2 position, double health, int damage, int visionRange, IWorld world, RuleSet ruleSet)
        {
            _position = position;
            _health = health;
            _damage = damage;
            _visionRange = visionRange;
            _world = world;
            _ruleSet = ruleSet;
        }
    }
}
