namespace SistemasOperacionais.Services;
using SistemasOperacionais.Interfaces;
using System;
public class ProcessManagerServices : IProcessManagerServices
{
    protected List<IProcessServices> ProcessList;
    protected bool IsSJF;
    protected int TTotalCPU;
    public ProcessManagerServices(bool isSJF)
    {
        this.ProcessList = new List<IProcessServices>();
        this.IsSJF = isSJF;
        this.TTotalCPU = 0;
    }
    public bool GetIsSJF(){
        return this.IsSJF;
    }
    public void SetIsSJF(bool isSJF){
        this.IsSJF = isSJF;
    }
    public void GetProcessList(){
        int cpuCounter = 0;
        Console.WriteLine("{0,-15} | {1,-15} | {2,-15} | {3, -15} | {4, -15}", "PID","Prioridade","Tempo de CPU", "TE", "TT");
        foreach(IProcessServices process in ProcessList){
            RunProcess(process, cpuCounter);
            Console.WriteLine(string.Format("{0,-15} | {1,-15} | {2,-15} | {3, -15} | {4, -15}", process.GetPID(), process.GetPriority(), process.GetTCPU(), process.GetTE(), process.GetTT()));
            cpuCounter+=process.GetTCPU();
        }
    }
    public void AddProcessToProcessList(IProcessServices process){
        this.ProcessList.Add(process);
    }
    public void RemoveProcessFromProcessList(IProcessServices process){
        this.ProcessList.Remove(process);
    }
    public void IncrementTTotalCPU(int TimeSpent){
        this.TTotalCPU += TimeSpent;
    }
    public void SetTTotalCPU(int TTotalCPU){
        this.TTotalCPU = TTotalCPU;
    }
    public int GetTTotalCPU(){
        return this.TTotalCPU;
    }
    public void OrderProcessList(){
        if(this.IsSJF){
            OrderByPriority();
        }else{
            OrderByTCPU();
        }
    }
    protected void OrderByPriority(){
        ProcessList = ProcessList.OrderBy(x => x.GetPriority()).ToList();
    }
    protected void OrderByTCPU(){
        ProcessList = ProcessList.OrderBy(x => x.GetTCPU()).ToList();
    }
    public void RunProcess(IProcessServices process, int cpuCounter){
        process.SetTE(cpuCounter);
        process.SetTT(process.GetTE());
    }

}
