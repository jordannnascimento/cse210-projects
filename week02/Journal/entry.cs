using System;

public class Entry
{
    // Atributos (membros) da classe Entry
    public string _date;
    public string _promptText;
    public string _entryText;

    // Método responsável por exibir a entrada na tela.
    // Manter o Display dentro da Entry segue o princípio de abstração:
    // se mudarmos o que a Entry guarda, só essa classe precisa ser atualizada.
    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine($"{_entryText}\n");
    }
}