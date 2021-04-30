﻿using System.Collections.Generic;
using System.Text;

namespace Agent.antlr.ast
{
   
    public class Node 
    {

        protected ASTError error = null;
        protected List<Node> body = new List<Node>();
        
        public virtual string GetNodeType()
        {
            return "Node";
        }

        public virtual List<Node> GetChildren()
        {
            return this.body;
        }

        public virtual Node AddChild(Node node)
        {
            body.Add(node);
            return this;
        }

        public virtual Node RemoveChild(Node node)
        {
            body.Remove(node);
            return this;
        }

        public ASTError GetError()
        {
            return this.error;
        }

        public void SetError(string message)
        {
            this.error = new ASTError(message);
        }

        private string BuildString(StringBuilder builder)
        {
            builder.Append("[" + this.GetNodeType() + "]");
            foreach (var child in this.GetChildren()) {
                child.BuildString(builder);
            }

            return builder.ToString();
        }
        
         public override string ToString()
        {
            return BuildString(new StringBuilder()).ToString();
        }
    }
}