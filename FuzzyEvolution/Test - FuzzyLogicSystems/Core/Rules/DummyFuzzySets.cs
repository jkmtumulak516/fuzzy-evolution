using System.Collections.Generic;
using FuzzyLogicSystems.Core.Values;
using FuzzyLogicSystems.Core.Values.Generic;

namespace TestFuzzyLogicSystems.Core.Rules
{
    public class DummyFuzzySets
    {
        public class TestTemperature : FuzzySet<InputFuzzyMember>
        {
            public TestTemperature(int category) : base(category) { }

            private InputFuzzyMember _hot;
            private InputFuzzyMember _warm;
            private InputFuzzyMember _cool;
            private InputFuzzyMember _cold;

            protected override ISet<InputFuzzyMember> InitializeMembers()
            {
                var set = new HashSet<InputFuzzyMember>();

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

            public InputFuzzyMember Hot { get => _hot; }
            public InputFuzzyMember Warm { get => _warm; }
            public InputFuzzyMember Cool { get => _cool; }
            public InputFuzzyMember Cold { get => _cold; }
        }

        public class TestHeight : FuzzySet<InputFuzzyMember>
        {
            public TestHeight(int category) : base(category) { }

            private InputFuzzyMember _tall;
            private InputFuzzyMember _slightly_tall;
            private InputFuzzyMember _slightly_short;
            private InputFuzzyMember _short;

            protected override ISet<InputFuzzyMember> InitializeMembers()
            {
                var set = new HashSet<InputFuzzyMember>();

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

            public InputFuzzyMember Tall { get => _tall; }
            public InputFuzzyMember SlightlyTall { get => _slightly_tall; }
            public InputFuzzyMember SlightlyShort { get => _slightly_short; }
            public InputFuzzyMember Short { get => _short; }
        }

        public class TestSpecial : FuzzySet<ResultFuzzyMember>
        {
            public TestSpecial(int category) : base(category) { }

            private ResultFuzzyMember _unique;
            private ResultFuzzyMember _original;
            private ResultFuzzyMember _unoriginal;
            private ResultFuzzyMember _plain;

            protected override ISet<ResultFuzzyMember> InitializeMembers()
            {
                var set = new HashSet<ResultFuzzyMember>();

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
                _plain = new LinearResult("Plain", this, 20, 25, 20);
                set.Add(_plain);

                return set;
            }

            public ResultFuzzyMember Unique { get => _unique; }
            public ResultFuzzyMember Original { get => _original; }
            public ResultFuzzyMember Unoriginal { get => _unoriginal; }
            public ResultFuzzyMember Plain { get => _plain; }
        }
    }
}
