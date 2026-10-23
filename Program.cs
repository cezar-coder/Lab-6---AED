using System;

public class Program
{
    static void mostraVetor(int[] v)
    {
        Console.WriteLine("[" + string.Join(", ", v) + "]");
    }

    public static void Main()
    {
        Console.WriteLine("=== Parte 1: teste da pilha ===");
        Pilha p = new Pilha(5);
        p.empilha(1); p.empilha(3); p.empilha(5); p.empilha(7);
        p.mostra();                              // [1, 3, 5, 7]
        Console.WriteLine(p.desempilha());       // 7
        Console.WriteLine(p.consultaTopo());     // 5
        p.empilha(8); p.empilha(9);
        p.mostra();                              // [1, 3, 5, 8, 9]
        Console.WriteLine(p.cheia());            // True
        try { p.empilha(2); }
        catch (Exception e) { Console.WriteLine(e.Message); } // Erro: pilha cheia
        Pilha vz = new Pilha(2);
        try { vz.desempilha(); }
        catch (Exception e) { Console.WriteLine(e.Message); } // Erro: pilha vazia
        try { vz.consultaTopo(); }
        catch (Exception e) { Console.WriteLine(e.Message); } // Erro: pilha vazia

        Console.WriteLine("\n=== Parte 2: rastreio (Pilha(4)) ===");
        Pilha q = new Pilha(4);
        string ret;
        q.empilha(10); Console.WriteLine("empilha(10)  | - | " + q.texto() + " | " + q.tamanho());
        q.empilha(20); Console.WriteLine("empilha(20)  | - | " + q.texto() + " | " + q.tamanho());
        ret = q.desempilha().ToString(); Console.WriteLine("desempilha() | " + ret + " | " + q.texto() + " | " + q.tamanho());
        q.empilha(30); Console.WriteLine("empilha(30)  | - | " + q.texto() + " | " + q.tamanho());
        q.empilha(40); Console.WriteLine("empilha(40)  | - | " + q.texto() + " | " + q.tamanho());
        ret = q.desempilha().ToString(); Console.WriteLine("desempilha() | " + ret + " | " + q.texto() + " | " + q.tamanho());
        ret = q.desempilha().ToString(); Console.WriteLine("desempilha() | " + ret + " | " + q.texto() + " | " + q.tamanho());
        q.empilha(50); Console.WriteLine("empilha(50)  | - | " + q.texto() + " | " + q.tamanho());

        Console.WriteLine("\n=== Parte 3.1: inverte ===");
        Console.WriteLine(Parte3.inverte("PUCMINAS"));   // SANIMCUP
        Console.WriteLine("[" + Parte3.inverte("") + "]");

        Console.WriteLine("\n=== Parte 3.2: balanceado ===");
        string[] exprs = { "(a+b)*[c-d]", "{[()]}", "((a)", "a+b)", "([)]" };
        foreach (string e in exprs)
            Console.WriteLine(e + " -> " + (Parte3.balanceado(e) ? "true" : "false"));

        Console.WriteLine("\n=== Parte 4.1: rastreio {5, 2, 9, 1, 7} ===");
        Parte4.trace = true;
        int cmp;
        int[] v1 = { 5, 2, 9, 1, 7 };
        int[] s1 = Parte4.bubblePilhas(v1, out cmp);
        Parte4.trace = false;

        Console.WriteLine("\n=== Parte 4.2: testes ===");
        Console.Write("{5, 2, 9, 1, 7} -> "); mostraVetor(s1);
        Console.WriteLine("comparacoes = " + cmp);
        int[] v2 = { 1, 2, 3, 4, 5 };
        int[] s2 = Parte4.bubblePilhas(v2, out cmp);
        Console.Write("{1, 2, 3, 4, 5} -> "); mostraVetor(s2);
        Console.WriteLine("comparacoes = " + cmp);
        int[] v3 = { 9, 7, 5, 2, 1, 8, 3 };
        int[] s3 = Parte4.bubblePilhas(v3, out cmp);
        Console.Write("{9, 7, 5, 2, 1, 8, 3} -> "); mostraVetor(s3);
        Console.WriteLine("comparacoes = " + cmp);
        int[] vv = new int[0];
        int[] sv = Parte4.bubblePilhas(vv, out cmp);
        Console.WriteLine("vetor vazio -> tamanho " + sv.Length + ", comparacoes = " + cmp);

        Console.WriteLine("\n=== Desafio: ordenaPilha ===");
        Pilha d = new Pilha(6);
        d.empilha(4); d.empilha(9); d.empilha(1); d.empilha(7); d.empilha(3);
        Console.Write("entrada: "); d.mostra();
        Pilha o = Parte4.ordenaPilha(d);
        Console.Write("ordenada (maior no topo): "); o.mostra();
    }
}
