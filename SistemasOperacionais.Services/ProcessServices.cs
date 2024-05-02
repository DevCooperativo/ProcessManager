namespace SistemasOperacionais.Services;
using SistemasOperacionais.Interfaces;

public class ProcessServices : IProcessServices
{
    protected int Position;
    protected int PID;
    protected int Priority;
    protected int TCPU;
    protected List<ProcessServices> ProcessList = new List<ProcessServices>();
    protected int TT;
    protected int TE;

    public ProcessServices(){
        this.TT = 0;
        this.TE = 0;
    }
    public int GetPID(){
        return this.PID;
    }
    public void SetPID(int PID){
        if(PID<=0){
            Console.WriteLine("O PID deve ser maior que 0. Insira novamente");
            PID = int.Parse(Console.ReadLine());
            this.SetPID(PID);
        }
        this.PID = PID;
    }
    public int GetPriority(){
        return this.Priority;
    }
    public void SetPriority(int Priority){
        this.Priority = Priority;
    }
    public int GetTCPU(){
        return this.TCPU;
    }
    public void SetTCPU(int TCPU){
        this.TCPU = TCPU;
    }
    public int GetTT(){
        return this.TT;
    }
    public void SetTT(int te){
        this.TT = this.TCPU + te;
    }
    public int GetTE(){
        return this.TE;
    }
    public void SetTE(int tt){
        this.TE = tt;
    }

}
