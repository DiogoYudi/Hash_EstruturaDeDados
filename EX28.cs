//28) Implemente um programa com as seguintes opções: Sem tratamento de colisão, Tratamento de colisão Linear e Tratamento de colisão com Lista Encadeada.
//	Dentro de cada opção deve haver as funcionalidades: Inserir, Alterar e Relatar.
//	O vetor deve ser do tipo abstrato de dado composto por idade, nome e whats. Serão necessários 3 vetores, um para cada tipo de tratamento de colisão.
//Para inserir um novo registro, solicite a idade, nome e whats. Utilize a idade como chave.
//Para alterar solicite a idade (chave) para ser utilizada na busca. Caso encontrada, informe o nome e o whats da pessoa. Após a consulta, o usuário pode atualizar somente o nome e o whats.
//Para relatar, percorra o vetor do inicio ao fim e exiba todos os registros.


const int MAX = 5;
int MENU()
{
    Console.WriteLine("MENU");
    Console.WriteLine("1. Inserir");
    Console.WriteLine("2. Alterar");
    Console.WriteLine("3. Relatar");
    return Convert.ToInt32(Console.ReadLine());
}

int Hash(int chave)
{
    return (chave % MAX);
}

void Cadastre(ref string nome, ref int chave, ref string whats)
{
    
    Console.Write("Digite o nome: ");
    nome = Console.ReadLine();
    Console.Write("Digite a idade: ");
    chave = Convert.ToInt32(Console.ReadLine());
    Console.Write("Digite o número do whatsapp: ");
    whats = Console.ReadLine();
}

void Consulte(int chave, ref tp_no atual, tp_no[] v2, int pos)
{
    tp_no anterior = null;
    atual = v2[pos];
    while (atual != null && atual.idade != chave)
    { 
        anterior = atual;
        atual = atual.prox;
    }

}

void InserirSTC(tp_no[] v, string nome, int chave, string whats)
{
    int pos = Hash(chave);
    v[pos] = new tp_no();
    v[pos].nome = nome;
    v[pos].idade = chave;
    v[pos].whats = whats;
}

void AlterarSTC(tp_no[] v)
{
    Console.Write("Informe a idade dos dados que deseja encontrar: ");
    int idade = Convert.ToInt32(Console.ReadLine());
    int pos = Hash(idade);
    if (v[pos].idade == idade && v[pos] != null)
    {
        Console.WriteLine("Nome:" + v[pos].nome);
        Console.WriteLine("Idade:" + v[pos].idade);
        Console.WriteLine("Whatsapp:" + v[pos].whats);
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("Insira o novo nome: ");
        v[pos].nome = Console.ReadLine();
        Console.WriteLine("Insira o novo whats: ");
        v[pos].whats = Console.ReadLine();
    }
    else
        Console.WriteLine("Idade não encontrado");
}

void RelatarSTC(tp_no[] v)
{
    int pos = 0;
    while (pos < MAX)
    {
        if (v[pos] != null)
        {
            Console.WriteLine("Nome:" + v[pos].nome);
            Console.WriteLine("Idade:" + v[pos].idade);
            Console.WriteLine("Whatsapp:" + v[pos].whats);
            pos++;
        }
        else
        {
            pos++;
            Console.WriteLine("Vetor vazio");
        }
    }
}

void InserirTCL(tp_no[] v1, string nome, int chave, string whats)
{
    int pos = Hash(chave);
    int cont = 0;
    while (cont < MAX && v1[pos] != null)
    {
        pos++;
        pos = pos % MAX;
    }
    if (cont != MAX)
    {
        v1[pos] = new tp_no();
        v1[pos].nome = nome;
        v1[pos].idade = chave;
        v1[pos].whats = whats;
    }
    else
        Console.WriteLine("Vetor cheio");
}

