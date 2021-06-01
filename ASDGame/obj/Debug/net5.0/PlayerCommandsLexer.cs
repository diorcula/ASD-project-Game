//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.6
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\Users\arnold\source\repos\Test\Test\InputHandling\Antlr\Grammar\PlayerCommands.g4 by ANTLR 4.6.6

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace InputHandling.Antlr.Grammar {
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public partial class PlayerCommandsLexer : Lexer {
	public const int
		SPACE=1, MOVE=2, WALK=3, GO=4, ATTACK=5, SLASH=6, STRIKE=7, PICKUP=8, 
		GET=9, DROP=10, EXIT=11, LEAVE=12, SAY=13, SHOUT=14, REPLACE=15, PAUSE=16, 
		RESUME=17, CREATE_SESSION=18, JOIN_SESSION=19, REQUEST_SESSIONS=20, START_SESSION=21, 
		FORWARD=22, UP=23, NORTH=24, BACKWARD=25, DOWN=26, SOUTH=27, LEFT=28, 
		WEST=29, RIGHT=30, EAST=31, NUMBER=32, MESSAGE=33;
	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"SPACE", "MOVE", "WALK", "GO", "ATTACK", "SLASH", "STRIKE", "PICKUP", 
		"GET", "DROP", "EXIT", "LEAVE", "SAY", "SHOUT", "REPLACE", "PAUSE", "RESUME", 
		"CREATE_SESSION", "JOIN_SESSION", "REQUEST_SESSIONS", "START_SESSION", 
		"FORWARD", "UP", "NORTH", "BACKWARD", "DOWN", "SOUTH", "LEFT", "WEST", 
		"RIGHT", "EAST", "NUMBER", "MESSAGE"
	};


	public PlayerCommandsLexer(ICharStream input)
		: base(input)
	{
		_interp = new LexerATNSimulator(this,_ATN);
	}

	private static readonly string[] _LiteralNames = {
		null, null, "'move'", "'walk'", "'go'", "'attack'", "'slash'", "'strike'", 
		"'pickup'", "'get'", "'drop'", "'exit'", "'leave'", "'say'", "'shout'", 
		"'replace'", "'pause'", "'resume'", "'create_session'", "'join_session'", 
		"'request_sessions'", "'start_session'", "'forward'", "'up'", "'north'", 
		"'backward'", "'down'", "'south'", "'left'", "'west'", "'right'", "'east'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "SPACE", "MOVE", "WALK", "GO", "ATTACK", "SLASH", "STRIKE", "PICKUP", 
		"GET", "DROP", "EXIT", "LEAVE", "SAY", "SHOUT", "REPLACE", "PAUSE", "RESUME", 
		"CREATE_SESSION", "JOIN_SESSION", "REQUEST_SESSIONS", "START_SESSION", 
		"FORWARD", "UP", "NORTH", "BACKWARD", "DOWN", "SOUTH", "LEFT", "WEST", 
		"RIGHT", "EAST", "NUMBER", "MESSAGE"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[System.Obsolete("Use Vocabulary instead.")]
	public static readonly string[] tokenNames = GenerateTokenNames(DefaultVocabulary, _SymbolicNames.Length);

	private static string[] GenerateTokenNames(IVocabulary vocabulary, int length) {
		string[] tokenNames = new string[length];
		for (int i = 0; i < tokenNames.Length; i++) {
			tokenNames[i] = vocabulary.GetLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = vocabulary.GetSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}

		return tokenNames;
	}

	[System.Obsolete("Use IRecognizer.Vocabulary instead.")]
	public override string[] TokenNames
	{
		get
		{
			return tokenNames;
		}
	}

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "PlayerCommands.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return _serializedATN; } }

	public static readonly string _serializedATN =
		"\x3\xAF6F\x8320\x479D\xB75C\x4880\x1605\x191C\xAB37\x2#\x12B\b\x1\x4\x2"+
		"\t\x2\x4\x3\t\x3\x4\x4\t\x4\x4\x5\t\x5\x4\x6\t\x6\x4\a\t\a\x4\b\t\b\x4"+
		"\t\t\t\x4\n\t\n\x4\v\t\v\x4\f\t\f\x4\r\t\r\x4\xE\t\xE\x4\xF\t\xF\x4\x10"+
		"\t\x10\x4\x11\t\x11\x4\x12\t\x12\x4\x13\t\x13\x4\x14\t\x14\x4\x15\t\x15"+
		"\x4\x16\t\x16\x4\x17\t\x17\x4\x18\t\x18\x4\x19\t\x19\x4\x1A\t\x1A\x4\x1B"+
		"\t\x1B\x4\x1C\t\x1C\x4\x1D\t\x1D\x4\x1E\t\x1E\x4\x1F\t\x1F\x4 \t \x4!"+
		"\t!\x4\"\t\"\x3\x2\x6\x2G\n\x2\r\x2\xE\x2H\x3\x3\x3\x3\x3\x3\x3\x3\x3"+
		"\x3\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x5\x3\x5\x3\x5\x3\x6\x3\x6\x3\x6"+
		"\x3\x6\x3\x6\x3\x6\x3\x6\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\b\x3\b\x3\b"+
		"\x3\b\x3\b\x3\b\x3\b\x3\t\x3\t\x3\t\x3\t\x3\t\x3\t\x3\t\x3\n\x3\n\x3\n"+
		"\x3\n\x3\v\x3\v\x3\v\x3\v\x3\v\x3\f\x3\f\x3\f\x3\f\x3\f\x3\r\x3\r\x3\r"+
		"\x3\r\x3\r\x3\r\x3\xE\x3\xE\x3\xE\x3\xE\x3\xF\x3\xF\x3\xF\x3\xF\x3\xF"+
		"\x3\xF\x3\x10\x3\x10\x3\x10\x3\x10\x3\x10\x3\x10\x3\x10\x3\x10\x3\x11"+
		"\x3\x11\x3\x11\x3\x11\x3\x11\x3\x11\x3\x12\x3\x12\x3\x12\x3\x12\x3\x12"+
		"\x3\x12\x3\x12\x3\x13\x3\x13\x3\x13\x3\x13\x3\x13\x3\x13\x3\x13\x3\x13"+
		"\x3\x13\x3\x13\x3\x13\x3\x13\x3\x13\x3\x13\x3\x13\x3\x14\x3\x14\x3\x14"+
		"\x3\x14\x3\x14\x3\x14\x3\x14\x3\x14\x3\x14\x3\x14\x3\x14\x3\x14\x3\x14"+
		"\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15"+
		"\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x16\x3\x16\x3\x16"+
		"\x3\x16\x3\x16\x3\x16\x3\x16\x3\x16\x3\x16\x3\x16\x3\x16\x3\x16\x3\x16"+
		"\x3\x16\x3\x17\x3\x17\x3\x17\x3\x17\x3\x17\x3\x17\x3\x17\x3\x17\x3\x18"+
		"\x3\x18\x3\x18\x3\x19\x3\x19\x3\x19\x3\x19\x3\x19\x3\x19\x3\x1A\x3\x1A"+
		"\x3\x1A\x3\x1A\x3\x1A\x3\x1A\x3\x1A\x3\x1A\x3\x1A\x3\x1B\x3\x1B\x3\x1B"+
		"\x3\x1B\x3\x1B\x3\x1C\x3\x1C\x3\x1C\x3\x1C\x3\x1C\x3\x1C\x3\x1D\x3\x1D"+
		"\x3\x1D\x3\x1D\x3\x1D\x3\x1E\x3\x1E\x3\x1E\x3\x1E\x3\x1E\x3\x1F\x3\x1F"+
		"\x3\x1F\x3\x1F\x3\x1F\x3\x1F\x3 \x3 \x3 \x3 \x3 \x3!\x3!\a!\x11D\n!\f"+
		"!\xE!\x120\v!\x5!\x122\n!\x3\"\x3\"\x6\"\x126\n\"\r\"\xE\"\x127\x3\"\x3"+
		"\"\x2\x2\x2#\x3\x2\x3\x5\x2\x4\a\x2\x5\t\x2\x6\v\x2\a\r\x2\b\xF\x2\t\x11"+
		"\x2\n\x13\x2\v\x15\x2\f\x17\x2\r\x19\x2\xE\x1B\x2\xF\x1D\x2\x10\x1F\x2"+
		"\x11!\x2\x12#\x2\x13%\x2\x14\'\x2\x15)\x2\x16+\x2\x17-\x2\x18/\x2\x19"+
		"\x31\x2\x1A\x33\x2\x1B\x35\x2\x1C\x37\x2\x1D\x39\x2\x1E;\x2\x1F=\x2 ?"+
		"\x2!\x41\x2\"\x43\x2#\x3\x2\x4\x3\x2\x32;\x3\x2$$\x12E\x2\x3\x3\x2\x2"+
		"\x2\x2\x5\x3\x2\x2\x2\x2\a\x3\x2\x2\x2\x2\t\x3\x2\x2\x2\x2\v\x3\x2\x2"+
		"\x2\x2\r\x3\x2\x2\x2\x2\xF\x3\x2\x2\x2\x2\x11\x3\x2\x2\x2\x2\x13\x3\x2"+
		"\x2\x2\x2\x15\x3\x2\x2\x2\x2\x17\x3\x2\x2\x2\x2\x19\x3\x2\x2\x2\x2\x1B"+
		"\x3\x2\x2\x2\x2\x1D\x3\x2\x2\x2\x2\x1F\x3\x2\x2\x2\x2!\x3\x2\x2\x2\x2"+
		"#\x3\x2\x2\x2\x2%\x3\x2\x2\x2\x2\'\x3\x2\x2\x2\x2)\x3\x2\x2\x2\x2+\x3"+
		"\x2\x2\x2\x2-\x3\x2\x2\x2\x2/\x3\x2\x2\x2\x2\x31\x3\x2\x2\x2\x2\x33\x3"+
		"\x2\x2\x2\x2\x35\x3\x2\x2\x2\x2\x37\x3\x2\x2\x2\x2\x39\x3\x2\x2\x2\x2"+
		";\x3\x2\x2\x2\x2=\x3\x2\x2\x2\x2?\x3\x2\x2\x2\x2\x41\x3\x2\x2\x2\x2\x43"+
		"\x3\x2\x2\x2\x3\x46\x3\x2\x2\x2\x5J\x3\x2\x2\x2\aO\x3\x2\x2\x2\tT\x3\x2"+
		"\x2\x2\vW\x3\x2\x2\x2\r^\x3\x2\x2\x2\xF\x64\x3\x2\x2\x2\x11k\x3\x2\x2"+
		"\x2\x13r\x3\x2\x2\x2\x15v\x3\x2\x2\x2\x17{\x3\x2\x2\x2\x19\x80\x3\x2\x2"+
		"\x2\x1B\x86\x3\x2\x2\x2\x1D\x8A\x3\x2\x2\x2\x1F\x90\x3\x2\x2\x2!\x98\x3"+
		"\x2\x2\x2#\x9E\x3\x2\x2\x2%\xA5\x3\x2\x2\x2\'\xB4\x3\x2\x2\x2)\xC1\x3"+
		"\x2\x2\x2+\xD2\x3\x2\x2\x2-\xE0\x3\x2\x2\x2/\xE8\x3\x2\x2\x2\x31\xEB\x3"+
		"\x2\x2\x2\x33\xF1\x3\x2\x2\x2\x35\xFA\x3\x2\x2\x2\x37\xFF\x3\x2\x2\x2"+
		"\x39\x105\x3\x2\x2\x2;\x10A\x3\x2\x2\x2=\x10F\x3\x2\x2\x2?\x115\x3\x2"+
		"\x2\x2\x41\x121\x3\x2\x2\x2\x43\x123\x3\x2\x2\x2\x45G\a\"\x2\x2\x46\x45"+
		"\x3\x2\x2\x2GH\x3\x2\x2\x2H\x46\x3\x2\x2\x2HI\x3\x2\x2\x2I\x4\x3\x2\x2"+
		"\x2JK\ao\x2\x2KL\aq\x2\x2LM\ax\x2\x2MN\ag\x2\x2N\x6\x3\x2\x2\x2OP\ay\x2"+
		"\x2PQ\a\x63\x2\x2QR\an\x2\x2RS\am\x2\x2S\b\x3\x2\x2\x2TU\ai\x2\x2UV\a"+
		"q\x2\x2V\n\x3\x2\x2\x2WX\a\x63\x2\x2XY\av\x2\x2YZ\av\x2\x2Z[\a\x63\x2"+
		"\x2[\\\a\x65\x2\x2\\]\am\x2\x2]\f\x3\x2\x2\x2^_\au\x2\x2_`\an\x2\x2`\x61"+
		"\a\x63\x2\x2\x61\x62\au\x2\x2\x62\x63\aj\x2\x2\x63\xE\x3\x2\x2\x2\x64"+
		"\x65\au\x2\x2\x65\x66\av\x2\x2\x66g\at\x2\x2gh\ak\x2\x2hi\am\x2\x2ij\a"+
		"g\x2\x2j\x10\x3\x2\x2\x2kl\ar\x2\x2lm\ak\x2\x2mn\a\x65\x2\x2no\am\x2\x2"+
		"op\aw\x2\x2pq\ar\x2\x2q\x12\x3\x2\x2\x2rs\ai\x2\x2st\ag\x2\x2tu\av\x2"+
		"\x2u\x14\x3\x2\x2\x2vw\a\x66\x2\x2wx\at\x2\x2xy\aq\x2\x2yz\ar\x2\x2z\x16"+
		"\x3\x2\x2\x2{|\ag\x2\x2|}\az\x2\x2}~\ak\x2\x2~\x7F\av\x2\x2\x7F\x18\x3"+
		"\x2\x2\x2\x80\x81\an\x2\x2\x81\x82\ag\x2\x2\x82\x83\a\x63\x2\x2\x83\x84"+
		"\ax\x2\x2\x84\x85\ag\x2\x2\x85\x1A\x3\x2\x2\x2\x86\x87\au\x2\x2\x87\x88"+
		"\a\x63\x2\x2\x88\x89\a{\x2\x2\x89\x1C\x3\x2\x2\x2\x8A\x8B\au\x2\x2\x8B"+
		"\x8C\aj\x2\x2\x8C\x8D\aq\x2\x2\x8D\x8E\aw\x2\x2\x8E\x8F\av\x2\x2\x8F\x1E"+
		"\x3\x2\x2\x2\x90\x91\at\x2\x2\x91\x92\ag\x2\x2\x92\x93\ar\x2\x2\x93\x94"+
		"\an\x2\x2\x94\x95\a\x63\x2\x2\x95\x96\a\x65\x2\x2\x96\x97\ag\x2\x2\x97"+
		" \x3\x2\x2\x2\x98\x99\ar\x2\x2\x99\x9A\a\x63\x2\x2\x9A\x9B\aw\x2\x2\x9B"+
		"\x9C\au\x2\x2\x9C\x9D\ag\x2\x2\x9D\"\x3\x2\x2\x2\x9E\x9F\at\x2\x2\x9F"+
		"\xA0\ag\x2\x2\xA0\xA1\au\x2\x2\xA1\xA2\aw\x2\x2\xA2\xA3\ao\x2\x2\xA3\xA4"+
		"\ag\x2\x2\xA4$\x3\x2\x2\x2\xA5\xA6\a\x65\x2\x2\xA6\xA7\at\x2\x2\xA7\xA8"+
		"\ag\x2\x2\xA8\xA9\a\x63\x2\x2\xA9\xAA\av\x2\x2\xAA\xAB\ag\x2\x2\xAB\xAC"+
		"\a\x61\x2\x2\xAC\xAD\au\x2\x2\xAD\xAE\ag\x2\x2\xAE\xAF\au\x2\x2\xAF\xB0"+
		"\au\x2\x2\xB0\xB1\ak\x2\x2\xB1\xB2\aq\x2\x2\xB2\xB3\ap\x2\x2\xB3&\x3\x2"+
		"\x2\x2\xB4\xB5\al\x2\x2\xB5\xB6\aq\x2\x2\xB6\xB7\ak\x2\x2\xB7\xB8\ap\x2"+
		"\x2\xB8\xB9\a\x61\x2\x2\xB9\xBA\au\x2\x2\xBA\xBB\ag\x2\x2\xBB\xBC\au\x2"+
		"\x2\xBC\xBD\au\x2\x2\xBD\xBE\ak\x2\x2\xBE\xBF\aq\x2\x2\xBF\xC0\ap\x2\x2"+
		"\xC0(\x3\x2\x2\x2\xC1\xC2\at\x2\x2\xC2\xC3\ag\x2\x2\xC3\xC4\as\x2\x2\xC4"+
		"\xC5\aw\x2\x2\xC5\xC6\ag\x2\x2\xC6\xC7\au\x2\x2\xC7\xC8\av\x2\x2\xC8\xC9"+
		"\a\x61\x2\x2\xC9\xCA\au\x2\x2\xCA\xCB\ag\x2\x2\xCB\xCC\au\x2\x2\xCC\xCD"+
		"\au\x2\x2\xCD\xCE\ak\x2\x2\xCE\xCF\aq\x2\x2\xCF\xD0\ap\x2\x2\xD0\xD1\a"+
		"u\x2\x2\xD1*\x3\x2\x2\x2\xD2\xD3\au\x2\x2\xD3\xD4\av\x2\x2\xD4\xD5\a\x63"+
		"\x2\x2\xD5\xD6\at\x2\x2\xD6\xD7\av\x2\x2\xD7\xD8\a\x61\x2\x2\xD8\xD9\a"+
		"u\x2\x2\xD9\xDA\ag\x2\x2\xDA\xDB\au\x2\x2\xDB\xDC\au\x2\x2\xDC\xDD\ak"+
		"\x2\x2\xDD\xDE\aq\x2\x2\xDE\xDF\ap\x2\x2\xDF,\x3\x2\x2\x2\xE0\xE1\ah\x2"+
		"\x2\xE1\xE2\aq\x2\x2\xE2\xE3\at\x2\x2\xE3\xE4\ay\x2\x2\xE4\xE5\a\x63\x2"+
		"\x2\xE5\xE6\at\x2\x2\xE6\xE7\a\x66\x2\x2\xE7.\x3\x2\x2\x2\xE8\xE9\aw\x2"+
		"\x2\xE9\xEA\ar\x2\x2\xEA\x30\x3\x2\x2\x2\xEB\xEC\ap\x2\x2\xEC\xED\aq\x2"+
		"\x2\xED\xEE\at\x2\x2\xEE\xEF\av\x2\x2\xEF\xF0\aj\x2\x2\xF0\x32\x3\x2\x2"+
		"\x2\xF1\xF2\a\x64\x2\x2\xF2\xF3\a\x63\x2\x2\xF3\xF4\a\x65\x2\x2\xF4\xF5"+
		"\am\x2\x2\xF5\xF6\ay\x2\x2\xF6\xF7\a\x63\x2\x2\xF7\xF8\at\x2\x2\xF8\xF9"+
		"\a\x66\x2\x2\xF9\x34\x3\x2\x2\x2\xFA\xFB\a\x66\x2\x2\xFB\xFC\aq\x2\x2"+
		"\xFC\xFD\ay\x2\x2\xFD\xFE\ap\x2\x2\xFE\x36\x3\x2\x2\x2\xFF\x100\au\x2"+
		"\x2\x100\x101\aq\x2\x2\x101\x102\aw\x2\x2\x102\x103\av\x2\x2\x103\x104"+
		"\aj\x2\x2\x104\x38\x3\x2\x2\x2\x105\x106\an\x2\x2\x106\x107\ag\x2\x2\x107"+
		"\x108\ah\x2\x2\x108\x109\av\x2\x2\x109:\x3\x2\x2\x2\x10A\x10B\ay\x2\x2"+
		"\x10B\x10C\ag\x2\x2\x10C\x10D\au\x2\x2\x10D\x10E\av\x2\x2\x10E<\x3\x2"+
		"\x2\x2\x10F\x110\at\x2\x2\x110\x111\ak\x2\x2\x111\x112\ai\x2\x2\x112\x113"+
		"\aj\x2\x2\x113\x114\av\x2\x2\x114>\x3\x2\x2\x2\x115\x116\ag\x2\x2\x116"+
		"\x117\a\x63\x2\x2\x117\x118\au\x2\x2\x118\x119\av\x2\x2\x119@\x3\x2\x2"+
		"\x2\x11A\x122\a\x32\x2\x2\x11B\x11D\t\x2\x2\x2\x11C\x11B\x3\x2\x2\x2\x11D"+
		"\x120\x3\x2\x2\x2\x11E\x11C\x3\x2\x2\x2\x11E\x11F\x3\x2\x2\x2\x11F\x122"+
		"\x3\x2\x2\x2\x120\x11E\x3\x2\x2\x2\x121\x11A\x3\x2\x2\x2\x121\x11E\x3"+
		"\x2\x2\x2\x122\x42\x3\x2\x2\x2\x123\x125\a$\x2\x2\x124\x126\n\x3\x2\x2"+
		"\x125\x124\x3\x2\x2\x2\x126\x127\x3\x2\x2\x2\x127\x125\x3\x2\x2\x2\x127"+
		"\x128\x3\x2\x2\x2\x128\x129\x3\x2\x2\x2\x129\x12A\a$\x2\x2\x12A\x44\x3"+
		"\x2\x2\x2\a\x2H\x11E\x121\x127\x2";
	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN.ToCharArray());
}
} // namespace InputHandling.Antlr.Grammar
