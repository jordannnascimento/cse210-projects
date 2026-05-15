using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    // Lista de entradas. Acessada sempre através dos métodos da classe (abstração).
    public List<Entry> _entries = new List<Entry>();

    // Separador usado para salvar/carregar do arquivo.
    // Usamos "~|~" pois é improvável aparecer no conteúdo do usuário.
    private string _separator = "~|~";

    // Adiciona uma nova entrada ao diário.
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    // Exibe todas as entradas chamando o Display de cada uma.
    // O Journal não precisa saber os detalhes de como uma Entry se exibe.
    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is empty.\n");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    // Salva todas as entradas em um arquivo.
    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}{_separator}{entry._promptText}{_separator}{entry._entryText}");
            }
        }
        Console.WriteLine($"Journal saved to {file}\n");
    }

    // Carrega entradas de um arquivo, substituindo as atuais.
    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine($"File {file} not found.\n");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(file);

        foreach (string line in lines)
        {
            string[] parts = line.Split(_separator);
            if (parts.Length == 3)
            {
                Entry entry = new Entry();
                entry._date = parts[0];
                entry._promptText = parts[1];
                entry._entryText = parts[2];
                _entries.Add(entry);
            }
        }
        Console.WriteLine($"Journal loaded from {file}\n");
    }
}