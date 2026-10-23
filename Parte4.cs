using System;

// Parte 4 - Bubble Sort com pilhas (A = entrada, B = auxiliar, R = resultado)
// e desafio opcional (ordenar uma pilha).
public static class Parte4
{
    // Se true, imprime o estado ao final de cada passada (usado no rastreio 4.1).
    public static bool trace = false;

    // 4.2 Devolve o vetor em ordem crescente e conta as comparações carry > x.
    public static int[] bubblePilhas(int[] v, out int comparacoes)
    {
        int n = v.Length;
        comparacoes = 0;

        Pilha A = new Pilha(n);
        Pilha B = new Pilha(n);
        Pilha R = new Pilha(n);

        // carrega o vetor em A, na ordem do vetor (o último fica no topo)
        for (int i = 0; i < n; i++)
            A.empilha(v[i]);

        for (int restantes = n; restantes >= 1; restantes--)
        {
            int carry = A.desempilha();
            for (int k = 0; k < restantes - 1; k++)
            {
                int x = A.desempilha();
                comparacoes++;
                if (carry > x)
                {
                    B.empilha(x);          // a bolha segue com carry
                }
                else
                {
                    B.empilha(carry);
                    carry = x;             // x vira a nova bolha
                }
            }
            R.empilha(carry);              // o maior dos restantes vai para R

            if (trace)
                Console.WriteLine("Passada " + (n - restantes + 1) + ": carry final = " + carry
                    + " | B = " + B.texto() + " | R = " + R.texto());

            Pilha t = A; A = B; B = t;     // B vira a entrada da próxima passada
        }

        // R tem o maior na base e o menor no topo: desempilhar dá ordem crescente
        int[] saida = new int[n];
        for (int i = 0; i < n; i++)
            saida[i] = R.desempilha();
        return saida;
    }

    // Desafio: devolve uma pilha com o maior valor no topo, usando uma única
    // pilha auxiliar e uma variável. A pilha de entrada é esvaziada.
    public static Pilha ordenaPilha(Pilha p)
    {
        Pilha aux = new Pilha(p.tamanho());
        while (!p.vazia())
        {
            int t = p.desempilha();
            while (!aux.vazia() && aux.consultaTopo() > t)
                p.empilha(aux.desempilha());
            aux.empilha(t);
        }
        return aux;
    }
}
