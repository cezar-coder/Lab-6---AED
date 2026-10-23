using System;

// Parte 1 - TAD Pilha com vetor.
// topo = próxima posição livre = quantidade de elementos.
public class Pilha
{
    private int[] item;
    private int topo;

    public Pilha(int maxTam)
    {
        item = new int[maxTam];
        topo = 0;
    }

    public bool vazia()
    {
        return topo == 0;
    }

    public bool cheia()
    {
        return topo == item.Length;
    }

    public int tamanho()
    {
        return topo;
    }

    public void empilha(int x)
    {
        if (cheia())
            throw new Exception("Erro: pilha cheia");
        item[topo] = x;
        topo++;
    }

    public int desempilha()
    {
        if (vazia())
            throw new Exception("Erro: pilha vazia");
        topo--;
        return item[topo]; // não apaga: a posição só deixa de valer
    }

    public int consultaTopo()
    {
        if (vazia())
            throw new Exception("Erro: pilha vazia");
        return item[topo - 1];
    }

    // imprime base -> topo, ex.: [1, 3, 5]
    public void mostra()
    {
        Console.WriteLine(texto());
    }

    // mesma formatação de mostra(), devolvida como string
    public string texto()
    {
        string s = "[";
        for (int i = 0; i < topo; i++)
        {
            if (i > 0) s += ", ";
            s += item[i];
        }
        return s + "]";
    }
}
