using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace CodeAnalyzer.����ɨ��.R00016
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class R00016Analyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "R00016";

        private const string Category = "����ɨ��";

        private static readonly string Title = "61.CodeAnalyzer.SPEC:R00016";

        private static readonly string MessageFormat = "�����Ĳ������Ƶ�����ĸ����Сд��ͷ";

        private static readonly string Description = "����ɨ��>SPEC:R00016;�����Ĳ������Ƶ�����ĸ����Сд��ͷ";

        private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat,
            Category, DiagnosticSeverity.Info, true, Description,
            CommonHelper.HelpLinkUri);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule);

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSymbolAction(AnalyzeSymbol, SymbolKind.Method);
        }

        private static void AnalyzeSymbol(SymbolAnalysisContext context)
        {
            var methodSymbol = (IMethodSymbol)context.Symbol;

            foreach (IParameterSymbol methodSymbolParameter in methodSymbol.Parameters)
            {
                var firstChar = methodSymbolParameter.Name.ToCharArray().FirstOrDefault();

                if (firstChar != default(char) && firstChar > 'A' && firstChar < 'Z')
                {
                    var diagnostic = Diagnostic.Create(Rule, methodSymbolParameter.Locations[0], methodSymbolParameter.Name);

                    context.ReportDiagnostic(diagnostic);
                }
            }
        }
    }
}