using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

internal class Csv
{
    public string caminhoArquivo { get; set; }

    public Csv(string caminhoArquivo) => this.caminhoArquivo = caminhoArquivo;

    public void EscreverArquivo<T>(T apontamento)
    {
        var records  = new List<T>() { apontamento };

        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            // Don't write the header again.
            HasHeaderRecord = false,
        };
        using (var stream = File.Open(this.caminhoArquivo, FileMode.Append))
        using (var writer = new StreamWriter(stream))
        using (var csv = new CsvWriter(writer, config))
        {
            csv.WriteRecords(records);
            csv.Flush();
        }
    }

    public IEnumerable<T> LerArquivo<T>()
    {
        IEnumerable<T> records;

        using (var reader = new StreamReader(this.caminhoArquivo))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            records = csv.GetRecords<T>();
        }

        return records;
    }
}