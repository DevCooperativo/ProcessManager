namespace SistemasOperacionais.Interfaces;
public interface IProcessServices
{
    int GetPID();
    int GetPriority();
    int GetTCPU();
    void SetTT(int te);
    int GetTT();
    void SetTE(int tt);
    int GetTE();
}
