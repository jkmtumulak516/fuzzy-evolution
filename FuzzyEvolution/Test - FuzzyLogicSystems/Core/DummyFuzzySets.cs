using System.Collections.Generic;
using FuzzyLogicSystems.Core.Values;
using FuzzyLogicSystems.Core.Values.Generic;

namespace TestFuzzyLogicSystems.Core
{
    public class DummyFuzzySets
    {
        public class TestTemperature : FuzzySet<IInputFuzzyMember>
        {
            public TestTemperature(int category) : base(category) { }

            private IInputFuzzyMember _hot;
            private IInputFuzzyMember _warm;
            private IInputFuzzyMember _cool;
            private IInputFuzzyMember _cold;

            protected override ISet<IInputFuzzyMember> InitializeMembers()
            {
                var set = new HashSet<IInputFuzzyMember>();

                // hot
                _hot = new LinearInput("Hot", this, 35, false, true, 7.5f, 2.5f);
                set.Add(_hot);

                // warm 
                _warm = new LinearInput("Warm", this, 27.5f, false, false, 5, 1.5f);
                set.Add(_warm);

                // cool
                _cool = new LinearInput("Cool", this, 20, false, false, 5, 1.5f);
                set.Add(_cool);

                // cold
                _cold = new LinearInput("Cold", this, 12.5f, true, false, 7.5f, 2.5f);
                set.Add(_cold);

                return set;
            }

            public IInputFuzzyMember Hot { get => _hot; }
            public IInputFuzzyMember Warm { get => _warm; }
            public IInputFuzzyMember Cool { get => _cool; }
            public IInputFuzzyMember Cold { get => _cold; }
        }

        public class TestHeight : FuzzySet<IInputFuzzyMember>
        {
            public TestHeight(int category) : base(category) { }

            private IInputFuzzyMember _tall;
            private IInputFuzzyMember _slightly_tall;
            private IInputFuzzyMember _slightly_short;
            private IInputFuzzyMember _short;

            protected override ISet<IInputFuzzyMember> InitializeMembers()
            {
                var set = new HashSet<IInputFuzzyMember>();

                // hot
                _tall = new LinearInput("Tall", this, 200, false, true, 15, 5);
                set.Add(_tall);

                // warm 
                _slightly_tall = new LinearInput("Slightly Tall", this, 180, false, false, 15, 2.5f);
                set.Add(_slightly_tall);

                // cool
                _slightly_short = new LinearInput("Slightly Short", this, 160, false, false, 15, 2.5f);
                set.Add(_slightly_short);

                // cold
                _short = new LinearInput("Short", this, 140, true, false, 15, 5);
                set.Add(_short);

                return set;
            }

            public IInputFuzzyMember Tall { get => _tall; }
            public IInputFuzzyMember SlightlyTall { get => _slightly_tall; }
            public IInputFuzzyMember SlightlyShort { get => _slightly_short; }
            public IInputFuzzyMember Short { get => _short; }
        }
    
        public class TestWeight : FuzzySet<IInputFuzzyMember>
        {
            public TestWeight(int category) : base(category) { }

            private IInputFuzzyMember _heavy;
            private IInputFuzzyMember _slightly_heavy;
            private IInputFuzzyMember _slightly_light;
            private IInputFuzzyMember _light;

            protected override ISet<IInputFuzzyMember> InitializeMembers()
            {
                var set = new HashSet<IInputFuzzyMember>();

                // hot
                _heavy = new LinearInput("Heavy", this, 200, false, true, 15, 5);
                set.Add(_heavy);

                // warm 
                _slightly_heavy = new LinearInput("Slightly Heavy", this, 180, false, false, 15, 2.5f);
                set.Add(_slightly_heavy);

                // cool
                _slightly_light = new LinearInput("Slightly Light", this, 160, false, false, 15, 2.5f);
                set.Add(_slightly_light);

                // cold
                _light = new LinearInput("Light", this, 140, true, false, 15, 5);
                set.Add(_light);

                return set;
            }

            public IInputFuzzyMember Heavy { get => _heavy; }
            public IInputFuzzyMember SlightlyHeavy{ get => _slightly_heavy; }
            public IInputFuzzyMember SlightlyLight { get => _slightly_light; }
            public IInputFuzzyMember Light { get => _light; }
        }

        public class TestSpecial : FuzzySet<IResultFuzzyMember>
        {
            public TestSpecial(int category) : base(category) { }

            private IResultFuzzyMember _unique;
            private IResultFuzzyMember _original;
            private IResultFuzzyMember _unoriginal;
            private IResultFuzzyMember _plain;

            protected override ISet<IResultFuzzyMember> InitializeMembers()
            {
                var set = new HashSet<IResultFuzzyMember>();

                // hot
                _unique = new LinearResult("Unique", this, 100, 10, 5);
                set.Add(_unique);

                // warm 
                _original = new LinearResult("Original", this, 85, 15, 5);
                set.Add(_original);

                // cool
                _unoriginal = new LinearResult("Unoriginal", this, 55, 20, 10);
                set.Add(_unoriginal);

                // cold
                _plain = new LinearResult("Plain", this, 20, 30, 20);
                set.Add(_plain);

                return set;
            }

            public IResultFuzzyMember Unique { get => _unique; }
            public IResultFuzzyMember Original { get => _original; }
            public IResultFuzzyMember Unoriginal { get => _unoriginal; }
            public IResultFuzzyMember Plain { get => _plain; }
        }
    }
}
