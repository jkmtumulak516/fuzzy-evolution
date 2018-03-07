using FuzzyLogicSystems.Core.Values;
using FuzzyLogicSystems.Core.Values.Generic;
using System.Collections.Generic;

namespace TestRobotSoccer.GameState
{
    class Orientation : FuzzySet<IInputFuzzyMember>
    {
        public Orientation(int category) : base(category) { }

        private IInputFuzzyMember _very_good;
        private IInputFuzzyMember _good;
        private IInputFuzzyMember _bad;

        protected override ISet<IInputFuzzyMember> InitializeMembers()
        {
            HashSet<IInputFuzzyMember> collection = new HashSet<IInputFuzzyMember>();
            var increment = 45;
            var peak = 0f;
            var halfWidth = increment;

            _very_good = new LinearInput("Very Good", this, peak, true, false, halfWidth, 0);
            collection.Add(_very_good);

            _good = new LinearInput("Good", this, peak += increment, false, false, halfWidth, 0);
            collection.Add(_good);

            _bad = new LinearInput("Bad", this, peak += increment, false, true, halfWidth, 0);
            collection.Add(_bad);

            return collection;
        }

        public IInputFuzzyMember VeryGood { get { return _very_good; } }
        public IInputFuzzyMember Good { get { return _good; } }
        public IInputFuzzyMember Bad { get { return _bad; } }
    }
}
