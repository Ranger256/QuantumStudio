using System;
using System.Collections.Generic;

namespace Quantum2.Core.QASM
{

    public class QGate
    {
        private QState[] _qStates;

        private Rule[] _rules;

        private double[] _args; 

        private List<Index> _indexRules;
        private List<Index> _indexArgs;

        public QState[] QStates
        {
            get
            {
                return _qStates;
            }
        }

        public Rule[] Rules
        {
            get
            {
                return _rules;
            }
        }

        public double[] Args
        {
            get
            {
                return _args;
            }
        }

        public QGate()
        {
            _indexRules = new List<Index>();
            _indexArgs = new List<Index>();
        }

        public void Apply()
        {
            if (_rules == null)
                Console.WriteLine("RULES NULL");

            if (_qStates == null)
                Console.WriteLine("QSTATES NULL");

            if (_indexRules == null)
                Console.WriteLine("Index Rules NULL");

            for (int i = 0; i < _indexArgs.Count; i++)
            {
                _rules[_indexArgs[i]._indexRule].SetArg(_args[_indexArgs[i]._indexGateState], _indexArgs[i]._indexRuleState);
            }

            for (int i = 0; i < _indexRules.Count;i++)
            {
               

                _rules[_indexRules[i]._indexRule].SetState(_qStates[_indexRules[i]._indexGateState], _indexRules[i]._indexRuleState);
            }

            for(int i = 0; i < _rules.Length;i++)
            {
                _rules[i].Apply();
            }
        }

        public void SetGateRuleState(uint indexRule, uint indexRuleState, uint indexGateState)
        {
            _indexRules.Add(new Index(indexRule, indexRuleState, indexGateState));
        }

        public void SetGateRuleArg(uint indexRule, uint indexRuleArg, uint indexGateArg)
        {
            _indexArgs.Add(new Index(indexRule, indexRuleArg, indexGateArg));
        }

        public void SetState(QState state, uint indexState)
        {
            _qStates[indexState] = state;
        }

        public void SetRule(Rule rule, uint indexRule)
        {
            _rules[indexRule] = rule;
        }

        public void SetArg(double arg, uint indexArg)
        {
            _args[indexArg] = arg;
        }

        public void SetCountStates(uint countStates)
        {
            _qStates = new QState[countStates];
        }

        public void SetCountRules(uint countRules)
        {
            _rules = new Rule[countRules];
        }

        public void SetCountArgs(uint countArgs)
        {
            _args = new double[countArgs];
        }

        class Index
        {
            public uint _indexRule;
            public uint _indexRuleState;

            public uint _indexGateState;

            public Index(uint indexRule, uint indexRuleState, uint indexGateState)
            {
                _indexRule = indexRule;
                _indexRuleState = indexRuleState;
                _indexGateState = indexGateState;
            }
        }
     }
}
