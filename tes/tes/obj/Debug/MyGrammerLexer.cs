//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.6
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from E:\study\Level 4\First semester\compiler\LABS\compiler_course_topics-main\topecs\New folder\tes\tes\MyGrammar.g4 by ANTLR 4.6.6

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace tes {
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public partial class MyGrammerLexer : Lexer {
	public const int
		STARTPROGRAM=1, ENDPROGRAM=2, PRINTT=3, LIFT=4, RIGHT=5, SEMI=6, NUMBER=7, 
		WS=8;
	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"STARTPROGRAM", "ENDPROGRAM", "PRINTT", "LIFT", "RIGHT", "SEMI", "NUMBER", 
		"WS"
	};


	public MyGrammerLexer(ICharStream input)
		: base(input)
	{
		_interp = new LexerATNSimulator(this,_ATN);
	}

	private static readonly string[] _LiteralNames = {
		null, "'StartP'", "'EndP'", "'print'", "'('", "')'", "';'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "STARTPROGRAM", "ENDPROGRAM", "PRINTT", "LIFT", "RIGHT", "SEMI", 
		"NUMBER", "WS"
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

	public override string GrammarFileName { get { return "MyGrammar.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return _serializedATN; } }

	public static readonly string _serializedATN =
		"\x3\xAF6F\x8320\x479D\xB75C\x4880\x1605\x191C\xAB37\x2\n\x37\b\x1\x4\x2"+
		"\t\x2\x4\x3\t\x3\x4\x4\t\x4\x4\x5\t\x5\x4\x6\t\x6\x4\a\t\a\x4\b\t\b\x4"+
		"\t\t\t\x3\x2\x3\x2\x3\x2\x3\x2\x3\x2\x3\x2\x3\x2\x3\x3\x3\x3\x3\x3\x3"+
		"\x3\x3\x3\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x5\x3\x5\x3\x6\x3\x6"+
		"\x3\a\x3\a\x3\b\x6\b-\n\b\r\b\xE\b.\x3\t\x6\t\x32\n\t\r\t\xE\t\x33\x3"+
		"\t\x3\t\x2\x2\x2\n\x3\x2\x3\x5\x2\x4\a\x2\x5\t\x2\x6\v\x2\a\r\x2\b\xF"+
		"\x2\t\x11\x2\n\x3\x2\x4\x3\x2\x32;\x5\x2\v\f\xF\xF\"\"\x38\x2\x3\x3\x2"+
		"\x2\x2\x2\x5\x3\x2\x2\x2\x2\a\x3\x2\x2\x2\x2\t\x3\x2\x2\x2\x2\v\x3\x2"+
		"\x2\x2\x2\r\x3\x2\x2\x2\x2\xF\x3\x2\x2\x2\x2\x11\x3\x2\x2\x2\x3\x13\x3"+
		"\x2\x2\x2\x5\x1A\x3\x2\x2\x2\a\x1F\x3\x2\x2\x2\t%\x3\x2\x2\x2\v\'\x3\x2"+
		"\x2\x2\r)\x3\x2\x2\x2\xF,\x3\x2\x2\x2\x11\x31\x3\x2\x2\x2\x13\x14\aU\x2"+
		"\x2\x14\x15\av\x2\x2\x15\x16\a\x63\x2\x2\x16\x17\at\x2\x2\x17\x18\av\x2"+
		"\x2\x18\x19\aR\x2\x2\x19\x4\x3\x2\x2\x2\x1A\x1B\aG\x2\x2\x1B\x1C\ap\x2"+
		"\x2\x1C\x1D\a\x66\x2\x2\x1D\x1E\aR\x2\x2\x1E\x6\x3\x2\x2\x2\x1F \ar\x2"+
		"\x2 !\at\x2\x2!\"\ak\x2\x2\"#\ap\x2\x2#$\av\x2\x2$\b\x3\x2\x2\x2%&\a*"+
		"\x2\x2&\n\x3\x2\x2\x2\'(\a+\x2\x2(\f\x3\x2\x2\x2)*\a=\x2\x2*\xE\x3\x2"+
		"\x2\x2+-\t\x2\x2\x2,+\x3\x2\x2\x2-.\x3\x2\x2\x2.,\x3\x2\x2\x2./\x3\x2"+
		"\x2\x2/\x10\x3\x2\x2\x2\x30\x32\t\x3\x2\x2\x31\x30\x3\x2\x2\x2\x32\x33"+
		"\x3\x2\x2\x2\x33\x31\x3\x2\x2\x2\x33\x34\x3\x2\x2\x2\x34\x35\x3\x2\x2"+
		"\x2\x35\x36\b\t\x2\x2\x36\x12\x3\x2\x2\x2\x5\x2.\x33\x3\b\x2\x2";
	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN.ToCharArray());
}
} // namespace tes
