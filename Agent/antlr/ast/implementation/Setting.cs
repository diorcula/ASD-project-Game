﻿namespace Agent.antlr.ast
{
    public class Setting : Node, ISetting
    {
        public string SettingnName { get; set; }
        public string GetNodeType()
        {
            return "Setting";
        }
    }
}