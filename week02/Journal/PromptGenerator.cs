using System;
using System.Collections.Generic;

public class PromptGenerator
{
    // Lista de prompts. Mantida como atributo para que possa ser
    // facilmente alterada/expandida sem afetar outras classes.
    public List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What did I learn today that I want to remember?",
        "What am I grateful for today?"
    };

    // Retorna um prompt aleatório da lista.
    // Se no futuro buscarmos prompts de um banco de dados web,
    // só esta classe precisará ser alterada.
    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}