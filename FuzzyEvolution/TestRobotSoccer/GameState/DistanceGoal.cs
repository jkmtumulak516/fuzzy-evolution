using FuzzyLogicSystems.Core.Values;
using FuzzyLogicSystems.Core.Values.Generic;
using System.Collections.Generic;

namespace TestRobotSoccer.GameState
{
    class DistanceGoal : FuzzySet<IInputFuzzyMember>
    {
        public DistanceGoal(int category) : base(category) { }

        private IInputFuzzyMember _very_near;
        private IInputFuzzyMember _moderately_near;
        private IInputFuzzyMember _medium;
        private IInputFuzzyMember _moderately_far;
        private IInputFuzzyMember _very_far;

        protected override ISet<IInputFuzzyMember> InitializeMembers()
        {
            HashSet<IInputFuzzyMember> collection = new HashSet<IInputFuzzyMember>();
            var increment = 150 / 4;
            var peak = 0f;
            var halfWidth = increment;

            _very_near = new LinearInput("Very Near", this, peak, true, false, halfWidth, 0);
            collection.Add(_very_near);

            _moderately_near = new LinearInput("Moderately Near", this, peak += increment, false, false, halfWidth, 0);
            collection.Add(_moderately_near);

            _medium = new LinearInput("Medium", this, peak += increment, false, false, halfWidth, 0);
            collection.Add(_medium);

            _moderately_far = new LinearInput("Moderately Far", this, peak += increment, false, false, halfWidth, 0);
            collection.Add(_moderately_far);

            _very_far = new LinearInput("Very far", this, peak += increment, false, true, halfWidth, 0);
            collection.Add(_very_far);

            return collection;
        }

        public IInputFuzzyMember VeryNear { get { return _very_near; } }
        public IInputFuzzyMember ModeratelyNear { get { return _moderately_near; } }
        public IInputFuzzyMember Medium { get { return _medium; } }
        public IInputFuzzyMember ModeratelyFar { get { return _moderately_far; } }
        public IInputFuzzyMember VeryFar { get { return _very_far; } }
    }
}
