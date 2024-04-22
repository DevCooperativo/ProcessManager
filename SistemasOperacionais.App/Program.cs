using SistemasOperacionais.Services;
System.Console.Clear();
Console.WriteLine("Bem vindo ao gerenciador de processos:\nPalhaçada e Risadinha\n\n");
Console.WriteLine("Primeiramente, defina o método de otimização a ser utilizado:\n1 - Prioridade\n2 - SJF (Shortes Job First)");
int otimizacaoUtilizada = int.Parse(Console.ReadLine());

ProcessManagerServices pm = new(otimizacaoUtilizada==1?true:false);

Console.WriteLine("Agora, quantos processos serão executados neste teste?");
int numeroDeProcessos = int.Parse(Console.ReadLine());

for (int i = 0; i < numeroDeProcessos; i++)
{
    ProcessServices ps = new();
    Console.WriteLine("Qual o PID do processo?");
    int PID = int.Parse(Console.ReadLine());
    ps.SetPID(PID);
    Console.WriteLine("Qual a prioridade do processo?");
    int Priority = int.Parse(Console.ReadLine());
    ps.SetPriority(Priority);
    Console.WriteLine("Qual o tempo de CPU do processo?");
    int TCPU = int.Parse(Console.ReadLine());
    ps.SetTCPU(TCPU);
    pm.AddProcessToProcessList(ps);
}

pm.OrderProcessList();

pm.GetProcessList();
