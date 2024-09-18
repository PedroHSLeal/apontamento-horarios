// funções principais para o funcionamento
// no terminal do usuario (cmd, powershell pelo menos), o cara deve escrever o comando "horarios agora, para setar o horario no ? (estou pensando em fazer no sqlite, xlsx, ou txt mexmo)"

using Horarios;
using McMaster.Extensions.CommandLineUtils;
using System.Linq;

var app = new CommandLineApplication();

app.HelpOption();

var descricao = app.Option("--descricao <DESCRICAO>", "descricao do seu apontamento", CommandOptionType.SingleValue);

var nomeArquivo = app.Option("--arquivo <NOME_DO_ARQUIVO>", "nome do arquivo para salvar seus apontamentos", CommandOptionType.SingleValue);
nomeArquivo.DefaultValue = "apontamentos";

app.OnExecute(() =>
{
    string nomeArquivoFormatado = nomeArquivo.Value()!;
    
    if (descricao.HasValue())
    {
        if (!string.IsNullOrEmpty(nomeArquivoFormatado))
        {
            string caminhoProjeto = string.Join("\\", Directory.GetCurrentDirectory(), !nomeArquivoFormatado.EndsWith(".csv") ? $"{nomeArquivoFormatado}.csv" : nomeArquivoFormatado);
            
            var csv = new Csv(caminhoProjeto);

            var apontamento = new Apontamento();

            apontamento.Descricao = descricao.Value()!;
            apontamento.Data = DateOnly.FromDateTime(DateTime.Now);
            apontamento.HorarioInicio = TimeOnly.FromDateTime(DateTime.Now);

            csv.EscreverArquivo(apontamento);

            Console.WriteLine(csv.LerArquivo<Apontamento>().ToString());
        }
    }
});

app.Execute(args);