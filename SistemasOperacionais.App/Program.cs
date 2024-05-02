using System.Runtime.CompilerServices;
using SistemasOperacionais.Services;
Console.Clear();
Console.WriteLine("Bem vindo ao gerenciador de processos:\nPalhaçada e Risadinha\n\n");
int otimizacaoUtilizada = -1;
while (otimizacaoUtilizada < 1 || otimizacaoUtilizada > 2)
{
    Console.WriteLine("Primeiramente, defina o método de otimização a ser utilizado:\n1 - Prioridade\n2 - SJF (Shortes Job First)");
    otimizacaoUtilizada = int.TryParse(Console.ReadLine(), out otimizacaoUtilizada) ? otimizacaoUtilizada : -1;
    if (otimizacaoUtilizada < 1 || otimizacaoUtilizada > 2)
    {
        Console.WriteLine("Opcão inválida. Tente novamente");
    }
}

ProcessManagerServices pm = new(otimizacaoUtilizada == 1 ? true : false);

int numeroDeProcessos = -1;
while (numeroDeProcessos < 1)
{
    Console.WriteLine("Agora, quantos processos serão executados neste teste?");
    numeroDeProcessos = int.TryParse(Console.ReadLine(), out numeroDeProcessos) ? numeroDeProcessos : 0;
    if (numeroDeProcessos < 1)
    {
        Console.WriteLine("O numero de processos deve ser maior que 0. Insira novamente");
    }
}

for (int i = 0; i < numeroDeProcessos; i++)
{
    ProcessServices ps = new();
    int PID = 0;
    while (PID < 1)
    {
        Console.WriteLine("Qual o PID do processo?");
        PID = int.TryParse(Console.ReadLine(), out PID) ? PID : 0;
        if (PID < 1)
        {
            Console.WriteLine("O PID deve ser maior que 0. Insira novamente");
        }
    }
    ps.SetPID(PID);
    int priority = -21;
    while (priority is < -20 or > 19 && priority != 0)
    {
        Console.WriteLine("Qual a prioridade do processo?");
        priority = int.TryParse(Console.ReadLine(), out priority) ? priority : -21;
        if (priority < -20 || priority > 19 && priority != 0)
        {
            Console.WriteLine("A prioridade deve estar entre -20 e 19 e ser diferente de 0. Insira novamente");
        }
    }
    ps.SetPriority(priority);
    int TCPU = -1;
    while (TCPU < 0)
    {
        Console.WriteLine("Qual o tempo de CPU do processo?");
        TCPU = int.TryParse(Console.ReadLine(), out TCPU) ? TCPU : -1;
        if (TCPU < 0)
        {
            Console.WriteLine("O tempo de CPU deve ser maior ou igual a 0. Insira novamente");
        }
    }

    ps.SetTCPU(TCPU);
    pm.AddProcessToProcessList(ps);
}

pm.OrderProcessList();

pm.GetProcessList();
