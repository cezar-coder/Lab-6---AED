using System;

// Parte 3 - Usando a pilha (só operações do TAD).
public static class Parte3
{
    // 3.1 Inverte um texto: o último caractere empilhado é o primeiro a sair.
    public static string inverte(string s)
    {
        Pilha p = new Pilha(s.Length);
        foreach (char c in s)
            p.empilha(c);

        string r = "";
        while (!p.vazia())
            r += (char)p.desempilha();
        return r;
    }

    // 3.2 Verifica se (), [] e {} abrem e fecham na ordem certa.
    public static bool balanceado(string expr)
    {
        Pilha p = new Pilha(expr.Length);
        foreach (char c in expr)
        {
            if (c == '(' || c == '[' || c == '{')
            {
                p.empilha(c);
            }
            else if (c == ')' || c == ']' || c == '}')
            {
                if (p.vazia()) return false;          // fechamento sem abertura
                char abre = (char)p.desempilha();
                if (!casam(abre, c)) return false;    // tipo ou ordem errada
            }
        }
        return p.vazia();                              // sobrou abertura => false
    }

    private static bool casam(char abre, char fecha)
    {
        return (abre == '(' && fecha == ')')
            || (abre == '[' && fecha == ']')
            || (abre == '{' && fecha == '}');
    }
}