void AltereTCL(tp_no[] v1)
{
    Console.Write("Informe a idade dos dados que deseja encontrar: ");
    int idade = Convert.ToInt32(Console.ReadLine());
    int pos = Hash(idade);
    int qtd = 1;
    while ((v1[pos] == null || v1[pos].idade != idade) && qtd <= MAX)
    {
        pos++;
        pos = pos % MAX;
        qtd++;
    }
    if (v1[pos].idade == idade)
    {
        Console.WriteLine("Nome:" + v1[pos].nome);
        Console.WriteLine("Idade:" + v1[pos].idade);
        Console.WriteLine("Whatsapp:" + v1[pos].whats);
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("Insira o novo nome: ");
        v1[pos].nome = Console.ReadLine();
        Console.WriteLine("Insira o novo whats: ");
        v1[pos].whats = Console.ReadLine();
    }
    else
        Console.WriteLine("Idade não encontrado");
}

void InsereLE(tp_no[] v2, int chave, string nome, string whats)
{
    int pos = Hash(chave);
    tp_no no = new tp_no();
    no.nome = nome;
    no.idade = chave;
    no.whats = whats;
    if (v2[pos] != null)
        no.prox = v2[pos];
    v2[pos] = no;
}   

void AltereLE(tp_no[] v2)
{
    tp_no atual = null;
    Console.Write("Informe a idade dos dados que deseja encontrar: ");
    int idade = Convert.ToInt32(Console.ReadLine());
    int pos = Hash(idade);
    Consulte(idade, ref atual, v2, pos);
    if (atual == null)
        Console.WriteLine("Idade não encontrado");
    else
    {
        Console.WriteLine("Nome:" + atual.nome);
        Console.WriteLine("Idade:" + atual.idade);
        Console.WriteLine("Whatsapp:" + atual.whats);
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("Insira o novo nome: ");
        atual.nome = Console.ReadLine();
        Console.WriteLine("Insira o novo whats: ");
        atual.whats = Console.ReadLine();

    }
}

void RelatarLE(tp_no[] v2)
{
    int pos = 0;
    while (pos < MAX)
    {
        tp_no no = v2[pos];
        while (no != null)
        {
            Console.WriteLine("Nome: " + no.nome);
            Console.WriteLine("Idade: " + no.idade);
            Console.WriteLine("Whats: " + no.whats);
            no = no.prox;
        }
        pos++;
    }
}

tp_no[] v = new tp_no[MAX];
tp_no[] v1 = new tp_no[MAX];
tp_no[] v2 = new tp_no[MAX];
int chave = 0;
string nome = "", whats = "";
string op = "0";
while (op != "4")
{
    Console.WriteLine("MENU");
    Console.WriteLine("1. Sem tratamento de colisão");
    Console.WriteLine("2. Tratamento de colisão linear");
    Console.WriteLine("3. Tratamento de colisão com lista encadeada");
    Console.WriteLine("4. Sair");
    op = Console.ReadLine();
    switch (op)
    {
        case "1":
            int r = MENU();
            if (r == 1)
            {
                Cadastre(ref nome, ref chave, ref whats);
                InserirSTC(v, nome, chave, whats);
            }
            else if (r == 2)
                AlterarSTC(v);
            else if (r == 3)
                RelatarSTC(v);
            break;
        case "2":
            int r1 = MENU();
            if (r1 == 1)
            {
                Cadastre(ref nome, ref chave, ref whats);
                InserirTCL(v1, nome, chave, whats);
            }
            else if (r1 == 2)
                AltereTCL(v1);
            else if (r1 == 3)
                RelatarSTC(v1);
            break;
        case "3":
            int r2 = MENU();
            if (r2 == 1)
            {
                Cadastre(ref nome, ref chave, ref whats);
                InsereLE(v2, chave, nome, whats);
            }
            else if (r2 == 2)
                AltereLE(v2);
            else if (r2 == 3)
                RelatarLE(v2);
            break;
    }
}

class tp_no
{
    public string nome, whats;
    public int idade;
    public tp_no prox;
}
