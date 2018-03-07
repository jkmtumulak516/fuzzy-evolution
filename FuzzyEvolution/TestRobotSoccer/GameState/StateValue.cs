using FuzzyLogicSystems.Core.Values;
using FuzzyLogicSystems.Core.Values.Generic;
using System.Collections.Generic;

namespace TestRobotSoccer.GameState
{
    class StateValue : FuzzySet<IResultFuzzyMember>
    {
        public StateValue(int category) : base(category) { }

        private IResultFuzzyMember _more_defense;
        private IResultFuzzyMember _light_defense;
        private IResultFuzzyMember _defense_offense;
        private IResultFuzzyMember _light_offense;
        private IResultFuzzyMember _more_offense;

        protected override ISet<IResultFuzzyMember> InitializeMembers()
        {
            HashSet<IResultFuzzyMember> collection = new HashSet<IResultFuzzyMember>();
            var increment = 2.5f;
            var peak = 0f;
            var halfWidth = increment;

            _more_defense = new LinearResult("More Defense", this, peak, halfWidth, 0);
            collection.Add(_more_defense);

            _light_defense = new LinearResult("Light Defense", this, peak += increment, halfWidth, 0);
            collection.Add(_light_defense);

            _defense_offense = new LinearResult("Defense Offense", this, peak += increment, halfWidth, 0);
            collection.Add(_defense_offense);

            _light_offense = new LinearResult("Light Offense", this, peak += increment, halfWidth, 0);
            collection.Add(_light_offense);

            _more_offense = new LinearResult("More Offense", this, peak += increment, halfWidth, 0);
            collection.Add(_more_offense);

            return collection;
        }

        public IResultFuzzyMember MoreDefense { get { return _more_defense; } }
        public IResultFuzzyMember LightDefense { get { return _light_defense; } }
        public IResultFuzzyMember DefenseOffense { get { return _defense_offense; } }
        public IResultFuzzyMember LightOffense { get { return _light_offense; } }
        public IResultFuzzyMember MoreOffense { get { return _more_offense; } }
    }
}
