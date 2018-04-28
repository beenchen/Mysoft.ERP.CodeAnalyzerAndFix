using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace CodeAnalyzer.����ɨ��.C00005
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class C00005Analyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "C00005";

        private const string Category = "����ɨ��";

        private static readonly string Title = "CodeAnalyzer.SPEC:C00005";

        private static readonly string MessageFormat = "��Ʒ�����ֹ��Ƴɾ�̬��Ա�����ǹ��߷���:{0}";

        private static readonly string Description = "����ɨ��>SPEC:C00005;��Ʒ�����ֹ��Ƴɾ�̬��Ա�����ǹ��߷���";

        private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat,
            Category, DiagnosticSeverity.Error, true, Description,
            CommonHelper.helpLinkUri);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule);

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSymbolAction(AnalyzeSymbol, SymbolKind.Method);
        }

        private static void AnalyzeSymbol(SymbolAnalysisContext context)
        {
            var methodSymbol = (IMethodSymbol)context.Symbol;

            if (methodSymbol.IsStatic && 
                methodSymbol.ContainingType.Name.EndsWith("Initializer") == false && 
                methodSymbol.ContainingType.Name.EndsWith("Helper") == false &&
                methodSymbol.ContainingType.Name.EndsWith("Extensions") == false && 
                methodSymbol.ContainingType.Name.EndsWith("Factory") == false &&
                methodSymbol.ContainingType.Name.EndsWith("Manager") == false &&
                methodSymbol.ContainingType.Name.EndsWith("Enum") == false &&
                methodSymbol.ContainingType.Name.EndsWith("LangRes") == false &&
                methodSymbol.ContainingType.Name.EndsWith("Const") == false)
            {
                var diagnostic = Diagnostic.Create(Rule, methodSymbol.Locations[0], methodSymbol.Name);

                context.ReportDiagnostic(diagnostic);

            }
        }
    }
}