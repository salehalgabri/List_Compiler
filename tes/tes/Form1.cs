using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System.Threading.Tasks;
using System.Drawing;
using Antlr4.Runtime.Misc;

namespace tes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 0)
            {
                string input = richTextBox1.Text.ToString();

                AntlrInputStream inputStream = new AntlrInputStream(input);

                MyGrammarLexer lexer = new MyGrammarLexer(inputStream);
                CommonTokenStream tokenStream = new CommonTokenStream(lexer);
                MyGrammarParser parser = new MyGrammarParser(tokenStream);

                textBox2.Clear();
                parser.RemoveErrorListeners();
                parser.AddErrorListener(new MyErrorListener(textBox2,richTextBox1));

                parser.BuildParseTree = true;
                IParseTree tree = parser.program();

                MyGrammarVisitor visitor = new MyGrammarVisitor(textBox2);
                visitor.Visit(tree);
            }
        }
        public class MyErrorListener : BaseErrorListener
        {
            private RichTextBox inputRichTextBox; // النص المصدر
            private TextBox errorTextBox;         // صندوق عرض الأخطاء

            public MyErrorListener(TextBox _errorTextBox, RichTextBox _inputRichTextBox)
            {
                errorTextBox = _errorTextBox;
                inputRichTextBox = _inputRichTextBox;
            }

            public override void SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
            {
                // عرض رسالة الخطأ في صندوق عرض الأخطاء
                errorTextBox.AppendText($"Syntax Error: {msg} at line {line}, position {charPositionInLine}\n");

                // تحديد النص الذي يحتوي على الخطأ
                HighlightError(line, charPositionInLine, offendingSymbol.Text);
            }

            private void HighlightError(int line, int charPositionInLine, string offendingText)
            {
                // تقسيم النص حسب الأسطر
                string[] lines = inputRichTextBox.Text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

                if (line <= lines.Length)
                {
                    string errorLine = lines[line - 1]; // الحصول على السطر الذي يحتوي على الخطأ

                    // حساب موقع بداية الخطأ في النص الكامل
                    int startIndex = inputRichTextBox.GetFirstCharIndexFromLine(line - 1) + charPositionInLine;
                    int length = offendingText?.Length ?? 1; // طول النص الذي يحتوي على الخطأ (افتراضيًا 1)

                    // تغيير خلفية النص إلى اللون الأحمر
                    inputRichTextBox.SelectionStart = startIndex;
                    inputRichTextBox.SelectionLength = length;
                    inputRichTextBox.SelectionColor = Color.Red;

                    // إعادة التركيز إلى النص
                    inputRichTextBox.Focus();

                    // إعادة الخلفية إلى الوضع الطبيعي بعد وقت قصير
                    Task.Delay(10000).ContinueWith(_ =>
                    {
                        inputRichTextBox.Invoke(new Action(() =>
                        {
                            inputRichTextBox.SelectionStart = startIndex;
                            inputRichTextBox.SelectionLength = length;
                            inputRichTextBox.SelectionColor = Color.Black;
                        }));
                    });
                }
            }
        }

        public class MyGrammarVisitor : MyGrammarBaseVisitor<object>
        {
            private Dictionary<string, List<int>> lists = new Dictionary<string, List<int>>(); // تخزين القوائم باسمها
            private TextBox outputTextBox; // TextBox لعرض النتائج

            public MyGrammarVisitor(TextBox _outputTextBox)
            {
                outputTextBox = _outputTextBox;
            }

            // تعريف القائمة
            public override object VisitListDeclaration(MyGrammarParser.ListDeclarationContext context)
            {
                string listName = context.ID().GetText();
                List<int> values = new List<int>();

                foreach (var number in context.NUMBER())
                {
                    values.Add(int.Parse(number.GetText()));
                }

                lists[listName] = values;
                outputTextBox.AppendText($"List '{listName}' created with values: {string.Join(", ", values)}\n");
                return null;
            }

            // طباعة عنصر من القائمة
            public override object VisitPrintStatement(MyGrammarParser.PrintStatementContext context)
            {
                string listName = context.ID().GetText();
                int index = int.Parse(context.NUMBER().GetText());

                if (lists.ContainsKey(listName))
                {
                    List<int> list = lists[listName];

                    if (index >= 0 && index < list.Count)
                    {
                        outputTextBox.AppendText($"Value at {listName}[{index}] is: {list[index]}\n");
                    }
                    else
                    {
                        outputTextBox.AppendText($"Index {index} is out of range for list '{listName}'\n");
                    }
                }
                else
                {
                    outputTextBox.AppendText($"List '{listName}' not found.\n");
                }

                return null;
            }

            // إضافة عنصر إلى القائمة
            public override object VisitAddStatement(MyGrammarParser.AddStatementContext context)
            {
                string listName = context.ID().GetText();
                int value = int.Parse(context.NUMBER().GetText());

                if (lists.ContainsKey(listName))
                {
                    lists[listName].Add(value);
                    outputTextBox.AppendText($"Value {value} added to list '{listName}'\n");
                }
                else
                {
                    outputTextBox.AppendText($"List '{listName}' not found.\n");
                }

                return null;
            }

            // حذف عنصر من القائمة
            public override object VisitRemoveStatement(MyGrammarParser.RemoveStatementContext context)
            {
                string listName = context.ID().GetText();
                int value = int.Parse(context.NUMBER().GetText());

                if (lists.ContainsKey(listName))
                {
                    if (lists[listName].Remove(value))
                    {
                        outputTextBox.AppendText($"Value {value} removed from list '{listName}'\n");
                    }
                    else
                    {
                        outputTextBox.AppendText($"Value {value} not found in list '{listName}'\n");
                    }
                }
                else
                {
                    outputTextBox.AppendText($"List '{listName}' not found.\n");
                }

                return null;
            }

            public override object VisitContainStatement([NotNull] MyGrammarParser.ContainStatementContext context)
            {
                string listname = context.ID().GetText();
                int value = int.Parse(context.NUMBER().GetText());
                if(lists.ContainsKey(listname))
                {
                    if(lists[listname].Contains(value))
                    {
                        outputTextBox.AppendText($"Value {value} Is In'{listname}'\n");
                    }
                    else
                    {
                        outputTextBox.AppendText($"Value {value} Not Found In'{listname}'\n");
                    }

                }
                else
                {
                    outputTextBox.AppendText($"List '{listname}' not found.\n");
                }
                return null;
            }
        }
    }
}
