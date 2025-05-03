using System;
using System.Collections.Generic;

namespace Quantum2.Core.QASM
{
    public class ASTNode
    {
        private Token _token;

        private List<ASTNode> _astNodes;

        public Token Token
        {
            get
            {
                return _token;
            }
        }

        public List<ASTNode> ASTNodes
        {
            get
            {
                return _astNodes;
            }
        }

        public ASTNode(Token token)
        {
            _token = token;
            _astNodes = new List<ASTNode>();
        }
    }

    public class AST
    {
        private List<ASTNode> _mainASTNodes;

        public List<ASTNode> MainASTNodes
        {
            get
            {
                return _mainASTNodes;
            }
        }

        public void AddNode(ASTNode astNode)
        {
            _mainASTNodes.Add(astNode);
        }

        public AST()
        {
            _mainASTNodes = new List<ASTNode>();
        }
    }
}
